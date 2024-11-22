-- Create Database for Loan Management System
CREATE DATABASE LoanManagementSystemApp

-- Create Customer Table
CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(15) UNIQUE NOT NULL,
    Address NVARCHAR(255),
    CreditScore INT NOT NULL CHECK (CreditScore BETWEEN 300 AND 850))

-- Create Loan Table
CREATE TABLE Loan (
    LoanID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    PrincipalAmount DECIMAL(18,2) NOT NULL,
    InterestRate DECIMAL(5,2) NOT NULL,
    LoanTerm INT NOT NULL, -- Tenure in months
    LoanType NVARCHAR(50) CHECK (LoanType IN ('CarLoan', 'HomeLoan')),
    LoanStatus NVARCHAR(50) CHECK (LoanStatus IN ('Pending', 'Approved')) DEFAULT 'Pending',
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID))

-- Create HomeLoan Table
CREATE TABLE HomeLoan (
    LoanID INT PRIMARY KEY,
    PropertyAddress NVARCHAR(255) NOT NULL,
    PropertyValue DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (LoanID) REFERENCES Loan(LoanID) ON DELETE CASCADE)

-- Create CarLoan Table
CREATE TABLE CarLoan (
    LoanID INT PRIMARY KEY,
    CarModel NVARCHAR(100) NOT NULL,
    CarValue DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (LoanID) REFERENCES Loan(LoanID) ON DELETE CASCADE)

	-- Insert Sample Customers
INSERT INTO Customer (Name, Email, PhoneNumber, Address, CreditScore)
VALUES
('Ram', 'ram@example.com', '1234567890', '123 abc Street', 700),
('Krishna', 'krishna@example.com', '9876543210', '456 def Avenue', 650)

-- Insert Sample Loans
INSERT INTO Loan (CustomerID, PrincipalAmount, InterestRate, LoanTerm, LoanType, LoanStatus)
VALUES
(1, 30000.00, 7.5, 60, 'HomeLoan', 'Pending'),
(2, 15000.00, 8.0, 36, 'CarLoan', 'Pending')

-- Insert Sample HomeLoan Specific Data
INSERT INTO HomeLoan (LoanID, PropertyAddress, PropertyValue)
VALUES
(1, '123 abc Street', 350000.00)

-- Insert Sample CarLoan Specific Data
INSERT INTO CarLoan (LoanID, CarModel, CarValue)
VALUES
(2, 'Toyota Corolla', 20000.00)



