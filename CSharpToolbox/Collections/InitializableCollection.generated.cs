
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpToolbox.Collections
{
    public abstract class InitializableCollectionBase<TElement> : IInitializableCollection<TElement>
    {
        protected readonly IList<TElement> Container = new List<TElement>();

        public void Add(TElement element)
        {
            Container.Add(element);
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return Container.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class InitializableCollection<TElement> : InitializableCollectionBase<TElement>
    {
        
    }
	public class InitializableCollection<TElement, T1>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1>
	{
		private readonly Func<T1, TElement> _map;
		public InitializableCollection(Func<T1, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1)
		{
			Container.Add(_map(item1));
		}
	}
	public class InitializableCollection<TElement, T1, T2>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2>
	{
		private readonly Func<T1, T2, TElement> _map;
		public InitializableCollection(Func<T1, T2, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2)
		{
			Container.Add(_map(item1, item2));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3>
	{
		private readonly Func<T1, T2, T3, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3)
		{
			Container.Add(_map(item1, item2, item3));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4>
	{
		private readonly Func<T1, T2, T3, T4, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4)
		{
			Container.Add(_map(item1, item2, item3, item4));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5>
	{
		private readonly Func<T1, T2, T3, T4, T5, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
		{
			Container.Add(_map(item1, item2, item3, item4, item5));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, T8, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7, item8));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7, item8, item9));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15));
		}
	}
	public class InitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
		: InitializableCollection<TElement>,
		IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
	{
		private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TElement> _map;
		public InitializableCollection(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TElement> map)
		{
			_map = map;
		}
		public void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15, T16 item16)
		{
			Container.Add(_map(item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16));
		}
	}
}