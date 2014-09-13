using System;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.Diagnostics;
using System.Web;
using System.Windows.Forms;
using System.Web.Security;
using System.IO;



	//ע�⣺�����ʵ����IConfigurationSectionHandler�ӿڣ�
	//������˽ӿ��е�Create���������Կ��Զ��������ļ����Զ�������ýڡ�

namespace NetFocus.MagzineSubscribe.CMPServices
{

	public class CMPConfigurationHandler : IConfigurationSectionHandler
	{
		private static ContainerMappingSet containerMapSet;

		public CMPConfigurationHandler() { }//һ���յĹ��캯��

		
		public object Create( object parent, object input, XmlNode section )//ʵ�ֽӿ��еķ���
		{
			XmlNode procedureFilesRootNode = section.SelectSingleNode("//ContainerMappingSetFiles");
			ContainerMappingSet cms = new ContainerMappingSet();
			XmlDocument doc = new XmlDocument();
			string fileName;
			foreach (XmlNode procedureFileNode in procedureFilesRootNode.ChildNodes)
			{
				if (!(procedureFileNode is XmlElement)) 
				{
					continue;
				}
				try
				{
					fileName = Path.GetFullPath(procedureFileNode.Attributes["value"].InnerText);
					
					doc.Load(fileName);
					XmlNode containerMappingRoot = doc.SelectSingleNode("//ContainerMappingSet");
					ContainerMapping cm;
					foreach (XmlNode containerNode in containerMappingRoot.ChildNodes)
					{
						cm = new ContainerMapping( containerNode );
						cms[cm.ContainerMappingId] = cm;
					}	

				}
				catch(Exception e)
				{
					MessageBox.Show(e.Message);
				}

			}
			containerMapSet = cms;

			SiteProfile.DefaultDataSource = ConfigurationSettings.AppSettings["DefaultDataSource"];
			
			SiteProfile.DbTypeHints["Varchar"] = System.Data.SqlDbType.VarChar;
			SiteProfile.DbTypeHints["Int"] = System.Data.SqlDbType.Int;
			SiteProfile.DbTypeHints["Date"] = System.Data.SqlDbType.DateTime;
			SiteProfile.DbTypeHints["Text"] = System.Data.SqlDbType.Text;
			SiteProfile.DbTypeHints["Bit"] = System.Data.SqlDbType.Bit;
			SiteProfile.DbTypeHints["Money"] = System.Data.SqlDbType.Money;
			SiteProfile.DbTypeHints["Binary"] = System.Data.SqlDbType.Binary;
			
			return null;
	
		}

		
		public static ContainerMappingSet ContainerMaps  //�����Է���һ������ӳ�伯
		{
			get 
			{
				return containerMapSet;
			}
			set 
			{
				containerMapSet = value;
			}
		}
	}
}
