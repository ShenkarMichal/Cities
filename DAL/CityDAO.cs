using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public class CityDAO : DataContext
    {
        public int AddCity(City city)
        {
            try
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return city.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CityDTO GetCityWithID(int ID)
        {
            City city = db.Cities.First(x => x.ID == ID);
            CityDTO dTO = new CityDTO();
            dTO.ID = city.ID;
            dTO.City = city.City1;
            return dTO;
        }

        public List<CityDTO> GetAllCities()
        {
            List<CityDTO> cityDTOs = new List<CityDTO>();
            List <City> list = new List<City>();
            if (General.Sort)
            {
                list = db.Cities.ToList();
            }
            else
            {
                list = db.Cities.OrderByDescending(x => x.City1).ToList();
            }
            foreach (City c in list)
            {
                CityDTO city = new CityDTO();
                city.ID = c.ID;
                city.City = c.City1;
                cityDTOs.Add(city);
            }
            return cityDTOs;
        }

        public bool UpdateCity(CityDTO model)
        {
            try
            {
                City city = db.Cities.First(x => x.ID == model.ID);
                if (city != null)
                {
                    city.City1 = model.City;
                    db.SaveChanges();
                }
                return city != null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteCity(int ID)
        {
            try
            {
                City city = db.Cities.First(x => x.ID == ID);
                if (city != null)
                {
                    db.Cities.Remove(city);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CityDTO> GetSearchCities(string text)
        {                
            List<CityDTO> cityDTOs = new List<CityDTO>();
            List<City> cities = new List<City>();
            cities = db.Cities.Where(x=>x.City1.StartsWith(text)).ToList();
            foreach (City city in cities)
            {
                CityDTO dTO = new CityDTO();
                dTO.ID = city.ID;
                dTO.City = city.City1;
                cityDTOs.Add(dTO);
            }
            return cityDTOs;
        }

        public List<CityDTO> SortCities(bool v)
        {
            List<CityDTO> cityDTOs = new List<CityDTO>();
            List<City> cities = new List<City>();
            if(v)
            {
                cities = db.Cities.ToList();
            }
            else
            {
                cities = db.Cities.OrderByDescending(x => x.City1).ToList();
            }
            foreach (City city in cities)
            {
                CityDTO dTO = new CityDTO();
                dTO.ID = city.ID;
                dTO.City = city.City1;
                cityDTOs.Add(dTO);
            }
            return cityDTOs;
        }
    }
}
