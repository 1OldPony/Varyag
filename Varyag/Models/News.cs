using System.Collections.Generic;
using System.ComponentModel;

namespace Varyag.Models
{
    public class News
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
        [DisplayName("Главная фотка")]
        public byte[] NewsMainFoto { get; set; }

        public List<Foto> NewsFotos { get; set; }
    }

    public enum NewsKeyWord
    {
        Жизнь_кораблей, СМИ, Новые_корабли
    }
}
