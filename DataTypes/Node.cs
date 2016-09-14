using System.Collections.Generic;

namespace DataTypes.TreeObject
{
	public class Node<T>
	{
		private		List<Node<T>>	m_Children;
		private		T				m_Data;

		public Node(T data)
		{
			m_Data = data;
			m_Children = new List<Node<T>>();
		}

		public void AddChild(Node<T> childNode)
		{
			m_Children.Add(childNode);
		}

		public T Data()
		{
			return m_Data;
		}
	}
}
