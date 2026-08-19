/* =========================================================
   Sun Medical Hospital (SMH) - Extended Database
   Part 2 - Section B : 10 Management-Scenario SQL Queries
   ========================================================= */


/* ---------------------------------------------------------
   Q1. Patients (Persons) admitted to a SPECIFIC ward.
       (example: Surgical Ward, ward_id = 102)
   --------------------------------------------------------- */
SELECT  p.person_id,
        p.first_name,
        p.last_name,
        w.ward_name,
        a.admit_date,
        a.discharge_date
FROM    PERSON              p
JOIN    PATIENT_ENCOUNTER   pe ON pe.person_id    = p.person_id
JOIN    ADMISSION           a  ON a.encounter_id  = pe.encounter_id
JOIN    WARD                w  ON w.ward_id       = a.ward_id
WHERE   w.ward_id = 102;


/* ---------------------------------------------------------
   Q2. All operations performed by a SPECIFIC surgeon.
       (example: surgeon_id = 10  -> Alice Walker)
   --------------------------------------------------------- */
SELECT  o.operation_id,
        ot.name              AS op_type,
        o.operation_date,
        o.room,
        s.first_name || ' ' || s.last_name AS surgeon
FROM    OPERATION  o
JOIN    STAFF      s  ON s.staff_id   = o.surgeon_id
JOIN    OP_TYPE    ot ON ot.op_type_id = o.op_type_id
WHERE   o.surgeon_id = 10
ORDER BY o.operation_date;


/* ---------------------------------------------------------
   Q3. Total number of admissions per ward.
   --------------------------------------------------------- */
SELECT  w.ward_id,
        w.ward_name,
        COUNT(a.encounter_id) AS total_admissions
FROM    WARD       w
LEFT JOIN ADMISSION a ON a.ward_id = w.ward_id
GROUP BY w.ward_id, w.ward_name
ORDER BY total_admissions DESC;


/* ---------------------------------------------------------
   Q4. Patients who have been ADMITTED but have NOT YET
       received an operation.
   --------------------------------------------------------- */
SELECT  DISTINCT p.person_id,
        p.first_name,
        p.last_name,
        a.admit_date
FROM    PERSON             p
JOIN    PATIENT_ENCOUNTER  pe ON pe.person_id   = p.person_id
JOIN    ADMISSION          a  ON a.encounter_id = pe.encounter_id
WHERE   NOT EXISTS (
            SELECT 1
            FROM   OPERATION o
            WHERE  o.encounter_id = pe.encounter_id
        );


/* ---------------------------------------------------------
   Q5. Operations of a specific OP_TYPE within a date range.
       (example: Appendectomy, op_type_id = 200,
        between 2026-01-01 and 2026-06-30)
   --------------------------------------------------------- */
SELECT  o.operation_id,
        ot.name           AS op_type,
        o.operation_date,
        s.first_name || ' ' || s.last_name AS surgeon,
        o.room
FROM    OPERATION  o
JOIN    OP_TYPE    ot ON ot.op_type_id = o.op_type_id
JOIN    STAFF      s  ON s.staff_id    = o.surgeon_id
WHERE   o.op_type_id  = 200
AND     o.operation_date BETWEEN '2026-01-01' AND '2026-06-30'
ORDER BY o.operation_date;


/* ---------------------------------------------------------
   Q6. Patients who received an operation, with their
       corresponding observations.
   --------------------------------------------------------- */
SELECT  p.person_id,
        p.first_name || ' ' || p.last_name AS patient,
        ot.name        AS op_type,
        o.operation_date,
        ob.observation_date,
        ob.notes
FROM    PERSON             p
JOIN    PATIENT_ENCOUNTER  pe ON pe.person_id    = p.person_id
JOIN    OPERATION          o  ON o.encounter_id  = pe.encounter_id
JOIN    OP_TYPE            ot ON ot.op_type_id   = o.op_type_id
JOIN    OBSERVATION        ob ON ob.encounter_id = pe.encounter_id
                              AND ob.op_type_id  = o.op_type_id
ORDER BY p.person_id, o.operation_date;


/* ---------------------------------------------------------
   Q7. Most-frequently performed operation type.
   --------------------------------------------------------- */
SELECT  ot.op_type_id,
        ot.name,
        COUNT(*) AS times_performed
FROM    OPERATION  o
JOIN    OP_TYPE    ot ON ot.op_type_id = o.op_type_id
GROUP BY ot.op_type_id, ot.name
ORDER BY times_performed DESC
LIMIT 1;


/* ---------------------------------------------------------
   Q8. Staff members who have performed at least one
       operation as a surgeon OR an anaesthetist.
   --------------------------------------------------------- */
SELECT  DISTINCT s.staff_id,
        s.first_name || ' ' || s.last_name AS staff_name,
        s.role
FROM    STAFF s
WHERE   s.staff_id IN (SELECT surgeon_id      FROM OPERATION)
   OR   s.staff_id IN (SELECT anaesthetist_id FROM OPERATION
                       WHERE  anaesthetist_id IS NOT NULL)
ORDER BY s.staff_id;


/* ---------------------------------------------------------
   Q9. Admissions where the patient EXPECTED to receive an
       operation but did NOT actually receive one.
   --------------------------------------------------------- */
SELECT  pe.encounter_id,
        p.first_name || ' ' || p.last_name AS patient,
        ot.name AS expected_op_type,
        a.admit_date
FROM    PATIENT_ENCOUNTER  pe
JOIN    ADMISSION          a  ON a.encounter_id  = pe.encounter_id
JOIN    PERSON             p  ON p.person_id     = pe.person_id
JOIN    OP_TYPE            ot ON ot.op_type_id   = pe.expected_op_type_id
WHERE   pe.expected_op_type_id IS NOT NULL
AND     NOT EXISTS (
            SELECT 1
            FROM   OPERATION o
            WHERE  o.encounter_id = pe.encounter_id
        );


/* ---------------------------------------------------------
   Q10. Patients who have undergone MULTIPLE operations,
        listing the types of operations received.
   --------------------------------------------------------- */
SELECT  p.person_id,
        p.first_name || ' ' || p.last_name AS patient,
        COUNT(o.operation_id)              AS total_ops,
        GROUP_CONCAT(ot.name, ', ')        AS op_types
FROM    PERSON             p
JOIN    PATIENT_ENCOUNTER  pe ON pe.person_id   = p.person_id
JOIN    OPERATION          o  ON o.encounter_id = pe.encounter_id
JOIN    OP_TYPE            ot ON ot.op_type_id  = o.op_type_id
GROUP BY p.person_id, p.first_name, p.last_name
HAVING  COUNT(o.operation_id) > 1
ORDER BY total_ops DESC;
