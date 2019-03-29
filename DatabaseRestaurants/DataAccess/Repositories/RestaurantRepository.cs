using Restaurants.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.DataAccess.Repositories
{
    public class RestaurantRepository : BaseRepository
    {
        public Restaurant GetByID(int id)
        {
            Restaurant result = null;
            using (SqlConnection cnn = new SqlConnection(base.ConnectionString))
            {
                cnn.Open();

                string query = @"
                                SELECT r.RestaurantID
                                      ,r.CategoryID
	                                  ,cat.Name CategoryName
                                      ,r.CityID
	                                  ,c.Name CityName
                                      ,r.Name
                                  FROM [dbo].[Restaurants] r
                                  JOIN Cities c on c.CityID = r.CityID
                                  JOIN Categories cat on cat.CategoryID = r.CategoryID
                                  WHERE r.ID = @id";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters[0].Value = id;

                    SqlDataReader commandResult = command.ExecuteReader();
                    if (commandResult.Read())
                    {
                        result = new Restaurant();
                        result.ID = commandResult.GetInt32(commandResult.GetOrdinal("RestaurantID"));
                        result.Name = commandResult["Name"] as string;
                        result.CategoryID = commandResult.GetInt32(commandResult.GetOrdinal("CategoryID"));
                        result.CategoryName = commandResult.GetString(commandResult.GetOrdinal("CategoryName"));
                        result.CityID = commandResult.GetInt32(commandResult.GetOrdinal("CityID"));
                        result.CityName = commandResult.GetString(commandResult.GetOrdinal("CityName"));
                    }
                }

                // get the clild entities

                cnn.Close(); // this is not needed when using "using"
            }
            return result;
        }
        public List<Restaurant> GetAll()
        {
            List<Restaurant> result = new List<Restaurant>();
            using (SqlConnection cnn = new SqlConnection(base.ConnectionString))
            {
                cnn.Open();

                string query = @"
                                SELECT r.RestaurantID
                                      ,r.CategoryID
	                                  ,cat.Name CategoryName
                                      ,r.CityID
	                                  ,c.Name CityName
                                      ,r.Name
                                  FROM [dbo].[Restaurants] r
                                  JOIN Cities c on c.CityID = r.CityID
                                  JOIN Categories cat on cat.CategoryID = r.CategoryID";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.CommandType = CommandType.Text;

                    SqlDataReader commandResult = command.ExecuteReader();
                    while (commandResult.Read())
                    {
                        Restaurant restaurant = new Restaurant();
                        restaurant.ID = commandResult.GetInt32(commandResult.GetOrdinal("RestaurantID"));
                        restaurant.Name = commandResult["Name"] as string;
                        restaurant.CategoryID = commandResult.GetInt32(commandResult.GetOrdinal("CategoryID"));
                        restaurant.CategoryName = commandResult.GetString(commandResult.GetOrdinal("CategoryName"));
                        restaurant.CityID = commandResult.GetInt32(commandResult.GetOrdinal("CityID"));
                        restaurant.CityName = commandResult.GetString(commandResult.GetOrdinal("CityName"));
                        result.Add(restaurant);
                    }
                }

                cnn.Close(); // this is not needed when using "using"
            }
            return result;
        }
        public List<Restaurant> GetByCityID(int cityID)
        {
            List<Restaurant> result = new List<Restaurant>();
            using (SqlConnection cnn = new SqlConnection(base.ConnectionString))
            {
                cnn.Open();

                string query = @"
                                SELECT r.RestaurantID
                                      ,r.CategoryID
	                                  ,cat.Name CategoryName
                                      ,r.CityID
	                                  ,c.Name CityName
                                      ,r.Name
                                  FROM [dbo].[Restaurants] r
                                  JOIN Cities c on c.CityID = r.CityID
                                  JOIN Categories cat on cat.CategoryID = r.CategoryID
                                  WHERE r.CityID = @cityID";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("@cityID", SqlDbType.Int));
                    command.Parameters[0].Value = cityID;

                    SqlDataReader commandResult = command.ExecuteReader();
                    while (commandResult.Read())
                    {
                        Restaurant restaurant = new Restaurant();
                        restaurant.ID = commandResult.GetInt32(commandResult.GetOrdinal("RestaurantID"));
                        restaurant.Name = commandResult["Name"] as string;
                        restaurant.CategoryID = commandResult.GetInt32(commandResult.GetOrdinal("CategoryID"));
                        restaurant.CategoryName = commandResult.GetString(commandResult.GetOrdinal("CategoryName"));
                        restaurant.CityID = commandResult.GetInt32(commandResult.GetOrdinal("CityID"));
                        restaurant.CityName = commandResult.GetString(commandResult.GetOrdinal("CityName"));
                        result.Add(restaurant);
                    }
                }

                // get the clild entities

                cnn.Close(); // this is not needed when using "using"
            }
            return result;
        }

        public void Create(Restaurant restaurant)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = new SqlConnection(base.ConnectionString);

                cnn.Open();

                string query = @"
                                INSERT INTO Restaurants(CategoryID, CityID, Name)
                                VALUES(@categoryID, @cityID, @name);";

                SqlCommand command = new SqlCommand(query, cnn);

                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@categoryID", SqlDbType.Int));
                command.Parameters[0].Value = restaurant.CategoryID;
                command.Parameters.Add(new SqlParameter("@cityID", SqlDbType.Int));
                command.Parameters[1].Value = restaurant.CityID;
                command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar));
                command.Parameters[2].Value = restaurant.Name;

                //throw new Exception("can not create a new record");

                // set the ID to the object from the query result
                //int id = (int)command.ExecuteScalar();
                //restaurant.ID = id;
            }
            catch (Exception)
            {
                //exceptions are bubbled
                throw;
            }
            finally
            {
                //close and dispose are always called
                if (cnn != null)
                {
                    if (cnn.State == ConnectionState.Open)
                    {
                        cnn.Close();
                    }
                    cnn.Dispose();
                }
            }

        }

        /*
         public void DeleteById(int id){}

         public void Delete(Restaurant restaurant){}
         */

        public void DeleteByID(int id)
        {
            using (SqlConnection cnn = new SqlConnection(base.ConnectionString))
            {
                cnn.Open();

                string query = "DELETE FROM Restaurants WHERE RestaurantID = @id";

                using (SqlCommand command = new SqlCommand(query, cnn))
                {
					command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters[0].Value = id;

                    command.ExecuteNonQuery();
                }

                cnn.Close(); // this is not needed when using "using"
            }
        }
    }
}
