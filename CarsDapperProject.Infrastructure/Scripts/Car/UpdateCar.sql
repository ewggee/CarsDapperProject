UPDATE cars
SET 
	model = COALESCE(@model, model), 
	brand_id = COALESCE(@brand_id, brand_id), 
	owner_id = COALESCE(@owner_id, owner_id) 
WHERE id = @id