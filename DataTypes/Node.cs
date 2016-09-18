using System.Collections.Generic;

namespace DataTypes.TreeObject
{
	public class TreeNode<T>
	{
		private		List<TreeNode<T>>	m_Children;
		private		T				m_Data;

		public TreeNode(T data)
		{
			m_Data = data;
			m_Children = new List<TreeNode<T>>();
		}

		public void AddChild(TreeNode<T> childNode)
		{
			m_Children.Add(childNode);
		}

		public T Data()
		{
			return m_Data;
		}
	}
}
