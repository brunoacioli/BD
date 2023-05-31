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
### *g)*
```
CREATE PROC Project_budget_byDept @DeptNumInput SMALLINT
AS
	
	DECLARE @totalBudget as FLOAT, @orcamento as FLOAT, @projname as VARCHAR(10), @pNumber AS SMALLINT, @ploc AS VARCHAR(15),
	@empSsn as INT, @Esalary as FLOAT, @Deptnum as SMALLINT, @totalhours as INT, @hours as INT, @Ppresent as INT, @Ppast as INT,
	@ProjnamePast as VARCHAR(16), @plocPast as VARCHAR(16);

	CREATE TABLE #Results(
			pname	VARCHAR(16),
			pnumber SMALLINT,
			plocation VARCHAR(16),
			dnum	SMALLINT,
			budget FLOAT,
			totalbudget FLOAT
	);

	DECLARE C CURSOR FAST_FORWARD
	FOR SELECT Ssn, Salary, Hours,Pno,Pname,Plocation,Dnum
	From employee JOIN
	(SELECT	Essn,works_on.Hours,Pname,Pno,Plocation,Pnumber,Dnum
	FROM	works_on JOIN
						(SELECT Pname, Pnumber,Plocation,Dnum
						FROM project
						WHERE Dnum = @DeptNumInput) AS proj ON proj.Pnumber = Pno) AS employeeHours ON Ssn = employeeHours.Essn
						ORDER BY Pno ASC;

	OPEN C;

	FETCH C INTO @empssn,@Esalary,@hours,@pNumber,@projname,@ploc,@Deptnum;

	SELECT @Ppast = @pNumber  ,@totalBudget = 0, @totalhours = 0, @orcamento = 0;

	WHILE @@FETCH_STATUS =0
		BEGIN
			if @Ppast = @pNumber
				BEGIN 
					PRINT '1 if ' + CAST(@pNumber as VARCHAR);
					SET @totalBudget += @Esalary;
					SET @orcamento += (@hours*@Esalary)/40;
					SET @ProjnamePast = @projname;
					SET @plocPast = @ploc;


				END

			else
				BEGIN
					INSERT INTO #Results(pname, pnumber, plocation, dnum, budget, totalbudget)
					VALUES (@ProjnamePast, @Ppast, @plocPast, @Deptnum, @orcamento, @totalBudget);
					SELECT @totalBudget = 0, @orcamento = 0,@Ppast = @pNumber;
					SET @totalBudget += @Esalary;
					SET @orcamento += (@hours*@Esalary)/40;

					if (SELECT COUNT(Pno) FROM works_on WHERE Pno = @pNumber ) = 1
						BEGIN
							INSERT INTO #Results(pname, pnumber, plocation, dnum, budget, totalbudget)
							VALUES (@projname, @pNumber, @ploc, @Deptnum, @orcamento, @totalBudget);
							SELECT @totalBudget = 0, @orcamento = 0,@Ppast = @pNumber;
						END

				END

				PRINT CAST(@totalBudget as VARCHAR) + '-' + CAST(@orcamento as VARCHAR);
			FETCH  C INTO @empssn,@Esalary,@hours,@pNumber,@projname,@ploc,@Deptnum;
		END;

	CLOSE C;

	DEALLOCATE C;
```
### *h)*
```
CREATE TRIGGER delete_Depart_After ON department
AFTER DELETE
AS 
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'department_deleted')
    BEGIN
        CREATE TABLE department_deleted (
            Dname VARCHAR(64),
            Dnumber INT PRIMARY KEY,
            Msgr_start_date DATE,
            Mgr_ssn INT,
            FOREIGN KEY (Mgr_ssn) REFERENCES employee(Ssn)
        );
    END;

    INSERT INTO department_deleted (Dname, Dnumber, Msgr_start_date, Mgr_ssn)
    SELECT Dname, Dnumber, Mgr_start_date, Mgr_ssn
    FROM deleted;
END;


CREATE TRIGGER delete_Depart_Instead ON department
INSTEAD OF DELETE
AS 
BEGIN
    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'department_deleted')
    BEGIN
        CREATE TABLE department_deleted (
            Dname VARCHAR(64),
            Dnumber INT PRIMARY KEY,
            Msgr_start_date DATE,
            Mgr_ssn INT,
            FOREIGN KEY (Mgr_ssn) REFERENCES employee(Ssn)
        );
    END;

    INSERT INTO department_deleted (Dname, Dnumber, Msgr_start_date, Mgr_ssn)
    SELECT Dname, Dnumber, Mgr_start_date, Mgr_ssn
    FROM deleted;
END;


```