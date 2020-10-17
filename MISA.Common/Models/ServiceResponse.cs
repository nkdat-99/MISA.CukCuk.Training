using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class ServiceResponse
    {
        public List<string> Msg { get; set; } = new List<string>();
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}
