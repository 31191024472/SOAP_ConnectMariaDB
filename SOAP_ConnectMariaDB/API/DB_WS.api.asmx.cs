using SOAP_ConnectMariaDB.DB;
using SOAP_ConnectMariaDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOAP_ConnectMariaDB.API
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<City> getAllCities()
        {
            CityRepository countryRepository = new CityRepository();
            return countryRepository.getAllCities();
        }
        [WebMethod]
        public bool AddCity(string name, string countryCode, string district, int population)
        {
            CityRepository repository = new CityRepository();
            City city = new City(0, name, countryCode, district, population);
            return repository.AddCity(city);
        }

        [WebMethod]
        public bool UpdateCity(int id, string name, string countryCode, string district, int population)
        {
            CityRepository repository = new CityRepository();
            City city = new City(id, name, countryCode, district, population);
            return repository.UpdateCity(city);
        }

        [WebMethod]
        public bool DeleteCity(int id)
        {
            CityRepository repository = new CityRepository();
            return repository.DeleteCity(id);
        }

        [WebMethod]
        public City GetCityById(int id)
        {
            CityRepository repository = new CityRepository();
            return repository.GetCityById(id);
        }

        [WebMethod]
        public List<Country> GetAllCountries()
        {
            CountryRepository countryRepository = new CountryRepository();
            return countryRepository.GetAllCountries();
        }

        [WebMethod]
        public Country GetCountryByCode(string countryCode)
        {
            CountryRepository countryRepository = new CountryRepository();
            return countryRepository.GetCountryByCode(countryCode);
        }
        [WebMethod]
        public List<City> GetCitiesByCountry(string countryCode)
        {
            CityRepository cityRepository = new CityRepository();
            return cityRepository.GetCitiesByCountry(countryCode);
        }

        [WebMethod]
        public City GetCityByName(string cityName)
        {
            CityRepository cityRepository = new CityRepository();
            return cityRepository.GetCityByName(cityName);
        }

    }
}
