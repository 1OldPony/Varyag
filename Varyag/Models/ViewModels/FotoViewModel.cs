using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Varyag.Models.ViewModels
{
    public class FotoViewModel
    {
        public int FotoID { get; set; }
        public string Alt { get; set; }
        public string Name { get; set; }
        public IFormFile Foto { get; set; }
        public int? ShipProjectID { get; set; }
        public int? NewsID { get; set; }
    }
}
