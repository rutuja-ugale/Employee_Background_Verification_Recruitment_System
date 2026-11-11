-- Database Schema for Employee Background Verification System

CREATE TABLE Candidates (
    CandidateId INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    Department VARCHAR(50) NOT NULL,
    AppliedRole VARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE VerificationRequests (
    VerificationId INT PRIMARY KEY IDENTITY(1,1),
    CandidateId INT NOT NULL,
    Status VARCHAR(20) NOT NULL DEFAULT 'Pending', -- Pending, InProgress, Approved, Rejected
    AssignedAgent VARCHAR(100),
    Comments VARCHAR(500),
    SubmittedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME,
    FOREIGN KEY (CandidateId) REFERENCES Candidates(CandidateId) ON DELETE CASCADE
);

CREATE TABLE VerificationDocuments (
    DocumentId INT PRIMARY KEY IDENTITY(1,1),
    VerificationId INT NOT NULL,
    DocumentType VARCHAR(50) NOT NULL, -- NationalID, DegreeCertificate, EmploymentLetter, AddressProof
    FilePath VARCHAR(255) NOT NULL,
    IsVerified BIT DEFAULT 0,
    UploadedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (VerificationId) REFERENCES VerificationRequests(VerificationId) ON DELETE CASCADE
);

-- Seed Initial Data
INSERT INTO Candidates (FirstName, LastName, Email, PhoneNumber, Department, AppliedRole)
VALUES 
('Rahul', 'Sharma', 'rahul.sharma@example.com', '+919876543210', 'Engineering', 'Software Engineer'),
('Priya', 'Patel', 'priya.patel@example.com', '+919812345678', 'Product', 'Product Manager');

INSERT INTO VerificationRequests (CandidateId, Status, AssignedAgent, Comments)
VALUES 
(1, 'InProgress', 'agent.verification@company.com', 'Educational credentials under review.'),
(2, 'Pending', 'agent.verification@company.com', 'Awaiting document submission.');