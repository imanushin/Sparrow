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

            return View("View", model);
        }

        public ActionResult Edit(string testIdentity)
        {
            return View(new TestViewModel(testIdentity));
        }

        public ActionResult TestExecute(string testIdentity)
        {
            var lastExecuted = TestExecuteModel.FindLastExecuted(testIdentity);

            if (lastExecuted == null)
                return View(testIdentity);

            return View("TestExecute", lastExecuted);
        }

        public ActionResult StartTestExecuting(string testIdentity)
        {
            var startData = TestExecutor.StartTest(testIdentity);

            return TestExecute(testIdentity, startData.ExecutionId);
        }

        private ActionResult TestExecute(string testIdentity, long executionId)
        {
            return View("TestExecute", new TestExecuteModel(testIdentity,executionId));
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