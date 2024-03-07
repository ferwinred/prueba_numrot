using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }

}