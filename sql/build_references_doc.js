/* ----------------------------------------------------------
   Run with:
       npm install docx
       node build_references_doc.js
   Output:
       SMH_Design_Notes_with_References.docx
   ---------------------------------------------------------- */

const fs = require('fs');
const {
  Document, Packer, Paragraph, TextRun,
  AlignmentType, LevelFormat, HeadingLevel, PageBreak,
} = require('docx');

const P = (text, opts = {}) => new Paragraph({
  children: [new TextRun({ text, bold: opts.bold, italics: opts.italic })],
  alignment: opts.align,
  spacing: { after: 120 },
});

const H1 = t => new Paragraph({
  heading: HeadingLevel.HEADING_1,
  children: [new TextRun({ text: t, bold: true })],
  spacing: { before: 240, after: 120 },
});
const H2 = t => new Paragraph({
  heading: HeadingLevel.HEADING_2,
  children: [new TextRun({ text: t, bold: true })],
  spacing: { before: 200, after: 100 },
});

const bullet = (text) => new Paragraph({
  numbering: { reference: "bullets", level: 0 },
  children: [new TextRun(text)],
  spacing: { after: 80 },
});

const num = (text) => new Paragraph({
  numbering: { reference: "numbers", level: 0 },
  children: [new TextRun(text)],
  spacing: { after: 80 },
});

// helper for a reference entry (hanging indent, no bullet number from list)
const refPara = (text) => new Paragraph({
  spacing: { after: 120 },
  indent: { left: 720, hanging: 720 },
  children: [new TextRun(text)],
});

const children = [];

// ============= TITLE =============
children.push(new Paragraph({
  alignment: AlignmentType.CENTER,
  spacing: { before: 1800, after: 240 },
  children: [new TextRun({ text: "Sun Medical Hospital (SMH)", bold: true, size: 44 })],
}));
children.push(new Paragraph({
  alignment: AlignmentType.CENTER,
  spacing: { after: 1200 },
  children: [new TextRun({ text: "Design Notes, Relational Schema & References", bold: true, size: 32 })],
}));
children.push(new Paragraph({ children: [new PageBreak()] }));

// ============= DESIGN NOTES =============
children.push(H1("1. Design Notes"));
children.push(P("The existing database at Sun Medical Hospital (SMH) is developed for the use of the inpatient (IPD) workflow specifically (Emergency and Surgical). Now the system needs to be integrated with Outpatient (OPD) services and begin with Dental and Optical departments [11]. The primary objective is to create an extensible schema that will enable the hospital to add additional services without altering the schema [1], [2]."));

children.push(H2("1.1  Gap Analysis: Existing and New Requirements"));
children.push(P("Entity stiffness: Current model is highly reliant on the ADMISSION entity. It is not very suitable for outpatient non-surgical services (eye exam, dental cleaning, etc.) but is suitable for surgery [1], [12]."));
children.push(P("Limits to classification: Currently OP_TYPE is distinct for the surgical category. The additional requirement is for a generic SERVICE_TYPE or PROCEDURE_TYPE that would enable diagnostic tests, consultation and treatments to be undertaken in a number of specialties [1], [2]."));
children.push(P("Workflow Break: There aren't any plans to schedule out-patient at this time. The workflows for IPD are \"Admissions\" (ward based) and OPD are \"Appointments\" (time based) [6], [11]."));
children.push(P("Administrative Discharge: Inpatient and Outpatient units are independent administrative units that have different data properties (such as Ward assignments in IPD vs. Time-slots in OPD). A unified model has to take into account these differences, in order to avoid data integrity problems [2], [7]."));

children.push(H2("1.2  The Solution"));
children.push(P("To ensure future proofing, it is moving to the generalized SERVICE architecture, which discards procedure specific entities [1], [2]. A central SERVICE entity is a master catalogue of all the services offered by the hospital (Surgical, Dental, Optical, etc.). The service categorisation is proposed to be handled by a SERVICE_CATEGORY entity that will be used to split the services into administrative units (OPD vs. IPD) and speciality groupings [1], [12]."));
children.push(P("While a single SERVICE_TYPE linked only to ADMISSION is insufficient, we will implement a Polymorphic Encounter pattern [2], [6]."));
children.push(P("Unified Patient History: Both ADMISSION (Inpatient) and APPOINTMENT (Outpatient) will be \"Encounter\" points [11], [12]."));
children.push(P("Shared Observations: Clinical OBSERVATION and PRESCRIPTION entities will be connected to both types of encounters, so there will be one source of truth for patient health records no matter which department they are in [7], [11]."));
children.push(P("Entity Separation: ADMISSION to be responsible for bed management, ward assignment and inpatient surgical tracking. APPOINTMENT is added to provide scheduling, allocate resources (clinic areas) and control outpatient flow [6], [12]."));
children.push(P("By decoupling the \"Encounter\" (the visit) from the \"Service\" (what was done), adding a new department like Physiotherapy becomes a configuration task (adding a new record to the SERVICE table) rather than a coding task (adding new tables) [1], [2]."));

children.push(H2("1.3  Design Decisions and Trade-offs"));
children.push(num("Not going the way of pushing OPD services to the ADMISSION table. Admissions are based on ward occupancy otherwise there would be artificial increase in ward occupancy and administrative reporting of outpatient clinic would become difficult [11], [12]."));
children.push(num("Implementation of generalised OBSERVATION entity. This allows a specialist (such as a Dentist, Optician, Surgeon) to record particular clinical findings without the need for speciality specific tables [1], [7]."));

// ============= RELATIONAL SCHEMA =============
children.push(H1("2. Relational Schema"));
children.push(P("The following relational schema use a concise textual notation to define the logical structure [1], [2]. This approach is chosen for its clarity in illustrating key constraints and attribute domains [2], [4]."));

