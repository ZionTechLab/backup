Yamaha Style Editor (prototype)

This workspace contains a minimal .NET 8 WinForms starter and a core MIDI library.

Structure:
- YamahaStyle.Core: Core library with the MIDI engine (uses Melanchall.DryWetMIDI)
- YamahaStyle.WinForms: WinForms UI referencing the core project

Build and run (requires .NET 8 SDK):

# Restore packages and build
dotnet restore
dotnet build

# Run the WinForms app
dotnet run --project YamahaStyle.WinForms

Notes:
- The prototype lists MIDI output devices using DryWetMIDI.

- Next step: add MIDI file I/O, style-specific structures, and UI editor controls.