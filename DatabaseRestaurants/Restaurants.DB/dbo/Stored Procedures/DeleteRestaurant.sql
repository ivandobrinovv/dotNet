create PROCEDURE DeleteRestaurant
(
	@id int 
)
AS

BEGIN
	DELETE FROM Restaurants
	WHERE ID = @id;
END