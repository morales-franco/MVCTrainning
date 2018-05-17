using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSite.Models;

namespace TestSite.Binders
{
    //Enfoque IModelBinder
    public class EscuelaVMModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            int escuelaID = Convert.ToInt32(request.QueryString["escuelaID"]);
            string nombre = request.QueryString["nombre"];
            string calle = request.QueryString["calle"];
            int numero = Convert.ToInt32(request.QueryString["numero"]);


            return new EscuelaTestBinderVM
            {
                EscuelaID = escuelaID,
                Nombre = nombre,
                Direccion = string.Format("{0} {1}", calle, numero)
            };
        }
    }
}