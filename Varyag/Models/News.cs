using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Varyag.Models
{
    public class News
    {
        public int NewsId { get; set; }
        [DisplayName("Заголовок")]
        public string Header { get; set; }
        [DisplayName("Основной текст")]
        public string MainStory { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Дата новости")]
        public System.DateTime NewsDate { get; set; }
        [DisplayName("Ключевое слово")]
        public NewsKeyWord KeyWord { get; set; }
        [DisplayName("Путь к папке с фотографиями в галерею")]
        public string PathToGallery { get; set; }

        [DisplayName("Маленькая фотка")]
        public string ShortImgPath { get; set; }
        [DisplayName("ALT маленькой фотки")]
        public string ShortImgAlt { get; set; }
        [DisplayName("Title маленькой фотки")]
        public string ShortImgTitle { get; set; }
        [DisplayName("Масштаб маленькой фотки")]
        public string ShortImgScale { get; set; }
        [DisplayName("Х маленькой фотки")]
        public string ShortImgX { get; set; }
        [DisplayName("Y маленькой фотки")]
        public string ShortImgY { get; set; }
        [DisplayName("Текст мелкой фотки")]
        public string ShortStory { get; set; }

        [DisplayName("Средняя фотка")]
        public string MiddleImgPath { get; set; }
        [DisplayName("ALT средней фотки")]
        public string MiddleImgAlt { get; set; }
        [DisplayName("Title средней фотки")]
        public string MiddleImgTitle { get; set; }
        [DisplayName("Масштаб средней фотки")]
        public string MiddleImgScale { get; set; }
        [DisplayName("Х средней фотки")]
        public string MiddleImgX { get; set; }
        [DisplayName("Y средней фотки")]
        public string MiddleImgY { get; set; }
        [DisplayName("Текст средней фотки")]
        public string MiddleStory { get; set; }

        [DisplayName("Широкая фотка")]
        public string WideImgPath { get; set; }
        [DisplayName("ALT широкой фотки")]
        public string WideImgAlt { get; set; }
        [DisplayName("Title широкой фотки")]
        public string WideImgTitle { get; set; }
        [DisplayName("Масштаб широкой фотки")]
        public string WideImgScale { get; set; }
        [DisplayName("Х широкой фотки")]
        public string WideImgX { get; set; }
        [DisplayName("Y широкой фотки")]
        public string WideImgY { get; set; }
        [DisplayName("Текст широкой фотки")]
        public string WideStory { get; set; }

        public List<Foto> NewsFotos { get; set; }
    }

    public enum NewsKeyWord
    {
        Жизнь_кораблей, СМИ, Новые_корабли
    }

    public enum NewsFotoType
    {
        общая, мелкая, средняя, широкая
    }
}
