namespace YamahaStyle.Core;

using System.Collections.Generic;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Common;
using System;
using System.Linq;

public class MidiEngine : IDisposable
{
    private Playback? _playback;
    private OutputDevice? _outputDevice;
    private readonly object _lock = new();
    private MidiFile? _currentMidiFile;
    private string? _currentFilePath;
    private bool[]? _trackEnabled;
    private string? _currentOutputDeviceName;
    private double _masterVolume = 1.0; // 0.0 to 1.0
    private double[]? _trackVolumes; // 0.0 to 1.0 per track
    private int?[]? _trackChannels; // first channel per track, if any
    private double? _desiredTempoBpm;
    private double _baseTempoBpm = 120.0;
    /// <summary>
    /// Gets or sets the master volume (0.0 to 1.0).
    /// </summary>
    public double MasterVolume
    {
        get { lock (_lock) { return _masterVolume; } }
        set
        {
            lock (_lock)
            {
                _masterVolume = Math.Clamp(value, 0.0, 1.0);
                // apply live to device if playing
                if (IsPlaying)
                {
                    SendMasterVolumeToDevice();
                }
            }
        }
    }

    /// <summary>
    /// Desired playback tempo in BPM. If null, original file tempo is used.
    /// </summary>
    public double? DesiredTempoBpm
    {
        get { lock (_lock) { return _desiredTempoBpm; } }
        set
        {
            lock (_lock)
            {
                _desiredTempoBpm = value;
                // apply live if playing
                ApplyPlaybackTempoIfNeeded();
            }
        }
    }

    private void ApplyPlaybackTempoIfNeeded()
    {
        lock (_lock)
        {
            if (_playback == null)
                return;
            if (_desiredTempoBpm != null && _desiredTempoBpm > 0 && _baseTempoBpm > 0)
            {
                try
                {
                    _playback.Speed = _desiredTempoBpm.Value / _baseTempoBpm;
                }
                catch
                {
                    // ignore if playback does not support speed
                }
            }
            else
            {
                try { _playback.Speed = 1.0; } catch { }
            }
        }
    }

    /// <summary>
    /// Gets the volume for a specific track (0.0 to 1.0).
    /// </summary>
    public double GetTrackVolume(int index)
    {
        lock (_lock)
        {
            if (_trackVolumes == null || index < 0 || index >= _trackVolumes.Length)
                return 1.0;
            return _trackVolumes[index];
        }
    }

    /// <summary>
    /// Sets the volume for a specific track (0.0 to 1.0).
    /// </summary>
    public void SetTrackVolume(int index, double value)
    {
        lock (_lock)
        {
            if (_trackVolumes == null || index < 0 || index >= _trackVolumes.Length)
                return;
            _trackVolumes[index] = Math.Clamp(value, 0.0, 1.0);
        }
        // send live CC if playing
        if (IsPlaying)
        {
            SendChannelVolumeToDevice(index);
        }
    }

    private void SendChannelVolumeToDevice(int trackIndex)
    {
        lock (_lock)
        {
            if (_outputDevice == null || _trackVolumes == null || _trackChannels == null)
                return;
            if (trackIndex < 0 || trackIndex >= _trackChannels.Length)
                return;
            var ch = _trackChannels[trackIndex];
            if (ch == null)
                return;
            var vol = _masterVolume * _trackVolumes[trackIndex];
            int midiVol = (int)Math.Round(Math.Clamp(vol, 0.0, 1.0) * 127.0);
            try
            {
                var cc = new ControlChangeEvent((SevenBitNumber)7, (SevenBitNumber)midiVol) { Channel = (FourBitNumber)ch.Value };
                _outputDevice.SendEvent(cc);
            }
            catch
            {
                // ignore send errors
            }
        }
    }

    private void SendMasterVolumeToDevice()
    {
        lock (_lock)
        {
            if (_outputDevice == null || _trackVolumes == null || _trackChannels == null)
                return;
            for (int i = 0; i < _trackChannels.Length; i++)
            {
                var ch = _trackChannels[i];
                if (ch == null) continue;
                var vol = _masterVolume * (_trackVolumes != null && i < _trackVolumes.Length ? _trackVolumes[i] : 1.0);
                int midiVol = (int)Math.Round(Math.Clamp(vol, 0.0, 1.0) * 127.0);
                try
                {
                    var cc = new ControlChangeEvent((SevenBitNumber)7, (SevenBitNumber)midiVol) { Channel = (FourBitNumber)ch.Value };
                    _outputDevice.SendEvent(cc);
                }
                catch { }
            }
        }
    }

    public IEnumerable<string> GetOutputDeviceNames()
    {
        foreach (var device in OutputDevice.GetAll())
            yield return device.Name;
    }

