/* =========================================================
   Sun Medical Hospital (SMH) - Extended Database
   Part 2 - Section A : Schema Implementation + Sample Data
   Designed for Google Colab (SQLite via %sql / sqlite3)
   ========================================================= */

PRAGMA foreign_keys = ON;

/* ---------- Drop in reverse-dependency order ---------- */
DROP TABLE IF EXISTS OBSERVATION;
DROP TABLE IF EXISTS STAFF_OP_TYPE;
DROP TABLE IF EXISTS OPERATION;
DROP TABLE IF EXISTS PRESCRIPTION;
DROP TABLE IF EXISTS APPOINTMENT;
DROP TABLE IF EXISTS ADMISSION;
DROP TABLE IF EXISTS PATIENT_ENCOUNTER;
DROP TABLE IF EXISTS OP_TYPE;
DROP TABLE IF EXISTS SERVICE_TYPE;
DROP TABLE IF EXISTS WARD;
DROP TABLE IF EXISTS STAFF;
DROP TABLE IF EXISTS PERSON;

/* =========================================================
   1. PERSON  (patient)
   ========================================================= */
CREATE TABLE PERSON (
    person_id      INTEGER     PRIMARY KEY,
    first_name     VARCHAR(40) NOT NULL,
    last_name      VARCHAR(40) NOT NULL,
    dob            DATE        NOT NULL,
    gender         CHAR(1)     CHECK (gender IN ('M','F','O')),
    phone          VARCHAR(20),
    address        VARCHAR(120),
    blood_group    VARCHAR(3),
    insurance_no   VARCHAR(25)
);

/* =========================================================
   2. STAFF
   ========================================================= */
CREATE TABLE STAFF (
    staff_id       INTEGER      PRIMARY KEY,
    first_name     VARCHAR(40)  NOT NULL,
    last_name      VARCHAR(40)  NOT NULL,
    role           VARCHAR(25)  NOT NULL
                   CHECK (role IN ('GP','Surgeon','Anaesthetist','Nurse',
                                   'Dentist','Optometrist','Specialist')),
    department     VARCHAR(40),
    phone          VARCHAR(20),
    email          VARCHAR(60),
    hire_date      DATE
);

/* =========================================================
   3. WARD
   ========================================================= */
CREATE TABLE WARD (
    ward_id        INTEGER      PRIMARY KEY,
    ward_name      VARCHAR(40)  NOT NULL,
    ward_type      VARCHAR(30),
    capacity       INTEGER      CHECK (capacity > 0)
);

/* =========================================================
   4. SERVICE_TYPE  (NEW - supports the extension)
   Emergency / GP / Dental / Optic / Surgery
   ========================================================= */
CREATE TABLE SERVICE_TYPE (
    service_type_id  INTEGER     PRIMARY KEY,
    name             VARCHAR(30) NOT NULL UNIQUE,
    description      VARCHAR(150)
);

/* =========================================================
   5. OP_TYPE
   ========================================================= */
CREATE TABLE OP_TYPE (
    op_type_id       INTEGER     PRIMARY KEY,
    service_type_id  INTEGER     NOT NULL,
    name             VARCHAR(60) NOT NULL,
    description      VARCHAR(200),
    typical_duration INTEGER,                                -- minutes
    FOREIGN KEY (service_type_id) REFERENCES SERVICE_TYPE(service_type_id)
);

/* =========================================================
   6. PATIENT_ENCOUNTER  (super-class, disjoint specialisation)
   ========================================================= */
