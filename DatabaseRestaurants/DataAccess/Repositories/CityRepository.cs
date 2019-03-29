using Restaurants.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;//ADO.NET
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.DataAccess.Repositories
{
    public class CityRepository : BaseRepository
    {
		
        public City GetByID(int id)
        {
            City result = null;
            using (SqlConnection cnn = new SqlConnection(base.ConnectionString))
            {
                cnn.Open();

                string query = "SELECT * FROM Cities WHERE CityID = @id";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters[0].Value = id;

					
                    SqlDataReader commandResult = command.ExecuteReader();
                    if (commandResult.Read())
                    {
                        result = new City();
                        result.ID = commandResult.GetInt32(commandResult.GetOrdinal("CityID"));
                        result.Name = commandResult["Name"] as string;
                    }
                }

                cnn.Close(); // this is not needed when using "using"
            }
            return result;
        }
        public List<City> GetAll()
        {
            List<City> result = new List<City>();
            using (SqlConnection cnn = new SqlConnection(base.ConnectionString))
            {
                cnn.Open();

                string query = "SELECT * FROM Cities";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.CommandType = CommandType.Text;

                    SqlDataReader commandResult = command.ExecuteReader();
                    while (commandResult.Read())
                    {
                        City city = new City();
                        city.ID = commandResult.GetInt32(commandResult.GetOrdinal("CityID"));
                        city.Name = commandResult["Name"] as string;
                        result.Add(city);
                    }
                }

                cnn.Close(); // this is not needed when using "using"
            }
            return result;
        }

        // you can also add Create, Update and Delete methods
        //public void Create(City city);
        //public void Update(City city);
        //public void DeleteByID(int id);
    }
}
