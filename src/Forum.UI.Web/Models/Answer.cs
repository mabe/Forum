using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.UI.Web.Models
{
	public class Answer
	{
		public virtual long Id { get; set; }
		public virtual string Entry { get; set; }
		public virtual Question Question { get; set; }

		//If you want a threaded forum
		//public ICollection<Answer> Answers { get; set; }
	}
}