children.push(H2("2.1  Domain Definitions"));
children.push(P("The data types below follow the SQL standard [4], [5] and are fully supported in SQLite [9], the engine used in the Google Colab implementation environment [10]. SQL syntax conventions follow standard practitioner usage [3]."));
children.push(bullet("INT - Non-negative integer used for surrogate primary keys and foreign keys."));
children.push(bullet("VARCHAR(n) - Variable-length character string with a maximum length of n characters."));
children.push(bullet("CHAR(1) - Single-character field used for constrained values (e.g., gender). Use with a CHECK constraint: CHECK (gender IN ('M','F','O'))."));
children.push(bullet("DATE - Calendar date stored in YYYY-MM-DD format."));
children.push(bullet("TIME - Time value stored in HH:MM:SS format."));
children.push(bullet("TIMESTAMP - Date and time stored as YYYY-MM-DD HH:MM:SS (used for admission and observation timestamps)."));
children.push(bullet("DECIMAL(5,2) - Fixed-point decimal number with 5 total digits and 2 decimal places."));
children.push(bullet("TEXT - Variable-length text field used for notes, comments, and descriptions."));

// ============= REFERENCES =============
children.push(new Paragraph({ children: [new PageBreak()] }));
children.push(H1("References"));

const refs = [
  '[1]  S. S. Bagui and R. W. Earp, Database Design Using Entity-Relationship Diagrams, 3rd ed. Boca Raton, FL, USA: Auerbach Publications, 2022.',
  '[2]  R. Elmasri and S. B. Navathe, Fundamentals of Database Systems, 8th ed. Hoboken, NJ, USA: Pearson, 2024.',
  '[3]  A. DeBarros, Practical SQL: A Beginner’s Guide to Storytelling with Data, 2nd ed. San Francisco, CA, USA: No Starch Press, 2022.',
  '[4]  ISO/IEC 9075-1:2023, Information technology — Database languages SQL — Part 1: Framework (SQL/Framework). International Organization for Standardization, Geneva, Switzerland, Jun. 2023.',
  '[5]  ISO/IEC 9075-2:2023, Information technology — Database languages SQL — Part 2: Foundation (SQL/Foundation). International Organization for Standardization, Geneva, Switzerland, Jun. 2023.',
  '[6]  A. C. Babu, V. N. C. S. Teja, A. D. Reddy, E. N. Kumar, and V. Srinivas, “Web Based Hospital Management System,” in Proc. 9th Int. Conf. Advanced Computing and Communication Systems (ICACCS), Coimbatore, India, 2023, doi: 10.1109/ICACCS57279.2023.10112962.',
  '[7]  C. Tarigan and B. Sembiring, “Relational Database for Health Care,” Jurnal Penelitian Pendidikan IPA, vol. 9, no. 9, pp. 7421–7428, 2023.',
  '[8]  F. Rahutomo et al., “Database Management System Design Improvement for Child Stunting Data Collection in Multiple Observation Areas,” in Proc. 2022 7th Int. Conf. Information Management and Technology (ICIMTech), 2022.',
  '[9]  SQLite Consortium, “SQLite Documentation.” [Online]. Available: https://www.sqlite.org/docs.html. Accessed: May 2026.',
  '[10] Google Research, “Colaboratory: Frequently Asked Questions.” [Online]. Available: https://research.google.com/colaboratory/faq.html. Accessed: May 2026.',
  '[11] “Architectural patterns for health information systems: a systematic review,” Frontiers in Digital Health, vol. 7, 2025, doi: 10.3389/fdgth.2025.1694839.',
  '[12] “Design of an Efficient Hospital Management Database System,” in Proc. 2nd Int. Conf. Data Analysis and Machine Learning (DAML), 2024. [Online]. Available: https://www.scitepress.org/Papers/2024/135163/',
];
refs.forEach(r => children.push(refPara(r)));

// ===== Build doc =====
const doc = new Document({
  styles: {
    default: { document: { run: { font: "Arial", size: 22 } } },
    paragraphStyles: [
      { id: "Heading1", name: "Heading 1", basedOn: "Normal", next: "Normal", quickFormat: true,
        run: { size: 32, bold: true, font: "Arial", color: "1F4E78" },
        paragraph: { spacing: { before: 240, after: 120 }, outlineLevel: 0 } },
      { id: "Heading2", name: "Heading 2", basedOn: "Normal", next: "Normal", quickFormat: true,
        run: { size: 26, bold: true, font: "Arial", color: "2E75B6" },
        paragraph: { spacing: { before: 200, after: 100 }, outlineLevel: 1 } },
    ]
  },
  numbering: {
    config: [
      { reference: "bullets",
        levels: [{ level: 0, format: LevelFormat.BULLET, text: "•",
          alignment: AlignmentType.LEFT,
          style: { paragraph: { indent: { left: 720, hanging: 360 } } } }] },
      { reference: "numbers",
        levels: [{ level: 0, format: LevelFormat.DECIMAL, text: "%1.",
          alignment: AlignmentType.LEFT,
          style: { paragraph: { indent: { left: 720, hanging: 360 } } } }] },
    ]
  },
  sections: [{
    properties: {
      page: {
        size: { width: 12240, height: 15840 },
        margin: { top: 1440, right: 1440, bottom: 1440, left: 1440 },
      },
    },
    children,
  }]
});

Packer.toBuffer(doc).then(buf => {
  fs.writeFileSync('SMH_Design_Notes_with_References.docx', buf);
  console.log("Wrote SMH_Design_Notes_with_References.docx", buf.length, "bytes");
});
