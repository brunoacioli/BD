
/*
SELECT titles.[type],MAX(titles.advance) from titles
GROUP BY titles.[type] HAVING MAX(titles.advance) > 1.5 * AVG(titles.advance)


SELECT titles.title,authors.au_fname,authors.au_lname,titles.price * titles.ytd_sales * titles.royalty / 100 as billing from titles 
INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
GROUP BY titles.title, authors.au_fname, authors.au_lname,titles.price,titles.ytd_sales, titles.royalty



SELECT titles.title,titles.ytd_sales,titles.price * titles.ytd_sales as totalbilling ,titles.price * titles.ytd_sales * titles.royalty / 100 as au_billing,
(titles.price * titles.ytd_sales) - (titles.price * titles.ytd_sales * titles.royalty / 100) as pub_billing
from titles INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
GROUP BY titles.title,titles.price,titles.ytd_sales, titles.royalty



SELECT titles.title,titles.ytd_sales,authors.au_fname+ ' ' + authors.au_lname as author,
titles.price * titles.ytd_sales * titles.royalty / 100 *titleauthor.royaltyper / 100 as au_billing,
(titles.price * titles.ytd_sales) - (titles.price * titles.ytd_sales * titles.royalty / 100) as pub_billing
from titles 
INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
GROUP BY titles.title, authors.au_fname, authors.au_lname,titles.price,titles.ytd_sales, titles.royalty,titleauthor.royaltyper



SELECT stores.stor_name,titles.title,titles.title_id
FROM stores
JOIN sales ON stores.stor_id = sales.stor_id
JOIN titles ON sales.title_id = titles.title_id
GROUP BY stores.stor_name,titles.title,titles.title_id
HAVING COUNT(DISTINCT titles.title_id) = (SELECT COUNT(*) FROM titles)



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


SELECT titles.title from titles where titles.title_id NOT IN
(
	SELECT titles.title_id
	FROM stores
	JOIN sales ON stores.stor_id = sales.stor_id
	JOIN titles ON sales.title_id = titles.title_id
	WHERE stores.stor_name = 'Bookbeat'
)

*/
	












	
