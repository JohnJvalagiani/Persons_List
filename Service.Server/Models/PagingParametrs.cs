using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.server.Models
{
    public class PagingParametrs
    {

        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }

    public enum person
        {

         FirstNameENG ,
         LastNameENG ,
         FirstNameGEO,
         LastNameGEO ,
         PhoneNumber,
         PersonalNumber,
         Adress,

    }


}
