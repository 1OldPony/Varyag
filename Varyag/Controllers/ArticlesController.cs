using System;
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

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
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

        public async Task<IActionResult> FillArticle(string currentTextPart, IFormFileCollection fotos, string articleFolder, int? partsCounter, string PathToGallery1, string Text1, string PathToGallery2, string Text2, string PathToGallery3, string Text3, 
            string PathToGallery4, string Text4, string PathToGallery5, string Text5, string PathToGallery6, string Text6, string PathToGallery7, string Text7, string PathToGallery8, string Text8, string PathToGallery9, string Text9, string PathToGallery10, 
            string Text10, string PathToGallery11, string Text11, string PathToGallery12, string Text12, string PathToGallery13, string Text13, string PathToGallery14, string Text14, string PathToGallery15, string Text15)
        {
            string path = Path.Combine(_Environment.WebRootPath, "images", "articles");
            LittleHelper.DirectoryExistCheck(path);

            path = Path.Combine(path, "article"+ articleFolder);
            LittleHelper.DirectoryExistCheck(path);

            path = Path.Combine(path, partsCounter.ToString());
            if (!Directory.Exists(path))
                LittleHelper.DirectoryExistCheck(path);
            else
                LittleHelper.DeleteFiles(path, false);

            for (int i = 0; i <= (fotos.Count() - 1); i++)
            {
                string name = "ВерфьВаряг" + "(" + (i + 1).ToString() + ").jpg";

                using (var fileStream = new FileStream(path + "/" + name, FileMode.Create))
                {
                    await fotos[i].CopyToAsync(fileStream);
                }
            }

            string pathToText = Path.Combine(path, "Text.txt");
            if (Text1!=null)
            {
                Text1 = p
            }

            LittleHelper.SaveInTxt(path,);
            partsCounter++;

            return RedirectToAction("Create", new { partNumber = partsCounter, pathForPartGallery = path, text = pathToText, PTG1 = PathToGallery1, T1 = Text1, PTG2 = PathToGallery2, T2 = Text2, PTG3 = PathToGallery3, T3 = Text3, PTG4 = PathToGallery4,
                T4 = Text4, PTG5 = PathToGallery5, T5 = Text5, PTG6 = PathToGallery6, T6 = Text6, PTG7 = PathToGallery7, T7 = Text7, PTG8 = PathToGallery8, T8 = Text8, PTG9 = PathToGallery9, T9 = Text9,
                PTG10 = PathToGallery10, T10 = Text10, PTG11 = PathToGallery11, T11 = Text11, PTG12 = PathToGallery12, T12 = Text12, PTG13 = PathToGallery13, T13 = Text13, PTG14 = PathToGallery14, T14 = Text14,
                PTG15 = PathToGallery15, T15 = Text15, ArtFold = articleFolder});
        }

        // GET: Articles/Create
        public IActionResult Create(int? partNumber, string pathForPartGallery, string text, string PTG1, string T1, string PTG2, string T2, string PTG3, string T3,
            string PTG4, string T4, string PTG5, string T5, string PTG6, string T6, string PTG7, string T7, string PTG8, string T8, string PTG9, string T9, string PTG10,
            string T10, string PTG11, string T11, string PTG12, string T12, string PTG13, string T13, string PTG14, string T14, string PTG15, string T15)
        {
            ViewBag.Text1 = T1;
            ViewBag.PathForPartGallery1 = PTG1;
            ViewBag.Text2 = T2;
            ViewBag.PathForPartGallery2 = PTG2;
            ViewBag.Text3 = T3;
            ViewBag.PathForPartGallery3 = PTG3;
            ViewBag.Text4 = T4;
            ViewBag.PathForPartGallery4 = PTG4;
            ViewBag.Text5 = T5;
            ViewBag.PathForPartGallery5 = PTG5;
            ViewBag.Text6 = T6;
            ViewBag.PathForPartGallery6 = PTG6;
            ViewBag.Text7 = T7;
            ViewBag.PathForPartGallery7 = PTG7;
            ViewBag.Text8 = T8;
            ViewBag.PathForPartGallery8 = PTG8;
            ViewBag.Text9 = T9;
            ViewBag.PathForPartGallery9 = PTG9;
            ViewBag.Text10 = T10;
            ViewBag.PathForPartGallery10 = PTG10;
            ViewBag.Text11 = T11;
            ViewBag.PathForPartGallery11 = PTG11;
            ViewBag.Text12 = T12;
            ViewBag.PathForPartGallery12 = PTG12;
            ViewBag.Text13 = T13;
            ViewBag.PathForPartGallery13 = PTG13;
            ViewBag.Text14 = T14;
            ViewBag.PathForPartGallery14 = PTG14;
            ViewBag.Text15 = T15;
            ViewBag.PathForPartGallery15 = PTG15;

            ViewBag.PartNumber = partNumber;
            switch (partNumber)
            {
                case 1:
                    ViewBag.Text1 = text;
                    ViewBag.PathForPartGallery1 = pathForPartGallery;
                    break;
                case 2:
                    ViewBag.Text2 = text;
                    ViewBag.PathForPartGallery2 = pathForPartGallery;
                    break;
                case 3:
                    ViewBag.Text3 = text;
                    ViewBag.PathForPartGallery3 = pathForPartGallery;
                    break;
                case 4:
                    ViewBag.Text4 = text;
                    ViewBag.PathForPartGallery4 = pathForPartGallery;
                    break;
                case 5:
                    ViewBag.Text5 = text;
                    ViewBag.PathForPartGallery5 = pathForPartGallery;
                    break;
                case 6:
                    ViewBag.Text6 = text;
                    ViewBag.PathForPartGallery6 = pathForPartGallery;
                    break;
                case 7:
                    ViewBag.Text7 = text;
                    ViewBag.PathForPartGallery7 = pathForPartGallery;
                    break;
                case 8:
                    ViewBag.Text8 = text;
                    ViewBag.PathForPartGallery8 = pathForPartGallery;
                    break;
                case 9:
                    ViewBag.Text9 = text;
                    ViewBag.PathForPartGallery9 = pathForPartGallery;
                    break;
                case 10:
                    ViewBag.Text10 = text;
                    ViewBag.PathForPartGallery10 = pathForPartGallery;
                    break;
                case 11:
                    ViewBag.Text11 = text;
                    ViewBag.PathForPartGallery11 = pathForPartGallery;
                    break;
                case 12:
                    ViewBag.Text12 = text;
                    ViewBag.PathForPartGallery12 = pathForPartGallery;
                    break;
                case 13:
                    ViewBag.Text13 = text;
                    ViewBag.PathForPartGallery13 = pathForPartGallery;
                    break;
                case 14:
                    ViewBag.Text14 = text;
                    ViewBag.PathForPartGallery14 = pathForPartGallery;
                    break;
                default:
                    ViewBag.Text15 = text;
                    ViewBag.PathForPartGallery15 = pathForPartGallery;
                    break;
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
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleId,ArticleName,Text1,FotoPath1,Text2,FotoPath2,Text3,FotoPath3,Text4,FotoPath4,Text5,FotoPath5,Text6,FotoPath6,Text7,FotoPath7,Text8,FotoPath8,Text9,FotoPath9,Text10,FotoPath10,Text11,FotoPath11,Text12,FotoPath12,Text13,FotoPath13,Text14,FotoPath14,Text15,FotoPath15")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

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
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.ArticleId == id);
        }
    }
}
