# BD: Guião 3


## ​Problema 3.1
 
### *a)*

```
Cliente: (NIF, nome, endreço,  num_carta)
Candidates: NIF, num_carta
PK : NIF
FK:

ALUGUER: (Número, duração, data, NIF_Cliente, N_balcao, N_veículo)
Candidate: Número
PK: Número
FK: NIF_Cliente, N_balcao, N_veículo

Balcao: (Nome, número, endereço)
Candidate: Número
PK: Número
FK:

Veículo: (Matrícula, ano, marca, código_tipo)
Candidate: Matrícula
PK: Matrícula
FK: Código_tipo

Tipo Veículo: (Código, arcondicionado, designação)
Candidate: Código
PK: Código
FK:

Ligeiro:  (Código_tipo, portas, combustível)
Candidate: Código_tipo
PK: Código_tipo
FK: Código_tipo

Pesado: (Código_tipo, peso, passageiros)
Candidate: Código_tipo
PK: Código_tipo
FK: Código_tipo

Similaridade: (	Código_tipo1, Código_tipo2)
Candidate: Código_tipo1, 
PK: Código_tipo1, Código_tipo2


```


### *b)* 

```
... Write here your answer ...
```


### *c)* 

![q1c!](q1c.jpeg "AnImage")


## ​Problema 3.2

### *a)*

```
Airport: (Airport_code, City, State, Name)
Candidate: Airport_code
PK: Airport_Code
FK:

Airplane_Type: (Type_Name, Max_seats, Company)
Candidate: Type_Name
PK: Type_Name
FK:

Airport_Airplane_Type: (Id, Airport_code, Airport_Type_Name)
Candidate: Id,
PK: Id
FK: Airport_Code, Airport_Type_Name

Airplane: (Airplane_id, Total_no_of_seats, Airplane_Type_Name)
Candidate: Airplane_id
PK: Airplane_id
FK: Airplane_Type_Name

Leg_Instance: Date, No_of_avail_seats, Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number, Airplane_id
Candidates: Date, Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number, Airplane_id
PK: Date, Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number, Airplane_id
FK: Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number, Airplane_id

Seat: Seat_no, Date, Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number, Airplane_id
Candidate: Seat_no, Date, Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number, Airplane_id
PK: Seat_no, Date, Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number, Airplane_id
FK: Date, Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number, Airplane_id 

Flight_leg: Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number
Candidate: Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number
PK: Leg_no,Airport_Code_Arrival, Airport_Code_Departure, Flight_Number
FK: Airport_Code_Arrival, Airport_Code_Departure, Flight_Number

Flight: (Number, Airline, Weekday)
Candidate: Number
PK: Number
FK:

Fare: (Code, Restrictions, Amount, Flight_Number)
Candiidate: Code
PK: Code
FK: Flight_Number
```


### *b)* 

```
... Write here your answer ...
```


### *c)* 

![ex_3_2c!](q2.jpg "AnImage")


## ​Problema 3.3


### *a)* 2.1

![q3_1!](q3_1.jpg "AnImage")

### *b)* 2.2

![q3_2!](q3_2.jpg "AnImage")

### *c)* 2.3

![ex_3_3_c!](q3_3.jpg "AnImage")

### *d)* 2.4

![ex_3_3_d!](q3_4.jpg "AnImage")