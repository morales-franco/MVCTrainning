using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSite.Models;

namespace TestSite.Binders
{
    //Enfoque DefaultModelBinder
    public class AlumnoVMModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            int alumnoID = Convert.ToInt32(request.QueryString["alumnoid"]);
            string nombre = request.QueryString["nombre"];
            string calle = request.QueryString["calle"];
            int numero = Convert.ToInt32(request.QueryString["numero"]);


            return new AlumnoTestBinderVM
            {
                AlumnoID = alumnoID,
                Nombre = nombre,
                Direccion = string.Format("{0} {1}", calle, numero)
            };
        }
    }
}