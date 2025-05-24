SELECT
    c.id,
    c.model,
    c.owner_id AS "OwnerId",
    o.name AS "OwnerName"
FROM cars c
LEFT JOIN owners o ON c.owner_id = o.id
WHERE c.brand_id = @brand_id