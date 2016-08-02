using System;
using System.Web.Mvc;

namespace EtudeV2.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
