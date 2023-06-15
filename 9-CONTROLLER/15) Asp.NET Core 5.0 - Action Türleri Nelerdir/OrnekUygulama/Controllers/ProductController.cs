using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Models;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        #region ViewResult
        //public ViewResult GetProducts()
        //{
        //    ViewResult result = View();
        //    return result;
        //}
        #endregion
        #region PartialViewResult
        //public PartialViewResult GetProducts()
        //{
        //    PartialViewResult result = PartialView();
        //    return result;
        //}
        #endregion
        #region JsonResult
        //public JsonResult GetProducts()
        //{
        //    JsonResult result = Json(new Product
        //    {
        //        Id = 5,
        //        ProductName="Terlik",
        //        Quantity = 15
        //    });
        //    return result;
        //}
        #endregion
        #region EmptyResult
        //public EmptyResult GetProducts()
        //{
        //    return new EmptyResult();
        //}
        #endregion
        #region ContentResult
        //public ContentResult GetProducts()
        //{
        //    ContentResult result = Content("Sebepsiz boş yere ayrılacaksan....");
        //    return result;
        //}
        #endregion
        #region ActionResult
        public ActionResult GetProducts()
        {
            if (true)
            {
                //......
                return Json(new object());
            }
            else if (true)
            {
                return Content("asfasasdasd");
            }
            return View();
        }
        #endregion
        #region IActionResult

        #endregion
    }
}
