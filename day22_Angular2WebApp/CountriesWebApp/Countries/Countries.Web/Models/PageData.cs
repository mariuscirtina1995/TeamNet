using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Countries.Web.Models
{
    public class PageData<T>
    {
        public int Total { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}