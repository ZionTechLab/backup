using System.Linq;
using Melanchall.DryWetMidi.Core;

namespace YamahaStyle.Core;

public static class MidiFileService
{
    public static StyleModel LoadMidiFile(string path)
    {
        var midiFile = MidiFile.Read(path);

        var tracks = midiFile.GetTrackChunks().ToList();

        // Find first SetTempoEvent if present
        var setTempo = midiFile
            .GetTrackChunks()
            .SelectMany(tc => tc.Events)
            .OfType<SetTempoEvent>()
            .FirstOrDefault();

        double bpm = 120.0;
        if (setTempo != null && setTempo.MicrosecondsPerQuarterNote > 0)
        {
            bpm = 60000000.0 / setTempo.MicrosecondsPerQuarterNote;
        }

        // Try to find title from TextEvent (simple heuristic)
        var textEvent = midiFile
            .GetTrackChunks()
            .SelectMany(tc => tc.Events)
            .OfType<TextEvent>()
            .FirstOrDefault();

        return new StyleModel
        {
            Title = textEvent?.Text ?? System.IO.Path.GetFileName(path),
            TempoBpm = bpm,
            TracksCount = tracks.Count
        };
    }

    public static void SaveMidiFile(MidiFile midiFile, string path)
    {
        midiFile.Write(path);
    }
}
