using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Varyag.Models
{
    public class LittleHelper
    {
        public static string PercentToCoordinates(string value)
        {
            char[] x = value.ToCharArray();
            string coordinates = "";
            for (int i = 0; i <= x.Length - 2; i++)
            {
                coordinates = coordinates + x[i].ToString();
            }
            return coordinates;
        }


        public static string PathAdapter(string path, string forWhat)
        {
            string[] pathParts = path.Split(new char[] { '\\' });
            string fotoPath = "";
            switch (forWhat)
            {
                case "preview":
                    fotoPath = "../" + pathParts[(pathParts.Length - 1) - 3] + "/" + pathParts[(pathParts.Length - 1) - 2] + "/"
                        + pathParts[(pathParts.Length - 1) - 1] + "/" + pathParts[(pathParts.Length - 1)];
                    break;
                case "gallery":
                    fotoPath = "~/" + pathParts[(pathParts.Length - 1) - 4] + "/" + pathParts[(pathParts.Length - 1) - 3] + "/" + pathParts[(pathParts.Length - 1) - 2] + "/"
                        + pathParts[(pathParts.Length - 1) - 1] + "/" + pathParts[(pathParts.Length - 1)];
                    break;
                case "frontFoto":
                    fotoPath = "/" + pathParts[(pathParts.Length - 1) - 3] + "/" + pathParts[(pathParts.Length - 1) - 2] + "/"
                        + pathParts[(pathParts.Length - 1) - 1] + "/" + pathParts[(pathParts.Length - 1)];
                    break;
                default:
                    break;
            }

            return fotoPath;
        }

        public static void DeleteFiles(string path,bool deleteDir)
        {
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                File.Delete(file);
            }
            if (deleteDir)
            {
                Directory.Delete(path);
            }
        }

        public static void MoveTo(string pathFrom, string pathTo)
        {
            File.Delete(pathTo);
            File.Move(pathFrom, pathTo);
        }

        public static List<NewsViewModel> NewsToSortedViewModel (List<News> news)
        {
            List<NewsViewModel> newsIntDate = new List<NewsViewModel>();

            foreach (var item in news)
            {
                string[] stringDate = item.NewsDate.Split('.');
                int newsDate = int.Parse(stringDate[2] + stringDate[1] + stringDate[0]);

                newsIntDate.Add(new NewsViewModel
                {
                    Header = item.Header,
                    KeyWord = item.KeyWord,
                    MainStory = item.MainStory,
                    MiddleFotoPreview = item.MiddleFotoPreview,
                    MiddleImgScale = item.MiddleImgScale,
                    MiddleImgX = item.MiddleImgX,
                    MiddleImgY = item.MiddleImgY,
                    MiddleStory = item.MiddleStory,
                    NewsId = item.NewsId,
                    PathToGallery = item.PathToGallery,
                    ShortFotoPreview = item.ShortFotoPreview,
                    ShortImgScale = item.ShortImgScale,
                    ShortImgX = item.ShortImgX,
                    ShortImgY = item.ShortImgY,
                    ShortStory = item.ShortStory,
                    WideFotoPreview = item.WideFotoPreview,
                    WideImgScale = item.WideImgScale,
                    WideImgX = item.WideImgX,
                    WideImgY = item.WideImgY,
                    WideStory = item.WideStory,
                    NewsDate = newsDate
                });
            }

            newsIntDate=newsIntDate.OrderByDescending(n => n.NewsDate).ToList();

            return newsIntDate;
        }

        public static List<ProjectPublicViewModel> ProjectsToSortedViewModel(List<Project> projects)
        {
            List<ProjectPublicViewModel> orderedProjects = new List<ProjectPublicViewModel>();
            foreach (var item in projects)
            {
                string[] parts1 = item.Name.Split('"');
                string[] parts2 = parts1[1].Split('-');
                orderedProjects.Add(new ProjectPublicViewModel
                {
                    Order = int.Parse(parts2[1]),
                    BoatRow = item.BoatRow,
                    BoatSail = item.BoatSail,
                    BoatTraditional = item.BoatTraditional,
                    BoatYal = item.BoatYal,
                    Botik = item.Botik,
                    Deep = item.Deep,
                    Description = item.Description,
                    EnginePower = item.EnginePower,
                    FreshWaterCap = item.FreshWaterCap,
                    FuelCap = item.FuelCap,
                    KaterCabin = item.KaterCabin,
                    KaterFish = item.KaterFish,
                    KaterPass = item.KaterPass,
                    KaterProject = item.KaterProject,
                    KaterRow = item.KaterRow,
                    LadyaProject = item.LadyaProject,
                    LadyaRow = item.LadyaRow,
                    LadyaSail = item.LadyaSail,
                    Length = item.Length,
                    MainFoto = item.MainFoto,
                    MaketCinema = item.MaketCinema,
                    MaketDesign = item.MaketDesign,
                    MaketMuseum = item.MaketMuseum,
                    MaketStudy = item.MaketStudy,
                    Mass = item.Mass,
                    Motosailer = item.Motosailer,
                    Name = item.Name,
                    NumberOfOars = item.NumberOfOars,
                    PassengerCap = item.PassengerCap,
                    Price = item.Price,
                    ProjectID = item.ProjectID,
                    SailArea = item.SailArea,
                    SailboatHistorical = item.SailboatHistorical,
                    SailboatProject = item.SailboatProject,
                    SailboatStudy = item.SailboatStudy,
                    ShipSheme = item.ShipSheme,
                    ShipShemeFull = item.ShipShemeFull,
                    Shvertbot = item.Shvertbot,
                    SleepingAreas = item.SleepingAreas,
                    Speed = item.Speed,
                    Volume = item.Volume,
                    Windth = item.Windth,
                    Yacht = item.Yacht
                });
            }

            orderedProjects = orderedProjects.OrderBy(x => x.Order).ToList();

            return orderedProjects;
        }

        public static string UrlGiver (string iframe)
        {
            string[] codeParts = iframe.Split(new char[] { '\"' }, StringSplitOptions.RemoveEmptyEntries);

            if (iframe.Contains("vk.com"))
                return (codeParts[1]);
            else
                return (codeParts[5]);
        }

        public static int NullCounter(params string[] parameters)
        {
            int nullCount = 0;
            foreach (var item in parameters)
            {
                if (item==null)
                {
                    nullCount++;
                }
            }
            return nullCount;
        }
    }
}