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
    }
}
