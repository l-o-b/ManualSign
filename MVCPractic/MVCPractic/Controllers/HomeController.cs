﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Office.Interop.Word;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing.Drawing2D;
using MVCPractic.Models;

namespace MVCPractic.Controllers
{
    public class HomeController : Controller
    {
        tbContentDbContext db = new tbContentDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(tbContent pic, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                string extension = Path.GetExtension(upload.FileName);
                if (extension == ".doc" || extension == ".docx")
                {
                    // получаем имя файла
                    string fileName = Path.GetFileName(upload.FileName);
                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                    string startupPath = "C:\\Users\\Users\\Documents\\Visual Studio 2015\\Projects\\MVCPractic\\MVCPractic\\Files";
                    var docPath = Path.Combine(startupPath, fileName);
                    Application app = new Application();
                    Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
                    app.Visible = false;
                    //открываем документ
                    doc = app.Documents.Open(docPath);
                    doc.ShowGrammaticalErrors = false;
                    doc.ShowRevisions = false;
                    doc.ShowSpellingErrors = false;

                    foreach (Window window in doc.Windows)
                    {
                        foreach (Pane pane in window.Panes)
                        {
                            for (var i = 1; i <= pane.Pages.Count; i++)
                            {
                                Page page = null;
                                bool populated = false;
                                while (!populated)
                                {
                                    try
                                    {
                                        page = pane.Pages[i];
                                        populated = true;
                                    }
                                    catch (COMException ex)
                                    {
                                        Thread.Sleep(1);
                                    }
                                }
                                var bits = page.EnhMetaFileBits;
                                var target = Path.Combine(startupPath + "\\", string.Format("{1}_page_{0}", i, fileName.Split('.')[0]));

                                try
                                {
                                    using (var ms = new MemoryStream((byte[])(bits)))
                                    {
                                        var image = Image.FromStream(ms);
                                        var pngTarget = Path.ChangeExtension(target, "png");
                                        image.Save(pngTarget, ImageFormat.Png);
                                        //сохраняем изображение
                                        pic.ContentPic = bits;
                                        db.Contents.Add(pic);
                                        db.SaveChanges();
                                        //получается так что изображение не отображается, надо как то выводить через метод... 

                                    }
                                }

                                catch (System.Exception ex)
                                {
                                    doc.Close(true, Type.Missing, Type.Missing);
                                    Marshal.ReleaseComObject(doc);
                                    doc = null;
                                    app.Quit(true, Type.Missing, Type.Missing);
                                    Marshal.ReleaseComObject(app);
                                    app = null;
                                    throw ex;
                                }
                            }
                        }
                    }
                    doc.Close(true, Type.Missing, Type.Missing);
                    Marshal.ReleaseComObject(doc);
                    doc = null;
                    app.Quit(true, Type.Missing, Type.Missing);
                    Marshal.ReleaseComObject(app);
                    app = null;
                }
                else
                {

                }
            }

            return RedirectToAction("Index");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}