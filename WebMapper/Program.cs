using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTypes.TreeObject;


namespace WebMapper
{
	class Program
	{
		static void Main(string[] args)
		{
			// testing tree creation 
			Node<int> el1 = new Node<int>(1);

			Node<int> el2 = new Node<int>(10);
			Node<int> el3 = new Node<int>(11);
			Node<int> el4 = new Node<int>(12);

			Node<int> el5 = new Node<int>(100);
			Node<int> el6 = new Node<int>(101);
			Node<int> el7 = new Node<int>(102);

			Node<int> el8 = new Node<int>(120);

			el4.AddChild(el8);

			el2.AddChild(el5);
			el2.AddChild(el6);
			el2.AddChild(el7);

			el1.AddChild(el2);
			el1.AddChild(el3);
			el1.AddChild(el4);

			Tree<int> tree = new Tree<int>(el1);
			//

			WebPage page = new WebPage("http://wwww.facebook.com");
			page.ReadContents();
			page.GetLinks();

			Node<string> webTree = RecursiveLinkTreeBuilder.BuildTree("http://wwww.facebook.com", 1);
			Console.WriteLine("");
		}
	}
}
