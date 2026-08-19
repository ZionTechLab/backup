# Website Design Brief — thilina-perera.zionsl.com

**Hand this document to your designer/design tool as-is. It contains everything needed to build the site: goal, brand system, tech stack, sitemap, and full page-by-page copy. No further content decisions should be needed — only visual execution.**

---

## 1. Project Goal

Build a personal website for Thilina Perera that positions him as a technical founder and systems thinker — not a job-seeking employee, not a generic developer portfolio. The site is the credibility anchor for his LinkedIn/content strategy: every post links back here for the long-form version.

**One-line brief:** A dark, confident, no-nonsense site for someone who audits systems, architects ERPs, and does MSc-level AI research — built from Negombo, Sri Lanka, sold globally.

---

## 2. Who He Is (for context, not to be copied verbatim into the site)

Lead Software Engineer at Hayleys Advantis (22+ years in software engineering, started in ERP support in 2010). Founder/architect of Galaxy ERP (multi-tenant ERP, Postgres). Runs black-box security audits for enterprise domains. MSc candidate in Advanced Machine Learning at Wrexham University (dissertation: RAG for Sinhala-medium business education). Based in Negombo, Sri Lanka.

---

## 3. Brand System

### Voice
| Element | Style |
|---|---|
| Tone | Direct, technical, unhurried |
| Sentences | Short. No fluff. |
| Avoid | "Passionate," "rockstar," "ninja," exclamation marks, corporate jargon |
| Embrace | Proof over claims. Systems over buzzwords. |

### Color Palette
| Role | Hex | Usage |
|---|---|---|
| Background | `#03122B` | Full page background; cards use a slightly lighter tint of the same navy |
| Accent | `#F04E11` | Headings, CTAs, links, icons, dividers — used sparingly, never as a full background |
| Text | `#FFFFFF` | Body text at ~90% opacity for secondary copy, 100% for headings |

### Typography
Inter or Geist — system-native, clean, no display/script fonts. Generous line-height for long-form blog copy.

### Visual don'ts
No headshot collage, no stock-photo skylines/laptops/handshakes, no icon soup, no gradients that fight the flat navy/orange system. If a visual element could appear in a generic SaaS template, cut it.

---

## 4. Tech Stack

| Layer | Choice |
|---|---|
| Framework | Next.js 14 (static export, `output: 'export'`) |
| Styling | Tailwind CSS |
| Content | MDX for blog posts |
| Hosting | Cloudflare Pages |
| Font | Inter or Geist |

**Current status:** a Next.js 16 static-export build already exists locally (`~/projects/thilina-perera-portfolio`). Open to-dos before launch: fix per-page metadata titles, push the repo to GitHub, deploy to Cloudflare Pages under `thilina-perera.zionsl.com`. A designer/builder picking this up should treat those three items as the finish line, not a full rebuild, unless a visual direction change is explicitly requested.

---

## 5. Sitemap (6 pages, no contact page)

```
/              Hero + Work preview + CTA
/about         Who I am
/work          Three case studies
/security      Audit approach + methodology
/blog          Post list
/blog/{slug}   Individual post
```

Contact info (LinkedIn, GitHub, email) lives in the global footer only — no dedicated contact page.

---

## 6. Full Page Copy

### `/` — Home

**Heading:** I find what's broken and fix it.

**Subtext:** Security audits. System architecture. Business technology. One person, no handoffs.

**CTA button:** See my work → `/work`

**Below the fold:** three cards previewing the case studies from `/work` — title, one-line summary, link. Truncated versions of the full case study copy below.

---

### `/about`

**Heading:** About

**Paragraph 1 — Who:**
I'm Thilina Perera. Lead Software Engineer. MSc candidate in Advanced Machine Learning at Wrexham University. Based in Negombo, Sri Lanka.

**Paragraph 2 — What I believe:**
Most technical problems aren't technical. They're structural. Bad handoffs. Missing ownership. Systems no one audits. I fix the system first. The code follows.

**Paragraph 3 — What I've done:**
Built and deployed production extensions for Azure DevOps. Published machine learning systems with peer-reviewed methodology. Audited enterprise domains and found what internal teams missed.

**Paragraph 4 — What I'm building:**
An HR technology platform for Sri Lankan SMEs. Market research complete. Architecture in progress.

**Closing line:** If you need someone who traces problems back to root cause — not symptoms — let's talk.

---

### `/work` — Case Studies

#### Case Study 1: Azure DevOps Time Tracker

**Client:** Private enterprise organisation
**Role:** Solo developer — architecture, frontend, deployment
**Stack:** React 18, TypeScript, Azure DevOps Extension SDK v4, Webpack 5

**Problem:** The organisation tracked time against work items manually — spreadsheets, email chains, verbal estimates. No audit trail. No connection to actual completed work.

**What I built:** A full-stack Azure DevOps extension with five integrated hubs:
- Time Tracker panel on every work item form
- Cross-project report with filtering, grouping, CSV export
- User-specific report for individual tracking
- Team utilisation dashboard (actual vs expected hours)
- Settings hub for task types, cost centres, role-based access

