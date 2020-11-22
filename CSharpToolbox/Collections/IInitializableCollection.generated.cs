
using System.Collections.Generic;

namespace CSharpToolbox.Collections
{
	public interface IInitializableCollection<TElement> : IEnumerable<TElement>
	{
		void Add(TElement element);
	}
	public interface IInitializableCollection<TElement, T1> : IInitializableCollection<TElement>
	{
		void Add(T1 item1);
	}
	public interface IInitializableCollection<TElement, T1, T2> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15);
	}
	public interface IInitializableCollection<TElement, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : IInitializableCollection<TElement>
	{
		void Add(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, T9 item9, T10 item10, T11 item11, T12 item12, T13 item13, T14 item14, T15 item15, T16 item16);
	}
}