using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CityDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "נא למלא שם יישוב")]        
        public string City { get; set; }
    }
}
