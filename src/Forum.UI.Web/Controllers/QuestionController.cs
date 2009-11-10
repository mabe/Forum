using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Forum.UI.Web.Data;
using Forum.UI.Web.Models;

namespace Forum.UI.Web.Controllers
{
	[HandleError]
    public class QuestionController : Controller
    {
		private readonly Repository<Question, long> repository;

		public QuestionController()
			: this(new Repository<Question, long>(MvcApplication.CurrentSession)) { }

		public QuestionController(Repository<Question, long> repository)
		{
			this.repository = repository;
		}

        public ActionResult Index()
        {
            return View(repository.All());
        }

        public ActionResult Details(long id)
        {
			var q = repository.Get(id);

			q.Viewed++;

            return View(q);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create([Bind(Exclude="Id")]Question question)
        {
            try
            {
				if (!ModelState.IsValid)
					throw new NotImplementedException();

				question.Started = DateTime.Now;

				repository.Save(question);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            return View(repository.Get(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(long id, Question question)
        {
            try
            {
				if (!ModelState.IsValid)
					throw new NotImplementedException();

				var q = repository.Load(id);

				//can use automapper
				q.Title = question.Title;
				q.Entry = question.Entry;

				repository.Save(q);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
