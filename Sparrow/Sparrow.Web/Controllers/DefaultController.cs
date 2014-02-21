using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sparrow.Web.Models;

namespace Sparrow.Web.Controllers
{
    public sealed class DefaultController : Controller
    {
        public new ActionResult View(string testIdentity)
        {
            return View(new TestViewModel(testIdentity));
        }

        public ActionResult Edit(string testIdentity)
        {
            return base.View(new TestViewModel(testIdentity));
        }
    }
}