namespace DataTypes.TreeObject
{
	public class Tree<T>
	{
		private Node<T> m_Parent;

		public Tree(Node<T> node)
		{
			m_Parent = node;
		}
	}
}
