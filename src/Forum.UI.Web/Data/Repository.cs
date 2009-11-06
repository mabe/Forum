using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;

namespace Forum.UI.Web.Data
{
	public class Repository<T, IdT>
	{
		private readonly ISession session;

		public Repository(ISession session) 
		{
			this.session = session;
		}

		public IEnumerable<T> All()
		{
			return session.Linq<T>().ToList();
		}

		public T Get(IdT id)
		{
			return session.Get<T>(id);
		}

		public T Load(IdT id)
		{
			return session.Load<T>(id);
		}

		public void Save(T obj)
		{
			session.SaveOrUpdate(obj);
		}

		public void Delete(T obj)
		{
			session.Delete(obj);
		}
	}
}