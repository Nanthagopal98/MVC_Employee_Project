CREATE DATABASE MVC_Employee_Payroll

USE MVC_Employee_Payroll

CREATE TABLE Employees(
EmployeeId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Name VARCHAR(50) NOT NULL,
Profile VARCHAR(250) NOT NULL,
Gender VARCHAR(10) NOT NULL,
Department VARCHAR(250) NOT NULL,
Salary FLOAT NOT NULL,
StartDate DATE NOT NULL
)


SELECT * FROM Employees

GO
CREATE PROCEDURE AddEmployee @Name VARCHAR(50),@Profile VARCHAR(250),@Gender VARCHAR(10),@Department VARCHAR(250),@Salary FLOAT,@StartDate DATE
AS
BEGIN
INSERT INTO Employees VALUES (@Name,@Profile,@Gender,@Department,@Salary,@StartDate)
END

GO
CREATE PROCEDURE GetEmployee
AS
BEGIN
SELECT * FROM Employees
END

GO
CREATE PROCEDURE UpdateEmployee @EmployeeId INT,@Name VARCHAR(50),@Profile VARCHAR(250),@Gender VARCHAR(10),@Department VARCHAR(250),@Salary FLOAT,@StartDate DATE
AS 
BEGIN
UPDATE Employees SET Name = @Name,Profile = @Profile, Gender = @Gender, Department = @Department, Salary = @Salary, StartDate = @StartDate WHERE EmployeeId = @EmployeeId
END

GO
CREATE PROCEDURE DeleteEmployee @EmployeeId INT
AS
BEGIN
DELETE FROM  Employees WHERE EmployeeId = @EmployeeId
END


INSERT INTO Employees VALUES ('Nantha', 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fpngtree.com%2Ffreepng%2Fbusiness-male-icon-vector_4187852.html&psig=AOvVaw1-FNtMpXFWnMW4YHH87kfM&ust=1665821277769000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCOCyy6ei3_oCFQAAAAAdAAAAABAD',
'M','Engineer',2500.25,'2022-10-14')