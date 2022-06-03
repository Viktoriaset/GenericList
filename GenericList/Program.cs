using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace GenericList
{

	interface List<T>
	{
		public abstract void add(T element);
		public abstract void put(T element, int position);
		public abstract void remove(int position);
		public abstract int find(T element);
		public abstract T get(int index);
	}

	public class ArrayList<T> : List<T> {
		private T[] arr;
		private int DEFAULT_ARRAYLIST_SIZE = 0;
		private int length;

		public int size()
        {
			return length;
        }

		public ArrayList()
		{
			arr = new T[DEFAULT_ARRAYLIST_SIZE];
			length = 0;
		}

		public ArrayList(int n)
		{
			arr = new T[n];
			length = n;
		}

		public void add(T element)
        {
			for (int i = 0; i < arr.Length; i++)
            {
				if (arr[i] == null)
                {
					arr[i] = element;
					return;
                }
            }

			T[] temp = new T[(length == 0)? 2 : length * 2];
			for (int i = 0; i < arr.Length; i++)
            {
				temp[i] = arr[i];
            }

			temp[arr.Length] = element;
			arr = temp;
			length = (length == 0) ? 2 : length * 2;


		}

		public void put(T element, int position)
        {
			if (position >= length)
            {
				Console.WriteLine("Error going outside the array");
				return;
            }
			arr[position] = element;
        }
		public void remove(int position) 
		{
			T[] temp = new T[length-1];
			int cur = 0;
			for (int i = 0; i < length; i++)
			{
				if (i != position)
				{
					temp[cur++] = arr[i];
				}
            }
			arr = temp;
			length -= 1;
		}

		public int find (T element)
        {
			for (int i = 0; i < length; i++)
            {
				if (arr[i].Equals(element))
                {
					return i;
                }
            }

			Console.WriteLine("Not found element");
			return -1;
        }

		public T get(int index)
        {

			if (index < 0 || index >= length) {
				Console.WriteLine("Error going outside the array");
			}

			return arr[index];
        }
	}


	public class LinkedList<T> : List<T>
	{
		private class Node<Y>
		{
			public Node<Y> previous = null;
			public Node<Y> next = null;
			public Y payload;
		}

		private Node<T> node;



		public LinkedList()
		{
			node = null;

		}

		public void add(T element)
        {
			if (node == null)
			{
				node = new Node<T>();
				node.payload = element;
			}
			else
			{
				Node<T> temp = node;
				while (temp.next != null)
				{
					temp = temp.next;
				}

				temp.next = new Node<T>();
				temp.next.previous = temp;
				temp.next.payload = element;
			}

        }

        public void put(T element, int position)
        {
			Node<T> temp = node;
			

			if (position == 0) {

				node = new Node<T>();
				node.next = temp;
				node.payload = element;
				temp.previous = node;
				return;
			}

			
			int curr = 0;
			while (curr < position)
            {
				if (temp.next == null)
                {
					Console.WriteLine("Erorr");
					return;
                }
				temp = temp.next;
				curr++;
            }

			Node<T> next = temp;
			temp = new Node<T>();
			temp.previous = next.previous;
			temp.next = next;
			temp.payload = element;
			next.previous.next = temp;

        }

        public void remove(int position)
        {

			Node<T> temp = node;
            for (int i = 0; i < position; i++)
            {
				if (temp.next == null)
                {
					Console.WriteLine("Error remove");
					return;
                }
				temp = temp.next;
				
            }
			if (temp.next != null)
            {
				temp.previous.next = temp.next;
            } else
            {
				temp.previous.next = null;
            }

			
        }

        public int find(T element)
        {
			Node<T> temp = node;
			int count = 0;
			while (temp != null && temp.Equals(element))
            {
				temp = temp.next;
				count++;
            }

			if (temp == null)
            {
				return -1;
            }

			return count;
        }

        public T get(int index)
        {
			Node<T> temp = node;
			for (int i = 0; i < index; i++)
			{
				if (temp.next == null)
				{
					Console.WriteLine("Error remove");
					break;
				}
				temp = temp.next;



			}
			return temp.payload;
		}
    }

    class Program
    {
        static void Main(string[] args)
        {
			ArrayList<int> arrayList = new ArrayList<int>();
			Console.WriteLine(arrayList.size());
			arrayList.add(10);
			Console.WriteLine(arrayList.size());
			Console.WriteLine(arrayList.get(0));
			Console.WriteLine(arrayList.find(10));
			arrayList.put(1, 1);
			Console.WriteLine(arrayList.get(1));
			arrayList.remove(1);

			LinkedList<int> l = new LinkedList<int>();
			l.add(22);
			Console.WriteLine(l.get(0));
			Console.WriteLine(l.find(22));
			l.put(21, 0);
			l.put(2, 1);
			Console.WriteLine(l.get(0) + l.get(1) + l.get(2));
			l.remove(2);
			Console.WriteLine(l.get(1));
        }
    }
}
