using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeAppEip.Web.ViewModels
{
    public class PaginationViewModel<T>
    {
        public int total { get; set; }
        public List<T> rows { get; set; }
    }
}
