UPDATE brands
SET
	name = COALESCE(@name, name)
WHERE id = @id