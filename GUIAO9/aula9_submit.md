# BD: Guião 9


## ​9.1
 
### *a)*

```
GO
CREATE PROC remove_employee (@Ssn INT)
AS
	
	DELETE FROM Works_on WHERE Essn=@Ssn;
	DELETE FROM Dependent WHERE Essn=@Ssn;	
	UPDATE DEPARTMENT set Mgr_ssn = NULL, Mgr_start_date = NULL WHERE Mgr_ssn = @Ssn;
	UPDATE EMPLOYEE set Super_ssn = NULL WHERE Super_ssn = @Ssn;	
	DELETE FROM employee WHERE Ssn = @Ssn;

    -- Ter cuidado em dar update nas tabelas Department e Employee

```

### *b)* 

```
GO
CREATE PROC managers (@Mng_ssn INT OUTPUT, @Mng_years INT OUTPUT)
AS
	
	SELECT CONCAT(Fname, ' ', Minit, ' ', Lname) AS Manager_name, Ssn FROM EMPLOYEE;	
	SELECT TOP 1 @Mng_ssn = Mgr_ssn, @Mng_years = DATEDIFF(YEAR, Mgr_start_date, CAST(GETDATE() AS DATE)) FROM DEPARTMENT JOIN EMPLOYEE ON Mgr_ssn = Ssn WHERE Mgr_start_date IS NOT NULL ORDER BY Mgr_start_date;
	SELECT * FROM DEPARTMENT JOIN EMPLOYEE ON Mgr_ssn = Ssn;
	
```

### *c)* 

```
GO
CREATE TRIGGER one_dept ON Department INSTEAD OF INSERT, UPDATE
AS
	BEGIN
		IF (SELECT count(*) FROM inserted) > 0
			BEGIN
				DECLARE @employee_ssn AS INT;
				SELECT @employee_ssn = Mgr_ssn FROM inserted;   
				IF (@employee_ssn) IS NULL OR ((SELECT count(*) FROM Employee WHERE Ssn=@employee_ssn) = 0)
					RAISERROR('Employee doesnt existing', 16, 1);
				ELSE
					BEGIN
						IF (SELECT COUNT(Dnumber) FROM Company.Department WHERE Mgr_ssn=@employee_ssn) >=1
							RAISERROR('Employee cant manage more than one department', 16, 1);	
						ELSE
							INSERT INTO Company.Department SELECT * FROM inserted;
					END
			END
	END

```

### *d)* 

```
GO
CREATE TRIGGER get_low ON Employee AFTER INSERT, UPDATE
AS
	BEGIN
		DECLARE @ssn_emp AS INT;
		DECLARE @sal_emp AS INT;
		DECLARE @dno AS INT;
		DECLARE @mgr_sal AS INT;
		SELECT @ssn_emp=inserted.Ssn, @sal_emp=inserted.Salary, @dno=inserted.Dno FROM inserted;
		SELECT @mgr_sal=Employee.Salary FROM Department
			INNER JOIN Employee ON Department.Mgr_Ssn=Employee.Ssn
			WHERE @dno=Department.Dnumber;
		IF @sal_emp > @mgr_sal
		BEGIN
			UPDATE Employee SET Employee.Salary=@mgr_sal-1
			WHERE Employee.Ssn=@ssn_emp
		END
	END
```

### *e)* 

```
GO
CREATE FUNCTION proj_info (@emp_ssn INT) RETURNS @table
TABLE([name] VARCHAR(45), [location] VARCHAR(15))
AS
	BEGIN
		INSERT @table
			SELECT Project.Pname, Project.Plocation FROM Project
				INNER JOIN Works_on ON Works_on.Pno=Project.Pnumber
				WHERE Works_on.Essn=@emp_ssn
		RETURN;
	END
```

### *f)* 

```
GO
CREATE FUNCTION better_paid_emp (@dno INT) RETURNS @table
TABLE ([ssn] INT, [fname] VARCHAR(15), [lname] VARCHAR(15))
AS
    BEGIN 
        INSERT @table
            SELECT Employee.Ssn, Employee.Fname, Employee.Lname
            FROM Employee JOIN (SELECT Dno, AVG(Salary) as avg_sal 
                                        FROM Department, Employee
                                        WHERE Dno=Dnumber
                                        GROUP BY Dno) AS dep_avg_sal
            ON dep_avg_sal.Dno=Employee.Dno AND Salary > avg_sal AND Employee.Dno = @dno;
        RETURN;
    END

```

