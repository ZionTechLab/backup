import React from 'react';
import './AboutUs.css';
import config from '../../config/config';

const AboutUs = () => {
  return (
    <div className="">
      <div className="">
        {/* <div className="topbar">
          <button className="back-btn" onClick={() => window.history.back()}>
            <svg viewBox="0 0 24 24"><polyline points="15,18 9,12 15,6"/></svg>
            Back
          </button>
          <span className="topbar-title">Sinhala Hymnal</span>
          <div style={{ width: 36 }} />
        </div> */}

        <div className="hero text-center overflow-hidden position-relative">
          <div className="hero-icon rounded-circle d-flex align-items-center justify-content-center">
            <svg viewBox="0 0 24 24"><path d="M12 21C12 21 4 13.5 4 8a8 8 0 0 1 16 0c0 5.5-8 13-8 13z"/><circle cx="12" cy="8" r="2.5"/></svg>
          </div>
          <div className="hero-label">· About Us ·</div>
          <div className="hero-title">Sinhala Hymnal Project</div>
          <div className="hero-sub fst-italic">A free devotional gift to the community</div>
          <div className="hero-ornament d-flex align-items-center justify-content-center gap-2">
            <div className="orn-line" />
            <div className="orn-diamond" />
            <div className="orn-line" />
          </div>
        </div>

        <div className="stats">
          <div className="stat text-center"><div className="stat-num">500+</div><div className="stat-label">Hymns</div></div>
          <div className="stat text-center"><div className="stat-num">50+</div><div className="stat-label">Churches</div></div>
          <div className="stat text-center"><div className="stat-num">Free</div><div className="stat-label">Always</div></div>
        </div>

        <div className="body p-4">
          <div className="section mb-4">
            <div className="section-header d-flex align-items-center gap-2 mb-3">
              <div className="section-icon rounded-circle d-flex align-items-center justify-content-center flex-shrink-0"><svg viewBox="0 0 24 24"><path d="M12 2l3.09 6.26L22 9.27l-5 4.87 1.18 6.88L12 17.77l-6.18 3.25L7 14.14 2 9.27l6.91-1.01L12 2z"/></svg></div>
              <span className="section-title fw-medium">Our Mission</span>
            </div>
            <p className="section-text fst-italic">To preserve and share Sinhala Christian hymns — making worship accessible to every church, family, and believer, completely free of charge, forever.</p>
          </div>

          <div className="divider d-flex align-items-center gap-2 mb-4"><div className="div-line flex-grow-1" /><div className="div-diamond" /><div className="div-line flex-grow-1" /></div>

          <div className="section mb-4">
            <div className="section-header d-flex align-items-center gap-2 mb-3">
              <div className="section-icon rounded-circle d-flex align-items-center justify-content-center flex-shrink-0"><svg viewBox="0 0 24 24"><path d="M4 19.5A2.5 2.5 0 0 1 6.5 17H20"/><path d="M6.5 2H20v20H6.5A2.5 2.5 0 0 1 4 19.5v-15A2.5 2.5 0 0 1 6.5 2z"/></svg></div>
              <span className="section-title fw-medium">About This Project</span>
            </div>
            <p className="section-text fst-italic">The Sinhala Hymnal is a volunteer-driven charity project built to digitise our rich collection of Sinhala devotional hymns. No ads. No subscriptions. No cost — ever. It is a service of love for the Sinhala Christian community across Sri Lanka and the world.</p>
          </div>

          <div className="divider d-flex align-items-center gap-2 mb-4"><div className="div-line flex-grow-1" /><div className="div-diamond" /><div className="div-line flex-grow-1" /></div>

          <div className="section-header d-flex align-items-center gap-2 mb-3">
            <div className="section-icon rounded-circle d-flex align-items-center justify-content-center flex-shrink-0"><svg viewBox="0 0 24 24"><circle cx="12" cy="8" r="4"/><path d="M4 20c0-4 3.6-7 8-7s8 3 8 7"/></svg></div>
            <span className="section-title fw-medium">Meet the Founder</span>
          </div>

          <div className="founder-card rounded-3 p-3 mb-4">
            <div className="founder-top d-flex align-items-center gap-3 mb-3">
              <div className="founder-avatar rounded-circle d-flex align-items-center justify-content-center flex-shrink-0"><svg viewBox="0 0 24 24"><circle cx="12" cy="8" r="4"/><path d="M4 20c0-4 3.6-7 8-7s8 3 8 7"/></svg></div>
              <div>
                <div className="founder-name fw-medium">Your Name Here</div>
                <div className="founder-role fst-italic">Founder &amp; Project Lead</div>
              </div>
            </div>
            <p className="founder-bio fst-italic mb-3">"I started this project because I wanted every Sinhala-speaking believer — whether in a village church or abroad — to have easy access to our beautiful hymns. This is my offering to God and to our community."</p>
            <div className="social-row d-flex gap-2 flex-wrap">
              <button type="button" className="social-btn">LinkedIn</button>
              <button type="button" className="social-btn">Facebook</button>
              <button type="button" className="social-btn">Instagram</button>
            </div>
          </div>

          <div className="divider d-flex align-items-center gap-2 mb-4"><div className="div-line flex-grow-1" /><div className="div-diamond" /><div className="div-line flex-grow-1" /></div>

          <div className="volunteer-card rounded-3 p-3 mb-4">
            <div className="vol-badge d-inline-block">We Need You</div>
            <div className="vol-title fw-medium">Join as a Volunteer</div>
            <div className="vol-sub fst-italic mb-3">Help us grow this free resource for the community</div>

            <div className="vol-role d-flex align-items-start gap-2">
              <div className="vol-role-icon rounded-circle d-flex align-items-center justify-content-center flex-shrink-0"><svg viewBox="0 0 24 24"><path d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"/><path d="M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"/></svg></div>
              <div>
                <div className="vol-role-title fw-medium">Hymn Data Entry</div>
                <div className="vol-role-desc fst-italic">Type and format Sinhala hymn lyrics from hymnals into our database. No tech skills needed — just patience and care.</div>
              </div>
            </div>

            <a className="wa-btn w-100 d-flex align-items-center justify-content-center gap-2" href={`https://wa.me/${config.contact.whatsapp}`} target="_blank" rel="noreferrer">Message us on WhatsApp to Volunteer</a>
          </div>

          <div className="support-card rounded-3 p-3 mb-4 text-center">
            <div className="support-title fw-medium mb-1">Support This Project</div>
            <p className="support-text fst-italic mb-3">This is a self-funded charity effort. A small donation helps cover server costs and keeps the hymnal free for everyone, always.</p>
            <button className="support-btn d-inline-flex align-items-center gap-2">Donate to Support Us</button>
          </div>

          <div className="contact-row d-flex align-items-center justify-content-center gap-2 pb-1">
            <svg width="13" height="13" viewBox="0 0 24 24" fill="none" stroke="#a07848" strokeWidth="1.5" strokeLinecap="round"><path d="M4 4h16c1.1 0 2 .9 2 2v12c0 1.1-.9 2-2 2H4c-1.1 0-2-.9-2-2V6c0-1.1.9-2 2-2z"/><polyline points="22,6 12,13 2,6"/></svg>
            <span className="contact-text fst-italic">Questions?</span>
            <a className="contact-link" href={`mailto:${config.contact.email}`}>{config.contact.email}</a>
          </div>

        </div>
{/* 
        <div className="toolbar">
          <div className="tool"><span className="tool-label">Home</span></div>
          <div className="tool"><span className="tool-label">Index</span></div>
          <div className="tool active"><span className="tool-label">About</span></div>
          <div className="tool"><span className="tool-label">Share</span></div>
          <div className="tool"><span className="tool-label">Settings</span></div>
        </div> */}
      </div>
    </div>
  );
};

export default AboutUs;
