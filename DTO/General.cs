using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class General
    {
        public static class Messages
        {
            public static string success = "success";
            public static string error = "error";
            public static string dbError = "dbError";
        }

        public static class PaginationData
        {
            public static int NumberOfCities = 0;
            public static int NumberOfCitiesPerPage = 7;
            public static int NumberOfPages = 1;
            public static int CurrentPage = 1;
        }

        public static string searchText = "";

        public static bool Sort = true;

    }
}
