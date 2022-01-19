﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Varyag.Models;
using Varyag.Models.ViewModels;

namespace Varyag.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly VaryagContext _context;
        private readonly IHostingEnvironment _Environment;

        public ArticlesController(VaryagContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _Environment = appEnvironment;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Article.ToListAsync());
        }

        public async Task<IActionResult> FillArticle(int? articleId, string pathToGall, string currentTextPart, IFormFileCollection fotos, IFormFileCollection preview, string articleFolder, string articleName,
            int? partsCounter, string actionType, string articleRoute, string PathToGallery1, string PathToGallery2, string PathToGallery3, string PathToGallery4, string PathToGallery5, string PathToGallery6, 
            string PathToGallery7, string PathToGallery8, string PathToGallery9, string PathToGallery10, string PathToGallery11, string PathToGallery12, string PathToGallery13, string PathToGallery14, string PathToGallery15, 
            string articleType, string shortFotoScale, string shortFotoX, string shortFotoY, string shortStory, string middleFotoScale, bool deleteGallery,
            string middleFotoX, string middleFotoY, string middleStory, string wideFotoScale, string wideFotoX, string wideFotoY, string wideStory)
        {
            string path = Path.Combine(_Environment.WebRootPath, "images", "articles");
            LittleHelper.DirectoryExistCheck(path);

            string fold = articleFolder;
            if (pathToGall != null)
            {
                fold = LittleHelper.PathAdapter(pathToGall, "articleFolder");
            }

            string folderPath;
            if (fold == null)
            {
                for (int i = 1; i < 100000; i++)
                {
                    folderPath = Path.Combine(path, "article" + i.ToString());
                    if (!Directory.Exists(folderPath))
                    {
                        path = folderPath;
                        LittleHelper.DirectoryExistCheck(path);
                        fold = "article" + i.ToString();
                        break;
                    }
                }
            }
            else
            {
                path = Path.Combine(path, fold);
            }

            path = Path.Combine(path, partsCounter.ToString());
            if (!Directory.Exists(path))
            {
                LittleHelper.DirectoryExistCheck(path);
            }
            else
            {
                if (fotos.Count != 0)
                {
                    string[] files = Directory.GetFiles(path);
                    foreach (var file in files)
                    {
                        string[] extension = file.Split('.');
                        if (extension[1] != "txt")
                        {
                            System.IO.File.Delete(file);
                        }
                    }
                }
            }
            
            if (fotos.Count()!=0)
            {
                for (int i = 0; i <= (fotos.Count() - 1); i++)
                {
                    string name = "ВерфьВаряг" + "(" + (i + 1).ToString() + ").jpg";
                    using (var fileStream = new FileStream(path + "/" + name, FileMode.Create))
                    {
                        await fotos[i].CopyToAsync(fileStream);
                    }
                }
            }

            string pathToText = Path.Combine(path, "Text.txt");
            if (currentTextPart == "<p>-</p>") 
            {
                await LittleHelper.SaveInTxt(pathToText, null);
            }
            else if (currentTextPart != null)
            {
                await LittleHelper.SaveInTxt(pathToText, currentTextPart);
            }

            if (deleteGallery)
            {
                if (path != null)
                {
                    //LittleHelper.DeleteFiles(path + "\\preview", true);
                    string[] files = Directory.GetFiles(path);
                    foreach (var file in files)
                    {
                        string[] extension = file.Split('.');
                        if (extension[1] != "txt")
                        {
                            System.IO.File.Delete(file);
                        }
                    }
                }
                ////ClearGallery(path);
                //LittleHelper.DeleteFiles(path, true);
                path = null;
            }

            if (actionType!="Edit")
            {
                return RedirectToAction("Create", new
                {
                    partNumber = partsCounter,
                    pathForPartGallery = path,
                    folder = fold,
                    name = articleName,
                    route = articleRoute,
                    type = articleType,
                    //PTPREVIEW = previewPath,
                    PTG1 = PathToGallery1,
                    PTG2 = PathToGallery2,
                    PTG3 = PathToGallery3,
                    PTG4 = PathToGallery4,
                    PTG5 = PathToGallery5,
                    PTG6 = PathToGallery6,
                    PTG7 = PathToGallery7,
                    PTG8 = PathToGallery8,
                    PTG9 = PathToGallery9,
                    PTG10 = PathToGallery10,
                    PTG11 = PathToGallery11,
                    PTG12 = PathToGallery12,
                    PTG13 = PathToGallery13,
                    PTG14 = PathToGallery14,
                    PTG15 = PathToGallery15,
                    shFotoScale=shortFotoScale,
                    shFotoX = shortFotoX,
                    shFotoY = shortFotoY,
                    shStory = shortStory,
                    midFotoScale = middleFotoScale,
                    midFotoX = middleFotoX,
                    midFotoY = middleFotoY,
                    midStory = middleStory,
                    wFotoScale = wideFotoScale,
                    wFotoX = wideFotoX,
                    wFotoY = wideFotoY,
                    wStory = wideStory
                });
            }
            else
            {
                return RedirectToAction("Edit", new
                {
                    id= articleId,
                    partNumber = partsCounter,
                    pathForPartGallery = path,
                    folder = fold,
                    name = articleName,
                    route = articleRoute,
                    type = articleType,
                    PTG1 = PathToGallery1,
                    PTG2 = PathToGallery2,
                    PTG3 = PathToGallery3,
                    PTG4 = PathToGallery4,
                    PTG5 = PathToGallery5,
                    PTG6 = PathToGallery6,
                    PTG7 = PathToGallery7,
                    PTG8 = PathToGallery8,
                    PTG9 = PathToGallery9,
                    PTG10 = PathToGallery10,
                    PTG11 = PathToGallery11,
                    PTG12 = PathToGallery12,
                    PTG13 = PathToGallery13,
                    PTG14 = PathToGallery14,
                    PTG15 = PathToGallery15,
                    shFotoScale = shortFotoScale,
                    shFotoX = shortFotoX,
                    shFotoY = shortFotoY,
                    shStory = shortStory,
                    midFotoScale = middleFotoScale,
                    midFotoX = middleFotoX,
                    midFotoY = middleFotoY,
                    midStory = middleStory,
                    wFotoScale = wideFotoScale,
                    wFotoX = wideFotoX,
                    wFotoY = wideFotoY,
                    wStory = wideStory
                });
            }
        }


        //[HttpPost]
        public void SaveTempFoto(IFormFile newsFoto, string fotoType)
        {
            string[] names = new string[] { "short.jpg", "middle.jpg", "wide.jpg" };
            if (newsFoto != null)
            {
                switch (fotoType)
                {
                    case "общая":
                        foreach (var item in names)
                        {
                            SaveImgAsync(item, newsFoto);
                        }
                        break;
                    case "мелкая":
                        SaveImgAsync(names[0], newsFoto);
                        break;
                    case "средняя":
                        SaveImgAsync(names[1], newsFoto);
                        break;
                    case "широкая":
                        SaveImgAsync(names[2], newsFoto);
                        break;
                    default:
                        break;
                }
            }
        }
        private void SaveImgAsync(string name, IFormFile newsFoto)
        {
            string path = Path.Combine(_Environment.WebRootPath, "images", "temp");
            LittleHelper.DirectoryExistCheck(path);

            using (var fileStream = new FileStream(path + "/" + name, FileMode.Create))
            {
                newsFoto.CopyTo(fileStream);
            }
        }
        //public IActionResult PreviewRefresh()
        //{
        //    return PartialView("Default");
        //    //return View("Default"); 
        //}

        //public async void FillPreview(IFormFileCollection preview, string previewPath)
        //{
        //    string name = "ВерфьВаряг(превью).jpg";
        //    using (var fileStream = new FileStream(previewPath + "/" + name, FileMode.Create))
        //    {
        //        await preview[0].CopyToAsync(fileStream);
        //    }
        //}

        // GET: Articles/Create
        public IActionResult Create(int? partNumber, string pathForPartGallery, string folder, string name, string route, string PTPREVIEW, string PTG1,string type,
            string PTG2, string PTG3, string PTG4, string PTG5, string PTG6, string PTG7, string PTG8, string PTG9, string PTG10, string PTG11, string PTG12, 
            string PTG13, string PTG14, string PTG15, string shFotoScale, string shFotoX, string shFotoY, string shStory, string midFotoScale, 
            string midFotoX, string midFotoY, string midStory, string wFotoScale, string wFotoX, string wFotoY, string wStory)
        {
            ViewBag.RefreshEditor = new EditorModel()
            {
                shortFotoScale = shFotoScale,
                shortFotoX = shFotoX,
                shortFotoY = shFotoY,
                shortStory = shStory,
                middleFotoScale = midFotoScale,
                middleFotoX = midFotoX,
                middleFotoY = midFotoY,
                middleStory = midStory,
                wideFotoScale = wFotoScale,
                wideFotoX = wFotoX,
                wideFotoY = wFotoY,
                wideStory = wStory
            };

            if (PTPREVIEW!=null)
            {
                ViewBag.PathForPreview = PTPREVIEW;
            }
            if (PTG1!=null)
            {
                ViewBag.Text1 = LittleHelper.TextFromPTG(PTG1).Result;
                ViewBag.PathForPartGallery1 = PTG1;
            }
            if (PTG2 != null)
            {
                ViewBag.Text2 = LittleHelper.TextFromPTG(PTG2).Result;
                ViewBag.PathForPartGallery2 = PTG2;
            }
            if (PTG3 != null)
            {
                ViewBag.Text = LittleHelper.TextFromPTG(PTG3).Result;
                ViewBag.PathForPartGallery3 = PTG3;
            }
            if (PTG4 != null)
            {
                ViewBag.Text4 = LittleHelper.TextFromPTG(PTG4).Result;
                ViewBag.PathForPartGallery4 = PTG4;
            }
            if (PTG5 != null)
            {
                ViewBag.Text = LittleHelper.TextFromPTG(PTG5).Result;
                ViewBag.PathForPartGallery5 = PTG5;
            }
            if (PTG6 != null)
            {
                ViewBag.Text6 = LittleHelper.TextFromPTG(PTG6).Result;
                ViewBag.PathForPartGallery6 = PTG6;
            }
            if (PTG7 != null)
            {
                ViewBag.Text7 = LittleHelper.TextFromPTG(PTG7).Result;
                ViewBag.PathForPartGallery7 = PTG7;
            }
            if (PTG8 != null)
            {
                ViewBag.Text8 = LittleHelper.TextFromPTG(PTG8).Result;
                ViewBag.PathForPartGallery8 = PTG8;
            }
            if (PTG9 != null)
            {
                ViewBag.Text9 = LittleHelper.TextFromPTG(PTG9).Result;
                ViewBag.PathForPartGallery9 = PTG9;
            }
            if (PTG10 != null)
            {
                ViewBag.Text10 = LittleHelper.TextFromPTG(PTG10).Result;
                ViewBag.PathForPartGallery10 = PTG10;
            }
            if (PTG11 != null)
            {
                ViewBag.Text11 = LittleHelper.TextFromPTG(PTG11).Result;
                ViewBag.PathForPartGallery11 = PTG11;
            }
            if (PTG12 != null)
            {
                ViewBag.Text12 = LittleHelper.TextFromPTG(PTG12).Result;
                ViewBag.PathForPartGallery12 = PTG12;
            }
            if (PTG13 != null)
            {
                ViewBag.Text13 = LittleHelper.TextFromPTG(PTG13).Result;
                ViewBag.PathForPartGallery13 = PTG13;
            }
            if (PTG14 != null)
            {
                ViewBag.Text14 = LittleHelper.TextFromPTG(PTG14).Result;
                ViewBag.PathForPartGallery14 = PTG14;
            }
            if (PTG15 != null)
            {
                ViewBag.Text15 = LittleHelper.TextFromPTG(PTG15).Result;
                ViewBag.PathForPartGallery15 = PTG15;
            }

            switch (partNumber)
            {
                case 1:
                    ViewBag.Text1 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery1 = pathForPartGallery;
                    break;
                case 2:
                    ViewBag.Text2 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery2 = pathForPartGallery;
                    break;
                case 3:
                    ViewBag.Text3 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery3 = pathForPartGallery;
                    break;
                case 4:
                    ViewBag.Text4 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery4 = pathForPartGallery;
                    break;
                case 5:
                    ViewBag.Text5 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery5 = pathForPartGallery;
                    break;
                case 6:
                    ViewBag.Text6 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery6 = pathForPartGallery;
                    break;
                case 7:
                    ViewBag.Text7 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery7 = pathForPartGallery;
                    break;
                case 8:
                    ViewBag.Text8 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery8 = pathForPartGallery;
                    break;
                case 9:
                    ViewBag.Text9 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery9 = pathForPartGallery;
                    break;
                case 10:
                    ViewBag.Text10 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery10 = pathForPartGallery;
                    break;
                case 11:
                    ViewBag.Text11 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery11 = pathForPartGallery;
                    break;
                case 12:
                    ViewBag.Text12 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery12 = pathForPartGallery;
                    break;
                case 13:
                    ViewBag.Text13 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery13 = pathForPartGallery;
                    break;
                case 14:
                    ViewBag.Text14 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery14 = pathForPartGallery;
                    break;
                case 15:
                    ViewBag.Text15 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    ViewBag.PathForPartGallery15 = pathForPartGallery;
                    break;
                default:
                    break;
            }

            ViewBag.Folder = folder;
            ViewBag.Name = name;
            ViewBag.Route = route;
            ViewBag.Type = type;
            if (partNumber!=null)
            {
                partNumber++;
                ViewBag.PartNumber = partNumber;
            }
            else
            {
                ViewBag.PartNumber = 1;
            }

            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Article article)
        {
            string pathTemp = Path.Combine(_Environment.WebRootPath, "images", "temp");
            string pathForFinalTemp = Path.Combine(article.PathToGallery1, "preview");
            string shortPreview = "", middlePreview = "", widePreview = "";

            LittleHelper.DirectoryExistCheck(pathForFinalTemp);

            string[] fotos = new string[] { "short.jpg", "middle.jpg", "wide.jpg" };

            foreach (var foto in fotos)
            {
                string pathStart = Path.Combine(pathTemp, foto);
                string pathEnd = Path.Combine(pathForFinalTemp, foto);

                System.IO.File.Move(pathStart, pathEnd);

                switch (foto)
                {
                    case "short.jpg":
                        shortPreview = LittleHelper.PathAdapter(pathEnd, "articlePreview");
                        break;
                    case "middle.jpg":
                        middlePreview = LittleHelper.PathAdapter(pathEnd, "articlePreview");
                        break;
                    case "wide.jpg":
                        widePreview = LittleHelper.PathAdapter(pathEnd, "articlePreview");
                        break;
                    default:
                        break;
                }
            }
            //if (true)
            //{

            //}
            article.ShortFotoPreview = shortPreview;
            article.MiddleFotoPreview = middlePreview;
            article.WideFotoPreview = widePreview;
            article.ShortImgScale = article.ShortImgScale + "%";
            article.ShortImgX = article.ShortImgX + "%";
            article.ShortImgY = article.ShortImgY + "%";
            article.MiddleImgScale = article.MiddleImgScale + "%";
            article.MiddleImgX = article.MiddleImgX + "%";
            article.MiddleImgY = article.MiddleImgY + "%";
            article.WideImgScale = article.WideImgScale + "%";
            article.WideImgX = article.WideImgX + "%";
            article.WideImgY = article.WideImgY + "%";

            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id, int? partNumber, string pathForPartGallery, string folder, string name, string route, string PTG1, string PTG2, string PTG3, string PTG4,
            string PTG5, string PTG6, string PTG7, string PTG8, string PTG9, string PTG10, string PTG11, string PTG12, string PTG13, string PTG14, string PTG15, string type, string shFotoScale,
            string shFotoX, string shFotoY, string shStory, string midFotoScale,string midFotoX, string midFotoY, string midStory, string wFotoScale, string wFotoX, string wFotoY, string wStory)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewBag.RefreshEditor = new EditorModel()
            {
                shortFotoScale = shFotoScale,
                shortFotoX = shFotoX,
                shortFotoY = shFotoY,
                shortStory = shStory,
                middleFotoScale = midFotoScale,
                middleFotoX = midFotoX,
                middleFotoY = midFotoY,
                middleStory = midStory,
                wideFotoScale = wFotoScale,
                wideFotoX = wFotoX,
                wideFotoY = wFotoY,
                wideStory = wStory
            };

            if (PTG1 != null)
            {
                ViewBag.Text1 = LittleHelper.TextFromPTG(PTG1).Result;
                ViewBag.PathForPartGallery1 = PTG1;
            }
            if (PTG2 != null)
            {
                ViewBag.Text2 = LittleHelper.TextFromPTG(PTG2).Result;
                ViewBag.PathForPartGallery2 = PTG2;
            }
            if (PTG3 != null)
            {
                ViewBag.Text3 = LittleHelper.TextFromPTG(PTG3).Result;
                ViewBag.PathForPartGallery3 = PTG3;
            }
            if (PTG4 != null)
            {
                ViewBag.Text4 = LittleHelper.TextFromPTG(PTG4).Result;
                ViewBag.PathForPartGallery4 = PTG4;
            }
            if (PTG5 != null)
            {
                ViewBag.Text5 = LittleHelper.TextFromPTG(PTG5).Result;
                ViewBag.PathForPartGallery5 = PTG5;
            }
            if (PTG6 != null)
            {
                ViewBag.Text6 = LittleHelper.TextFromPTG(PTG6).Result;
                ViewBag.PathForPartGallery6 = PTG6;
            }
            if (PTG7 != null)
            {
                ViewBag.Text7 = LittleHelper.TextFromPTG(PTG7).Result;
                ViewBag.PathForPartGallery7 = PTG7;
            }
            if (PTG8 != null)
            {
                ViewBag.Text8 = LittleHelper.TextFromPTG(PTG8).Result;
                ViewBag.PathForPartGallery8 = PTG8;
            }
            if (PTG9 != null)
            {
                ViewBag.Text9 = LittleHelper.TextFromPTG(PTG9).Result;
                ViewBag.PathForPartGallery9 = PTG9;
            }
            if (PTG10 != null)
            {
                ViewBag.Text10 = LittleHelper.TextFromPTG(PTG10).Result;
                ViewBag.PathForPartGallery10 = PTG10;
            }
            if (PTG11 != null)
            {
                ViewBag.Text11 = LittleHelper.TextFromPTG(PTG11).Result;
                ViewBag.PathForPartGallery11 = PTG11;
            }
            if (PTG12 != null)
            {
                ViewBag.Text12 = LittleHelper.TextFromPTG(PTG12).Result;
                ViewBag.PathForPartGallery12 = PTG12;
            }
            if (PTG13 != null)
            {
                ViewBag.Text13 = LittleHelper.TextFromPTG(PTG13).Result;
                ViewBag.PathForPartGallery13 = PTG13;
            }
            if (PTG14 != null)
            {
                ViewBag.Text14 = LittleHelper.TextFromPTG(PTG14).Result;
                ViewBag.PathForPartGallery14 = PTG14;
            }
            if (PTG15 != null)
            {
                ViewBag.Text15 = LittleHelper.TextFromPTG(PTG15).Result;
                ViewBag.PathForPartGallery15 = PTG15;
            }

            switch (partNumber)
            {
                case 1:
                    if (pathForPartGallery!=null)
                    {
                        ViewBag.Text1 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery1 = pathForPartGallery;
                    break;
                case 2:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text2 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery2 = pathForPartGallery;
                    break;
                case 3:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text3 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery3 = pathForPartGallery;
                    break;
                case 4:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text4 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery4 = pathForPartGallery;
                    break;
                case 5:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text5 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery5 = pathForPartGallery;
                    break;
                case 6:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text6 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery6 = pathForPartGallery;
                    break;
                case 7:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text7 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery7 = pathForPartGallery;
                    break;
                case 8:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text8 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery8 = pathForPartGallery;
                    break;
                case 9:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text9 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery9 = pathForPartGallery;
                    break;
                case 10:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text10 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery10 = pathForPartGallery;
                    break;
                case 11:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text11 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery11 = pathForPartGallery;
                    break;
                case 12:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text12 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery12 = pathForPartGallery;
                    break;
                case 13:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text13 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery13 = pathForPartGallery;
                    break;
                case 14:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text14 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery14 = pathForPartGallery;
                    break;
                case 15:
                    if (pathForPartGallery != null)
                    {
                        ViewBag.Text15 = LittleHelper.TextFromPTG(pathForPartGallery).Result;
                    }
                    ViewBag.PathForPartGallery15 = pathForPartGallery;
                    break;
                default:
                    break;
            }

            ViewBag.ShortImgX = LittleHelper.PercentToCoordinates(article.ShortImgX);
            ViewBag.ShortImgY = LittleHelper.PercentToCoordinates(article.ShortImgY);
            ViewBag.ShortImgScale = LittleHelper.PercentToCoordinates(article.ShortImgScale);
            ViewBag.MiddleImgX = LittleHelper.PercentToCoordinates(article.MiddleImgX);
            ViewBag.MiddleImgY = LittleHelper.PercentToCoordinates(article.MiddleImgY);
            ViewBag.MiddleImgScale = LittleHelper.PercentToCoordinates(article.MiddleImgScale);
            ViewBag.WideImgX = LittleHelper.PercentToCoordinates(article.WideImgX);
            ViewBag.WideImgY = LittleHelper.PercentToCoordinates(article.WideImgY);
            ViewBag.WideImgScale = LittleHelper.PercentToCoordinates(article.WideImgScale);

            ViewBag.Folder = folder;
            ViewBag.Name = name;
            ViewBag.Route = route;
            ViewBag.Type = type;

            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            string pathTemp = Path.Combine(_Environment.WebRootPath, "images", "temp");
            string pathForFinalTemp = Path.Combine(article.PathToGallery1, "preview");
            LittleHelper.DirectoryExistCheck(pathForFinalTemp);
            //string shortPreview = "", middlePreview = "", widePreview = "";

            string[] files = Directory.GetFiles(pathTemp);
            if (files.Count()!=0)
            {

                string[] fotos = new string[] { "short.jpg", "middle.jpg", "wide.jpg" };

                foreach (var foto in fotos)
                {
                    string pathStart = Path.Combine(pathTemp, foto);
                    string pathEnd = Path.Combine(pathForFinalTemp, foto);

                    if (System.IO.File.Exists(pathStart))
                    {
                        if (System.IO.File.Exists(pathEnd))
                        {                     
                            System.IO.File.Delete(pathEnd);
                        }
                        System.IO.File.Move(pathStart, pathEnd);
                    }
                }
            }

            article.ShortImgScale = article.ShortImgScale + "%";
            article.ShortImgX = article.ShortImgX + "%";
            article.ShortImgY = article.ShortImgY + "%";
            article.MiddleImgScale = article.MiddleImgScale + "%";
            article.MiddleImgX = article.MiddleImgX + "%";
            article.MiddleImgY = article.MiddleImgY + "%";
            article.WideImgScale = article.WideImgScale + "%";
            article.WideImgX = article.WideImgX + "%";
            article.WideImgY = article.WideImgY + "%";

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .FirstOrDefaultAsync(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Article.FindAsync(id);

            //List<Article> article2 = _context.Article.Where(a=>a.ArticleId==id).ToList();
            //string[] paths = new[] {article.PathToGallery1, article.PathToGallery2, article.PathToGallery3, article.PathToGallery4, article.PathToGallery5, article.PathToGallery6, article.PathToGallery7,
            //    article.PathToGallery8, article.PathToGallery9, article.PathToGallery10, article.PathToGallery11, article.PathToGallery12, article.PathToGallery13, article.PathToGallery14, article.PathToGallery15 };
            if (article.PathToGallery1!=null)
            {
                ClearGallery(article.PathToGallery1);
            }
            if (article.PathToGallery2 != null)
            {
                ClearGallery(article.PathToGallery2);
            }
            if (article.PathToGallery3 != null)
            {
                ClearGallery(article.PathToGallery3);
            }
            if (article.PathToGallery4 != null)
            {
                ClearGallery(article.PathToGallery4);
            }
            if (article.PathToGallery5 != null)
            {
                ClearGallery(article.PathToGallery5);
            }
            if (article.PathToGallery6 != null)
            {
                ClearGallery(article.PathToGallery6);
            }
            if (article.PathToGallery7 != null)
            {
                ClearGallery(article.PathToGallery7);
            }
            if (article.PathToGallery8 != null)
            {
                ClearGallery(article.PathToGallery8);
            }
            if (article.PathToGallery9 != null)
            {
                ClearGallery(article.PathToGallery9);
            }
            if (article.PathToGallery10 != null)
            {
                ClearGallery(article.PathToGallery10);
            }
            if (article.PathToGallery11 != null)
            {
                ClearGallery(article.PathToGallery11);
            }
            if (article.PathToGallery12 != null)
            {
                ClearGallery(article.PathToGallery12);
            }
            if (article.PathToGallery13 != null)
            {
                ClearGallery(article.PathToGallery13);
            }
            if (article.PathToGallery14 != null)
            {
                ClearGallery(article.PathToGallery14);
            }
            if (article.PathToGallery15 != null)
            {
                ClearGallery(article.PathToGallery15);
            }
            //foreach (var item in paths)
            //{
            //    LittleHelper.DeleteFiles(item, true);
            //    LittleHelper.DeleteFiles(item + "\\preview", true);
            //}

            string[] paths = article.PathToGallery1.Split(new char[] { '\\' });
            string mainFolderPath = "";
            for (int i = 0; i < (paths.Length-1); i++)
            {
                mainFolderPath = Path.Combine(mainFolderPath, paths[i]);
            }
            LittleHelper.DeleteFiles(mainFolderPath, true);

            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void ClearGallery(string path)
        {
            if (path!=null)
            {
                LittleHelper.DeleteFiles(path + "\\preview", true);
                LittleHelper.DeleteFiles(path, true);
            }
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.ArticleId == id);
        }
    }
}
