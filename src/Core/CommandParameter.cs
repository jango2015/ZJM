
using System;
using System.Xml.Serialization;
using System.Data;
using System.Reflection;

namespace NetFocus.MagzineSubscribe.CMPServices
{
	public class CommandParameter  //��������һ������Ĳ���
	{
		private string classMember;
		private string parameterName;
		private string dbTypeHint;
		private int size;
		private ParameterDirection parameterDirection;//�����ķ���Ϊö������

		//�κι��췽����Ҫֱ�ӻ��ӵ����������������������󻯵Ĺ�����롣
		private void ConstructCommandParameter(string initClassMember,string initParameterName,string initDbTypeHint,string initParameterDirection,int initSize )
		{
			classMember = initClassMember;
			parameterName = initParameterName;
			dbTypeHint = initDbTypeHint;
			ParamDirection = initParameterDirection;
			size = initSize;
		}

		
		public CommandParameter()//һ�����췽���������κβ���
		{
			ConstructCommandParameter( "Not Set", "Not Set", "Not Set", "ReturnValue", -1 );
		}

		public CommandParameter(string initClassMember,string initParameterName,string initDbTypeHint,string initParameterDirection,int initSize )//�������Ĺ��췽��
		{
			ConstructCommandParameter( initClassMember,initParameterName,initDbTypeHint,initParameterDirection,initSize );
		}

		
		public string ClassMember
		{
			get 
			{
				return classMember;
			}
			set 
			{
				classMember = value;
			}
		}

		public string ParameterName
		{
			get 
			{
				return parameterName;
			}
			set 
			{
				parameterName = value;
			}
		}

		public string DbTypeHint
		{
			get 
			{
				return dbTypeHint;
			}
			set 
			{
				dbTypeHint = value;
			}
		}

		public int Size
		{
			get 
			{
				return size;
			}
			set 
			{
				size = value;
			}
		}
		public string ParamDirection
		{
			get 
			{
				return parameterDirection.ToString();
			}
			set 
			{
				if (value == "Input")
					parameterDirection = ParameterDirection.Input;
				else if (value == "InputOutput")
					parameterDirection = ParameterDirection.InputOutput;
				else if (value == "Output" )
					parameterDirection = ParameterDirection.Output;
				else
					parameterDirection = ParameterDirection.ReturnValue;
			}
		}

		
		//ע�⣬���������ֻ�������ԣ������������ͬ��
		public ParameterDirection RealParameterDirection
		{
			get 
			{
				return parameterDirection;
			}
		}
	}
}

