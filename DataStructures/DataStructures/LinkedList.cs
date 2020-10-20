using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class LinkedList<T> : IEnumerable
    {
		internal LinkedListNode<T> head;

		public LinkedList()
		{
			head = null;
		}

		public int Count { get; private set; }
		public LinkedListNode<T> Append(T value)
		{
			var newNode = new LinkedListNode<T>(value);

			if (head == null)
			{
				head = newNode;
				Count++;
				return head;
			}

			LinkedListNode<T> node = head;

			while (node.next != null)
			{
				node = node.next;
			}

			node.next = newNode;
			newNode.previous = node;

			Count++;
			return newNode;
		}

		public LinkedListNode<T> Find(T value)
		{
			if (head == null)
			{
				return null;
			}

			return FindFromNode(head, value);
		}

		public LinkedListNode<T> FindFromNode(LinkedListNode<T> fromNode, T value)
		{
			if (fromNode == null)
			{
				throw new ArgumentNullException(nameof(fromNode));
			}

			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			var node = fromNode;
			var comparer = EqualityComparer<T>.Default;
			while (node.next != null)
			{
				if (comparer.Equals(node.Value, value))
				{
					return node;
				}

				node = node.next;
			}

			return null;
		}

		public void Delete(T value)
		{
			if(value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}	

			var node = Find(value);
			if (node == null)
			{
				return;
			}

			if (node.previous == null)
			{
				head = node;
				node.previous = null;
			}
			else
			{
				node.previous.next = node.next;
			}
		}

		private class LinkedListEnumerator : IEnumerator
		{
			private readonly LinkedList<T> list;
			private LinkedListNode<T> current;
			public object Current => current;

			public LinkedListEnumerator(LinkedList<T> list)
			{
				this.list = list;
				current = list.head;
			}
			public bool MoveNext()
			{
				if (current.Next == null)
				{
					return false;
				}

				current = current.next;
				return true;
			}

			public void Reset()
			{
				current = list.head;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return new LinkedListEnumerator(this);
		}
	}

	public sealed class LinkedListNode<TData>
	{
		internal LinkedListNode<TData> next;
		internal LinkedListNode<TData> previous;

		public TData Value;

		public LinkedListNode<TData> Next => next;
		public LinkedListNode<TData> Previous => previous;
		public LinkedListNode(TData value)
		{
			this.Value = value;
			previous = null;
		}
	}
}
