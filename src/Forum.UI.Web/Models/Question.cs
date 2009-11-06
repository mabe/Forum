using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.UI.Web.Models
{
	public class Question
	{
		public virtual long Id { get; set; }

		public virtual int Answers { get; set; }
		public virtual int Viewed { get; set; }
		public virtual string Title { get; set; }
		public virtual DateTime Started { get; set; }
	}
}