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
    public class CategoryRepository : BaseRepository
    {
        public Category GetByID(int id)
        {
            Category result = null;
            using (SqlConnection cnn = new SqlConnection(base.ConnectionString))
            {
                cnn.Open();

                string query = "SELECT * FROM Categories WHERE CategoryID = @id";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    command.Parameters[0].Value = id;


                    SqlDataReader commandResult = command.ExecuteReader();
                    if (commandResult.Read())
                    {
                        result = new Category();
                        result.ID = commandResult.GetInt32(commandResult.GetOrdinal("CategoryID"));
                        result.Name = commandResult["Name"] as string;
                    }
                }

                cnn.Close(); // this is not needed when using "using"
            }
            return result;
        }
        public List<Category> GetAll()
        {
            List<Category> result = new List<Category>();
            using (SqlConnection cnn = new SqlConnection(base.ConnectionString))
            {
                cnn.Open();

                string query = "SELECT * FROM Category";
                using (SqlCommand command = new SqlCommand(query, cnn))
                {
                    command.CommandType = CommandType.Text;

                    SqlDataReader commandResult = command.ExecuteReader();
                    while (commandResult.Read())
                    {
                        Category city = new Category();
                        city.ID = commandResult.GetInt32(commandResult.GetOrdinal("CategoryID"));
                        city.Name = commandResult["Name"] as string;
                        result.Add(city);
                    }
                }

                cnn.Close(); // this is not needed when using "using"
            }
            return result;
        }

        public void Create(Category category)
        {
            // use stored procedure for this method
            throw new NotImplementedException();
        }


    }
}
