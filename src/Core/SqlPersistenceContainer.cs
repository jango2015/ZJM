
using System;
using System.Xml;
using System.Xml.Serialization; 
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace NetFocus.MagzineSubscribe.CMPServices
{
	//������һ����ӦSQL Server�ĳ־��������࣬�̳б�׼��������
	public class SqlPersistenceContainer : StdPersistenceContainer  
	{
		public SqlPersistenceContainer() : base() { }

		public SqlPersistenceContainer( ContainerMapping initCurrentMap ) : base( initCurrentMap )
		{

		}

		
		public override void Execute( PersistableObject currentObject )
		{
			try 
			{
				CommandMapping cmdMap = (CommandMapping)ContainerMapping.CommandMappingList[ContainerMapping.CurrentCommandName];  
				SqlCommand currentCommand = BuildCommandFromMapping( cmdMap );//����һ��Commandӳ�����������һ��SqlCommand����
				AssignValuesToParameters( cmdMap, ref currentCommand, currentObject );
				currentCommand.Connection.Open();

				if (cmdMap.ReturnValueType == "DataSet")
				{
					AssignReturnValueToDataSet( cmdMap, currentCommand, ref currentObject );
					AssignOutputValuesToInstance( cmdMap, currentCommand, ref currentObject );
					currentCommand.Connection.Close();
				}
				else
				{
					currentCommand.ExecuteNonQuery();
					currentCommand.Connection.Close();
					AssignOutputValuesToInstance( cmdMap, currentCommand, ref currentObject );
				}
				currentCommand.Connection.Dispose();
				currentCommand.Dispose();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message,e);
			}
		}

	
		private void AssignReturnValueToDataSet( CommandMapping cmdMap,SqlCommand currentCmd,ref PersistableObject persistObject )
		{
			DataSet internalData = persistObject.ResultSet;
			SqlDataAdapter sqlDa = new SqlDataAdapter( currentCmd );
			sqlDa.Fill( internalData );
		}

		
		private void AssignOutputValuesToInstance( CommandMapping cmdMap,SqlCommand currentCmd,ref PersistableObject persistObject )
		{
			Type objType;
			PropertyInfo prop;

			objType = persistObject.GetType();
			SqlParameter curParam;
			foreach (CommandParameter cmdParameter in cmdMap.Parameters )
			{
				if ( (cmdParameter.RealParameterDirection == ParameterDirection.InputOutput ) ||
					(cmdParameter.RealParameterDirection == ParameterDirection.ReturnValue ) ||
					(cmdParameter.RealParameterDirection == ParameterDirection.Output ) )
				{
					curParam = currentCmd.Parameters[ cmdParameter.ParameterName ];
					prop = objType.GetProperty( cmdParameter.ClassMember );
					if (prop != null)
					{
						if ( curParam.Value != DBNull.Value )//�������������ֵ��Ϊ��
						{
							prop.SetValue( persistObject, curParam.Value, null );//Ϊ��ǰ��������ֵ
						} 
					}
				}
			}

		}

		
		private void AssignValuesToParameters( CommandMapping cmdMap,ref SqlCommand currentCmd,PersistableObject persistObject )
		{
			Type objType;
			PropertyInfo prop;

			objType = persistObject.GetType();

			foreach (CommandParameter cmdParameter in cmdMap.Parameters )
			{
				if ( (cmdParameter.RealParameterDirection == ParameterDirection.Input ) ||
					(cmdParameter.RealParameterDirection == ParameterDirection.InputOutput ) )
				{
					prop = objType.GetProperty( cmdParameter.ClassMember );//�õ�objType������������ΪcmdParameter.ClassMember��һ�����Զ���
					currentCmd.Parameters[ cmdParameter.ParameterName ].Value = prop.GetValue( persistObject, null );//��persistObject������prop����ʾ�����Ե�ֵ��Ϊ��ǰsql command��������Ӧ�Ĳ�����ֵ

				}
			}
		}

		
		private SqlCommand BuildCommandFromMapping( CommandMapping cmdMap )
		{
			SqlConnection conn = new SqlConnection( SiteProfile.DefaultDataSource );
			
			SqlCommand sqlCommand = conn.CreateCommand();
			sqlCommand.CommandText = cmdMap.CommandName;
			sqlCommand.CommandType = CommandType.StoredProcedure;
			foreach ( CommandParameter cmdParameter in cmdMap.Parameters )
			{
				SqlParameter newParam = new SqlParameter();
				newParam.ParameterName = cmdParameter.ParameterName;
				newParam.Direction = cmdParameter.RealParameterDirection;
				newParam.SqlDbType = (SqlDbType)SiteProfile.DbTypeHints[cmdParameter.DbTypeHint];
				newParam.Size = cmdParameter.Size;

				sqlCommand.Parameters.Add( newParam );
			}

			return sqlCommand;
		}


	}
}
