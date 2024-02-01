using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CityBLL
    {
        CityDAO dao = new CityDAO();

        public bool AddCity(CityDTO model)
        {
            City city = new City();
            city.City1 = model.City;
            int ID = dao.AddCity(city);
            return true;
        }

        public CityDTO GetCityWithID(int ID)
        {
            CityDTO city = dao.GetCityWithID(ID);
            return city;
        }

        public List<CityDTO> GetAllCities()
        {
            List<CityDTO> list = new List<CityDTO>();
            list = dao.GetAllCities();
            return list;
        }

        public bool UpdateCity(CityDTO model)
        {
            return dao.UpdateCity(model);            
        }

        public bool DeleteCity(int ID)
        {
            return dao.DeleteCity(ID);
        }

        public List<CityDTO> GetSearchCities(string text)
        {
            List<CityDTO> list = new List<CityDTO>();
            list = dao.GetSearchCities(text);
            return list;
        }

    }
}
