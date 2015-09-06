SELECT Top 10 *
FROM books
WHERE id NOT IN
	(SELECT Top 20 id
	FROM books
	ORDER BY UnitPrice,id)
ORDER BY UnitPrice,id