using MySqlConnector;
using SOAP_ConnectMariaDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_ConnectMariaDB.DB
{
    public class CityRepository
    {
        private MySqlConnection connection;
        public CityRepository()
        {
            connection = ConnectDB.getInstance();
        }

        public List<City> getAllCities()
        {
            connection.Open();
            string sql = "select * from city";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<City> cities = new List<City>();
            while (rdr.Read())
            {
                City city = new City(
                    int.Parse(rdr[0].ToString()),
                        rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(),
                        int.Parse(rdr[4].ToString())
                    );
                cities.Add(city);
            }
            connection.Close();
            return cities;
        }
        public bool AddCity(City city)
        {
            connection.Open();
            string sql = "INSERT INTO city (Name, CountryCode, District, Population) VALUES (@Name, @CountryCode, @District, @Population)";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Name", city.Name);
            cmd.Parameters.AddWithValue("@CountryCode", city.CountryCode);
            cmd.Parameters.AddWithValue("@District", city.District);
            cmd.Parameters.AddWithValue("@Population", city.Population);
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }

        public bool UpdateCity(City city)
        {
            connection.Open();
            string sql = "UPDATE city SET Name = @Name, CountryCode = @CountryCode, District = @District, Population = @Population WHERE Id = @Id";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Id", city.Id);
            cmd.Parameters.AddWithValue("@Name", city.Name);
            cmd.Parameters.AddWithValue("@CountryCode", city.CountryCode);
            cmd.Parameters.AddWithValue("@District", city.District);
            cmd.Parameters.AddWithValue("@Population", city.Population);
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }

        public bool DeleteCity(int cityId)
        {
            connection.Open();
            string sql = "DELETE FROM city WHERE Id = @Id";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Id", cityId);
            int rowsAffected = cmd.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }

        public City GetCityById(int cityId)
        {
            connection.Open();
            string sql = "SELECT * FROM city WHERE Id = @Id";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Id", cityId);
            MySqlDataReader rdr = cmd.ExecuteReader();
            City city = null;
            if (rdr.Read())
            {
                city = new City(
                    int.Parse(rdr["Id"].ToString()),
                    rdr["Name"].ToString(),
                    rdr["CountryCode"].ToString(),
                    rdr["District"].ToString(),
                    int.Parse(rdr["Population"].ToString())
                );
            }
            connection.Close();
            return city;
        }

        public List<City> GetCitiesByCountry(string countryCode)
        {
            connection.Open();
            string sql = "SELECT * FROM city WHERE CountryCode = @CountryCode";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@CountryCode", countryCode);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<City> cities = new List<City>();
            while (reader.Read())
            {
                cities.Add(new City
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    District = reader["District"].ToString(),
                    Population = Convert.ToInt32(reader["Population"])
                });
            }
            connection.Close();
            return cities;
        }
        public City GetCityByName(string cityName)
        {
            connection.Open();
            string sql = "SELECT * FROM city WHERE Name = @Name";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Name", cityName);
            MySqlDataReader reader = cmd.ExecuteReader();
            City city = null;
            if (reader.Read())
            {
                city = new City
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Name = reader["Name"].ToString(),
                    District = reader["District"].ToString(),
                    Population = Convert.ToInt32(reader["Population"])
                };
            }
            connection.Close();
            return city;
        }

    }
}