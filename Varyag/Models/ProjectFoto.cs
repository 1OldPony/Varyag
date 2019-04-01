using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Varyag.Models
{
    public class ProjectFoto
    {
        public int ProjectFotoID { get; set; }
        public byte[] Foto { get; set; }
        
        public int ShipProjectID { get; set; }
        public ShipProject ShipProject { get; set; }
    }
}
