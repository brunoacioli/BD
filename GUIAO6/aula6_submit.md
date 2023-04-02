# BD: Guião 6

## Problema 6.1

### *a)* Todos os tuplos da tabela autores (authors);

```
SELECT * FROM AUTHORS
```

### *b)* O primeiro nome, o último nome e o telefone dos autores;

```
SELECT au_fname,au_lname,phone FROM AUTHORS
```

### *c)* Consulta definida em b) mas ordenada pelo primeiro nome (ascendente) e depois o último nome (ascendente); 

```
SELECT au_fname,au_lname,phone FROM AUTHORS
 ORDER BY au_fname,au_lname asc;

```

### *d)* Consulta definida em c) mas renomeando os atributos para (first_name, last_name, telephone); 

```
SELECT au_fname as first_name ,au_lname as last_name ,phone as telephone FROM AUTHORS
ORDER BY au_fname,au_lname asc;

```

### *e)* Consulta definida em d) mas só os autores da Califórnia (CA) cujo último nome é diferente de ‘Ringer’; 

```
SELECT au_fname as first_name ,au_lname as last_name ,phone,state as telephone FROM AUTHORS
WHERE state = 'CA' and au_lname != 'Ringer' ORDER BY au_fname,au_lname asc ;

```

### *f)* Todas as editoras (publishers) que tenham ‘Bo’ em qualquer parte do nome; 

```
SELECT * FROM PUBLISHERS WHERE pub_name LIKE '%Bo%'
```

### *g)* Nome das editoras que têm pelo menos uma publicação do tipo ‘Business’; 

```
SELECT DISTINCT publishers.pub_id,pub_name,type FROM PUBLISHERS
INNER JOIN TITLES ON publishers.pub_id = titles.pub_id  WHERE type = 'business'
```

### *h)* Número total de vendas de cada editora; 

```
SELECT publishers.pub_id,publishers.pub_name,SUM(qty) as SOMA FROM publishers
INNER JOIN TITLES ON publishers.pub_id = titles.pub_id
INNER JOIN SALES ON titles.title_id = sales.title_id
GROUP BY publishers.pub_id,publishers.pub_name
```

### *i)* Número total de vendas de cada editora agrupado por título; 

```
SELECT titles.title,SUM(qty) as SOMA FROM titles
INNER JOIN SALES ON titles.title_id = sales.title_id
GROUP BY titles.title
```

### *j)* Nome dos títulos vendidos pela loja ‘Bookbeat’; 

```
SELECT stores.stor_name,titles.title FROM TITLES
INNER JOIN SALES ON titles.title_id = sales.title_id
INNER JOIN STORES ON sales.stor_id = stores.stor_id
WHERE stores.stor_name = 'Bookbeat'
```

### *k)* Nome de autores que tenham publicações de tipos diferentes; 

```
SELECT au_lname, au_fname,  COUNT(type) as typeCount FROM  authors
INNER JOIN titleauthor ON authors.au_id = titleauthor.au_id
INNER JOIN titles ON titleauthor.title_id = titles.title_id
GROUP BY au_lname, au_fname HAVING count(distinct titles.type) > 1
```

### *l)* Para os títulos, obter o preço médio e o número total de vendas agrupado por tipo (type) e editora (pub_id);

```
SELECT titles.pub_id,titles.[type], AVG(price) as avgPrice ,SUM(qty) as totalSales 
	FROM TITLES
	INNER JOIN SALES ON titles.title_id = sales.title_id
	GROUP BY pub_id,titles.[type]
```

### *m)* Obter o(s) tipo(s) de título(s) para o(s) qual(is) o máximo de dinheiro “à cabeça” (advance) é uma vez e meia superior à média do grupo (tipo);

```
SELECT titles.[type],MAX(titles.advance) from titles
GROUP BY titles.[type] HAVING MAX(titles.advance) > 1.5 * AVG(titles.advance)
```
### *n)* Obter, para cada título, nome dos autores e valor arrecadado por estes com a sua venda;

```
SELECT titles.title,authors.au_fname,authors.au_lname,titles.price * titles.ytd_sales * titles.royalty / 100 as billing from titles 
INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
GROUP BY titles.title, authors.au_fname, authors.au_lname,titles.price,titles.ytd_sales, titles.royalty
```

### *o)* Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, a faturação total, o valor da faturação relativa aos autores e o valor da faturação relativa à editora;

