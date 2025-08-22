-- Create DB
IF DB_ID('MedicalDB') IS NULL CREATE DATABASE MedicalDB;
GO
USE MedicalDB;
GO

-- Drop if re-running
IF OBJECT_ID('dbo.Appointments') IS NOT NULL DROP TABLE dbo.Appointments;
IF OBJECT_ID('dbo.Doctors')     IS NOT NULL DROP TABLE dbo.Doctors;
IF OBJECT_ID('dbo.Patients')    IS NOT NULL DROP TABLE dbo.Patients;
GO

-- Tables (exactly as in the brief)
CREATE TABLE dbo.Doctors(
  DoctorID     INT IDENTITY(1,1) PRIMARY KEY,
  FullName     VARCHAR(100) NOT NULL,
  Specialty    VARCHAR(100) NOT NULL,
  Availability BIT NOT NULL
);

CREATE TABLE dbo.Patients(
  PatientID INT IDENTITY(1,1) PRIMARY KEY,
  FullName  VARCHAR(100) NOT NULL,
  Email     VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE dbo.Appointments(
  AppointmentID   INT IDENTITY(1,1) PRIMARY KEY,
  DoctorID        INT NOT NULL,
  PatientID       INT NOT NULL,
  AppointmentDate DATETIME NOT NULL,
  Notes           VARCHAR(500) NULL,
  CONSTRAINT FK_App_Doctors  FOREIGN KEY(DoctorID)  REFERENCES dbo.Doctors(DoctorID),
  CONSTRAINT FK_App_Patients FOREIGN KEY(PatientID) REFERENCES dbo.Patients(PatientID)
);

-- Sample data (Doctors, Patients)
INSERT INTO dbo.Doctors(FullName, Specialty, Availability) VALUES
('Dr. Ama Mensah','Cardiology',1),
('Dr. Kwesi Boateng','Dermatology',1),
('Dr. Linda Owusu','Pediatrics',0),
('Dr. Yaw Asare','Orthopedics',1);

INSERT INTO dbo.Patients(FullName, Email) VALUES
('Akosua Agyeman','akosua@example.com'),
('John Doe','john.doe@example.com'),
('Efua Sackey','efua@example.com');

SELECT * FROM Doctors;
SELECT * FROM Patients;
