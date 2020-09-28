using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.server.Models
{
    public class DetailedSearchParametrs
    {
        public PagingParametrs pagingParametrs { get; set; }
        public person SearchPersonsBy { get; set; }
        public person OrderPersonsby { get; set; }
        public string SearchValue { get; set; }

    }
}
