SELECT EXISTS(
	SELECT id 
	FROM brands
	WHERE id = @id)