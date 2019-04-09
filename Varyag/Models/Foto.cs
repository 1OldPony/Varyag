using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Varyag.Models
{
    public class Foto
    {
        public int FotoID { get; set; }
        [DisplayName("ALT для фотки")]
        public string Alt { get; set; }
        [DisplayName("Name для фотки")]
        public string Name { get; set; }
        public byte[] ProjectFoto { get; set; }
        
        public int? ShipProjectID { get; set; }
        public Project ShipProject { get; set; }

        public int? NewsID { get; set; }
        public News News { get; set; }
    }
}
