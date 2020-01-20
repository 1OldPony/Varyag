using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Varyag.Models.ViewModels
{
    public class EditorModel
    {
        public string shortFotoScale { get; set; }
        public string shortFotoX { get; set; }
        public string shortFotoY { get; set; }
        public string shortStory { get; set; }

        public string middleFotoScale { get; set; }
        public string middleFotoX { get; set; }
        public string middleFotoY { get; set; }
        public string middleStory { get; set; }

        public string wideFotoScale { get; set; }
        public string wideFotoX { get; set; }
        public string wideFotoY { get; set; }
        public string wideStory { get; set; }

        public string headerRefresh { get; set; }
        public string mainStoryRefresh { get; set; }
        public string keyWordRefresh { get; set; }
        [DataType(DataType.Date)]
        public DateTime newsDateRefresh { get; set; }
    }
}