```
SELECT titles.title,titles.ytd_sales,titles.price * titles.ytd_sales as totalbilling ,titles.price * titles.ytd_sales * titles.royalty / 100 as au_billing,
(titles.price * titles.ytd_sales) - (titles.price * titles.ytd_sales * titles.royalty / 100) as pub_billing
from titles INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
GROUP BY titles.title,titles.price,titles.ytd_sales, titles.royalty
```

### *p)* Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, o nome de cada autor, o valor da faturação de cada autor e o valor da faturação relativa à editora;

```
SELECT titles.title,titles.ytd_sales,authors.au_fname+ ' ' + authors.au_lname as author,
titles.price * titles.ytd_sales * titles.royalty / 100 *titleauthor.royaltyper / 100 as au_billing,
(titles.price * titles.ytd_sales) - (titles.price * titles.ytd_sales * titles.royalty / 100) as pub_billing
from titles 
INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
GROUP BY titles.title, authors.au_fname, authors.au_lname,titles.price,titles.ytd_sales, titles.royalty,titleauthor.royaltyper
```

### *q)* Lista de lojas que venderam pelo menos um exemplar de todos os livros;

```
SELECT stores.stor_name,titles.title,titles.title_id
FROM stores
INNER JOIN sales ON stores.stor_id = sales.stor_id
INNER JOIN titles ON sales.title_id = titles.title_id
GROUP BY stores.stor_name,titles.title,titles.title_id
HAVING COUNT(DISTINCT titles.title_id) = (SELECT COUNT(*) FROM titles)
```

### *r)* Lista de lojas que venderam mais livros do que a média de todas as lojas;

```
SELECT stores.stor_name, SUM(sales.qty) as total_sum
FROM stores
INNER JOIN sales ON stores.stor_id = sales.stor_id
INNER JOIN titles ON sales.title_id = titles.title_id
GROUP BY stores.stor_name
HAVING SUM(sales.qty) > (SELECT AVG(total_sum) from 
							(
								SELECT stores.stor_name, SUM(sales.qty) as total_sum
								FROM stores
								INNER JOIN sales ON stores.stor_id = sales.stor_id
								INNER JOIN titles ON sales.title_id = titles.title_id
								GROUP BY stores.stor_name
							) as t
						)
```

### *s)* Nome dos títulos que nunca foram vendidos na loja “Bookbeat”;

```
SELECT titles.title from titles where titles.title_id NOT IN
(
	SELECT titles.title_id
	FROM stores
	JOIN sales ON stores.stor_id = sales.stor_id
	JOIN titles ON sales.title_id = titles.title_id
	WHERE stores.stor_name = 'Bookbeat'
)
```

### *t)* Para cada editora, a lista de todas as lojas que nunca venderam títulos dessa editora; 

```

```

## Problema 6.2

### ​5.1

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_1_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_1_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
SELECT Fname, Minit, Lname, Company_Employee.Ssn
FROM Company_Employee
JOIN Company_Works_on ON Company_Employee.Ssn = Company_Works_on.Essn
JOIN Company_Project ON Company_Works_on.Pno = Company_Project.Pnumber;
```

##### *b)* 

```
SELECT Fname, Lname, Ssn
FROM Company_Employee
INNER JOIN
  (SELECT Ssn
   FROM Company_Employee
   WHERE Fname = 'Carlos' AND Lname = 'Gomes') AS supervisor
ON Company_Employee.Super_ssn = supervisor.Ssn;

```

##### *c)* 

```
SELECT Pname, SUM(Company_Works_on.Hours) AS TotalHours 
FROM Company_Project JOIN Company_Works_on 
ON Company_Project.Pnumber = Company_Works_on.Pno GROUP BY Pname

```

##### *d)* 

```
SELECT Company_Employee.Fname, Company_Employee.Minit, Company_Employee.Lname, Company_Project.Pname, Company_Works_on.Dno, Company_Works_on.Hours
FROM Company_Employee 
JOIN Company_Works_on ON Company_Employee.Ssn = Company_Works_on.Essn 
JOIN Company_Project ON Company_Works_on.Pno = Company_Project.Pnumber 
WHERE Company_Project.Pname = 'Aveiro Digital' AND Company_Works_on.Dno = 3 AND Company_Works_on.Hours > 20;

