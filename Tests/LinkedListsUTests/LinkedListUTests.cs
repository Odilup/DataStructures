using DataStructures;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListsUTests
{
	[TestClass]
	public class LinkedListUTests
	{
		[TestMethod]
		public void LinkedList_Append()
		{
			var list = new LinkedList<int>();

			var node = list.Append(7);
			list.Append(9);
			list.Append(5);
			
			Assert.IsTrue(node.Value == 7);
			Assert.IsTrue(node.Next.Value == 9);
			Assert.IsTrue(node.Next.Next.Value == 5);
		}

		[TestMethod]
		public void LinkedList_Count()
		{
			var list = new LinkedList<int>();

			list.Append(7);
			list.Append(9);
			list.Append(5);

			Assert.IsTrue(list.Count == 3);
		}

		[TestMethod]
		public void LinkedList_Find()
		{
			var list = new LinkedList<int>();

			list.Append(7);
			list.Append(9);
			list.Append(5);

			var node = list.Find(9);
			Assert.IsTrue(node.Value == 9);
		}

		[TestMethod]
		public void LinkedList_Delete()
		{
			var list = new LinkedList<int>();

			list.Append(7);
			list.Append(9);
			list.Append(5);
			list.Append(8);

			list.Delete(9);
			var node = list.Find(7);
			Assert.IsTrue(node.Next.Value == 5);
		}

	}
}
