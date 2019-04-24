using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Varyag.Models
{
    public class Foto
    {
        public int FotoID { get; set; }
        [DisplayName("ALT для фотки")]
        public string Alt { get; set; }
        [DisplayName("Title для фотки")]
        public string Name { get; set; }
        [Required]
        public byte[] ProjectFoto { get; set; }
        
        public int? ShipProjectID { get; set; }
        public Project ShipProject { get; set; }

        public int? NewsID { get; set; }
        public News News { get; set; }
    }
}
