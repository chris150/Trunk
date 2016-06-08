using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyWebHzg.Frontend.HzgWeb.Models;
using MyWebHzg.Entities;
using MyWebHzg.Service;

namespace MyWebHzg.HzgWeb.Controllers
{
    //[Authorize] // mit diesem Attribut kann auf die Seite Movies nur zugegriffen werden, wenn wir uns zuerst angemeldet haben!!!!
    public class MovieController : Controller
    {
        //
        // GET: /Movie/Index
        public async Task<ActionResult> Index(string genreFilter, string mediumTypeFilter, string titleFilter)
        {
            HzgWebService svc = new HzgWebService();

            List<ExtMovie> movies = new List<ExtMovie>();

            if (string.IsNullOrEmpty(genreFilter) && string.IsNullOrEmpty(mediumTypeFilter) && string.IsNullOrEmpty(titleFilter))
            {
                movies.AddRange(await svc.GetAllExtMoviesAsync());
            }
            else if (!string.IsNullOrEmpty(titleFilter))
            {
                movies.AddRange(await svc.GetMoviesByTitle(titleFilter, genreFilter, mediumTypeFilter));
            }

            else if (!string.IsNullOrEmpty(genreFilter))
            {
                movies.AddRange(await svc.GetExtMoviesByGenreIdAsync(new Guid(genreFilter)));
            }
            else if (!string.IsNullOrEmpty(mediumTypeFilter))
            {
                movies.AddRange(await svc.GetExtMoviesByMediumTypeIdAsync(new Guid(mediumTypeFilter)));
            }

            var genres = await svc.GetAllGenres();
            // ViewBag.Genres = new SelectList(genres.Select(g => g.GenreCd), genres.Select(g => g.Bezeichnung));

            ViewBag.Genres = new List<SelectListItem>(genres.Select(g => new SelectListItem
                                                        {
                                                            Value = g.GenreId.ToString(),
                                                            Text = g.GenreCd
                                                        }));

            
            var mediumTypes = await svc.GetAllMediumTypes();
            ViewBag.MediumTypes = new List<SelectListItem>(mediumTypes.Select(m => new SelectListItem
                                                        {
                                                            Value = m.MediumTypeId.ToString(),
                                                            Text = m.Bezeichnung
                                                        }));

            

            return View(movies);
        }


        public async Task<ActionResult> Index_Grid()
        {
            ViewBag.localName = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            HzgWebService svc = new HzgWebService();

            List<ExtMovie> movies = new List<ExtMovie>();
            movies.AddRange(await svc.GetAllExtMoviesAsync());

            return View(movies);
        }

        //
        // GET: /Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Movie/Create
        // Anzeige der Eingabemaske
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            // Ein leeres Model erstellt und an View übergeben

            // Oder wir legen eine Movie-Objekt mit Defaultwerten an
            Movie movie = new Movie
            {
                MovieId = Guid.NewGuid(),
                GenreId = new Guid("86dfdd65-ebda-489e-945f-3becc5b28783"),
                MediumTypeId = new Guid("6592fcbb-2adb-43fb-9a1f-c90b968950a8"),
                ReleaseDate = DateTime.Now
            };

            HzgWebService svc = new HzgWebService();
            
            NewEditMovieModel model = new NewEditMovieModel();
            model.Movie = movie;

            /* Genre und Mediumtype Listen initialisieren */
            await InitGenreMediumtypes(model, svc);
         
            // Model an View übergeben.
            return View(model);
        }

