# Portfolio — thilina-perera.zionsl.com

**Status:** Built — Next.js 16 static export @ `~/projects/thilina-perera-portfolio`  
**To-Do:** Fix per-page metadata titles, push to GitHub, deploy to Cloudflare Pages

---

## Brand Voice

| Element | Style |
|---------|-------|
| Tone | Direct, technical, unhurried |
| Sentence length | Short. No fluff. |
| Avoid | "Passionate," "rockstar," "ninja," exclamation marks |
| Embrace | Proof over claims. Systems over buzzwords. |

---

## Color Palette

| Role | Hex | Usage |
|------|-----|-------|
| Background | `#03122B` | Full page BG, cards (slightly lighter) |
| Accent | `#F04E11` | Headings, CTAs, links, icons, dividers |
| Text | `#FFFFFF` | Body text (opacity 0.9 for secondary) |

---

## Tech Stack

| Layer | Choice |
|-------|--------|
| Framework | Next.js 14 (static export `output: 'export'`) |
| Styling | Tailwind CSS |
| Content | MDX for blog posts |
| Hosting | Cloudflare Pages |
| Font | Inter or Geist (system-native, clean) |

---

## Site Map (6 Pages)

```
/              Hero + Work preview + CTA
/about         Who I am
/work          Three case studies
/security      Audit approach + methodology
/blog          Post list
/blog/{slug}   Individual post
```

No contact page — put LinkedIn, GitHub, email in footer (global).

---

## Page Content — Full Copy

### `/` — Hero

**Heading:** I find what's broken and fix it.

**Subtext:** Security audits. System architecture. Business technology. One person, no handoffs.

**CTA Button:** See my work → `/work`

**Below fold:** 3 cards with case study previews (title, one-line, link). Same content as `/work` but truncated.

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

**Problem:**
The organisation tracked time against work items manually — spreadsheets, email chains, verbal estimates. No audit trail. No connection to actual completed work.

**What I built:**
A full-stack Azure DevOps extension with five integrated hubs:
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

**Result:**
Deployed to production. Active across multiple teams. Time tracking integrated into the workflow — not a separate system.

---

#### Case Study 2: Enterprise Security Audits

**Service type:** External black-box security assessment  
**Methodology:** DNS enumeration, SSL inspection, header analysis, endpoint fuzzing, subdomain discovery, CMS probing, JS bundle analysis

**Problem:**
Organisations deploy public-facing infrastructure without systematic security review. Issues accumulate: mock authentication in production, source maps exposing internal code, CORS wildcards, missing security headers, debug endpoints accessible without authentication.

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

**Problem:**
Sri Lanka's $1.2 billion BPO industry is dominated by manual processes. HR outsourcing — payroll, recruitment, compliance, leave management — is handled through spreadsheets and phone calls. SMEs pay premium rates for basic services because providers lack automation.

**What I'm building:**
A technology-first HR outsourcing platform targeting Sri Lankan SMEs:
- Automated payroll processing with EPF/ETF compliance
- Employee self-service portal (leave, attendance, documents)
- Recruitment pipeline with CV screening automation
- Client dashboard with real-time reporting

**Business model:**
Per-employee-per-month pricing. 30-50% below existing competitors because automation handles what manual providers do with four staff members.

**Current stage:**
Market research complete. Competitor analysis done. Financial model built (break-even month 3-4). Architecture design in progress. Built on Next.js + Express with PostgreSQL.

---

### `/security`

**Heading:** How I Audit

**Intro:**
Every system has gaps. The question is whether you find them before someone else does.

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

**Interested in an audit?** → LinkedIn or email in footer.

---

### `/blog` — Post List

Simple list: title, date, 1-sentence summary, read link.

---

#### Blog Post 1: Black-Box Security Audits — A Practical Methodology

**Date:** July 2026 | **Read time:** 8 minutes

**Summary:** How I approach external security assessments. From DNS enumeration to JS bundle analysis, with lessons from real audits.

---

#### Blog Post 2: Building an Azure DevOps Extension — What the Docs Don't Tell You

**Date:** August 2026 | **Read time:** 6 minutes

**Summary:** Optimistic concurrency, soft deletes, and why ExtensionDataService is both your best friend and worst enemy.

---

### Global Footer

```
Thilina Perera — Negombo, Sri Lanka
GitHub · LinkedIn · Email
Built in Sri Lanka. Deployed globally.
```

---

## To-Do

- [ ] Content reviewed and approved by Thilina
- [ ] Next.js project scaffolded
- [ ] Tailwind + color palette configured
- [ ] All 6 pages built
- [ ] Blog MDX pipeline set up
- [ ] Deploy to `thilina-perera.zionsl.com` via Cloudflare Pages
