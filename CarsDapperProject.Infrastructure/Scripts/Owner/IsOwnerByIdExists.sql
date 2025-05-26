SELECT EXISTS (
	SELECT id 
	FROM owners
	WHERE id = @id)