    public void PlayFile(string path, string? outputDeviceName = null)
    {
        lock (_lock)
        {
            Stop();

            // If different file than currently loaded, read and initialize track enables
            if (_currentMidiFile == null || !string.Equals(_currentFilePath, path, StringComparison.OrdinalIgnoreCase))
            {
                _currentMidiFile = MidiFile.Read(path);
                _currentFilePath = path;
                var count = _currentMidiFile.GetTrackChunks().Count();
                _trackEnabled = Enumerable.Range(0, count).Select(i => true).ToArray();
                // Initialize per-track volumes to 1.0 (max)
                _trackVolumes = Enumerable.Range(0, count).Select(i => 1.0).ToArray();
                // build track -> channel mapping
                _trackChannels = new int?[count];
                var chunks = _currentMidiFile.GetTrackChunks().ToList();
                for (int i = 0; i < chunks.Count; i++)
                {
                    var evt = chunks[i].Events.OfType<ChannelEvent>().FirstOrDefault();
                    if (evt != null)
                        _trackChannels[i] = (int)evt.Channel;
                    else
                        _trackChannels[i] = null;
                }
                // determine base tempo from first SetTempoEvent if present
                var firstTempo = _currentMidiFile.GetTrackChunks().SelectMany(c => c.Events.OfType<SetTempoEvent>()).FirstOrDefault();
                if (firstTempo != null && firstTempo.MicrosecondsPerQuarterNote > 0)
                {
                    _baseTempoBpm = 60000000.0 / firstTempo.MicrosecondsPerQuarterNote;
                }
            }

            _currentOutputDeviceName = outputDeviceName;

            if (!string.IsNullOrEmpty(outputDeviceName))
            {
                try
                {
                    _outputDevice = OutputDevice.GetByName(outputDeviceName);
                }
                catch
                {
                    _outputDevice = OutputDevice.GetAll().FirstOrDefault();
                }
            }
            else
            {
                _outputDevice = OutputDevice.GetAll().FirstOrDefault();
            }

            if (_outputDevice == null)
                throw new InvalidOperationException("No MIDI output device available.");

            var filtered = GetFilteredMidiFile();
            // Apply initial master and track volumes by inserting CC events into the filtered file
            ApplyVolumeToPlayback(filtered);
            _playback = filtered.GetPlayback(_outputDevice);
            // apply desired tempo to playback speed if requested
            if (_desiredTempoBpm != null && _desiredTempoBpm > 0 && _baseTempoBpm > 0)
            {
                try { _playback.Speed = _desiredTempoBpm.Value / _baseTempoBpm; } catch { }
            }
            _playback.Start();
        }
    }

    public void Stop()
    {
        lock (_lock)
        {
            try
            {
                if (_playback != null)
                {
                    if (_playback.IsRunning)
                        _playback.Stop();
                    _playback.Dispose();
                    _playback = null;
                }

                if (_outputDevice != null)
                {
                    _outputDevice.Dispose();
                    _outputDevice = null;
                }
            }
            catch
            {
                // swallow exceptions during stop/cleanup
            }
        }
    }

    public bool IsPlaying
    {
        get
        {
            lock (_lock)
            {
                return _playback != null && _playback.IsRunning;
            }
        }
    }

    public void Dispose()
    {
        Stop();
    }

    private MidiFile GetFilteredMidiFile()
    {
        if (_currentMidiFile == null)
            throw new InvalidOperationException("No MIDI file loaded.");

        var outFile = new MidiFile();
        var chunks = _currentMidiFile.GetTrackChunks().ToList();
        for (int i = 0; i < chunks.Count; i++)
        {
            if (_trackEnabled != null && i < _trackEnabled.Length && !_trackEnabled[i])
            {
                outFile.Chunks.Add(new TrackChunk());
            }
            else
            {
                // add existing chunk (shallow copy) - acceptable for playback
                outFile.Chunks.Add(chunks[i]);
            }
        }

        // tempo/events preserved because enabled track chunks are copied; no explicit tempo map copy performed
        // If user requested a desired tempo, replace or insert SetTempoEvent(s)
        if (_desiredTempoBpm != null && _desiredTempoBpm > 0)
        {
            long microsecondsPerQuarter = (long)Math.Round(60000000.0 / _desiredTempoBpm.Value);
            var outChunks = outFile.GetTrackChunks().ToList();
            bool any = false;
            foreach (var chunk in outChunks)
            {
                var tempoEvents = chunk.Events.OfType<SetTempoEvent>().ToList();
                if (tempoEvents.Count > 0)
                {
                    any = true;
                    foreach (var te in tempoEvents)
                        te.MicrosecondsPerQuarterNote = microsecondsPerQuarter;
                }
            }
            if (!any && outChunks.Count > 0)
            {
                // insert into first chunk
                outChunks[0].Events.Insert(0, new SetTempoEvent(microsecondsPerQuarter));
            }
        }

        return outFile;
    }

