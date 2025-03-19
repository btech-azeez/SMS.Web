using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Web.Models
{
    public class PaginationModel
    {
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
        public List<UserModel> Result { get; set; }
        public int TotalPages { get; set; }

    }
}