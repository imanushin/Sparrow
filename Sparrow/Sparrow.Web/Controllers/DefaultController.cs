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
            var model = new TestViewModel(testIdentity);

            if (!model.IsExists)
                return Redirect(RouteConfig.TestEditLink(testIdentity));

            return View(model);
        }

        public ActionResult Edit(string testIdentity)
        {
            return View(new TestViewModel(testIdentity));
        }

        public ActionResult TestExecute(string testIdentity)
        {
            return View(new TestExecuteModel(testIdentity));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveTest(string testIdentity, string testEditBox)
        {
            var model = new TestViewModel(testIdentity);

            model.SaveNewTest(testEditBox);

            return Redirect(RouteConfig.TestViewLink(testIdentity));
        }
    }
}