import { useEffect, useRef, useCallback } from "react";
import { useParams, useNavigate } from "react-router-dom";
import * as Yup from "yup";
import { useFormikBuilder } from "../../../helpers/formikBuilder";
import ApiService from "./service";
import MessageBoxService from "../../../services/MessageBoxService";

// Strips any HTML tags not explicitly produced by the toolbar (b, i, u, br).
// Uses DOMParser so script content is never executed, even during parsing.
function sanitizeLyrics(html) {
  const allowed = new Set(['b', 'i', 'u', 'br']);
  const doc = new DOMParser().parseFromString(html, 'text/html');
  doc.body.querySelectorAll('*').forEach((el) => {
    if (!allowed.has(el.nodeName.toLowerCase())) {
      el.replaceWith(...el.childNodes);
    } else {
      // Strip all attributes to prevent XSS (e.g., onclick)
      while (el.attributes.length > 0) {
        el.removeAttribute(el.attributes[0].name);
      }
    }
  });
  return doc.body.innerHTML;
}

const fields = {
  title: {
    name: "title",
    type: "text",
    placeholder: "Song Title",
    className: "col-sm-12",
    initialValue: "",
    validation: Yup.string().required("Title is required"),
  },
  lyrics: {
    name: "lyrics",
    type: "textarea",
    placeholder: "Song Lyrics (supports Markdown / HTML)",
    className: "col-sm-12",
    initialValue: "",
    validation: Yup.string().required("Lyrics are required"),
  },
};

function AddSong() {
  const { id } = useParams();
  const navigate = useNavigate();
  const isEdit = !!id;

  const handleSubmit = async (values) => {
    const payload = {
      ...values,
      lyrics: sanitizeLyrics(values.lyrics.replace(/\n/g, '<br>')),
      id: parseInt(id || 0),
      isUpdate: !!id,
    };

    const response = await ApiService.update(payload);
    if (response.success) {
      MessageBoxService.show({
        message: isEdit ? "Song updated successfully!" : "Song added successfully!",
        type: "success",
        onClose: () => navigate("/song-book/all"),
      });
    }
  };

  const formik = useFormikBuilder(fields, handleSubmit);

  const lyricsRef = useRef(null);
  const lyricsValueRef = useRef(formik.values.lyrics);
  const setFieldValueRef = useRef(formik.setFieldValue);
  const setValuesRef = useRef(formik.setValues);

  // Keep refs current on every render so callbacks always see latest formik methods
  lyricsValueRef.current = formik.values.lyrics;
  setFieldValueRef.current = formik.setFieldValue;
  setValuesRef.current = formik.setValues;

  useEffect(() => {
    if (!isEdit) return;
    const fetchSong = async () => {
      const response = await ApiService.get(id);
      if (response.success && response.data) {
        setValuesRef.current({
          title: response.data.title || "",
          lyrics: (response.data.lyrics || "").replace(/<br\s*\/?>/gi, '\n'),
        });
      }
    };
    fetchSong();
  }, [id, isEdit]);

  const wrapSelection = useCallback((before, after) => {
    const ta = lyricsRef.current;
    if (!ta) return;
    const start = ta.selectionStart;
    const end = ta.selectionEnd;
    const text = lyricsValueRef.current;
    const selected = text.substring(start, end);
    const newText = text.substring(0, start) + before + selected + after + text.substring(end);
    setFieldValueRef.current("lyrics", newText);
    setTimeout(() => {
      ta.focus();
      ta.selectionStart = start + before.length;
      ta.selectionEnd = end + before.length;
    }, 0);
  }, []); // stable — reads formik state via refs, not closure

  return (
    <div className="d-flex flex-column sb-editor-screen">
      <div className="container-fluid py-3 d-flex flex-column flex-grow-1 min-h-0">
        <div className="card d-flex flex-column flex-grow-1 min-h-0">
          <div className="card-body d-flex flex-column flex-grow-1 min-h-0">
            <h5 className="card-title mb-3">
              {isEdit ? `Edit Song (ID: ${id})` : "Add New Song"}
            </h5>
            <form onSubmit={formik.handleSubmit} className="d-flex flex-column flex-grow-1 min-h-0">
              {/* Title field */}
              <div className="mb-3">
                <input
                  type="text"
                  className={`form-control ${formik.touched.title && formik.errors.title ? "is-invalid" : ""}`}
                  placeholder="Song Title"
                  name="title"
                  value={formik.values.title}
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                />
                {formik.touched.title && formik.errors.title && (
                  <div className="invalid-feedback">{formik.errors.title}</div>
                )}
              </div>

              {/* Lyrics editor with toolbar */}
              <div className="d-flex flex-column flex-grow-1 border rounded min-h-0">
                <div className="d-flex gap-1 p-2 border-bottom bg-light rounded-top">
                  <button type="button" className="btn btn-sm btn-outline-secondary" title="Bold" onClick={() => wrapSelection("<b>", "</b>")}>
                    <i className="bi bi-type-bold"></i>
                  </button>
                  <button type="button" className="btn btn-sm btn-outline-secondary" title="Italic" onClick={() => wrapSelection("<i>", "</i>")}>
                    <i className="bi bi-type-italic"></i>
                  </button>
                  <button type="button" className="btn btn-sm btn-outline-secondary" title="Underline" onClick={() => wrapSelection("<u>", "</u>")}>
                    <i className="bi bi-type-underline"></i>
                  </button>
                </div>
                <textarea
                  ref={lyricsRef}
                  className={`form-control border-0 flex-grow-1 sb-lyrics-textarea ${formik.touched.lyrics && formik.errors.lyrics ? "is-invalid" : ""}`}
                  placeholder="Song Lyrics (press Enter for line breaks)"
                  name="lyrics"
                  value={formik.values.lyrics}
                  onChange={formik.handleChange}
                  onBlur={formik.handleBlur}
                />
                {formik.touched.lyrics && formik.errors.lyrics && (
                  <div className="invalid-feedback px-2 pb-2">{formik.errors.lyrics}</div>
                )}
              </div>

              {/* Action buttons */}
              <div className="d-flex gap-2 mt-3">
                <button type="submit" className="btn btn-primary">
                  {isEdit ? "Update" : "Save"}
                </button>
                <button
                  type="button"
                  className="btn btn-outline-secondary"
                  onClick={() => navigate("/song-book/all")}
                >
                  Cancel
                </button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}

export default AddSong;
