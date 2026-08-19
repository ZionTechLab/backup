import React, { useState, useEffect } from 'react';
import { parseChordProFormat, validateBrackets } from '../utils/chordUtils';
import './ChordEditor.css';

const ChordEditor = ({ initialValue = '', onContentChange, showPreview = true }) => {
  const [rawText, setRawText] = useState(initialValue);
  const [parsedLines, setParsedLines] = useState([]);
  const [isValidInput, setIsValidInput] = useState(true);

  useEffect(() => {
    setRawText(initialValue);
  }, [initialValue]);

  useEffect(() => {
    // Validate brackets
    const bracketsOk = validateBrackets(rawText);
    setIsValidInput(bracketsOk);

    // Parse for preview
    const lines = rawText.split('\\n');
    const newParsedLines = lines.map(line => parseChordProFormat(line));
    setParsedLines(newParsedLines);

    if (onContentChange) {
      onContentChange(rawText, bracketsOk); // Pass raw text and validity state up
    }
  }, [rawText, onContentChange]);

  const handleTextChange = (event) => {
    setRawText(event.target.value);
  };

  return (
    <div className="chord-editor-container">
      <textarea
        value={rawText}
        onChange={handleTextChange}
        className={`editor-textarea ${!isValidInput ? 'invalid-input' : ''}`}
        placeholder="Enter lyrics with chords, e.g., [C]Verse 1 [G]lyrics..."
        rows={10}
      />
      {!isValidInput && (
        <p className="validation-error">Bracket error: Ensure all '[' have a matching ']'.</p>
      )}

      {showPreview && (
        <div className="editor-preview">
          <h4 className="preview-title">Live Preview</h4>
          {parsedLines.map((lineSegments, lineIndex) => (
            <div key={lineIndex} className="preview-line">
              {lineSegments.map((segment, segIndex) => {
                if (segment.type === 'chord') {
                  return (
                    <span key={segIndex} className="segment-chord-wrapper">
                      <strong className="segment-chord">{segment.chord}</strong>
                      <span className="segment-text-after-chord">{segment.text}</span>
                    </span>
                  );
                }
                return <span key={segIndex} className="segment-text">{segment.content}</span>;
              })}
            </div>
          ))}
           {rawText && parsedLines.length === 0 && !isValidInput && (
             <p>Enter valid content to see preview.</p>
           )}
           {rawText && parsedLines.every(line => line.length === 0) && isValidInput && (
             <p><em>(Empty lines or no parsable content)</em></p>
           )}
        </div>
      )}
    </div>
  );
};

export default ChordEditor;
