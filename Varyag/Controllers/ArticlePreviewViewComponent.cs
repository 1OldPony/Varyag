using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;
using Varyag.Models.ViewModels;

namespace Varyag.Controllers
{
    public class ArticlePreviewViewComponent : ViewComponent
    {
        private readonly VaryagContext db;
        private readonly IHostingEnvironment _Environment;

        public ArticlePreviewViewComponent(VaryagContext context, IHostingEnvironment appEnvironment)
        {
            db = context;
            _Environment = appEnvironment;
        }

        public async Task<IViewComponentResult> InvokeAsync(IFormFile newsFoto,
            string fotoType, string shortFotoScale, string shortFotoX, string shortFotoY,
            string shortStory, string middleFotoScale, string middleFotoX, string middleFotoY,
            string middleStory, string wideFotoScale, string wideFotoX, string wideFotoY,
            string wideStory, int? newId)
        {
            string[] names = new string[] { "short.jpg", "middle.jpg", "wide.jpg" };
            if (newsFoto != null)
            {
                switch (fotoType)
                {
                    case "общая":
                        foreach (var item in names)
                        {
                            await SaveImgAsync(item, newsFoto);
                        }
                        break;
                    case "мелкая":
                        await SaveImgAsync(names[0], newsFoto);
                        break;
                    case "средняя":
                        await SaveImgAsync(names[1], newsFoto);
                        break;
                    case "широкая":
                        await SaveImgAsync(names[2], newsFoto);
                        break;
                    default:
                        break;
                }
            }

            return View();
        }


        private async Task SaveImgAsync(string name, IFormFile newsFoto)
        {
            string path = Path.Combine(_Environment.WebRootPath, "images", "temp");
            LittleHelper.DirectoryExistCheck(path);

            using (var fileStream = new FileStream(path + "/" + name, FileMode.Create))
            {
                await newsFoto.CopyToAsync(fileStream);
            }
        }
    }
}