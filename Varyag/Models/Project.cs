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

        [DisplayName("Название проекта")]
        public string Name { get; set; }

        [DisplayName("Длинна корпуса наибольшая, м")]
        [MaxLength(5)]
        public string Length { get; set; }

        [DisplayName("Ширина корпуса наибольшая, м")]
        [MaxLength(5)]
        public string Windth { get; set; }

        [DisplayName("Осадка в полном грузу, м")]
        [MaxLength(5)]
        public string Deep { get; set; }

        [DisplayName("Водоизмещение порожнем, т")]
        [MaxLength(10)]
        public string Volume { get; set; }

        [DisplayName("Вес корпуса, кг")]
        [MaxLength(10)]
        public string Mass { get; set; }

        [DisplayName("Количество весел, шт")]
        [MaxLength(5)]
        public string NumberOfOars { get; set; }

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
        public int? PassengerCap { get; set; }

        [DisplayName("Запас топлива, л")]
        public int? FuelCap { get; set; }

        [DisplayName("Запас пресной воды, л")]
        public int? FreshWaterCap { get; set; }

        [Required]
        [DisplayName("Тип судна")]
        public ShipType Type { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Круизное")]
        public bool CruiseShip { get; set; }
        [DisplayName("Учебное")]
        public bool StudyShip { get; set; }
        [DisplayName("Рыболовецкое")]
        public bool FishingShip { get; set; }
        [DisplayName("Историческое")]
        public bool HistoricalShip { get; set; }
        [DisplayName("Исследовательское")]
        public bool ReserchShip { get; set; }
        [DisplayName("Пассажирское")]
        public bool PassangerShip { get; set; }

        public List<Foto> ShipFotos { get; set; }
    }
    public enum ShipType
    {
        Лодка, Катер, Ладья, Драккар, Яхта, Шлюпка, Шхуна, Струг, Бот
    }
}
