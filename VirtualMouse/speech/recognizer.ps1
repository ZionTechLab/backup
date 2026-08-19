# System.Speech command recognizer sidecar.
# Captures the default mic, matches a fixed grammar, prints one JSON line per event.
# Node (src/voice.js) spawns this and reads stdout.
$ErrorActionPreference = "Stop"

function Emit($obj) {
  [Console]::Out.WriteLine(($obj | ConvertTo-Json -Compress))
  [Console]::Out.Flush()
}

try {
  Add-Type -AssemblyName System.Speech

  $engine = New-Object System.Speech.Recognition.SpeechRecognitionEngine
  $engine.SetInputToDefaultAudioDevice()

  # Fixed command phrases. A small grammar means high accuracy.
  $phrases = @(
    "click", "right click", "double click",
    "move up", "move down", "move left", "move right",
    "scroll up", "scroll down",
    "go to sleep", "wake up"
  )
  $choices = New-Object System.Speech.Recognition.Choices
  foreach ($p in $phrases) { $choices.Add($p) }
  $gb = New-Object System.Speech.Recognition.GrammarBuilder
  $gb.Append($choices)
  $engine.LoadGrammar((New-Object System.Speech.Recognition.Grammar $gb))

  # Fire a JSON line for every recognized phrase.
  Register-ObjectEvent -InputObject $engine -EventName SpeechRecognized -Action {
    $res = $Event.SourceEventArgs.Result
    [Console]::Out.WriteLine((@{
      type       = "cmd"
      text       = $res.Text
      confidence = [math]::Round([double]$res.Confidence, 2)
    } | ConvertTo-Json -Compress))
    [Console]::Out.Flush()
  } | Out-Null

  Emit @{ type = "ready" }

  $engine.RecognizeAsync([System.Speech.Recognition.RecognizeMode]::Multiple)
  while ($true) { Start-Sleep -Seconds 1 }
}
catch {
  Emit @{ type = "error"; message = $_.Exception.Message }
  exit 1
}
