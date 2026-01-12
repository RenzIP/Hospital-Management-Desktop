-- =============================================
-- Hospital Management System Database
-- Created: 2026-01-12
-- =============================================
-- Create Database
CREATE DATABASE IF NOT EXISTS hospital_management;
USE hospital_management;
-- =============================================
-- Table: users (untuk login)
-- =============================================
CREATE TABLE IF NOT EXISTS users (
    id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(150) UNIQUE,
    role ENUM('admin', 'doctor', 'nurse', 'staff') DEFAULT 'staff',
    department VARCHAR(100),
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
-- =============================================
-- Table: staff (dokter dan staff medis)
-- =============================================
CREATE TABLE IF NOT EXISTS staff (
    id INT PRIMARY KEY AUTO_INCREMENT,
    staff_id VARCHAR(20) NOT NULL UNIQUE,
    name VARCHAR(150) NOT NULL,
    cnic VARCHAR(20) NOT NULL,
    phone_no VARCHAR(20),
    date_of_birth DATE,
    email VARCHAR(150) UNIQUE,
    password VARCHAR(255),
    qualification VARCHAR(50),
    department VARCHAR(100),
    gender ENUM('Male', 'Female') DEFAULT 'Male',
    working_from VARCHAR(20),
    working_to VARCHAR(20),
    salary DECIMAL(12, 2) DEFAULT 0,
    address TEXT,
    photo VARCHAR(255),
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
-- =============================================
-- Table: patients (pasien)
-- =============================================
CREATE TABLE IF NOT EXISTS patients (
    id INT PRIMARY KEY AUTO_INCREMENT,
    patient_id VARCHAR(20) NOT NULL UNIQUE,
    name VARCHAR(150) NOT NULL,
    cnic VARCHAR(20),
    phone_no VARCHAR(20),
    date_of_birth DATE,
    email VARCHAR(150),
    gender ENUM('Male', 'Female') DEFAULT 'Male',
    blood_group ENUM('A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'),
    address TEXT,
    emergency_contact VARCHAR(20),
    emergency_contact_name VARCHAR(150),
    medical_history TEXT,
    allergies TEXT,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
-- =============================================
-- Table: appointments (janji temu)
-- =============================================
CREATE TABLE IF NOT EXISTS appointments (
    id INT PRIMARY KEY AUTO_INCREMENT,
    appointment_id VARCHAR(20) NOT NULL UNIQUE,
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    appointment_date DATE NOT NULL,
    appointment_time TIME NOT NULL,
    status ENUM('scheduled', 'completed', 'cancelled', 'no_show') DEFAULT 'scheduled',
    reason TEXT,
    notes TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (patient_id) REFERENCES patients(id) ON DELETE CASCADE,
    FOREIGN KEY (doctor_id) REFERENCES staff(id) ON DELETE CASCADE
);
-- =============================================
-- Table: laboratory (hasil lab)
-- =============================================
CREATE TABLE IF NOT EXISTS laboratory (
    id INT PRIMARY KEY AUTO_INCREMENT,
    lab_id VARCHAR(20) NOT NULL UNIQUE,
    patient_id INT NOT NULL,
    doctor_id INT NOT NULL,
    test_name VARCHAR(150) NOT NULL,
    test_date DATE NOT NULL,
    result TEXT,
    status ENUM('pending', 'in_progress', 'completed') DEFAULT 'pending',
    notes TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (patient_id) REFERENCES patients(id) ON DELETE CASCADE,
    FOREIGN KEY (doctor_id) REFERENCES staff(id) ON DELETE CASCADE
);
-- =============================================
-- Table: capital (keuangan/modal)
-- =============================================
CREATE TABLE IF NOT EXISTS capital (
    id INT PRIMARY KEY AUTO_INCREMENT,
    transaction_id VARCHAR(20) NOT NULL UNIQUE,
    transaction_type ENUM('income', 'expense') NOT NULL,
    category VARCHAR(100) NOT NULL,
    amount DECIMAL(15, 2) NOT NULL,
    description TEXT,
    transaction_date DATE NOT NULL,
    created_by INT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (created_by) REFERENCES users(id) ON DELETE
    SET NULL
);
-- =============================================
-- Table: units (unit rumah sakit)
-- =============================================
CREATE TABLE IF NOT EXISTS units (
    id INT PRIMARY KEY AUTO_INCREMENT,
    unit_id VARCHAR(20) NOT NULL UNIQUE,
    unit_name VARCHAR(150) NOT NULL,
    unit_type ENUM(
        'ward',
        'icu',
        'ot',
        'emergency',
        'outpatient',
        'laboratory',
        'pharmacy'
    ) NOT NULL,
    capacity INT DEFAULT 0,
    current_occupancy INT DEFAULT 0,
    floor_number INT,
    building VARCHAR(50),
    head_doctor_id INT,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (head_doctor_id) REFERENCES staff(id) ON DELETE
    SET NULL
);
-- =============================================
-- INSERT SAMPLE DATA
-- =============================================
-- Insert Users (untuk login)
INSERT INTO users (username, password, email, role, department)
VALUES (
        'admin',
        'admin123',
        'admin@hospital.org',
        'admin',
        'Administration'
    ),
    (
        'dr.john',
        'password123',
        'john.smith@hospital.org',
        'doctor',
        'Cardiology'
    ),
    (
        'dr.sarah',
        'password123',
        'sarah.johnson@hospital.org',
        'doctor',
        'Neurology'
    ),
    (
        'nurse.mary',
        'password123',
        'mary.wilson@hospital.org',
        'nurse',
        'ICU'
    ),
    (
        'staff.jane',
        'password123',
        'jane.doe@hospital.org',
        'staff',
        'Reception'
    );
-- Insert Staff (Dokter)
INSERT INTO staff (
        staff_id,
        name,
        cnic,
        phone_no,
        date_of_birth,
        email,
        password,
        qualification,
        department,
        gender,
        working_from,
        working_to,
        salary,
        address
    )
VALUES (
        'MED-1',
        'Dr. John Smith',
        '23123-1312312-3',
        '2321-3123123',
        '1980-05-15',
        'john.smith@hospital.org',
        'password123',
        'MBBS',
        'Cardiology',
        'Male',
        '8:00:00 AM',
        '4:00:00 PM',
        150000.00,
        'house 1, street 2, city 3 and country 4'
    ),
    (
        'MED-2',
        'Dr. Sarah Johnson',
        '45678-9012345-6',
        '2321-4567890',
        '1985-08-22',
        'sarah.johnson@hospital.org',
        'password123',
        'MD',
        'Neurology',
        'Female',
        '9:00:00 AM',
        '5:00:00 PM',
        180000.00,
        '123 Medical Lane, Healthcare City'
    ),
    (
        'MED-3',
        'Dr. Michael Brown',
        '78901-2345678-9',
        '2321-7890123',
        '1978-03-10',
        'michael.brown@hospital.org',
        'password123',
        'MS',
        'Orthopedics',
        'Male',
        '7:00:00 AM',
        '3:00:00 PM',
        200000.00,
        '456 Doctor Street, Medical District'
    ),
    (
        'MED-4',
        'Dr. Emily Davis',
        '11223-3445566-7',
        '2321-1122334',
        '1990-11-30',
        'emily.davis@hospital.org',
        'password123',
        'MBBS',
        'Pediatrics',
        'Female',
        '8:00:00 AM',
        '4:00:00 PM',
        140000.00,
        '789 Health Avenue, Wellness Town'
    ),
    (
        'MED-5',
        'Dr. Robert Wilson',
        '99887-7665544-3',
        '2321-9988776',
        '1975-07-18',
        'robert.wilson@hospital.org',
        'password123',
        'DM',
        'ICU',
        'Male',
        '6:00:00 AM',
        '2:00:00 PM',
        220000.00,
        '321 Emergency Road, Critical Care City'
    ),
    (
        'MED-6',
        'Dr. Jennifer Martinez',
        '55443-3221100-9',
        '2321-5544332',
        '1988-01-25',
        'jennifer.martinez@hospital.org',
        'password123',
        'MD',
        'Dermatology',
        'Female',
        '10:00:00 AM',
        '6:00:00 PM',
        160000.00,
        '654 Skin Care Lane, Beauty District'
    ),
    (
        'MED-7',
        'Dr. David Lee',
        '66778-8990011-2',
        '2321-6677889',
        '1982-09-12',
        'david.lee@hospital.org',
        'password123',
        'MCh',
        'Surgery',
        'Male',
        '7:00:00 AM',
        '5:00:00 PM',
        250000.00,
        '987 Surgical Boulevard, Operation City'
    ),
    (
        'MED-8',
        'Dr. Lisa Anderson',
        '22334-4556677-8',
        '2321-2233445',
        '1992-04-08',
        'lisa.anderson@hospital.org',
        'password123',
        'DNB',
        'Radiology',
        'Female',
        '8:00:00 AM',
        '4:00:00 PM',
        170000.00,
        '147 X-Ray Street, Imaging Town'
    );
-- Insert Patients
INSERT INTO patients (
        patient_id,
        name,
        cnic,
        phone_no,
        date_of_birth,
        email,
        gender,
        blood_group,
        address,
        emergency_contact,
        emergency_contact_name,
        medical_history,
        allergies
    )
VALUES (
        'PAT-001',
        'Ahmad Yusuf',
        '12345-6789012-3',
        '0321-1234567',
        '1995-03-20',
        'ahmad.yusuf@email.com',
        'Male',
        'A+',
        'Jl. Sudirman No. 123, Jakarta',
        '0812-3456789',
        'Fatimah Yusuf',
        'Diabetes Type 2',
        'Penicillin'
    ),
    (
        'PAT-002',
        'Siti Rahayu',
        '23456-7890123-4',
        '0322-2345678',
        '1988-07-15',
        'siti.rahayu@email.com',
        'Female',
        'B+',
        'Jl. Thamrin No. 456, Jakarta',
        '0813-4567890',
        'Budi Rahayu',
        'Hypertension',
        'None'
    ),
    (
        'PAT-003',
        'Budi Santoso',
        '34567-8901234-5',
        '0323-3456789',
        '1970-11-08',
        'budi.santoso@email.com',
        'Male',
        'O+',
        'Jl. Gatot Subroto No. 789, Bandung',
        '0814-5678901',
        'Dewi Santoso',
        'Heart Disease, Cholesterol',
        'Aspirin'
    ),
    (
        'PAT-004',
        'Dewi Lestari',
        '45678-9012345-6',
        '0324-4567890',
        '2000-02-28',
        'dewi.lestari@email.com',
        'Female',
        'AB+',
        'Jl. Asia Afrika No. 321, Surabaya',
        '0815-6789012',
        'Andi Lestari',
        'Asthma',
        'Dust, Pollen'
    ),
    (
        'PAT-005',
        'Eko Prasetyo',
        '56789-0123456-7',
        '0325-5678901',
        '1985-09-14',
        'eko.prasetyo@email.com',
        'Male',
        'A-',
        'Jl. Diponegoro No. 654, Yogyakarta',
        '0816-7890123',
        'Nina Prasetyo',
        'None',
        'Sulfa drugs'
    );
-- Insert Appointments
INSERT INTO appointments (
        appointment_id,
        patient_id,
        doctor_id,
        appointment_date,
        appointment_time,
        status,
        reason,
        notes
    )
VALUES (
        'APT-001',
        1,
        1,
        '2026-01-15',
        '09:00:00',
        'scheduled',
        'Regular checkup for diabetes',
        'Patient needs fasting blood sugar test'
    ),
    (
        'APT-002',
        2,
        2,
        '2026-01-15',
        '10:30:00',
        'scheduled',
        'Headache and dizziness',
        'MRI scan recommended'
    ),
    (
        'APT-003',
        3,
        1,
        '2026-01-16',
        '08:00:00',
        'scheduled',
        'Heart follow-up',
        'ECG required'
    ),
    (
        'APT-004',
        4,
        4,
        '2026-01-16',
        '11:00:00',
        'scheduled',
        'Asthma control visit',
        'Bring inhaler usage log'
    ),
    (
        'APT-005',
        5,
        3,
        '2026-01-17',
        '14:00:00',
        'scheduled',
        'Back pain consultation',
        'X-ray of lumbar spine needed'
    );
-- Insert Laboratory Tests
INSERT INTO laboratory (
        lab_id,
        patient_id,
        doctor_id,
        test_name,
        test_date,
        result,
        status,
        notes
    )
VALUES (
        'LAB-001',
        1,
        1,
        'Fasting Blood Sugar',
        '2026-01-10',
        'FBS: 142 mg/dL (High)',
        'completed',
        'Recommend dietary changes'
    ),
    (
        'LAB-002',
        1,
        1,
        'HbA1c Test',
        '2026-01-10',
        'HbA1c: 7.2% (Above Target)',
        'completed',
        'Consider medication adjustment'
    ),
    (
        'LAB-003',
        2,
        2,
        'MRI Brain',
        '2026-01-11',
        NULL,
        'pending',
        'Scheduled for tomorrow'
    ),
    (
        'LAB-004',
        3,
        1,
        'Lipid Profile',
        '2026-01-09',
        'Total Cholesterol: 245 mg/dL, LDL: 160 mg/dL',
        'completed',
        'High cholesterol, recommend statins'
    ),
    (
        'LAB-005',
        3,
        1,
        'ECG',
        '2026-01-09',
        'Normal sinus rhythm',
        'completed',
        'No significant abnormalities'
    );
-- Insert Capital/Financial Records
INSERT INTO capital (
        transaction_id,
        transaction_type,
        category,
        amount,
        description,
        transaction_date
    )
VALUES (
        'TRX-001',
        'income',
        'Consultation Fees',
        5000000.00,
        'Monthly consultation income',
        '2026-01-01'
    ),
    (
        'TRX-002',
        'income',
        'Laboratory Services',
        3500000.00,
        'Laboratory test fees',
        '2026-01-05'
    ),
    (
        'TRX-003',
        'expense',
        'Medical Supplies',
        2000000.00,
        'Purchase of medical equipment and supplies',
        '2026-01-03'
    ),
    (
        'TRX-004',
        'expense',
        'Staff Salaries',
        15000000.00,
        'Monthly staff salary payment',
        '2026-01-01'
    ),
    (
        'TRX-005',
        'income',
        'Pharmacy Sales',
        4200000.00,
        'Pharmacy medicine sales',
        '2026-01-08'
    ),
    (
        'TRX-006',
        'expense',
        'Utilities',
        1500000.00,
        'Electricity and water bills',
        '2026-01-10'
    );
-- Insert Units
INSERT INTO units (
        unit_id,
        unit_name,
        unit_type,
        capacity,
        current_occupancy,
        floor_number,
        building,
        head_doctor_id
    )
VALUES (
        'UNIT-001',
        'General Ward A',
        'ward',
        50,
        35,
        1,
        'Main Building',
        1
    ),
    (
        'UNIT-002',
        'General Ward B',
        'ward',
        50,
        42,
        2,
        'Main Building',
        4
    ),
    (
        'UNIT-003',
        'Intensive Care Unit',
        'icu',
        20,
        15,
        3,
        'Main Building',
        5
    ),
    (
        'UNIT-004',
        'Operation Theater 1',
        'ot',
        5,
        2,
        4,
        'Surgical Wing',
        7
    ),
    (
        'UNIT-005',
        'Emergency Department',
        'emergency',
        30,
        18,
        1,
        'Emergency Building',
        5
    ),
    (
        'UNIT-006',
        'Outpatient Clinic',
        'outpatient',
        100,
        45,
        1,
        'Outpatient Building',
        2
    ),
    (
        'UNIT-007',
        'Laboratory',
        'laboratory',
        10,
        5,
        2,
        'Diagnostic Building',
        8
    ),
    (
        'UNIT-008',
        'Pharmacy',
        'pharmacy',
        5,
        3,
        1,
        'Main Building',
        NULL
    );
-- =============================================
-- CREATE INDEXES FOR BETTER PERFORMANCE
-- =============================================
CREATE INDEX idx_staff_department ON staff(department);
CREATE INDEX idx_staff_name ON staff(name);
CREATE INDEX idx_patients_name ON patients(name);
CREATE INDEX idx_appointments_date ON appointments(appointment_date);
CREATE INDEX idx_laboratory_date ON laboratory(test_date);
CREATE INDEX idx_capital_date ON capital(transaction_date);
-- =============================================
-- VIEWS FOR REPORTING
-- =============================================
-- View: Active Doctors
CREATE OR REPLACE VIEW view_active_doctors AS
SELECT staff_id,
    name,
    qualification,
    department,
    phone_no,
    email,
    CONCAT(working_from, ' - ', working_to) AS working_hours
FROM staff
WHERE is_active = TRUE;
-- View: Today's Appointments
CREATE OR REPLACE VIEW view_today_appointments AS
SELECT a.appointment_id,
    p.name AS patient_name,
    s.name AS doctor_name,
    a.appointment_time,
    a.status,
    a.reason
FROM appointments a
    JOIN patients p ON a.patient_id = p.id
    JOIN staff s ON a.doctor_id = s.id
WHERE a.appointment_date = CURDATE();
-- View: Pending Lab Tests
CREATE OR REPLACE VIEW view_pending_labs AS
SELECT l.lab_id,
    p.name AS patient_name,
    s.name AS doctor_name,
    l.test_name,
    l.test_date,
    l.status
FROM laboratory l
    JOIN patients p ON l.patient_id = p.id
    JOIN staff s ON l.doctor_id = s.id
WHERE l.status IN ('pending', 'in_progress');
-- =============================================
-- VERIFICATION QUERIES
-- =============================================
-- Uncomment below to verify data insertion
-- SELECT * FROM users;
-- SELECT * FROM staff;
-- SELECT * FROM patients;
-- SELECT * FROM appointments;
-- SELECT * FROM laboratory;
-- SELECT * FROM capital;
-- SELECT * FROM units;
SELECT 'Database hospital_management created successfully!' AS Status;
SELECT CONCAT('Total Users: ', COUNT(*)) AS Info
FROM users
UNION ALL
SELECT CONCAT('Total Staff: ', COUNT(*))
FROM staff
UNION ALL
SELECT CONCAT('Total Patients: ', COUNT(*))
FROM patients
UNION ALL
SELECT CONCAT('Total Appointments: ', COUNT(*))
FROM appointments
UNION ALL
SELECT CONCAT('Total Lab Tests: ', COUNT(*))
FROM laboratory
UNION ALL
SELECT CONCAT('Total Transactions: ', COUNT(*))
FROM capital
UNION ALL
SELECT CONCAT('Total Units: ', COUNT(*))
FROM units;