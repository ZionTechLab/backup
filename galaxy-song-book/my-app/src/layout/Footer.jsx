import { useState, useEffect } from "react";
import { useSelector } from "react-redux";
import { selectUser } from "../features/auth";
function useClock() {
  const [time, setTime] = useState(() => {
    const d = new Date();
    return `${String(d.getHours()).padStart(2, "0")}:${String(d.getMinutes()).padStart(2, "0")}`;
  });

  useEffect(() => {
    const tick = () => {
      const d = new Date();
      setTime(`${String(d.getHours()).padStart(2, "0")}:${String(d.getMinutes()).padStart(2, "0")}`);
    };
    const id = setInterval(tick, 10000);
    return () => clearInterval(id);
  }, []);

  return time;
}

function Footer() {
  const user = useSelector(selectUser);
  const time = useClock();
  const ctx  = user?.name ? user.name.toUpperCase().replace(/\s+/g, "-").slice(0, 12) : "SERVICE-PLUS";

  const segments = [
    { key: "ready", node: <><span className="ml-sb-dot" aria-hidden="true" />READY</> },
    { key: "ctx", node: <>CTX {ctx}</> },
    { key: "period", node: <>PERIOD May 2026</> },
    { key: "status", node: <>STATUS OPEN</> },
    { key: "fx", node: <>FX 2026-05-22</> },
    { key: "synced", node: <><span className="ml-sb-dot-hollow" aria-hidden="true" />SYNCED</> },
    { key: "time", node: <>{time}</> },
  ];

  // Duplicated once so the CSS animation (translateX 0 to -50%) can loop
  // seamlessly — the same technique as the login page's FX tape.
  const tape = [...segments, ...segments];

  return (
    <footer className="ml-statusbar" role="status" aria-label="System status">

      {/* Full row — desktop/tablet */}
      <div className="ml-sb-row d-none d-md-flex">
        <div className="ml-sb-seg ml-sb-ready">
          <span className="ml-sb-dot" aria-hidden="true" />
          READY
        </div>

        <div className="ml-sb-seg">
          CTX {ctx}
        </div>

        <div className="ml-sb-seg">
          PERIOD May 2026
        </div>

        <div className="ml-sb-seg">
          STATUS OPEN
        </div>

        <div className="ml-sb-seg">
          FX 2026-05-22
        </div>

        <div className="ml-sb-spacer" />

        <div className="ml-sb-seg">
          <span className="ml-sb-dot-hollow" aria-hidden="true" />
          SYNCED
        </div>

        <div className="ml-sb-seg">
          {time}
        </div>
      </div>

      {/* Scrolling ticker tape — small screens */}
      <div className="ml-sb-tape d-flex d-md-none">
        <div className="ml-sb-tape-inner">
          {tape.map((seg, i) => (
            <div className="ml-sb-tape-item" key={`${seg.key}-${i}`}>
              {seg.node}
            </div>
          ))}
        </div>
      </div>

    </footer>
  );
}

export default Footer;
