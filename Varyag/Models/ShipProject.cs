using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Varyag.Models
{
    
    public class ShipProject
    {
        public enum ShipType
        {
            Лодка, Катер, Ладья, Драккар, Яхта, Шлюпка, Шхуна, Струг, Бот
        }

        public int ProjectId;

        [Required]
        public string ProjectName { get; set; }
        [Required]
        public int ProjectLength { get; set; }
        [Required]
        public int ProjectWindth { get; set; }
        [Required]
        public int ProjectDeep { get; set; }
        [Required]
        public int ProjectVolume { get; set; }
        public int? ProjectEnginePower { get; set; }
        public int? ProjectSpeed { get; set; }
        public int? ProjectSailArea { get; set; }
        public int? ProjectSleepingAreas { get; set; }
        public int ProjectPassengerCap { get; set; }
        public int? ProjectFuelCap { get; set; }
        public int? ProjectFreshWaterCap { get; set; }
        [Required]
        public ShipType ProjectType { get; set; }
        [Required]
        public string ProjectDescription { get; set; }

        public bool CruiseShip { get; set; }
        public bool StudyShip { get; set; }
        public bool FishingShip { get; set; }
        public bool HistoricalShip { get; set; }
        public bool ReserchShip { get; set; }
        public bool PassangerShip { get; set; }
        
        public virtual List<ProjectFoto> Fotos { get; set; }
    }
}
