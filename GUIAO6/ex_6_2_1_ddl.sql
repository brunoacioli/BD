/*
CREATE TABLE Company_Employee(
	Ssn int NOT NULL PRIMARY KEY,
	Fname varchar(255) NOT NULL,
	Minit varchar(1) NOT NULL, 
	Lname varchar(255) NOT NULL,
	Bdate date NOT NULL,
	[Address] varchar(255) NOT NULL,
	Sex varchar(255),
	Salary int NOT NULL,
	Super_ssn int NOT NULL FOREIGN KEY REFERENCES Company_Employee(Ssn), 	
)


CREATE TABLE Company_Department(
	Dnumber  int NOT NULL PRIMARY KEY,
	Dname varchar(255) NOT NULL,
	Mgr_ssn int NOT NULL FOREIGN KEY REFERENCES Company_Employee(Ssn),
	Mgr_start_date date NOT NULL,

)


CREATE TABLE Company_Dept_locations(
	Dnumber  int NOT NULL FOREIGN KEY REFERENCES Company_Department(Dnumber),
	Dlocation varchar(255) NOT NULL,
	PRIMARY KEY(Dnumber,Dlocation),
)



CREATE TABLE Company_Project(
	Pnumber int PRIMARY KEY,
	Pname varchar(255) NOT NULL,
	Plocation varchar(255) NOT NULL,
	Dnum int NOT NULL FOREIGN KEY REFERENCES Company_Department(Dnumber),
)


CREATE TABLE Company_Works_on(
	Essn int FOREIGN KEY REFERENCES Company_Employee(Ssn),
	Pno int FOREIGN KEY REFERENCES Company_Project(Pnumber),
	[Hours] int NOT NULL,
	PRIMARY KEY(Essn,Pno)
)



CREATE TABLE Company_Dependent(
	Essn int FOREIGN KEY REFERENCES Company_Employee(Ssn),
	Dependent_name varchar(255) NOT NULL,
	Sex varchar(255) NOT NULL,
	Bdate date NOT NULL,
	Relationship varchar(255) NOT NULL,
)

*/