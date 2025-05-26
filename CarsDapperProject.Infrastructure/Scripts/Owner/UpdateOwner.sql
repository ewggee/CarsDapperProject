UPDATE owners
SET 
	name = COALESCE(@name, name),
	phone = COALESCE(@phone, phone),
	email = COALESCE(@email, email)
WHERE id = @id