CREATE TABLE PATIENT_ENCOUNTER (
    encounter_id        INTEGER      PRIMARY KEY,
    person_id           INTEGER      NOT NULL,
    staff_id            INTEGER      NOT NULL,            -- "encountered by"
    service_type_id     INTEGER      NOT NULL,
    encounter_type      VARCHAR(15)  NOT NULL
                        CHECK (encounter_type IN ('Admission','Appointment')),
    encounter_date      DATETIME     NOT NULL,
    expected_op_type_id INTEGER,                          -- "expects to receive"
    FOREIGN KEY (person_id)           REFERENCES PERSON(person_id),
    FOREIGN KEY (staff_id)            REFERENCES STAFF(staff_id),
    FOREIGN KEY (service_type_id)     REFERENCES SERVICE_TYPE(service_type_id),
    FOREIGN KEY (expected_op_type_id) REFERENCES OP_TYPE(op_type_id)
);

/* =========================================================
   7. ADMISSION  (subtype of PATIENT_ENCOUNTER)
   ========================================================= */
CREATE TABLE ADMISSION (
    encounter_id    INTEGER      PRIMARY KEY,
    ward_id         INTEGER      NOT NULL,
    admit_date      DATE         NOT NULL,
    discharge_date  DATE,
    FOREIGN KEY (encounter_id) REFERENCES PATIENT_ENCOUNTER(encounter_id),
    FOREIGN KEY (ward_id)      REFERENCES WARD(ward_id),
    CHECK (discharge_date IS NULL OR discharge_date >= admit_date)
);

/* =========================================================
   8. APPOINTMENT  (subtype of PATIENT_ENCOUNTER)
   ========================================================= */
CREATE TABLE APPOINTMENT (
    encounter_id      INTEGER      PRIMARY KEY,
    with_staff_id     INTEGER      NOT NULL,             -- "with"
    appointment_time  DATETIME     NOT NULL,
    status            VARCHAR(15)
                      CHECK (status IN ('Scheduled','Completed','Cancelled','NoShow')),
    FOREIGN KEY (encounter_id)  REFERENCES PATIENT_ENCOUNTER(encounter_id),
    FOREIGN KEY (with_staff_id) REFERENCES STAFF(staff_id)
);

/* =========================================================
   9. PRESCRIPTION  (from APPOINTMENT)
   ========================================================= */
CREATE TABLE PRESCRIPTION (
    prescription_id  INTEGER      PRIMARY KEY,
    encounter_id     INTEGER      NOT NULL,
    medication       VARCHAR(80)  NOT NULL,
    dosage           VARCHAR(40),
    instructions     VARCHAR(200),
    issued_date      DATE         NOT NULL,
    FOREIGN KEY (encounter_id) REFERENCES APPOINTMENT(encounter_id)
);

/* =========================================================
   10. OPERATION  ("actually receives")
   ========================================================= */
CREATE TABLE OPERATION (
    operation_id     INTEGER      PRIMARY KEY,
    encounter_id     INTEGER      NOT NULL,
    op_type_id       INTEGER      NOT NULL,
    surgeon_id       INTEGER      NOT NULL,
    anaesthetist_id  INTEGER,
    operation_date   DATETIME     NOT NULL,
    room             VARCHAR(20),
    FOREIGN KEY (encounter_id)    REFERENCES PATIENT_ENCOUNTER(encounter_id),
    FOREIGN KEY (op_type_id)      REFERENCES OP_TYPE(op_type_id),
    FOREIGN KEY (surgeon_id)      REFERENCES STAFF(staff_id),
    FOREIGN KEY (anaesthetist_id) REFERENCES STAFF(staff_id)
);

/* =========================================================
   11. STAFF_OP_TYPE  (M:N - staff "performs" op type)
   ========================================================= */
CREATE TABLE STAFF_OP_TYPE (
    staff_id            INTEGER  NOT NULL,
    op_type_id          INTEGER  NOT NULL,
    certification_date  DATE,
    PRIMARY KEY (staff_id, op_type_id),
    FOREIGN KEY (staff_id)   REFERENCES STAFF(staff_id),
    FOREIGN KEY (op_type_id) REFERENCES OP_TYPE(op_type_id)
);

/* =========================================================
   12. OBSERVATION  ("is for")
   ========================================================= */
