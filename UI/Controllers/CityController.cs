using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ActionResult Index(string id)
        {
            string text = General.searchText;
            int CurrentPage = Convert.ToInt32(id);
            List <CityDTO> model = new List<CityDTO>();
            if(text == "")
            {
                model = bLL.GetAllCities();                
            }
            else
            {
                model = bLL.GetSearchCities(text);
                if (model.Count == 0)
                {
                    ViewBag.ProcessState = General.Messages.error;
                    List <CityDTO> emptyList = new List<CityDTO>();
                    return View(emptyList);
                }
            }
            
            General.PaginationData.NumberOfCities = model.Count;
            General.PaginationData.NumberOfPages = (General.PaginationData.NumberOfCities / General.PaginationData.NumberOfCitiesPerPage);
            if(General.PaginationData.NumberOfCities % General.PaginationData.NumberOfCitiesPerPage != 0)
            {
                General.PaginationData.NumberOfPages ++;
            }
            
            General.PaginationData.CurrentPage =CurrentPage;
            List<CityDTO> newModel = new List<CityDTO>();
            if(model.Count > General.PaginationData.NumberOfCitiesPerPage &&
               General.PaginationData.NumberOfCitiesPerPage*General.PaginationData.CurrentPage > model.Count)
            {
                newModel = model.GetRange((General.PaginationData.CurrentPage - 1) * General.PaginationData.NumberOfCitiesPerPage,
                        Math.Min(General.PaginationData.NumberOfCitiesPerPage, model.Count - General.PaginationData.NumberOfCitiesPerPage));
            }
            else if(model.Count < General.PaginationData.NumberOfCitiesPerPage)
            {
                newModel = model;
            }
            else
            {
               newModel = model.GetRange((General.PaginationData.CurrentPage - 1) * General.PaginationData.NumberOfCitiesPerPage,
               General.PaginationData.NumberOfCitiesPerPage);
            }
            return View(newModel);
        }

        CityBLL bLL = new CityBLL();

        public ActionResult AddCity()
        {
            CityDTO city = new CityDTO();
            return View(city);
        }
        [HttpPost]
        public ActionResult AddCity(CityDTO model)
        {
            if (ModelState.IsValid)
            {
                List<CityDTO> cities = bLL.GetAllCities();
                CityDTO city = cities.FirstOrDefault(x => x.City == model.City);
                if(city == null)
                {
                    if (bLL.AddCity(model))
                    {
                        ViewBag.ProcessState = General.Messages.success;
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.ProcessState = General.Messages.error;
                    }
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.dbError;
                }                                          
            }
            else
            {
                ViewBag.ProcessState = General.Messages.error;
            }

            CityDTO newModel = new CityDTO();
            return View(newModel);
        }

        public ActionResult EditCity(int ID)
        {
            if(ID < 0)
            {
                ViewBag.ProcessState = General.Messages.error;
                CityDTO city = new CityDTO();
                return View(city);
            }
            else
            {
                CityDTO dTO = bLL.GetCityWithID(ID);
                return View(dTO);
            }
        }
        [HttpPost]
        public ActionResult EditCity(CityDTO model)
        {
            List<CityDTO> cities = bLL.GetAllCities();
            CityDTO city = cities.FirstOrDefault(x => x.City == model.City && x.ID != model.ID);
            if (!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Messages.error;
            }
            else if(city != null)
            {
                ViewBag.ProcessState = General.Messages.dbError;
            }
            else
            {
                if(bLL.UpdateCity(model))
                {
                    ViewBag.ProcessState = General.Messages.success;
                }
                else
                {
                    ViewBag.processState = General.Messages.error;
                }
            }

            return View(model);
        }

        public JsonResult DeleteCity(int ID)
        {
            if (bLL.DeleteCity(ID))
            {
                ViewBag.ProcessState = General.Messages.success;
            }
            else
            {
                ViewBag.ProcessState = General.Messages.error;
            }
            return Json("");
        }

        public ActionResult SearchCity(string text)
        {

            General.searchText = text;
            return RedirectToAction("Index", "City");            
        }

        public ActionResult SortCities()
        {
            bool Sort = General.Sort;
            if (Sort)
            {                
                General.Sort = false;
            }
            else
            {                
                General.Sort = true;
            }

            return RedirectToAction("Index", "City");
        }

    }
}