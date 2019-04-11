using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Varyag.Models.ViewModels
{
    public class FotoViewModel
    {
        public int FotoID { get; set; }
        [DisplayName("ALT для фотки")]
        public string Alt { get; set; }
        [DisplayName("Title для фотки")]
        public string Name { get; set; }
        [DisplayName("Фотка")]
        public IFormFile Foto { get; set; }
        public int? ShipProjectID { get; set; }
        public int? NewsID { get; set; }
    }
}
