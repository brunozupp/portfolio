using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteProjeto.Models
{
    public class ResponseAPI<T>
    {
        public int StatusCode { get; set; }

        public T Content { get; set; }
    }
}
