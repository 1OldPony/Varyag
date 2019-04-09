using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

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

        public List<Foto> NewsFotos  { get; set; }
    }
}