CREATE TABLE OBSERVATION (
    observation_id      INTEGER      PRIMARY KEY,
    encounter_id        INTEGER      NOT NULL,
    op_type_id          INTEGER,
    observation_date    DATETIME     NOT NULL,
    notes               VARCHAR(300),
    recorded_by_staff   INTEGER,
    FOREIGN KEY (encounter_id)      REFERENCES PATIENT_ENCOUNTER(encounter_id),
    FOREIGN KEY (op_type_id)        REFERENCES OP_TYPE(op_type_id),
    FOREIGN KEY (recorded_by_staff) REFERENCES STAFF(staff_id)
);


/* =========================================================
                       SAMPLE DATA
   (At least 5 rows per table)
   ========================================================= */

/* ---- PERSON ---- */
INSERT INTO PERSON VALUES
(1,'John',   'Smith',   '1980-04-12','M','555-1010','12 Oak St',   'O+', 'INS-1001'),
(2,'Mary',   'Johnson', '1992-07-23','F','555-1011','45 Pine Ave', 'A+', 'INS-1002'),
(3,'David',  'Brown',   '1975-11-02','M','555-1012','7 Maple Rd',  'B-', 'INS-1003'),
(4,'Linda',  'Davis',   '1988-02-15','F','555-1013','9 Elm St',    'AB+','INS-1004'),
(5,'Michael','Wilson',  '2001-09-30','M','555-1014','22 Birch Ln', 'O-', 'INS-1005'),
(6,'Sara',   'Taylor',  '1965-12-05','F','555-1015','31 Cedar Ct', 'A-', 'INS-1006');

/* ---- STAFF ---- */
INSERT INTO STAFF VALUES
(10,'Alice','Walker', 'Surgeon',     'Surgery','555-2001','alice@smh.com', '2015-03-01'),
(11,'Bob',  'Adams',  'Anaesthetist','Surgery','555-2002','bob@smh.com',   '2017-06-15'),
(12,'Carol','Evans',  'GP',          'GP',     '555-2003','carol@smh.com', '2018-01-10'),
(13,'Dan',  'Foster', 'Dentist',     'Dental', '555-2004','dan@smh.com',   '2020-09-01'),
(14,'Ella', 'Green',  'Optometrist', 'Optic',  '555-2005','ella@smh.com',  '2021-04-12'),
(15,'Frank','Hill',   'Surgeon',     'Dental', '555-2006','frank@smh.com', '2019-08-20'),
(16,'Gina', 'Iyer',   'Nurse',       'Surgery','555-2007','gina@smh.com',  '2022-02-05');

/* ---- WARD ---- */
INSERT INTO WARD VALUES
(100,'Emergency Ward','Emergency',20),
(101,'General Ward A','General',  30),
(102,'Surgical Ward', 'Surgical', 15),
(103,'Dental Ward',   'Dental',   10),
(104,'Optic Ward',    'Optic',     8);

/* ---- SERVICE_TYPE ---- */
INSERT INTO SERVICE_TYPE VALUES
(1,'Emergency','Emergency healthcare services'),
(2,'GP',       'General Practice consultations'),
(3,'Dental',   'Dental care services (NEW)'),
(4,'Optic',    'Optic / vision care services (NEW)'),
(5,'Surgery',  'Inpatient surgical services');

/* ---- OP_TYPE ---- */
INSERT INTO OP_TYPE VALUES
(200,5,'Appendectomy',     'Removal of appendix',                   60),
(201,5,'Cataract Surgery', 'Lens replacement (Surgery / Optic)',    45),
(202,3,'Tooth Extraction', 'Dental tooth removal (NEW)',            30),
(203,3,'Root Canal',       'Endodontic root canal (NEW)',           90),
(204,4,'Lasik Eye Surgery','Laser vision correction (NEW)',         40),
(205,1,'Wound Suturing',   'Emergency suturing',                    20),
(206,2,'General Check-Up', 'GP routine examination',                15);

