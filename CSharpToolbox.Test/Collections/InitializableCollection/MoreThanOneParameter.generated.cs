
using CSharpToolbox.Collections;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.InitializableCollection
{
	[TestClass]
	public class With02Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2) => x1 + x2;
		private InitializableCollection<int, int, int> GetCollection() => new InitializableCollection<int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2));
			Then(() => collection.Should().BeEquivalentTo(3));
		}
	}
	[TestClass]
	public class With03Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3) => x1 + x2 + x3;
		private InitializableCollection<int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3));
			Then(() => collection.Should().BeEquivalentTo(6));
		}
	}
	[TestClass]
	public class With04Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4) => x1 + x2 + x3 + x4;
		private InitializableCollection<int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4));
			Then(() => collection.Should().BeEquivalentTo(10));
		}
	}
	[TestClass]
	public class With05Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5) => x1 + x2 + x3 + x4 + x5;
		private InitializableCollection<int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5));
			Then(() => collection.Should().BeEquivalentTo(15));
		}
	}
	[TestClass]
	public class With06Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6) => x1 + x2 + x3 + x4 + x5 + x6;
		private InitializableCollection<int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6));
			Then(() => collection.Should().BeEquivalentTo(21));
		}
	}
	[TestClass]
	public class With07Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7) => x1 + x2 + x3 + x4 + x5 + x6 + x7;
		private InitializableCollection<int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7));
			Then(() => collection.Should().BeEquivalentTo(28));
		}
	}
	[TestClass]
	public class With08Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7, int x8) => x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8;
		private InitializableCollection<int, int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7, 8));
			Then(() => collection.Should().BeEquivalentTo(36));
		}
	}
	[TestClass]
	public class With09Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7, int x8, int x9) => x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9;
		private InitializableCollection<int, int, int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7, 8, 9));
			Then(() => collection.Should().BeEquivalentTo(45));
		}
	}
	[TestClass]
	public class With10Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7, int x8, int x9, int x10) => x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10;
		private InitializableCollection<int, int, int, int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
			Then(() => collection.Should().BeEquivalentTo(55));
		}
	}
	[TestClass]
	public class With11Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7, int x8, int x9, int x10, int x11) => x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10 + x11;
		private InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11));
			Then(() => collection.Should().BeEquivalentTo(66));
		}
	}
	[TestClass]
	public class With12Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7, int x8, int x9, int x10, int x11, int x12) => x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10 + x11 + x12;
		private InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12));
			Then(() => collection.Should().BeEquivalentTo(78));
		}
	}
	[TestClass]
	public class With13Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7, int x8, int x9, int x10, int x11, int x12, int x13) => x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10 + x11 + x12 + x13;
		private InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
			Then(() => collection.Should().BeEquivalentTo(91));
		}
	}
	[TestClass]
	public class With14Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7, int x8, int x9, int x10, int x11, int x12, int x13, int x14) => x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10 + x11 + x12 + x13 + x14;
		private InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
			Then(() => collection.Should().BeEquivalentTo(105));
		}
	}
	[TestClass]
	public class With15Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7, int x8, int x9, int x10, int x11, int x12, int x13, int x14, int x15) => x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10 + x11 + x12 + x13 + x14 + x15;
		private InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15));
			Then(() => collection.Should().BeEquivalentTo(120));
		}
	}
	[TestClass]
	public class With16Parameters : InitializableCollectionTestBase
	{
		private int Sum(int x1, int x2, int x3, int x4, int x5, int x6, int x7, int x8, int x9, int x10, int x11, int x12, int x13, int x14, int x15, int x16) => x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 + x10 + x11 + x12 + x13 + x14 + x15 + x16;
		private InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int> GetCollection() => new InitializableCollection<int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int>(Sum);
		protected override void AnInitializableCollection() => Initializable = GetCollection();
		[TestMethod]
		public void AddViaMapTest()
		{
			var collection = GetCollection();
			When(() => collection.Add(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16));
			Then(() => collection.Should().BeEquivalentTo(136));
		}
	}
}