INSERT INTO 
    cars (model, brand_id, owner_id) 
VALUES
    (@model, @brand_id, @owner_id)
RETURNING id