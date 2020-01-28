using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Varyag.Models.ViewModels
{
    public class ProjectViewModel
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
        public string EnginePower { get; set; }

        [DisplayName("Скорость под двигателем, узлов")]
        public string Speed { get; set; }

        [DisplayName("Площадь парусности, м2")]
        [MaxLength(10)]
        public string SailArea { get; set; }

        [DisplayName("Количество спальных мест, шт")]
        public string SleepingAreas { get; set; }

        [DisplayName("Пассажировместимость, чел")]
        public string PassengerCap { get; set; }

        [DisplayName("Запас топлива, л")]
        public string FuelCap { get; set; }

        [DisplayName("Запас пресной воды, л")]
        public string FreshWaterCap { get; set; }

        [DisplayName("Цена, т.р.")]
        public string Price { get; set; }

        [DisplayName("Краткое описание")]
        public string ShortDescription { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Прогулочная гребная лодка")]
        public bool BoatRow { get; set; }
        [DisplayName("Прогулочная парусная лодка")]
        public bool BoatSail { get; set; }
        [DisplayName("Народная лодка")]
        public bool BoatTraditional { get; set; }

        [DisplayName("Шлюпки ЯЛ-6, ЯЛ-4, ЯЛ-2")]
        public bool BoatYal { get; set; }
        [DisplayName("Гребной катер")]
        public bool KaterRow { get; set; }
        [DisplayName("Ботик")]
        public bool Botik { get; set; }

        [DisplayName("Мотосейлер")]
        public bool Motosailer { get; set; }
        [DisplayName("Каютный катер")]
        public bool KaterCabin { get; set; }
        [DisplayName("Рыболовный/рабочий катер")]
        public bool KaterFish { get; set; }
        [DisplayName("Пассажирский катер")]
        public bool KaterPass { get; set; }

        [DisplayName("Парусно-гребная ладья")]
        public bool LadyaRow { get; set; }
        [DisplayName("Парусно-моторная ладья")]
        public bool LadyaSail { get; set; }

        [DisplayName("Яхта")]
        public bool Yacht { get; set; }
        [DisplayName("Швертбот")]
        public bool Shvertbot { get; set; }
        [DisplayName("Учебный парусник")]
        public bool SailboatStudy { get; set; }
        [DisplayName("Исторический парусник")]
        public bool SailboatHistorical { get; set; }

        [DisplayName("Макет для обучения")]
        public bool MaketStudy { get; set; }
        [DisplayName("Макет для кино")]
        public bool MaketCinema { get; set; }
        [DisplayName("Макет для музеев")]
        public bool MaketMuseum { get; set; }
        [DisplayName("Макет для интерьеров")]
        public bool MaketDesign { get; set; }

        [DisplayName("Проект катера")]
        public bool KaterProject { get; set; }
        [DisplayName("Проект ладьи")]
        public bool LadyaProject { get; set; }
        [DisplayName("Проект парусника")]
        public bool SailboatProject { get; set; }

        [DisplayName("Схема")]
        public IFormFile ShipSheme { get; set; }
        [DisplayName("Схема с расположением")]
        public IFormFile ShipShemeFull { get; set; }
        [DisplayName("Главная фотка")]
        public IFormFile MainFoto { get; set; }
    }
}
