using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.UI.Web.Models;
using Forum.UI.Web.Data;

namespace Forum.UI.Web.Controllers
{
	[HandleError]
	public class QuestionController : Controller
	{
		private readonly Repository<Question, long> repository;

		public QuestionController()
			: this(new Repository<Question, long>(MvcApplication.CurrentSession))
		{

		}

		public QuestionController(Repository<Question, long> repository)
		{
			this.repository = repository;
		}

		public ActionResult Index()
		{
			return View(repository.All());
		}
	}
}
