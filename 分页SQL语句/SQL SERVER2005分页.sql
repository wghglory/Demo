SELECT *
FROM 
	(SELECT ROW_NUMBER() OVER (ORDER BY UnitPrice,id)
	AS PriceRank,* FROM books)
	AS Rank
WHERE PriceRank BETWEEN 21 AND 30
ORDER BY UnitPrice,id