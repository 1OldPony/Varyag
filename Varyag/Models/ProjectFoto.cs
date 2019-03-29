using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Varyag.Models
{
    public class ProjectFoto
    {
        public int FotoId { get; set; }
        public int ProjectId { get; set; }
        public byte[] Foto { get; set; }
    }
}
