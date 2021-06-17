using System.ComponentModel;

namespace Varyag.Models
{
    public class NewsViewModel
    {
        public int NewsId { get; set; }
        [DisplayName("Заголовок")]
        public string Header { get; set; }
        [DisplayName("Основной текст")]
        public string MainStory { get; set; }
        [DisplayName("Дата новости")]
        public int NewsDate { get; set; }
        [DisplayName("Дата новости для превью")]
        public string NewsDatePreview { get; set; }
        [DisplayName("Связанный проект")]
        public string LinkedProjectName { get; set; }
        [DisplayName("Ключевое слово")]
        public NewsKeyWord KeyWord { get; set; }
        [DisplayName("Путь к папке с фотографиями в галерею")]
        public string PathToGallery { get; set; }
        [DisplayName("Путь к 1 ролику")]
        public string PathToVideo1 { get; set; }
        [DisplayName("Путь ко 2 ролику")]
        public string PathToVideo2 { get; set; }
        [DisplayName("Путь к 3 ролику")]
        public string PathToVideo3 { get; set; }

        [DisplayName("Масштаб маленькой фотки")]
        public string ShortImgScale { get; set; }
        [DisplayName("Х маленькой фотки")]
        public string ShortImgX { get; set; }
        [DisplayName("Y маленькой фотки")]
        public string ShortImgY { get; set; }
        [DisplayName("Текст мелкой фотки")]
        public string ShortStory { get; set; }
        [DisplayName("Фотка для маленького превью")]
        public string ShortFotoPreview { get; set; }

        [DisplayName("Масштаб средней фотки")]
        public string MiddleImgScale { get; set; }
        [DisplayName("Х средней фотки")]
        public string MiddleImgX { get; set; }
        [DisplayName("Y средней фотки")]
        public string MiddleImgY { get; set; }
        [DisplayName("Текст средней фотки")]
        public string MiddleStory { get; set; }
        [DisplayName("Фотка для среднего превью")]
        public string MiddleFotoPreview { get; set; }

        [DisplayName("Масштаб широкой фотки")]
        public string WideImgScale { get; set; }
        [DisplayName("Х широкой фотки")]
        public string WideImgX { get; set; }
        [DisplayName("Y широкой фотки")]
        public string WideImgY { get; set; }
        [DisplayName("Текст широкой фотки")]
        public string WideStory { get; set; }
        [DisplayName("Фотка для широкого превью")]
        public string WideFotoPreview { get; set; }
    }
}
