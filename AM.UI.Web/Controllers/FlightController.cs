using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight serviceFlight;
        IServicePlane servicePlane;
        public FlightController(IServiceFlight serviceFlight,IServicePlane servicePlane)
        {
                this.serviceFlight = serviceFlight;
                this.servicePlane = servicePlane;
        }
        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart) // ? : nullable
        {
            if (dateDepart == null)
                return View(serviceFlight.GetAll());
            else return View(serviceFlight.GetMany(f => f.FlightDate.Equals(dateDepart)));
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create() // formulaire
        {
            ViewBag.mypalanes = new SelectList(servicePlane.GetAll(),"PlaneId","Capacity");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight f, IFormFile PilotImage)   // bouton
        {
            try
            {
                //ajout de l'image
                if (PilotImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",PilotImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);
                    f.PilotImage = PilotImage.FileName;
                }
                    // ajout dans la BDD
                    serviceFlight.Add(f);
                serviceFlight.Commit();// synchronisation avec la BDD
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
