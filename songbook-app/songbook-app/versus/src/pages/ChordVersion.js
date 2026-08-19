import React, { useState, useEffect, useRef, useMemo } from 'react';
import { useParams, Link } from 'react-router-dom';
import html2pdf from 'html2pdf.js';
import { getChordVersionById, getSongById } from '../data/api';
import { parseChordProFormat, transposeChordProString } from '../utils/chordUtils';
import './ChordVersion.css';

const ChordVersion = () => {
  const { songId, versionId } = useParams();
  const [version, setVersion] = useState(null);
  const [songTitle, setSongTitle] = useState('');
  const contentToExportRef = useRef(null); // Renamed for clarity

  const [transposeOffset, setTransposeOffset] = useState(0);
  const [displayedChords, setDisplayedChords] = useState('');

  const [showPdfOptions, setShowPdfOptions] = useState(false);
  const [pdfTheme, setPdfTheme] = useState('theme-light'); // Default PDF theme
  const [pdfChordStyle, setPdfChordStyle] = useState('chordsOnTop'); // 'chordsOnTop' or 'chordsInline'

  useEffect(() => {
    const currentVersion = getChordVersionById(versionId, songId);
    setVersion(currentVersion);
    if (currentVersion) {
      setDisplayedChords(currentVersion.chords);
      const parentSong = getSongById(songId);
      setSongTitle(parentSong ? parentSong.title : 'Song');
      // Set default PDF theme based on current app theme if possible, or keep a fixed default
      const currentAppTheme = document.body.className || 'theme-dark';
      setPdfTheme(currentAppTheme);
    }
  }, [songId, versionId]);

  useEffect(() => {
    if (version && version.chords) {
      if (transposeOffset === 0) {
        setDisplayedChords(version.chords);
      } else {
        setDisplayedChords(transposeChordProString(version.chords, transposeOffset));
      }
    }
  }, [version, transposeOffset]);

  const parsedLyrics = useMemo(() => {
    return parseChordProFormat(displayedChords);
  }, [displayedChords]);

  const handleTranspose = (semitones) => setTransposeOffset(prev => prev + semitones);
  const resetTranspose = () => setTransposeOffset(0);

  const generatePdfContentHtml = (forPdfChordStyle) => {
    // Generates HTML string for PDF based on selected chord style
    // This is a simplified approach; direct DOM manipulation of a cloned node is often better.
    let html = `<div class="pdf-export-content-inner ${pdfTheme}">`; // Apply theme to inner content for PDF
    html += `<h2 class="page-title">${songTitle} - ${version.title} (Chords)${transposeOffset !== 0 ? ` (Transposed ${transposeOffset > 0 ? '+' : ''}${transposeOffset})` : ''}</h2>`;
    html += `<p class="version-author">By: ${version.author || 'Unknown Author'}</p>`;
    html += `<div class="chords-display-area">`;

    if (forPdfChordStyle === 'chordsInline') {
      html += displayedChords.replace(/\[([^\]]+?)\]/g, '<strong class="segment-chord-inline">[$1]</strong>');
    } else { // chordsOnTop
      parsedLyrics.forEach(part => {
        if (part.type === 'text') {
          html += `<span class="lyric-segment">${part.content.replace(/</g, '&lt;').replace(/>/g, '&gt;')}</span>`;
        } else {
          html += `<span class="chord-block"><strong class="chord">${part.chord.replace(/</g, '&lt;').replace(/>/g, '&gt;')}</strong><span class="lyric-segment-with-chord">${part.text.replace(/</g, '&lt;').replace(/>/g, '&gt;')}</span></span>`;
        }
      });
    }
    html += `</div></div>`;
    return html;
  };

  const handleActualPdfGeneration = () => {
    if (!version) return;

    const tempExportElement = document.createElement('div');
    // Apply necessary styling for PDF rendering if not directly using contentToExportRef
    // This is crucial if CSS is not globally available to html2pdf or if specific PDF styles are needed.
    // For now, assuming .pdf-export-content-inner and its children styles are globally defined or will be handled by html2canvas.
    tempExportElement.innerHTML = generatePdfContentHtml(pdfChordStyle);
    document.body.appendChild(tempExportElement); // Needs to be in DOM for html2canvas

    const opt = {
      margin: 0.5,
      filename: `${songTitle.replace(/ /g, '_')}-${version.title.replace(/ /g, '_')}${transposeOffset !== 0 ? `_transposed${transposeOffset}` : ''}_${pdfChordStyle}.pdf`,
      image: { type: 'jpeg', quality: 0.98 },
      html2canvas: { scale: 2, useCORS: true, logging: false, removeContainer: true, backgroundColor: null }, // removeContainer true cleans up temp element
      jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
    };

    html2pdf().from(tempExportElement).set(opt).save().then(() => {
         if (document.body.contains(tempExportElement)) { // Ensure it's still there before removing
            document.body.removeChild(tempExportElement);
        }
    }).catch(err => {
      console.error("PDF Export failed:", err);
      if (document.body.contains(tempExportElement)) {
        document.body.removeChild(tempExportElement);
      }
    });
    setShowPdfOptions(false); // Close options after attempting export
  };


  if (!version) return <div className="not-found-message">Loading or version not found...</div>;

  return (
    <div className="chord-version-container card">
      <div ref={contentToExportRef} className="pdf-export-content"> {/* This ref is for on-screen display, not direct PDF source if re-rendering */}
        <h2 className="page-title">
          {songTitle} - {version.title} (Chords)
          {transposeOffset !== 0 && <span className="transpose-indicator"> (Transposed {transposeOffset > 0 ? '+' : ''}{transposeOffset})</span>}
        </h2>
        <p className="version-author">By: {version.author || 'Unknown Author'}</p>
        <div className="chords-display-area">
          {parsedLyrics.map((part, index) =>
            part.type === 'text' ?
            <span key={index} className="lyric-segment">{part.content}</span> :
            <span key={index} className="chord-block">
              <strong className="chord">{part.chord}</strong>
              <span className="lyric-segment-with-chord">{part.text}</span>
            </span>
          )}
        </div>
      </div>

      <div className="actions-toolbar">
        <div className="transpose-controls">
          {/* Transpose buttons */}
          <button onClick={() => handleTranspose(-1)} className="link-button transpose-btn">♭ (-1)</button>
          <button onClick={resetTranspose} className="link-button transpose-btn" disabled={transposeOffset === 0}>Reset</button>
          <button onClick={() => handleTranspose(1)} className="link-button transpose-btn">♯ (+1)</button>
          <span className="transpose-offset-display">Current: {transposeOffset > 0 ? '+' : ''}{transposeOffset}</span>
        </div>
        <button onClick={() => setShowPdfOptions(!showPdfOptions)} className="link-button export-pdf-btn">
          {showPdfOptions ? 'Cancel PDF Export' : 'Export as PDF'}
        </button>
      </div>

      {showPdfOptions && (
        <div className="pdf-options-panel card">
          <h4 className="panel-title">PDF Export Options</h4>
          <div className="form-group">
            <label htmlFor="pdfTheme">PDF Theme:</label>
            <select id="pdfTheme" value={pdfTheme} onChange={(e) => setPdfTheme(e.target.value)}>
              <option value="theme-light">Light</option>
              <option value="theme-dark">Dark</option>
              <option value="theme-book">Book</option>
            </select>
          </div>
          <div className="form-group">
            <label htmlFor="pdfChordStyle">Chord Style:</label>
            <select id="pdfChordStyle" value={pdfChordStyle} onChange={(e) => setPdfChordStyle(e.target.value)}>
              <option value="chordsOnTop">Chords on Top</option>
              <option value="chordsInline">Chords Inline [C]</option>
            </select>
          </div>
          <button onClick={handleActualPdfGeneration} className="link-button generate-pdf-btn">
            Generate PDF
          </button>
        </div>
      )}

      <div className="navigation-links">
        <Link to={`/songs/${songId}`} className="link-button">Back to Song Details</Link>
        <Link to="/" className="link-button">Back to Song List</Link>
      </div>
    </div>
  );
};

export default ChordVersion;
