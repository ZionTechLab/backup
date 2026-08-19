$md = Get-Content 'c:\repo\personal\notepad-lite\test-table.md' -Raw
$md = [regex]::Replace($md,'```[\s\S]*?```','',[System.Text.RegularExpressions.RegexOptions]::Singleline)
$md = [regex]::Replace($md,'`[^`]*`','')
$md = [regex]::Replace($md,'<[^>]+>','')
$md = [regex]::Replace($md,'!\[([^\]]*)\]\([^\)]*\)','$1')
$md = [regex]::Replace($md,'\[(.*?)\]\([^\)]*\)','$1')
$md = [regex]::Replace($md,'(?m)^[\s\|\-:]+$','',[System.Text.RegularExpressions.RegexOptions]::Multiline)
$md = [regex]::Replace($md,'^#{1,6}\s*','',[System.Text.RegularExpressions.RegexOptions]::Multiline)
$md = $md.Replace('**','').Replace('__','').Replace('*','').Replace('_','').Replace('~~','')
$md = $md.Replace('|',' ')
$md = [regex]::Replace($md,'(?m)^[>\-\+\*]\s+','',[System.Text.RegularExpressions.RegexOptions]::Multiline)
$md = [regex]::Replace($md,'\s+',' ').Trim()
Write-Output '---STRIPPED---'
Write-Output $md
Write-Output '---TOKENS---'
[regex]::Matches($md,'\S+').Count
