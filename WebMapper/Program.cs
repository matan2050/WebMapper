using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataTypes.TreeObject;


namespace WebMapper
{
	class Program
	{
		static void Main(string[] args)
		{
			// testing tree creation 
			TreeNode<int> el1 = new TreeNode<int>(1);

			TreeNode<int> el2 = new TreeNode<int>(10);
			TreeNode<int> el3 = new TreeNode<int>(11);
			TreeNode<int> el4 = new TreeNode<int>(12);

			TreeNode<int> el5 = new TreeNode<int>(100);
			TreeNode<int> el6 = new TreeNode<int>(101);
			TreeNode<int> el7 = new TreeNode<int>(102);

			TreeNode<int> el8 = new TreeNode<int>(120);

			el4.AddChild(el8);

			el2.AddChild(el5);
			el2.AddChild(el6);
			el2.AddChild(el7);

			el1.AddChild(el2);
			el1.AddChild(el3);
			el1.AddChild(el4);

			//

			WebPage page = new WebPage("http://wwww.facebook.com");
			page.ReadContents();
			page.GetLinks();

			TreeNode<string> webTree = RecursiveLinkTreeBuilder.BuildTree("http://wwww.facebook.com", 1);
			Console.WriteLine("");
		}
	}
}