    public void LoadFile(string path)
    {
        lock (_lock)
        {
            _currentMidiFile = MidiFile.Read(path);
            _currentFilePath = path;
            var count = _currentMidiFile.GetTrackChunks().Count();
            _trackEnabled = Enumerable.Range(0, count).Select(i => true).ToArray();
            _trackVolumes = Enumerable.Range(0, count).Select(i => 1.0).ToArray();
        }
    }

    public int GetTracksCount()
    {
        return _currentMidiFile?.GetTrackChunks().Count() ?? 0;
    }

    public IEnumerable<string> GetTrackNames()
    {
        if (_currentMidiFile == null)
            yield break;

        var chunks = _currentMidiFile.GetTrackChunks().ToList();
        for (int i = 0; i < chunks.Count; i++)
        {
            var text = chunks[i].Events.OfType<TextEvent>().FirstOrDefault()?.Text;
            yield return text ?? ($"Track {i + 1}");
        }
    }

    /// <summary>
    /// Returns a human-readable instrument/program description for the given track index.
    /// </summary>
    public string GetTrackInstrument(int index)
    {
        if (_currentMidiFile == null)
            return string.Empty;
        var chunks = _currentMidiFile.GetTrackChunks().ToList();
        if (index < 0 || index >= chunks.Count)
            return string.Empty;

        // Try program change event
        var program = chunks[index].Events.OfType<ProgramChangeEvent>().FirstOrDefault();
        if (program != null)
        {
            return $"Program {(int)program.ProgramNumber}";
        }

        // Fallback to channel mapping if available
        if (_trackChannels != null && index < _trackChannels.Length && _trackChannels[index] != null)
        {
            return $"Channel {_trackChannels[index].Value}";
        }

        // Fallback to textual name/meta
        var text = chunks[index].Events.OfType<TextEvent>().FirstOrDefault()?.Text;
        if (!string.IsNullOrEmpty(text))
            return text;

        return $"Track {index + 1}";
    }

    public void SetTrackEnabled(int index, bool enabled)
    {
        lock (_lock)
        {
            if (_trackEnabled == null)
                throw new InvalidOperationException("No MIDI file loaded.");
            if (index < 0 || index >= _trackEnabled.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            _trackEnabled[index] = enabled;

            // If currently playing, restart playback with filtered file (from start)
            if (IsPlaying && _currentFilePath != null)
            {
                var device = _currentOutputDeviceName;
                Stop();
                var filtered = GetFilteredMidiFile();
                ApplyVolumeToPlayback(filtered);
                _outputDevice = null;
                if (!string.IsNullOrEmpty(device))
                {
                    try { _outputDevice = OutputDevice.GetByName(device); } catch { _outputDevice = OutputDevice.GetAll().FirstOrDefault(); }
                }
                else
                    _outputDevice = OutputDevice.GetAll().FirstOrDefault();

                if (_outputDevice == null)
                    throw new InvalidOperationException("No MIDI output device available.");

                _playback = filtered.GetPlayback(_outputDevice);
                _playback.Start();
                _currentOutputDeviceName = device;
            }
        }
    }

    public bool GetTrackEnabled(int index)
    {
        if (_trackEnabled == null)
            return false;
        if (index < 0 || index >= _trackEnabled.Length)
            return false;
        return _trackEnabled[index];
    }

    /// <summary>
    /// Applies master and track volumes by inserting MIDI CC 7 (channel volume) events.
    /// </summary>
    private void ApplyVolumeToPlayback(MidiFile midiFile)
    {
        if (_trackVolumes == null)
            return;
        var chunks = midiFile.GetTrackChunks().ToList();
        for (int i = 0; i < chunks.Count; i++)
        {
            var chunk = chunks[i];
            // Find first channel event to determine channel
            var channelEvent = chunk.Events.OfType<ChannelEvent>().FirstOrDefault();
            if (channelEvent != null)
            {
                int channel = channelEvent.Channel;
                // Calculate volume (0-127)
                double vol = _masterVolume * (_trackVolumes != null && i < _trackVolumes.Length ? _trackVolumes[i] : 1.0);
                int midiVol = (int)Math.Round(vol * 127.0);
                midiVol = Math.Clamp(midiVol, 0, 127);
                // Insert CC 7 event at start
                chunk.Events.Insert(0, new ControlChangeEvent((SevenBitNumber)7, (SevenBitNumber)midiVol) { Channel = (FourBitNumber)channel });
            }
        }
    }
}

