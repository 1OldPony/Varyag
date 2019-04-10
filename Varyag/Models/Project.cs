using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Varyag.Models
{
    
    public class Project
    {
        public int ProjectID { get; set; }
        [Required]
        [DisplayName("Название проекта")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Длинна корпуса наибольшая, м")]
        [MaxLength(5)]
        public string Length { get; set; }

        [Required]
        [DisplayName("Ширина корпуса наибольшая, м")]
        [MaxLength(5)]
        public string Windth { get; set; }

        [Required]
        [DisplayName("Осадка в полном грузу, м")]
        [MaxLength(5)]
        public string Deep { get; set; }

        [Required]
        [DisplayName("Водоизмещение порожнем, т")]
        [MaxLength(10)]
        public string Volume { get; set; }

        [DisplayName("Мощность двигателя, л.с.")]
        public int? EnginePower { get; set; }

        [DisplayName("Скорость под двигателем, узлов")]
        public int? Speed { get; set; }

        [DisplayName("Площадь парусности, м2")]
        [MaxLength(10)]
        public string SailArea { get; set; }

        [DisplayName("Количество спальных мест, шт")]
        public int? SleepingAreas { get; set; }

        [DisplayName("Пассажировместимость, чел")]
        public int PassengerCap { get; set; }

        [DisplayName("Запас топлива, л")]
        public int? FuelCap { get; set; }

        [DisplayName("Запас пресной воды, л")]
        public int? FreshWaterCap { get; set; }

        [Required]
        [DisplayName("Тип судна")]
        public ShipType Type { get; set; }

        [Required]
        [DisplayName("Описание")]
        [DefaultValue("Описание судна")]
        public string Description { get; set; }

        public bool CruiseShip { get; set; }
        public bool StudyShip { get; set; }
        public bool FishingShip { get; set; }
        public bool HistoricalShip { get; set; }
        public bool ReserchShip { get; set; }
        public bool PassangerShip { get; set; }

        public List<Foto> ShipFotos { get; set; }
    }
    public enum ShipType
    {
        Лодка, Катер, Ладья, Драккар, Яхта, Шлюпка, Шхуна, Струг, Бот
    }
}
