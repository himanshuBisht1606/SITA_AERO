using BusinessLayer;
using BusinessLayer.Factory;
using BusinessLayer.Interface;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sita_Assignment.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IParcel _IParcel;
        public HomeController(IParcel IParcel)
        {
            _IParcel = IParcel;
        }
        /// <summary>
        /// Entry point
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Upload Xml file in local folder and do operation on it
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadXmlFile()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    var plannedData = new Plans();
                    string _path = string.Empty;
                    for (int i = 0; i < files.Count; i++)
                    {
                        var file = files[i];
                        
                        if (file != null && file.ContentLength > 0 && file.ContentType == "text/xml")
                        {
                            string _fileName = Path.GetFileName(file.FileName);
                            _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _fileName);
                            file.SaveAs(_path);
                        }
                    }
                    var xmlContainer = _IParcel.GetParcelData(_path);
                    plannedData = _IParcel.GeneratePlannedData(xmlContainer);
                    ViewBag.Message = "File upload Successful!!";
                    return PartialView("_plan", plannedData);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "File upload failed!!";
                    return Json("Error Occured. Please try again sometimes");
                }
            }
            else
            {
                return Json("No Files Selected");
            }
            
        }

    }
}