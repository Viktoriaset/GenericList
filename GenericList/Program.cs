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

			T[] temp = new T[length * 2];
			for (int i = 0; i < arr.Length; i++)
            {
				temp[i] = arr[i];
            }

			temp[arr.Length] = element;
			length = length * 2;
			
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
			T[] temp = new T[]
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
			public Node<Y> previous;
			public Node<Y> next;
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
			int curr = 0;
			while (temp != null && curr < position)
            {
				temp = temp.next;
				curr++;
            }

			Node<T> pre = temp.previous;
			Node<T> next = temp;
			Node<T> newNode = new Node<T>();
			pre.next = newNode;
			newNode.next = temp;
			newNode.payload = element;

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
			while (!temp.Equals(element))
            {
				temp = temp.next;
				count++;
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
            Console.WriteLine("Hello World!");
        }
    }
}
