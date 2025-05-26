INSERT INTO 
	owners (name, phone, email)
VALUES 
	(@name, @phone, @email)
RETURNING id