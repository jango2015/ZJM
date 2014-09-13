using System;
using System.Xml;
using System.Xml.Serialization; 
using System.Reflection;
using System.Collections;


namespace NetFocus.MagzineSubscribe.CMPServices
{
	public class ContainerMapping  //��������һ��������ӳ��
	{
		private string containerMappingId;
		private Hashtable commandMappingList = new Hashtable();
		private string currentCommandName;


		//������캯������Ҫ����Ϊ����һ���ڵ���Ϊ��ʼ��������
		//�������ڳ�ʼ��ʱ���Ǵ������ļ��ж�ȡContainerMapping�ڵ�ġ�
		public ContainerMapping( XmlNode xmlNode )
		{
			containerMappingId = xmlNode.SelectSingleNode( "ContainerMappingId" ).InnerText;
			XmlNodeList commandMappingNodeList;

			commandMappingNodeList = xmlNode.SelectNodes("Command");
			foreach(XmlNode commandMappingNode in commandMappingNodeList)
			{
				string commandName = commandMappingNode.SelectSingleNode( "CommandName" ).InnerText;
				commandMappingList[commandName] = CreateCommandMappingFromNode(commandName, commandMappingNode );
				
			}
			
		}

		protected static CommandMapping CreateCommandMappingFromNode(string commandName, XmlNode cmdNode )
		{
			CommandMapping newCmdMap = new CommandMapping(commandName);

			newCmdMap.ReturnValueType = cmdNode.SelectSingleNode("ReturnValueType").InnerText;
			//�����������ӳ�����Ĳ����б�
			CommandParameter newParam;
			foreach (XmlNode cmdParamNode in cmdNode.SelectNodes("Parameter"))
			{
				newParam = new CommandParameter();
				newParam.ClassMember = cmdParamNode.SelectSingleNode("ClassMember").InnerText;
				newParam.DbTypeHint = cmdParamNode.SelectSingleNode("DbTypeHint").InnerText;
				newParam.ParameterName = cmdParamNode.SelectSingleNode("ParameterName").InnerText;
				newParam.Size = System.Convert.ToInt32( cmdParamNode.SelectSingleNode("Size").InnerText );
				newParam.ParamDirection = cmdParamNode.SelectSingleNode("ParamDirection").InnerText;
				newCmdMap.AddParameter( newParam );
			}

			return newCmdMap;
		}

		
		public string ContainerMappingId
		{
			get 
			{
				return containerMappingId;
			}
			set 
			{
				containerMappingId = value;
			}
		}


		public Hashtable CommandMappingList
		{
			get
			{
				return commandMappingList;
			}
			set
			{
				commandMappingList = value;
			}
		}
		public string CurrentCommandName
		{
			get
			{
				return currentCommandName;
			}
			set
			{
				currentCommandName = value;
			}
		}
	}
}
