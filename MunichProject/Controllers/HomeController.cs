using MunichProject.Helpers;
using MunichProject.Infrastructure;
using MunichProject.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace MunichProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [HttpPost]
        public JsonResult PerformSingleton(FormModel model)
        {
            var result = AutoMapperInitialization.Current.Map<InternalDataObject>(model);

            return Json(new JsonResponse { IsSuccessful = true, Data = result });
        }

        [HttpPost]
        public JsonResult FactorialCalculator(int input)
        {
            if (input == 0) return Json(new JsonResponse { IsSuccessful = true, Data = input });
            if (input < 0) return Json(new JsonResponse { Message = "Invalid input. Input must be a positive number." });

            var result = CalculateFactorial(input);
            return Json(new JsonResponse { IsSuccessful = true, Data = result });
        }

        [HttpPost]
        public JsonResult FolderSizeCalculator()
        {
            // generate a random folder tree. configuration is on the top of helper class.
            var folderGeneratorHelper = new FolderGenerator();
            var rootFolder = folderGeneratorHelper.GenerateFolder(1, null);

            // currently, I take the root node to get the size, 
            // but we can take any folder to get size. 
            // i.e. rootFolder.Subfolders.First().GetSize()
            var result = rootFolder.GetSize(); 

            return Json(new JsonResponse { IsSuccessful = true, Data = new FolderSizeCalcResult { Size = result, FolderJson = JsonConvert.SerializeObject(rootFolder) } });
        }

        private int CalculateFactorial(int input)
        {
            if (input <= 1) return input;

            return input * CalculateFactorial(input - 1);
        }
    }

}