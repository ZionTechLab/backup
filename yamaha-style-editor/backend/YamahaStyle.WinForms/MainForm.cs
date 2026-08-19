using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YamahaStyle.Core;

namespace YamahaStyle.WinForms
{
    public class MainForm : Form
    {
        private ListBox _devicesList;
        private CheckedListBox _tracksList;
        private Button _refreshButton;
        private MidiEngine _engine;
        private ComboBox _deviceCombo;
        private Button _playButton;
        private Button _stopButton;
        private NumericUpDown _tempoUpDown;
        private TrackBar _masterVolumeTrackBar;
        private TrackBar _trackVolumeTrackBar;
        private string? _loadedMidiPath;
        private MenuStrip _menuStrip;

        public MainForm()
        {
            Text = "Yamaha Style Editor - WinForms (Prototype)";
            Width = 600;
            Height = 420;

            _menuStrip = new MenuStrip();
            var fileMenu = new ToolStripMenuItem("File");
            var openItem = new ToolStripMenuItem("Open MIDI...");
            openItem.Click += (s, e) => OpenMidiFile();
            fileMenu.DropDownItems.Add(openItem);
            _menuStrip.Items.Add(fileMenu);
            Controls.Add(_menuStrip);

            _tracksList = new CheckedListBox() { Left = 10, Top = 30, Width = 260, Height = 260 };
            _devicesList = new ListBox() { Left = 280, Top = 30, Width = 290, Height = 260 };
            _refreshButton = new Button() { Text = "Refresh MIDI Outputs", Left = 280, Top = 300, Width = 160 };
            _deviceCombo = new ComboBox() { Left = 180, Top = 300, Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            _playButton = new Button() { Text = "Play", Left = 430, Top = 300, Width = 60 };
            _stopButton = new Button() { Text = "Stop", Left = 500, Top = 300, Width = 60 };
            // tempo control
            _tempoUpDown = new NumericUpDown() { Left = 280, Top = 340, Width = 80, Minimum = 20, Maximum = 300, Value = 120 };
            var tempoLabel = new Label() { Left = 370, Top = 344, Width = 120, Text = "Tempo (BPM)" };
            _tempoUpDown.ValueChanged += (s, e) => OnTempoChanged();

            // master volume
            _masterVolumeTrackBar = new TrackBar() { Left = 280, Top = 370, Width = 200, Minimum = 0, Maximum = 100, Value = 100, TickFrequency = 10 };
            var masterLabel = new Label() { Left = 490, Top = 374, Width = 120, Text = "Master Volume" };
            _masterVolumeTrackBar.Scroll += (s, e) => OnMasterVolumeChanged();

            // per-track volume
            _trackVolumeTrackBar = new TrackBar() { Left = 280, Top = 400, Width = 200, Minimum = 0, Maximum = 100, Value = 100, TickFrequency = 10 };
            var trackVolLabel = new Label() { Left = 490, Top = 404, Width = 120, Text = "Track Volume" };
            _trackVolumeTrackBar.Scroll += (s, e) => OnTrackVolumeChanged();
            _playButton.Click += (s, e) => Play();
            _stopButton.Click += (s, e) => Stop();
            _refreshButton.Click += (s, e) => RefreshDevices();

            Controls.Add(_tracksList);
            Controls.Add(_devicesList);
            Controls.Add(_refreshButton);
            Controls.Add(_deviceCombo);
            Controls.Add(_playButton);
            Controls.Add(_stopButton);
            Controls.Add(_tempoUpDown);
            Controls.Add(tempoLabel);
            Controls.Add(_masterVolumeTrackBar);
            Controls.Add(masterLabel);
            Controls.Add(_trackVolumeTrackBar);
            Controls.Add(trackVolLabel);

            _tracksList.ItemCheck += TracksList_ItemCheck;
            _tracksList.SelectedIndexChanged += TracksList_SelectedIndexChanged;

            _engine = new MidiEngine();
            Shown += (s, e) => RefreshDevices();
        }

        private void OpenMidiFile()
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "MIDI files (*.mid;*.midi)|*.mid;*.midi|All files (*.*)|*.*";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var model = MidiFileService.LoadMidiFile(dlg.FileName);
                _loadedMidiPath = dlg.FileName;
                _devicesList.Items.Clear();
                _devicesList.Items.Add("Loaded: " + Path.GetFileName(dlg.FileName));
                _devicesList.Items.Add("Title: " + (model.Title ?? "(unknown)"));
                _devicesList.Items.Add("Tempo (BPM): " + model.TempoBpm.ToString("0.##"));
                _devicesList.Items.Add("Tracks: " + model.TracksCount);

                // Load tracks into the checked list
                _engine.LoadFile(dlg.FileName);
                _tracksList.Items.Clear();
                var names = _engine.GetTrackNames().ToList();
                for (int i = 0; i < names.Count; i++)
                {
                    var instr = _engine.GetTrackInstrument(i);
                    var label = string.IsNullOrEmpty(instr) ? names[i] : $"{names[i]} [{instr}]";
                    _tracksList.Items.Add(label, _engine.GetTrackEnabled(i));
                }
                // initialize per-track volume control to first track
                if (_tracksList.Items.Count > 0)
                {
                    _tracksList.SelectedIndex = 0;
                    _trackVolumeTrackBar.Value = (int)(_engine.GetTrackVolume(0) * 100);
                }
                // try to set tempo control from loaded file (via MidiFileService)
                try { var meta = MidiFileService.LoadMidiFile(dlg.FileName); _tempoUpDown.Value = (decimal)Math.Clamp(meta.TempoBpm, 20.0, 300.0); _engine.DesiredTempoBpm = (double)_tempoUpDown.Value; } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error loading MIDI file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDevices()
        {
            _devicesList.Items.Clear();
            try
            {
                var devices = _engine.GetOutputDeviceNames().ToList();
                if (devices.Count == 0)
                {
                    _devicesList.Items.Add("No MIDI output devices detected.");
                    return;
                }
                _deviceCombo.Items.Clear();
                foreach (var d in devices)
                {
                    _devicesList.Items.Add(d);
                    _deviceCombo.Items.Add(d);
                }
                if (_deviceCombo.Items.Count > 0 && _deviceCombo.SelectedIndex < 0)
                    _deviceCombo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                _devicesList.Items.Add("Error listing devices: " + ex.Message);
            }
        }

        private void TracksList_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            // e.NewValue contains the new checked state
            var index = e.Index;
            var willBeChecked = e.NewValue == CheckState.Checked;
            try
            {
                _engine.SetTrackEnabled(index, willBeChecked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error toggling track: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TracksList_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var idx = _tracksList.SelectedIndex;
            if (idx >= 0)
            {
                _trackVolumeTrackBar.Value = (int)(_engine.GetTrackVolume(idx) * 100);
            }
        }

        private void OnTempoChanged()
        {
            _engine.DesiredTempoBpm = (double)_tempoUpDown.Value;
        }

        private void OnMasterVolumeChanged()
        {
            _engine.MasterVolume = _masterVolumeTrackBar.Value / 100.0;
        }

        private void OnTrackVolumeChanged()
        {
            var idx = _tracksList.SelectedIndex;
            if (idx >= 0)
            {
                _engine.SetTrackVolume(idx, _trackVolumeTrackBar.Value / 100.0);
            }
        }

        private void Play()
        {
            if (string.IsNullOrEmpty(_loadedMidiPath) || !File.Exists(_loadedMidiPath))
            {
                MessageBox.Show(this, "No MIDI file loaded. Use File -> Open MIDI...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var deviceName = _deviceCombo.SelectedItem as string;
                _engine.PlayFile(_loadedMidiPath, deviceName);
                _playButton.Enabled = false;
                _stopButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Playback error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Stop()
        {
            try
            {
                _engine.Stop();
            }
            catch { }
            finally
            {
                _playButton.Enabled = true;
                _stopButton.Enabled = false;
            }
        }
    }
}
