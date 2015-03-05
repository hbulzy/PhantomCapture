using PhantomCapture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhantomCapture.Controllers
{
    public class CaptureController : Controller
    {
        // GET: Capture
        public ActionResult Index(string url, int? width = null, int? height = null)
        {
            var dirPath = Server.MapPath("~/App_Data/phantomjs");
            var model = new CaptureModel(dirPath);
            Byte[] results;
            if (width.HasValue && height.HasValue)
            {
                results = model.Captur(url, captureSize: new CaptureSize(width.Value, height.Value));
            }
            else
            {
                results = model.Captur(url);
            }

            return File(results, "image/png");
        }
    }
}