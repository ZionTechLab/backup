# MySQL Table Naming Convention

## Overview
This document outlines the standardized naming convention for MySQL database tables, designed to organize tables both vertically (by data type) and horizontally (by business module).

## Naming Format
```
{module}_{type}_{entityName}
```

### Components
- **module**: 2-3 letter lowercase abbreviation for business module
- **type**: 3-letter lowercase data classification
- **entityName**: camelCase descriptive name for the table's purpose

## Module Abbreviations
| Code | Module | Description |
|------|--------|-------------|
| `sec` | Security | Authentication, authorization, user management |
| `sal` | Sales | Sales processes, orders, customers |
| `fin` | Finance | Accounting, budgets, financial transactions |
| `inv` | Inventory | Stock management, items, warehouses |
| `hrm` | Human Resources | Employee management, payroll, attendance |
| `crm` | Customer Relations | Customer interactions, support |
| `pur` | Purchasing | Procurement, vendor management |
| `rpt` | Reports | Analytics, dashboards, reporting |
| `sys` | System | Configuration, settings, logs |

## Data Type Classifications
| Code | Type | Purpose | Examples |
|------|------|---------|----------|
| `ref` | Reference | Static lookup/dropdown data | Status codes, categories, types |
| `mas` | Master | Core business entities | Customers, products, employees |
| `txn` | Transaction | Business process records | Orders, payments, movements |

## Naming Examples

### Security Module
```sql
sec_ref_userRoles           -- User role lookup
sec_ref_permissions         -- Permission types
sec_mas_users               -- User master data
sec_mas_userSessions        -- User session management
sec_txn_loginAttempts       -- Login activity log
sec_txn_auditTrail          -- Security audit records
```

### Sales Module
```sql
sal_ref_salesTypes          -- Sales type lookup
sal_ref_paymentTerms        -- Payment terms reference
sal_mas_customers           -- Customer master
sal_mas_products            -- Product master
sal_txn_salesOrders         -- Sales order transactions
sal_txn_invoices            -- Invoice records
```

### Finance Module
```sql
fin_ref_accountTypes        -- Account type lookup
fin_ref_currencies          -- Currency reference
fin_mas_chartOfAccounts     -- Chart of accounts
fin_mas_costCenters         -- Cost center master
fin_txn_journalEntries      -- Journal transactions
fin_txn_budgetEntries       -- Budget transactions
```

## Junction/Linking Tables
For many-to-many relationships:
```
{module}_{type}_{entity1}{entity2}
```

Examples:
```sql
sec_mas_userRoles           -- Links users to roles
sal_mas_customerTerritories -- Links customers to territories
fin_mas_accountCostCenters  -- Links accounts to cost centers
```

## Guidelines

### Do's
- Use lowercase letters only
- Use underscores as separators (never hyphens)
- Use camelCase for entity names
- Keep table names under 64 characters
- Use plural nouns for consistency
- Be descriptive but concise

### Don'ts
- Don't use reserved MySQL keywords
- Don't use spaces or special characters
- Don't abbreviate unnecessarily
- Don't mix naming conventions within the same database

## Implementation Notes
- All table names follow this convention without requiring backticks
- Compatible with most database management tools
- Easily identifiable module ownership
- Clear data classification for maintenance and queries
- Scalable as the system grows

## Example Usage
```sql
-- Creating tables
CREATE TABLE sal_mas_customers (...);
CREATE TABLE fin_txn_journalEntries (...);

-- Querying tables
SELECT * FROM inv_ref_itemCategories;
SELECT * FROM hrm_txn_attendance WHERE date = '2025-08-18';

-- Joining related tables
SELECT c.customerName, o.orderDate 
FROM sal_mas_customers c
JOIN sal_txn_salesOrders o ON c.customerId = o.customerId;
```

---
*Last updated: August 2025*