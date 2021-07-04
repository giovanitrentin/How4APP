using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App666.Model
{
    public class Token
    {
        public string token { get; set; }
        public bool isAutenticado { get; set; }
        public DateTime validade { get; set; }
        public Vendedor vendedor { get; set; }
    }
}
