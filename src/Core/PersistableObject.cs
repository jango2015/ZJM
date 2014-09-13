
using System;
using System.Data;
using System.Xml;
using System.Xml.Serialization; 
using System.Text;

namespace NetFocus.MagzineSubscribe.CMPServices
{
	public class PersistableObject  //���ඨ����һ���־��Զ�����Ϊһ������
	{
		protected DataSet internalData = new DataSet();
		
		public PersistableObject()
		{}

		
		public bool CanPersist()  //���ظö����Ƿ��ܳ־�
		{
			return true;
		}

		
		public string ToXmlString()  //���л��ö���
		{
			try 
			{
				Type objType = this.GetType();
				StringBuilder sb = new StringBuilder();
				System.IO.StringWriter sw = new System.IO.StringWriter( sb );
				XmlSerializer xs = new XmlSerializer( objType );
				xs.Serialize( sw, this );
				return sw.GetStringBuilder().ToString();
			}
			catch 
			{
				return "Serialization Failure";
			}
		}
		
		public DataSet ResultSet
		{
			get 
			{
				return internalData;
			}
			set 
			{
				internalData = value;
			}
		}

	}
}
