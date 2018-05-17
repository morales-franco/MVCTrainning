using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSite.Models;

namespace TestSite.Controllers
{
    public class EscuelaController : Controller
    {
        // GET: Escuela
        public ActionResult Index()
        {
            return View();
        }

        //http://localhost:54351/Escuela/BindingTest?escuelaid=1&nombre=escuela&calle=calleFalsa&numero=123
        [HttpGet]
        public ActionResult BindingTest(EscuelaTestBinderVM model)
        {
            /*
             * Valor de model sin Implementar Model Binding:
                  EscuelaID: 1
                  Direccion: null
                  Nombre: "escuela"
             */

            /*
             * Valor de model una vez implementado EscuelaVMModelBinder:
                  EscuelaID: 1
                  Direccion: "calleFalsa 123"
                  Nombre: "escuela"
             */

            return Content(string.Format("BINDING TEST - EscuelaID: {0} - Nombre: {1} - Direccion: {2}", model.EscuelaID, model.Nombre, model.Direccion));
        }
    }
}