        //
        // POST: /Movie/Create
        // Speichern der Eingaben in Datenbank
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewEditMovieModel model)
        {
            try
            {
                HzgWebService svc = new HzgWebService();

                await svc.CreateMovie(model.Movie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {           
            HzgWebService svc = new HzgWebService();
            NewEditMovieModel model = new NewEditMovieModel();
            
            // damit wir wieder auf die richtige Seite zurück finden
            if (Request.Params.AllKeys.Contains("ReturnUri"))
            {
                ViewBag.ReturnUri = Request.Params["ReturnUri"];
            }
            else
            {
                ViewBag.ReturnUri = "/Movie/Index";
            }

            var movie = await svc.GetMovieById(id);

            if(movie == null)
            {
                return RedirectToAction("Index");
            }

            model.Movie = movie;
            model.Mode = Mode.Edit;

            /* Genre und Mediumtype Listen initialisieren */
            await InitGenreMediumtypes(model, svc);

            return View(model);
        }

        private async Task InitGenreMediumtypes(NewEditMovieModel model, HzgWebService svc){

            
            /* Genre und Mediumtype Listen initialisieren */
            var genres = await svc.GetAllGenres();
            model.Genres.AddRange(genres.Select(g => new SelectListItem
            {
                Value = g.GenreId.ToString(),
                Text = g.GenreCd
            }));


            var mediumTypes = await svc.GetAllMediumTypes();
            model.MediumTypes.AddRange(mediumTypes.Select(m => new SelectListItem
            {
                Value = m.MediumTypeId.ToString(),
                Text = m.Bezeichnung
            }));
        }

        //
        // POST: /Movie/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(NewEditMovieModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            // damit wir wieder zu dem Formular zurück springen woher wir her gekommen sind. 
            string returnUri = null;
            if (Request.Params.AllKeys.Contains("ReturnUri"))
            {
                returnUri = Request.Params["ReturnUri"];
            }

            try
            {
                HzgWebService svc = new HzgWebService();
                await svc.UpdateMovie(model.Movie);

                if (returnUri == null)
                {
                    return Redirect("Movie/Index");
                }
                
                return Redirect(returnUri);
            }
            catch(Exception ex)
            {
                // Logger (Log4Net) - um Exception zu loggen.
                throw ex;
            }
            
        }

        //
        // GET: /Movie/Delete/5
        //[HttpGet]
        //public ActionResult Delete(string id)
        //{
        //    return View();
        //}

        //
        // POST: /Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                HzgWebService svc = new HzgWebService();
                var movie = await svc.GetMovieById(id);
                if (movie != null)
                {
                    await svc.DeleteMovie(movie);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #region TreeView

        public ActionResult Index_Tree()
        {
            DirectoryTreeNode root = new DirectoryTreeNode
            {
                Id = "root",
                Text = Environment.MachineName
            };

            // Laufwerke auslesen
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (var driveInfo in allDrives)
            {
                DirectoryTreeNode childNode = new DirectoryTreeNode();
                childNode.Text = driveInfo.Name;
                childNode.Path = driveInfo.Name.Replace("\\", "\\\\");
                childNode.IsReady = driveInfo.IsReady;

                if (childNode.IsReady)
                {
                    childNode.Id = driveInfo.VolumeLabel;
                }
                else
                {
                    childNode.Id = driveInfo.Name;
                }

                root.ChildNodes.Add(childNode);
            }

            // 1. Verzeichnissebene auslesen
            foreach (var child in root.ChildNodes)
            {
                if (child.IsReady)
                {
                    child.ChildNodes.AddRange(this.InitDirectoryChildNodes(child.Path));
                }
            }

            return View(root);
        }

        
        private List<DirectoryTreeNode> InitDirectoryChildNodes(string parentPath)
        {
            List<DirectoryTreeNode> childs = new List<DirectoryTreeNode>();
            try
            {
                List<DirectoryInfo> directories = Directory.GetDirectories(parentPath).Select(s => new DirectoryInfo(s)).ToList();
                childs.AddRange(directories.Select(d => new DirectoryTreeNode { Id = d.Name, Text = d.Name, Path = d.FullName.Replace("\\", "\\\\") }));
            }
            catch (Exception ex)
            {
                string msg = ex.Message;                
            }

            return childs;
        }

        [HttpPost]
        public JsonResult GetDirectoryChildNodes(string parentPath, bool rootOnly = false)
        {
            //System.Threading.Thread.Sleep(5000);

            List<DirectoryTreeNode> childs = this.InitDirectoryChildNodes(parentPath);
            //foreach (var child in childs)
            //{
            //    child.ChildNodes.AddRange(this.InitDirectoryChildNodes(child.Path));
            //}

            childs.ForEach(c => c.ChildNodes.AddRange(this.InitDirectoryChildNodes(c.Path)));

            return Json(childs);
        }

        #endregion

    }
}
