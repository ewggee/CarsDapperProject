SELECT
    c.model,
    b.name AS "Brand"
FROM cars c
INNER JOIN brands b ON c.brand_id = b.id
WHERE c.owner_id = @owner_id