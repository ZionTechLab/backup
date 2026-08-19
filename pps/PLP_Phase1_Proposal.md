# Project Proposal
## Production Label Printing System (PLP) with QR Code — Phase 1
**Poly Packaging Services | May 2026 | Version 1.0**

---

## 1. Project Overview

A cloud-hosted, mobile-accessible web application is required to manage and print production LOT labels with QR codes across five production sections: Mixing, Extruder, Printing, Gusset, and Cutting. Manual label generation will be eliminated, traceability will be improved, and management dashboards and reports will be provided.

**Key Objectives**
- Auto LOT number generation with QR code labels (JobProfile embedded)
- Full traceability across all production sections
- Role-based access with audit trail and email alerts

> **Note:** Initial System Design, Requirements Analysis, and Software QA Testing costs are not included. These activities are to be performed by the Customer.

---

## 2. Phase 1 Scope

| Category | Deliverables |
|---|---|
| **User & Access** | User Management, Feature-based RBAC, Audit Trail Logs, Auto Email Alerts |
| **Dashboards** | Directors Dashboard, Managers Dashboard |
| **Masters (7)** | Job Profile, Customer, Machine/Section, Supervisor & Operator, Work Shift, Material Type, Product Sizes Grouping |
| **Label Printing (5)** | Mixing, Extruder, Printing, Gusset, Cutting — each with Double Sticker (Paper Core + Film), QR Code, Transfer Note |
| **Reports** | 5 Basic Reports with Export to Excel |

---

## 3. Proposed Technology Stack

| Layer | Technology | Notes |
|---|---|---|
| **Frontend** | React (PWA) | Mobile-accessible, installable on factory floor devices |
| **Backend** | Node.js | REST API |
| **Database** | PostgreSQL | Self-hosted on VPS — no licensing cost, no user limit, 200GB+ storage |
| **Hosting** | Contabo VPS | Up to 15 users — cloud fee does not change |
| **Security / WAF** | Cloudflare (Free) | DDoS protection, HTTPS, DNS management, Reverse Proxy |

---

## 4. Estimation & Investment

| Item | Cost |
|---|---|
| **Development Timeline** | ~50 days |
| **One-Time Development Cost** | LKR 585,000 |
| **Cloud Hosting Fee** (up to 15 users — fee does not change) | USD 29/mo |
| **Monthly Software Support** (bug fixes, security & framework updates, online support) | USD 15/mo |
| **Total Monthly Fee** | **USD 44/mo** |
| **Additional 5GB Cloud Storage** *(rate expires in 7 days)* | USD 5/mo |

> **ROI Note:** Currently paying ~LKR 50,000–150,000 for standalone reports alone. Phase 1 delivers full production traceability + reports for a comparable one-time investment.

---

## 5. Next Steps

| # | Action |
|---|---|
| 1 | Clarify Transfer Note fields, Dashboard KPIs, Email alert triggers |
| 2 | Confirm printer model for label printing integration |

---

*Confidential — For Internal Review Only*
