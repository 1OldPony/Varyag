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
                    fotoPath = "/" + pathParts[(pathParts.Length - 1) - 3] + "/" + pathParts[(pathParts.Length - 1) - 2] + "/"
                        + pathParts[(pathParts.Length - 1) - 1] + "/" + pathParts[(pathParts.Length - 1)];
                    break;
                case "gallery":
                    fotoPath = "/" + pathParts[(pathParts.Length - 1) - 4] + "/" + pathParts[(pathParts.Length - 1) - 3] + "/" + pathParts[(pathParts.Length - 1) - 2] + "/"
                        + pathParts[(pathParts.Length - 1) - 1] + "/" + pathParts[(pathParts.Length - 1)];
                    break;
                case "articlePreview":
                    fotoPath = "/" + pathParts[(pathParts.Length - 1) - 5] + "/" + pathParts[(pathParts.Length - 1) - 4] + "/" + pathParts[(pathParts.Length - 1) - 3] + "/"
                        + pathParts[(pathParts.Length - 1) - 2] + "/" + pathParts[(pathParts.Length - 1) - 1] + "/" + pathParts[(pathParts.Length - 1)];
                    break;
                case "frontFoto":
                    fotoPath = "/" + pathParts[(pathParts.Length - 1) - 3] + "/" + pathParts[(pathParts.Length - 1) - 2] + "/"
                        + pathParts[(pathParts.Length - 1) - 1] + "/" + pathParts[(pathParts.Length - 1)];
                    break;
                case "articleFolder":
                    fotoPath = pathParts[(pathParts.Length - 2)];
                    break;
                default:
                    break;
            }

            return fotoPath;
        }

        public static void DirectoryExistCheck(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void DeleteFiles(string pathToDirectory,bool deleteDir)
        {
            if (Directory.Exists(pathToDirectory))
            {
                string[] files = Directory.GetFiles(pathToDirectory);

                foreach (var file in files)
                {
                    File.Delete(file);
                }
                if (deleteDir)
                {
                    Directory.Delete(pathToDirectory);
                }
            }
        }

        public static void MoveTo(string pathFrom, string pathTo)
        {
            File.Delete(pathTo);
            File.Move(pathFrom, pathTo);
        }

        public static async Task SaveInTxt(string pathToText, string text)
        {
            using (var stream = new StreamWriter(pathToText, false, System.Text.Encoding.Default))
            {
                await stream.WriteLineAsync(text);
                stream.Close();
            }
        }

        public static async Task<string> TextFromPTG(string PTG)
        {
            string path = Path.Combine(PTG, "Text.txt");
            using (StreamReader stream = new StreamReader(path))
            {
                string text = await stream.ReadToEndAsync();
                stream.Close();
                return text;
            }
        }

        public static List<NewsViewModel> NewsToSortedViewModel (List<News> news)
        {
            List<NewsViewModel> newsIntDate = new List<NewsViewModel>();

            foreach (var item in news)
            {
                string[] stringDate = item.NewsDate.Split('.');
                int newsDate = int.Parse(stringDate[2] + stringDate[1] + stringDate[0]);
                string[] months = { "ЯНВАРЬ", "ФЕВРАЛЬ", "МАРТ", "АПРЕЛЬ", "МАЙ", "ИЮНЬ", "ИЮЛЬ", "АВГУСТ", "СЕНТЯБРЬ", "ОКТЯБРЬ", "НОЯБРЬ", "ДЕКАБРЬ" };
                string month = string.Concat(months[int.Parse(item.NewsDate.Substring(3, 2)) - 1], " ", item.NewsDate.Substring(6, 4));



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
                    PathToVideo1 = item.PathToVideo1,
                    PathToVideo2 = item.PathToVideo2,
                    PathToVideo3 = item.PathToVideo3,
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
                    NewsDate = newsDate,
                    NewsDatePreview = month,
                    LinkedProjectNames = item.LinkedProjectNames
                });
            }
            newsIntDate =newsIntDate.OrderByDescending(n => n.NewsDate).ToList();

            return newsIntDate;
        }

        public static List<ProjectPublicViewModel> ProjectsToSortedViewModel(List<Project> projects, bool boats, string lengthSort)
        {
            List<ProjectPublicViewModel> orderedProjects = new List<ProjectPublicViewModel>();
            foreach (var item in projects)
            {
                if (boats)
                {
                    char[] numbers = item.Length.ToCharArray();
                    string number="";

                    if (numbers.Length < 2)
                    {
                        number = string.Concat(numbers[0], '0');
                    }
                    else
                    {
                        foreach (var symbol in numbers)
                        {
                            if (symbol != '.' && symbol != ',')
                                number = string.Concat(number, symbol.ToString());
                            else
                                continue;
                        }
                    }

                    orderedProjects.Add(new ProjectPublicViewModel
                    {
                        Order = int.Parse(number),
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
                        Route = item.Route,
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
                else
                {
                    string number = "";

                    if (!item.Name.Contains('"') || !item.Name.Contains('-'))
                    {
                        char[] numbers = item.Length.ToCharArray();

                        if (numbers.Length < 2)
                        {
                            number = string.Concat(numbers[0], "0");
                        }
                        else
                        {
                            int pointCounter = 0;
                            foreach (var symbol in numbers)
                            {
                                if (symbol != '.' && symbol != ',')
                                    number = string.Concat(number, symbol.ToString());
                                else
                                    pointCounter++;
                                continue;
                            }
                            if (pointCounter == 0)
                            {
                                number = string.Concat(number, "0");
                            }
                        }
                    }
                    else
                    {
                        string[] parts1 = item.Name.Split('"');
                        string[] parts2 = parts1[1].Split('-');
                        char[] numbers = parts2[1].ToCharArray();
                        number = string.Concat(numbers[0], numbers[1]);
                    }
                    orderedProjects.Add(new ProjectPublicViewModel
                    {
                        Order = int.Parse(number),
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
                        Route = item.Route,
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
            }
            if (lengthSort == "Up")
            {
                orderedProjects = orderedProjects.OrderBy(x => x.Order).ToList();
            }
            else
            {
                orderedProjects = orderedProjects.OrderByDescending(x => x.Order).ToList();
            }
            return orderedProjects;
        }

        public static string UrlGiver (string iframe)
        {
            if (iframe.ToCharArray().Contains('\"'))
            {
                string[] codeParts = iframe.Split(new char[] { '\"' }, StringSplitOptions.RemoveEmptyEntries);

                if (iframe.Contains("vk.com"))
                    return codeParts[1];
                else
                    return codeParts[5];
            }
            else
                return iframe;
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