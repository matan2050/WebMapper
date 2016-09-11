using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTypes.TreeObject;

namespace WebMapper
{
	public static class RecursiveLinkTreeBuilder
	{
		public static Node<string> BuildTree(string url, uint levelsDown)
		{
			WebPage currentPage = new WebPage(url);
			currentPage.ReadContents();
			List<string> currentLinks = currentPage.GetLinks();

			Node<string> currentNode = new Node<string>(url);

			if (levelsDown == 0)
			{
				return currentNode;
			}

			for (int linkIndex = 0; 
					linkIndex < currentLinks.Count; 
						linkIndex++)
			{
				Node<string> lowerLevelLinks = BuildTree(currentLinks[linkIndex], levelsDown - 1);
				currentNode.AddChild(lowerLevelLinks);
			}

			return currentNode;
		}
	}
}
