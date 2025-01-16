using MySqlConnector;
using SOAP_ConnectMariaDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_ConnectMariaDB.DB
{
    public class CountryRepository
    {
        private MySqlConnection connection;

        public CountryRepository()
        {
            connection = ConnectDB.getInstance();
        }

        public List<Country> GetAllCountries()
        {
            connection.Open();
            string sql = "SELECT * FROM country";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Country> countries = new List<Country>();
            while (reader.Read())
            {
                countries.Add(new Country
                {
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString(),
                    Continent = reader["Continent"].ToString(),
                    Population = Convert.ToInt32(reader["Population"])
                });
            }
            connection.Close();
            return countries;
        }
        public Country GetCountryByCode(string countryCode)
        {
            connection.Open();
            string sql = "SELECT * FROM country WHERE Code = @Code";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Code", countryCode);
            MySqlDataReader reader = cmd.ExecuteReader();
            Country country = null;
            if (reader.Read())
            {
                country = new Country
                {
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString(),
                    Continent = reader["Continent"].ToString(),
                    Population = Convert.ToInt32(reader["Population"])
                };
            }
            connection.Close();
            return country;
        }


    }
}