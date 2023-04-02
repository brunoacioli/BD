/* SELECT * FROM AUTHORS

SELECT au_fname,au_lname,phone FROM AUTHORS

SELECT au_fname,au_lname,phone FROM AUTHORS ORDER BY au_fname asc

SELECT au_fname,au_lname,phone FROM AUTHORS ORDER BY au_lname asc

SELECT au_fname as first_name ,au_lname as last_name ,phone as telephone FROM AUTHORS ORDER BY au_lname asc

SELECT au_fname as first_name ,au_lname as last_name ,phone,state as telephone FROM AUTHORS WHERE state = 'CA' and au_lname != 'Ringer' ORDER BY au_fname,au_lname asc 

SELECT * FROM PUBLISHERS WHERE pub_name LIKE '%Bo%'

SELECT DISTINCT publishers.pub_id,pub_name,type FROM PUBLISHERS INNER JOIN TITLES ON publishers.pub_id = titles.pub_id  WHERE type = 'business'

SELECT publishers.pub_id,publishers.pub_name,SUM(qty) as SOMA FROM publishers INNER JOIN TITLES ON publishers.pub_id = titles.pub_id INNER JOIN SALES ON titles.title_id = sales.title_id GROUP BY publishers.pub_id,publishers.pub_name

SELECT titles.title,SUM(qty) as SOMA FROM titles INNER JOIN SALES ON titles.title_id = sales.title_id GROUP BY titles.title

SELECT stores.stor_name,titles.title FROM TITLES INNER JOIN SALES ON titles.title_id = sales.title_id INNER JOIN STORES ON sales.stor_id = stores.stor_id WHERE stores.stor_name = 'Bookbeat'

SELECT titles.pub_id,titles.[type], AVG(price) as avgPrice ,SUM(qty) as totalSales 
	FROM TITLES
	INNER JOIN SALES ON titles.title_id = sales.title_id
	GROUP BY pub_id,titles.[type]

*/