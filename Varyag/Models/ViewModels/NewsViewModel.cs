using System.Collections.Generic;
using System.ComponentModel;

namespace Varyag.Models.ViewModels
{
    public class NewsViewModel
    {
        public int NewsId { get; set; }
        [DisplayName("Заголовок")]
        public string Header { get; set; }
        [DisplayName("Краткий текст")]
        public string ShortStory { get; set; }
        [DisplayName("Основной текст")]
        public string MainStory { get; set; }
        [DisplayName("Ключевое слово")]
        public NewsKeyWord KeyWord { get; set; }

        [DisplayName("Маленькая фотка")]
        public string ShortImgPath { get; set; }
        [DisplayName("Масштаб маленькой фотки")]
        public string ShortImgScale { get; set; }
        [DisplayName("Х маленькой фотки")]
        public string ShortImgX { get; set; }
        [DisplayName("Y маленькой фотки")]
        public string ShortImgY { get; set; }

        [DisplayName("Средняя фотка")]
        public string MiddleImgPath { get; set; }
        [DisplayName("Масштаб средней фотки")]
        public string MiddleImgScale { get; set; }
        [DisplayName("Х средней фотки")]
        public string MiddleImgX { get; set; }
        [DisplayName("Y средней фотки")]
        public string MiddleImgY { get; set; }

        [DisplayName("Большая фотка")]
        public string WideImgPath { get; set; }
        [DisplayName("Масштаб большой фотки")]
        public string WideImgScale { get; set; }
        [DisplayName("Х большой фотки")]
        public string WideImgX { get; set; }
        [DisplayName("Y большой фотки")]
        public string WideImgY { get; set; }

        public List<Foto> NewsFotos { get; set; }
    }
}
