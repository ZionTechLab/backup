
## 2024-07-15 - [Attribute-based XSS in Custom Sanitizer]
**Vulnerability:** The custom HTML sanitizer `sanitizeLyrics` explicitly allowed `b`, `i`, `u`, and `br` elements but failed to strip attributes. This allowed attackers to inject JavaScript via event handlers (e.g., `<b onclick="alert(1)">`).
**Learning:** Only validating the tag name when creating a custom HTML sanitizer is insufficient, as malicious attributes can still bypass the check.
**Prevention:** Always explicitly strip or strictly validate attributes on all permitted elements when implementing custom sanitization logic using DOMParser.

## 2024-07-18 - [DOM Clobbering in HTML Sanitizer]
**Vulnerability:** A DOM clobbering vulnerability in the HTML sanitizer (`sanitizeLyrics`) allowed XSS payloads to bypass the sanitizer because the sanitizer loop threw a `TypeError` and terminated early when encountering a clobbered `tagName`.
**Learning:** Checking `el.tagName.toLowerCase()` is vulnerable to DOM clobbering if an attacker injects `<form><input name="tagName"></form>`. This causes `tagName` to evaluate to an HTML element instead of a string, making `.toLowerCase()` throw an error that terminates the sanitization loop for the rest of the document.
**Prevention:** Always use `el.nodeName.toLowerCase()` which is a getter on `Node` and is not susceptible to DOM clobbering by child elements.
