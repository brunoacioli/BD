/*
CREATE TABLE ReservaVoos_Flight(
number int NOT NULL PRIMARY KEY,
airline varchar(255) NOT NULL,
weekdays varchar(255) NOT NULL,
)


CREATE TABLE ReservaVoos_Airport(
airport_code int NOT NULL PRIMARY KEY,
[name] varchar(255) NOT NULL,
city varchar(255) NOT NULL,
state varchar(255) NOT NULL,
)



CREATE TABLE ReservaVoos_Airplane_type(
[type_name] varchar(255) NOT NULL PRIMARY KEY,
max_seates int NOT NULL,
company varchar(255) NOT NULL
)


CREATE TABLE ReservaVoos_Airport_Airplane_type(
airport_code int NOT NULL FOREIGN KEY REFERENCES ReservaVoos_Airport(airport_code), 
airplane_type_name varchar(255) NOT NULL FOREIGN KEY REFERENCES ReservaVoos_Airplane_type([type_name]),
PRIMARY KEY(airport_code,airplane_type_name),
)


CREATE TABLE ReservaVoos_Airplane(
airplane_id int NOT NULL PRIMARY KEY,
total_no_seats int NOT NULL,
[type_name] varchar(255) NOT NULL FOREIGN KEY REFERENCES ReservaVoos_Airplane_type([type_name]),
)


CREATE TABLE ReservaVoos_Flight_leg(
leg_no int NOT NULL,
airport_code_arrival int NOT NULL FOREIGN KEY REFERENCES ReservaVoos_Airport(airport_code),
airport_code_departure int NOT NULL FOREIGN KEY REFERENCES ReservaVoos_Airport(airport_code),
flight_number int NOT NULL FOREIGN KEY REFERENCES ReservaVoos_Flight(number),
PRIMARY KEY(leg_no,airport_code_arrival,airport_code_departure,flight_number),
)



CREATE TABLE ReservaVoos_Leg_instance(
no_avail_seats int NOT NULL,
[date] date NOT NULL,
airplane_id int NOT NULL FOREIGN KEY REFERENCES ReservaVoos_Airplane(airplane_id),
leg_no int NOT NULL,
airport_code_arrival int NOT NULL,
airport_code_departure int NOT NULL,
flight_number int NOT NULL,
PRIMARY KEY([date], airplane_id, leg_no, airport_code_arrival, airport_code_departure, flight_number),
FOREIGN KEY(leg_no, airport_code_arrival, airport_code_departure, flight_number) REFERENCES ReservaVoos_Flight_leg(leg_no, airport_code_arrival, airport_code_departure, flight_number),
)



CREATE TABLE ReservaVoos_Seat(
seat_no int NOT NULL,
[date] date NOT NULL,
airplane_id int NOT NULL,
leg_no int NOT NULL,
airport_code_arrival int NOT NULL,
airport_code_departure int NOT NULL,
flight_number int NOT NULL,
PRIMARY KEY(seat_no, [date], airplane_id, leg_no, airport_code_arrival, airport_code_departure, flight_number),
FOREIGN KEY([date], airplane_id, leg_no, airport_code_arrival, airport_code_departure, flight_number) REFERENCES ReservaVoos_Leg_instance([date], airplane_id, leg_no, airport_code_arrival, airport_code_departure, flight_number),

)



CREATE TABLE ReservaVoos_Fare(
code varchar(255) NOT NULL,
amount int NOT NULL,
restrictions varchar(255),
flight_number int NOT NULL FOREIGN KEY REFERENCES ReservaVoos_Flight(number),
)

*/