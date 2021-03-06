﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace WebMapper
{
	public class WebPage
	{
		private		string			m_Url;
		private		string			m_Contents;

		public WebPage(string url)
		{
			m_Url		= url;
			m_Contents	= null;
		}

		public void ReadContents()
		{
			WebResponse		response	= null;
			StreamReader	reader		= null;

			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(m_Url);
				request.Method = "GET";

				response = request.GetResponse();

				if (response == null)
				{
					return;
				}

				reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
				m_Contents = reader.ReadToEnd();
			}
			catch
			{
				m_Contents = string.Empty;
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}
				if (response != null)
				{
					response.Close();
				}
			}
		}

		// !!! GIVE THE CLASS A LINK LIST MEMBER !!!
		public List<string> GetLinks()
		{
			List<string> links = new List<string>();

			if (m_Contents == null)
			{
				throw new Exception("web page contents not read yet");
			}

			var matches = Regex.Matches(m_Contents, "href=");

			if (matches.Count == 0)
			{
				return links;
			}

			bool findLinks = true;
			char currentChar;
			bool inLink = false;
			int currentMatch = 0;

			StringBuilder currentLink = new StringBuilder();
			int currentIndex = matches[currentMatch].Index;

			while (findLinks)
			{
				currentChar = m_Contents[currentIndex];

				if ((inLink == true) && (currentChar != '"'))
				{
					currentLink.Append(currentChar);
					currentIndex++;
					continue;
				}

				if ((inLink == false) && (currentChar != '"'))
				{
					currentIndex++;
					continue;
				}

				if ((currentChar == '"') && (inLink == true))
				{
					inLink = false;
					string linkToAdd = currentLink.ToString();

					// link notation fix
					if (!linkToAdd.Contains("http"))
					{
						linkToAdd = m_Url + linkToAdd;
					}

					//if (linkString.Contains

					links.Add(linkToAdd);
					currentLink.Clear();

					if (currentMatch < matches.Count - 1)
					{
						currentMatch++;
						currentIndex = matches[currentMatch].Index;
					}
					else
					{
						findLinks = false;
					}
					continue;
				}

				if ((currentChar == '"') && (inLink == false))
				{
					inLink = true;
					currentIndex++;
					continue;
				}

			}
			return links;
		}
	}
}