```

##### *e)* 

```
SELECT DISTINCT Fname, Minit, Lname 
FROM Company_Employee 
WHERE Ssn NOT IN (SELECT Essn FROM works_on WHERE Pno IS NOT NULL);
```

##### *f)* 

```
SELECT Company_Department.Dname, AVG(Company_Employee.Salary) AS Average_Women_Salary 
FROM Company_Department 
    JOIN Company_Employee 
        ON Company_Department.Dnumber = Company_Employee.Dno 
WHERE Company_Employee.Sex = 'F' 
GROUP BY Company_Department.Dname;

```

##### *g)* 

```
SELECT Fname, Minit, Lname, COUNT(Company_Dependent.Essn) AS nDependentes 
FROM Company_Employee 
    JOIN Company_Dependent 
        ON Company_Employee.Ssn = Company_Dependent.Essn 
GROUP BY Company_Employee.Ssn 
HAVING COUNT(Company_Dependent.Essn) > 2;

```

##### *h)* 

```
SELECT DISTINCT Company_Employee.Fname, Company_Employee.Lname 
FROM Company_Employee 
    JOIN Company_Department 
        ON Company_Employee.Ssn = Company_Department.Mgr_ssn 
    JOIN Company_Dependent 
        ON Company_Department.Mgr_ssn = Company_Dependent.Essn 
WHERE Company_Employee.Ssn <> Company_Dependent.Essn;

```

##### *i)* 

```
SELECT Company_Employee.Fname, Company_Employee.Minit, Company_Employee.Lname, Company_Employee.Address 
FROM Company_Employee 
    JOIN Company_Works_on 
        ON Company_Employee.Ssn = Company_Works_on.Essn 
    JOIN Company_Project 
        ON Company_Works_on.Pno = Company_Project.Pnumber 
        AND Company_Project.Plocation = 'Aveiro'
    JOIN Company_Department 
        ON Company_Project.Dno = Company_Department.Dnumber 
        AND Company_Department.Dlocation != 'Aveiro';

```

### 5.2

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_2_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_2_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
SELECT nome, nif, fax, endereco, condpag, tipo
FROM fornecedor
INNER JOIN encomenda ON encomenda.fornecedor = fornecedor.nif
WHERE fornecedor.nif IS NULL
```

##### *b)* 

```
SELECT produto.nome, AVG(item.unidades) as average FROM produto INNER JOIN item ON produto.codigo = item.codProd
INNER JOIN encomenda ON item.numEnc = encomenda.numero
GROUP BY produto.nome
```


##### *c)* 

```
SELECT numEnc, AVG(nprodutos) AS nprod_avg
FROM (
  SELECT numEnc, COUNT(codProd) AS nprodutos
  FROM item
  GROUP BY numEnc
) AS subquery
GROUP BY numEnc
```


##### *d)* 

```
SELECT produto.codigo, fornecedor.nif, fornecedor.nome, SUM(item.unidades) AS qtd_total
FROM item
INNER JOIN produto
ON item.codProd = produto.codigo
INNER JOIN encomenda
ON item.numEnc = encomenda.numero
INNER JOIN fornecedor
ON encomenda.fornecedor = fornecedor.nif
WHERE fornecedor.nif = fornecedor.nif AND produto.codigo = produto.codigo
GROUP BY produto.codigo, fornecedor.nif, fornecedor.nome
```

### 5.3

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_3_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_3_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
SELECT nome, num_utente
FROM PrescricaoMed_Paciente
LEFT JOIN PrescricaoMed_Prescricao ON PrescricaoMed_Paciente.num_utente = PrescricaoMed_Prescricao.num_utente
WHERE PrescricaoMed_Prescricao.num_utente IS NULL;
```

##### *b)* 

```
SELECT especialidade, COUNT(PrescricaoMed_Prescricao.numero_unico) AS numPresc
FROM PrescricaoMed_Medico
INNER JOIN PrescricaoMed_Prescricao ON PrescricaoMed_Medico.num_id = PrescricaoMed_Prescricao.num_medico
GROUP BY PrescricaoMed_Medico.especialidade;
```


##### *c)* 

```
SELECT nif_farmacia, COUNT(*) AS PrescrPorFarm 
FROM PrescricaoMed_Prescricao 
    JOIN farmacia 
        ON PrescricaoMed_Prescricao.nif_farmacia = PrescricaoMed_Farmacia.nif 
GROUP BY nif_farmacia;

```


##### *d)* 

```

```

##### *e)* 

```
... Write here your answer ...
```

##### *f)* 

```
... Write here your answer ...
```
