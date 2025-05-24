SELECT
    c.id,
    c.model,
    c.brand_id AS "BrandId",
    c.owner_id AS "OwnerId",
	b.name AS "BrandName",
    o.name AS "OwnerName"
FROM cars c
INNER JOIN brands b ON c.brand_id = b.id
LEFT JOIN owners o ON c.owner_id = o.id
WHERE c.id = @id