## QUESTION 1

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





## QUESTION 2

-- 1) Create DB
IF DB_ID('PharmacyDB') IS NULL CREATE DATABASE PharmacyDB;
GO
USE PharmacyDB;
GO

-- 2) Drop (if re-running)
IF OBJECT_ID('dbo.Sales') IS NOT NULL DROP TABLE dbo.Sales;
IF OBJECT_ID('dbo.Medicines') IS NOT NULL DROP TABLE dbo.Medicines;
GO

-- 3) Tables
CREATE TABLE dbo.Medicines(
    MedicineID INT IDENTITY(1,1) PRIMARY KEY,
    Name       VARCHAR(100)  NOT NULL,
    Category   VARCHAR(50)   NOT NULL,
    Price      DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    Quantity   INT           NOT NULL CHECK (Quantity >= 0)
);

CREATE TABLE dbo.Sales(
    SaleID       INT IDENTITY(1,1) PRIMARY KEY,
    MedicineID   INT NOT NULL,
    QuantitySold INT NOT NULL CHECK (QuantitySold > 0),
    SaleDate     DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Sales_Meds FOREIGN KEY(MedicineID) REFERENCES dbo.Medicines(MedicineID)
);
GO

-- 4) Stored Procedures (exact names from brief)

-- AddMedicine with OUTPUT (shows ParameterDirection)
IF OBJECT_ID('dbo.AddMedicine') IS NOT NULL DROP PROCEDURE dbo.AddMedicine;
GO
CREATE PROCEDURE dbo.AddMedicine
    @Name     VARCHAR(100),
    @Category VARCHAR(50),
    @Price    DECIMAL(10,2),
    @Quantity INT,
    @NewId    INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Medicines(Name, Category, Price, Quantity)
    VALUES(@Name, @Category, @Price, @Quantity);

    SET @NewId = SCOPE_IDENTITY();
END
GO

-- SearchMedicine (by name OR category)
IF OBJECT_ID('dbo.SearchMedicine') IS NOT NULL DROP PROCEDURE dbo.SearchMedicine;
GO
CREATE PROCEDURE dbo.SearchMedicine
    @SearchTerm VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MedicineID, Name, Category, Price, Quantity
    FROM dbo.Medicines
    WHERE Name LIKE '%'+@SearchTerm+'%'
       OR Category LIKE '%'+@SearchTerm+'%';
END
GO

-- UpdateStock (set absolute quantity)
IF OBJECT_ID('dbo.UpdateStock') IS NOT NULL DROP PROCEDURE dbo.UpdateStock;
GO
CREATE PROCEDURE dbo.UpdateStock
    @MedicineID INT,
    @Quantity   INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Medicines
    SET Quantity = @Quantity
    WHERE MedicineID = @MedicineID;
END
GO

-- RecordSale (transaction; prevents negative stock)
IF OBJECT_ID('dbo.RecordSale') IS NOT NULL DROP PROCEDURE dbo.RecordSale;
GO
CREATE PROCEDURE dbo.RecordSale
    @MedicineID   INT,
    @QuantitySold INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRY
        BEGIN TRAN;

        DECLARE @Current INT;
        SELECT @Current = Quantity FROM dbo.Medicines WITH (UPDLOCK, ROWLOCK)
        WHERE MedicineID = @MedicineID;

        IF @Current IS NULL
            THROW 50001, 'Medicine not found.', 1;

        IF @Current < @QuantitySold
            THROW 50002, 'Insufficient stock for sale.', 1;

        INSERT INTO dbo.Sales(MedicineID, QuantitySold) VALUES(@MedicineID, @QuantitySold);

        UPDATE dbo.Medicines SET Quantity = Quantity - @QuantitySold WHERE MedicineID = @MedicineID;

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        DECLARE @Msg NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50099, @Msg, 1;
    END CATCH
END
GO

-- GetAllMedicines
IF OBJECT_ID('dbo.GetAllMedicines') IS NOT NULL DROP PROCEDURE dbo.GetAllMedicines;
GO
CREATE PROCEDURE dbo.GetAllMedicines
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MedicineID, Name, Category, Price, Quantity
    FROM dbo.Medicines
    ORDER BY Name;
END
GO

-- 5) (Optional) Seed a few rows to test UI quickly
INSERT INTO dbo.Medicines(Name, Category, Price, Quantity) VALUES
('Paracetamol 500mg','Analgesic',2.50,100),
('Amoxicillin 500mg','Antibiotic',12.00,60),
('Cetirizine 10mg','Antihistamine',4.00,80);


SELECT * FROM Medicines