/* ---- PATIENT_ENCOUNTER ---- */
INSERT INTO PATIENT_ENCOUNTER VALUES
(1000,1,12,2,'Appointment','2026-01-05 09:00',206),
(1001,2,10,5,'Admission',  '2026-01-10 11:30',200),
(1002,3,13,3,'Appointment','2026-02-14 14:00',202),
(1003,4,14,4,'Appointment','2026-02-20 10:15',204),
(1004,5,10,5,'Admission',  '2026-03-01 08:45',201),
(1005,6,15,3,'Admission',  '2026-03-08 13:20',203),
(1006,2,12,1,'Appointment','2026-03-15 16:00',NULL),
(1007,3,10,5,'Admission',  '2026-04-02 07:30',205),     -- expected op but never received
(1008,4,16,1,'Admission',  '2026-04-10 06:00',NULL),
(1009,5,12,2,'Appointment','2026-04-20 11:00',NULL);

/* ---- ADMISSION ---- */
INSERT INTO ADMISSION VALUES
(1001,102,'2026-01-10','2026-01-15'),
(1004,104,'2026-03-01','2026-03-04'),
(1005,103,'2026-03-08','2026-03-12'),
(1007,100,'2026-04-02','2026-04-03'),
(1008,101,'2026-04-10','2026-04-12');

/* ---- APPOINTMENT ---- */
INSERT INTO APPOINTMENT VALUES
(1000,12,'2026-01-05 09:00','Completed'),
(1002,13,'2026-02-14 14:00','Completed'),
(1003,14,'2026-02-20 10:15','Completed'),
(1006,12,'2026-03-15 16:00','Completed'),
(1009,12,'2026-04-20 11:00','Scheduled');

/* ---- PRESCRIPTION ---- */
INSERT INTO PRESCRIPTION VALUES
(300,1000,'Paracetamol 500mg','1 tab',  'Twice a day for 3 days',   '2026-01-05'),
(301,1002,'Amoxicillin 500mg','1 cap',  'Three times daily 5 days', '2026-02-14'),
(302,1003,'Eye drops',        '2 drops','Each eye twice daily',     '2026-02-20'),
(303,1006,'Vitamin C',        '1 tab',  'Daily for 30 days',        '2026-03-15'),
(304,1009,'Ibuprofen 200mg',  '1 tab',  'As needed',                '2026-04-20');

/* ---- OPERATION ---- */
INSERT INTO OPERATION VALUES
(400,1001,200,10,11,'2026-01-11 09:00','OR-1'),
(401,1004,201,10,11,'2026-03-02 10:00','OR-2'),
(402,1005,203,15,11,'2026-03-09 14:00','OR-3'),
(403,1001,205,10,11,'2026-01-12 11:00','OR-1'),     -- 2nd op, same admission
(404,1008,200,10,11,'2026-04-11 08:00','OR-1');

/* ---- STAFF_OP_TYPE ---- */
INSERT INTO STAFF_OP_TYPE VALUES
(10,200,'2015-05-01'),
(10,201,'2016-02-01'),
(10,205,'2015-04-01'),
(15,202,'2020-10-01'),
(15,203,'2021-01-15'),
(11,200,'2017-09-01'),
(14,204,'2021-06-01');

/* ---- OBSERVATION ---- */
INSERT INTO OBSERVATION VALUES
(500,1001,200,'2026-01-11 12:00','Recovery normal, vitals stable',16),
(501,1004,201,'2026-03-02 12:30','Vision check post-op satisfactory',14),
(502,1005,203,'2026-03-09 16:00','Mild swelling, prescribed pain relief',13),
(503,1001,205,'2026-01-12 13:00','Wound healing well',16),
(504,1008,200,'2026-04-11 11:00','Stable, monitoring continues',16);
