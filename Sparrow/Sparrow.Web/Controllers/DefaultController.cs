using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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

            return View("View", model);
        }

        public ActionResult Edit(string testIdentity)
        {
            return View(new TestViewModel(testIdentity));
        }

        public ActionResult TestExecute(string testIdentity)
        {
            var executionId = Request.Params["executionId"];

            if (!string.IsNullOrWhiteSpace(executionId))
            {
                return View("TestExecute", new TestExecuteModel(testIdentity, long.Parse(executionId)));
            }

            var lastExecuted = TestExecuteModel.FindLastExecuted(testIdentity);

            if (lastExecuted == null)
                return View(testIdentity);

            return View("TestExecute", lastExecuted);
        }

        public ActionResult StartTestExecuting(string testIdentity)
        {
            var startData = TestExecutor.StartTest(testIdentity);

            return RedirectToAction("TestExecute", new RouteValueDictionary()
            {
                {"testIdentity", testIdentity},
                {"executionId", startData.ExecutionId},
            });
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