**Technical highlights:**
- Optimistic concurrency via `__etag` — prevents two users overwriting the same entry
- Soft delete pattern — no data is ever physically removed
- Two-phase report loading — UI unlocks before enrichment completes
- Pipeline-based preprocessing with `ColumnTransformer` for consistent inference
- Auto-syncs Completed Work field on every action

**Result:** Deployed to production. Active across multiple teams. Time tracking integrated into the workflow — not a separate system.

---

#### Case Study 2: Enterprise Security Audits

**Service type:** External black-box security assessment
**Methodology:** DNS enumeration, SSL inspection, header analysis, endpoint fuzzing, subdomain discovery, CMS probing, JS bundle analysis

**Problem:** Organisations deploy public-facing infrastructure without systematic security review. Issues accumulate: mock authentication in production, source maps exposing internal code, CORS wildcards, missing security headers, debug endpoints accessible without authentication.

**What I found (redacted examples):**
- Mock authentication bypass in production JS bundle — anyone could skip real login
- Production source maps exposing readable frontend architecture
- Debug error log (ELMAH) publicly accessible — stack traces, server paths, request details
- Six subdomains with zero Cloudflare protection — origin IPs directly exposed
- IIS 8.5 on an EOL operating system (Windows Server 2012 R2 — 973 days without patches)
- CORS wildcard (`*`) on all responses

**What I deliver:**
- Prioritised findings with severity ratings (Critical / High / Medium / Low)
- Remediation steps with effort estimates
- Clear, non-technical summaries for management
- Verification re-audit after fixes are deployed

**Note:** Client identities and specific domains are withheld. Methodology and pattern analysis are shared.

---

#### Case Study 3: HR BPO Technology Platform

**Status:** In development
**Role:** Founder — market research, business planning, architecture

**Problem:** Sri Lanka's $1.2 billion BPO industry is dominated by manual processes. HR outsourcing — payroll, recruitment, compliance, leave management — is handled through spreadsheets and phone calls. SMEs pay premium rates for basic services because providers lack automation.

**What I'm building:** A technology-first HR outsourcing platform targeting Sri Lankan SMEs:
- Automated payroll processing with EPF/ETF compliance
- Employee self-service portal (leave, attendance, documents)
- Recruitment pipeline with CV screening automation
- Client dashboard with real-time reporting

**Business model:** Per-employee-per-month pricing. 30–50% below existing competitors because automation handles what manual providers do with four staff members.

**Current stage:** Market research complete. Competitor analysis done. Financial model built (break-even month 3–4). Architecture design in progress. Built on Next.js + Express with PostgreSQL.

---

### `/security`

**Heading:** How I Audit

**Intro:** Every system has gaps. The question is whether you find them before someone else does.

**Methodology:**
1. **Reconnaissance** — DNS, SSL, headers, subdomains. Map the surface before probing.
2. **Platform detection** — CMS version, framework, plugins, API endpoints.
3. **Path discovery** — Common misconfigurations, debug endpoints, backup files.
4. **Code analysis** — JS bundle inspection, exposed credentials, build artifacts.
5. **Reporting** — Prioritised findings, severity ratings, remediation steps.

**What I test:**
- Security headers (CSP, HSTS, XFO, CORS)
- Authentication bypass (mock auth, debug accounts)
- Information exposure (source maps, error logs, directory listings)
- Infrastructure (Cloudflare coverage, open ports, EOL systems)
- Email security (SPF, DMARC, spoofing)

**What I don't do:**
- Exploit vulnerabilities beyond proof of access
- Access or modify data on client systems
- Denial-of-service or destructive testing
- Share findings without client permission

**Closing CTA:** Interested in an audit? → LinkedIn or email in footer.

---

### `/blog` — Post List

Simple list layout: title, date, one-sentence summary, read link.

**Post 1 — Black-Box Security Audits: A Practical Methodology**
Date: July 2026 · Read time: 8 minutes
Summary: How I approach external security assessments. From DNS enumeration to JS bundle analysis, with lessons from real audits.

**Post 2 — Building an Azure DevOps Extension: What the Docs Don't Tell You**
Date: August 2026 · Read time: 6 minutes
Summary: Optimistic concurrency, soft deletes, and why ExtensionDataService is both your best friend and worst enemy.

*(Additional posts will sync over time from the LinkedIn content calendar — design the list view to scale past 2 entries without redesign.)*

---

### Global Footer (every page)

```
Thilina Perera — Negombo, Sri Lanka
GitHub · LinkedIn · Email
Built in Sri Lanka. Deployed globally.
```

---

## 7. Banner / Hero Visual Direction

Dark navy (`#03122B`) background, the orange accent (`#F04E11`) used sparingly — a rule line, an underline, a small mark — never as a dominant fill. If a hero illustration is used, keep it abstract and systems-related (a subtle node/schema diagram, a grid), not a stock photo or an icon collage. The banner/hero should look like it was designed by someone who reads database query plans for fun, not generated from a generic startup template.

---

## 8. Deliverables Checklist

- [ ] Content reviewed against this brief (no new copy needed — only layout/visual decisions)
- [ ] Per-page metadata titles fixed
- [ ] All 6 pages built to spec
- [ ] Blog MDX pipeline functioning, scalable past 2 posts
- [ ] Repo pushed to GitHub
- [ ] Deployed to `thilina-perera.zionsl.com` via Cloudflare Pages
