using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSite.Models;

namespace TestSite.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        //http://localhost:54351/Alumno/BindingTest?alumnoid=1&nombre=franco&calle=maipu&numero=264
        [HttpGet]
        public ActionResult BindingTest(AlumnoTestBinderVM model)
        {
            /*
             * Valor de model sin Implementar Model Binding:
                  AlumnoID: 1
                  Direccion: null
                  Nombre: "franco"
             */

            /*
             * Valor de model una vez implementado AlumnoVMModelBinder:
                  AlumnoID: 1
                  Direccion: "maipu 264"
                  Nombre: "franco"
             */

            return Content(string.Format("BINDING TEST - AlumnoID: {0} - Nombre: {1} - Direccion: {2}", model.AlumnoID, model.Nombre, model.Direccion));
        }

    }
}