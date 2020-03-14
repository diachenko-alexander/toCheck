using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;
using System.Configuration;
using System.Windows;

namespace Task4
{
    class Settings
    {
        public Brush BackColor { get; set; }
        public Brush TextColor { get; set; }
        public int TextSize { get; set; }
        public FontFamily TextFont { get; set; }

		XmlDocument doc;
		
		public Settings()
		{
			doc = LoadConfigDocument();
			ReadSettings();
		}

		public void SaveSettings()
		{
			XmlNode node = doc.SelectSingleNode("//appSettings");
			if (node == null)
			{
				node = doc.CreateNode(XmlNodeType.Element, "appSettings", "");
				XmlElement root = doc.DocumentElement;
				root.AppendChild(node);
			}

			string[] keys = new string[] {"BackColor",
										  "TextColor",
										  "TextSize",
										  "TextFont"};

			string[] values = new string[] { BackColor.ToString(),
											 TextColor.ToString(),
											 TextSize.ToString(),
											 TextFont.ToString() };

			
			for (int i = 0; i < keys.Length; i++)
			{
				XmlElement element = node.SelectSingleNode(string.Format("//add[@key='{0}']", keys[i])) as XmlElement;
				if (element != null)
				{
					element.SetAttribute("value", values[i]);
				} else
				{
					element = doc.CreateElement("add");
					element.SetAttribute("key", keys[i]);
					element.SetAttribute("value", values[i]);
					node.AppendChild(element);
				}
			}

			doc.Save(Assembly.GetExecutingAssembly().Location + ".config");
		}

		private void ReadSettings()
		{
			NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
			var bc = new BrushConverter();
			string messageException = string.Empty;

			try
			{
				BackColor = (Brush)bc.ConvertFromString(allAppSettings["BackColor"]);
			}
			catch (Exception)
			{
				BackColor = (Brush)bc.ConvertFromString(Colors.Gray.ToString());
				messageException += "Invaldid Back color settings: " + allAppSettings["BackColor"] + Environment.NewLine;				
			}

			try
			{
				TextColor = (Brush)bc.ConvertFromString(allAppSettings["TextColor"]);
			}
			catch (Exception)
			{
				TextColor = (Brush)bc.ConvertFromString(Colors.Black.ToString());
				messageException += "Invaldid Text color settings: " + allAppSettings["TextColor"] + Environment.NewLine;
			}

			try
			{
				TextSize = int.Parse(allAppSettings["TextSize"]);
			}
			catch (Exception)
			{
				TextSize = 14;
				messageException += "Invaldid Text size settings: " + allAppSettings["TextSize"] + Environment.NewLine;

			}

			try
			{
				TextFont = new FontFamily(allAppSettings["TextFont"]);
			}
			catch (Exception)
			{
				TextFont = new FontFamily("Arial");
				messageException += "Invalid Font family settings" + allAppSettings["TextFont"] + Environment.NewLine;
			}

			if (!string.IsNullOrEmpty(messageException))
			{
				MessageBox.Show(messageException, "EROR");
			}
		}

		private static XmlDocument LoadConfigDocument()
		{
			XmlDocument doc = null;
			try
			{
				doc = new XmlDocument();
				doc.Load(Assembly.GetExecutingAssembly().Location + ".config");
				return doc;
			}
			catch (System.IO.FileNotFoundException e)
			{
				throw new Exception("No configuration file found.", e);
			}
		}


	}
}
