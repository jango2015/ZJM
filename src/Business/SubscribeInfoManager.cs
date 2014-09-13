using System;
using System.Data;
using NetFocus.MagzineSubscribe.CMPServices;
using NetFocus.MagzineSubscribe.Data;


namespace NetFocus.MagzineSubscribe.Business
{

	public class SubscribeInfoManager
	{
		public SubscribeInfoManager()
		{
		}

		//����һ��������Ϣ
		public static int CreateSubscribeInfo(string name,string post,string company,string address,string region,string postCode,string telephone,string mobilephone,DateTime startDate,DateTime endDate,DateTime giveDate,int number,int monthCount,int totalMoney,string inscribe,string source,string payment,string invoice,string client,string operator1,string bonus,string localAddress,string subscription)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "InsertInfo";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();
			
			subscribeInfo.Post = post;
			subscribeInfo.Address = address;
			subscribeInfo.PostCode = postCode;
			subscribeInfo.Telephone = telephone;
			subscribeInfo.MobilePhone = mobilephone;
			subscribeInfo.Inscribe = inscribe;
			subscribeInfo.Source = source;
			subscribeInfo.Payment = payment;
			subscribeInfo.Invoice = invoice;
			subscribeInfo.Client = client;
			subscribeInfo.Operator = operator1;
			subscribeInfo.Bonus = bonus;
			subscribeInfo.Region = region;
			subscribeInfo.NewName = name;
			subscribeInfo.Number = number;
			subscribeInfo.MonthCount = monthCount;
			subscribeInfo.TotalMoney = totalMoney;
			subscribeInfo.NewCompany = company;
			subscribeInfo.StartDate = startDate;
			subscribeInfo.EndDate = endDate;
			subscribeInfo.GiveDate = giveDate;
			subscribeInfo.LocalAddress = localAddress;
			subscribeInfo.Subscription = subscription;

			spc.Execute(subscribeInfo);

			return subscribeInfo.Id;
		}
		
		//���������������������Ķ�����Ϣ,����һ��DataSet����
		public static DataSet RetriveSubscribeInfo(string name,string post,string company,string address,string region,string postCode,string telephone,string mobilephone,DateTime startDate,DateTime endDate,int compareDirection,int number,int monthCount,int totalMoney,string inscribe,string source,string payment,string invoice,string client,string operator1,string bonus,string localAddress,string subscription)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "RetrieveInfo";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();
			
			subscribeInfo.Post = post;
			subscribeInfo.Address = address;
			subscribeInfo.PostCode = postCode;
			subscribeInfo.Telephone = telephone;
			subscribeInfo.MobilePhone = mobilephone;
			subscribeInfo.Inscribe = inscribe;
			subscribeInfo.Source = source;
			subscribeInfo.Payment = payment;
			subscribeInfo.Invoice = invoice;
			subscribeInfo.Client = client;
			subscribeInfo.Operator = operator1;
			subscribeInfo.Bonus = bonus;
			subscribeInfo.Region = region;
			subscribeInfo.OldName = name;
			subscribeInfo.CompareDirection = compareDirection;
			subscribeInfo.Number = number;
			subscribeInfo.MonthCount = monthCount;
			subscribeInfo.TotalMoney = totalMoney;
			subscribeInfo.OldCompany = company;
			subscribeInfo.StartDate = startDate;
			subscribeInfo.EndDate = endDate;
			subscribeInfo.LocalAddress = localAddress;
			subscribeInfo.Subscription = subscription;

			spc.Execute( subscribeInfo );
			
			return subscribeInfo.ResultSet;

		}
		
		//��������ͳ�Ʊ��µ�������
		public static DataTable RetrieveInfoByDateOnly(DateTime inputDate)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "RetrieveInfoByDateOnly";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();
			
			subscribeInfo.StartDate = inputDate;

			spc.Execute(subscribeInfo);

			return subscribeInfo.ResultSet.Tables[0];

		}
		//��ѯĳ������ֵΪ�յ����м�¼
		public static DataSet RetrieveNullInfo(int searchDateType)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "RetrieveNullInfo";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();
			
			subscribeInfo.SearchDateType = searchDateType;

			spc.Execute(subscribeInfo);

			return subscribeInfo.ResultSet;

		}
		//����һ��������Ϣ
		public static int UpdateSubscribeInfo(string oldName,string newName,string post,string oldCompany,string newCompany,string address,string region,string postCode,string telephone,string mobilephone,DateTime startDate,DateTime endDate,DateTime giveDate,int number,int monthCount,int totalMoney,string inscribe,string source,string payment,string invoice,string client,string operator1,string bonus,string localAddress,string subscription)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "UpdateInfo";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();
			
			subscribeInfo.Post = post;
			subscribeInfo.Address = address;
			subscribeInfo.PostCode = postCode;
			subscribeInfo.Telephone = telephone;
			subscribeInfo.MobilePhone = mobilephone;
			subscribeInfo.Inscribe = inscribe;
			subscribeInfo.Source = source;
			subscribeInfo.Payment = payment;
			subscribeInfo.Invoice = invoice;
			subscribeInfo.Client = client;
			subscribeInfo.Operator = operator1;
			subscribeInfo.Bonus = bonus;
			subscribeInfo.Region = region;
			subscribeInfo.OldName = oldName;
			subscribeInfo.NewName = newName;
			subscribeInfo.Number = number;
			subscribeInfo.MonthCount = monthCount;
			subscribeInfo.TotalMoney = totalMoney;
			subscribeInfo.OldCompany = oldCompany;
			subscribeInfo.NewCompany = newCompany;
			subscribeInfo.StartDate = startDate;
			subscribeInfo.EndDate = endDate;
			subscribeInfo.GiveDate = giveDate;
			subscribeInfo.LocalAddress = localAddress;
			subscribeInfo.Subscription = subscription;

			spc.Execute( subscribeInfo );

			return subscribeInfo.Id;
		}
		
		//ɾ��һ��������Ϣ
		public static void DeleteSubscribeInfo(string name,string company)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "DeleteInfo";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();
			
			subscribeInfo.OldName = name;
			subscribeInfo.OldCompany = company;

			spc.Execute(subscribeInfo);
		}

		//����ʱ���������
		public static DataSet RetriveDataFromTempInfo()
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "RetrieveDataFromTempInfo";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();
			
			spc.Execute( subscribeInfo );
			
			return subscribeInfo.ResultSet;

		}
		//�������м��ĳ����¼�Ƿ����
		public static int CheckSubscribeExist(string name,string company)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "CheckSubscribeExist";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();
			
			subscribeInfo.OldName = name;
			subscribeInfo.OldCompany = company;

			spc.Execute( subscribeInfo );

			return subscribeInfo.Id;

		}
		
		//��OutputTemp���е����ݵ�����Excel�ĵ���
		public static void OutputDataToExcel(string path,string fileName,string tableName)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["ImportExportDataCatalog"];
			currentContainerMapping.CurrentCommandName = "p_exporttb";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();

			subscribeInfo.Path = path;
			subscribeInfo.FileName = fileName;
			subscribeInfo.TableName = tableName;

			spc.Execute(subscribeInfo);

		}
		
		//���tempInfo���е���������
		public static void ClearTempInfo()
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["ImportExportDataCatalog"];
			currentContainerMapping.CurrentCommandName = "ClearTempInfo";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();

			spc.Execute(subscribeInfo);

		}
		//���StatInfoTable���е���������
		public static void ClearStatInfoTable()
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["ImportExportDataCatalog"];
			currentContainerMapping.CurrentCommandName = "ClearStatInfoTable";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();

			spc.Execute(subscribeInfo);

		}
		//��StatInfoTable���в���һ����¼
		public static void InsertIntoStatInfoTable(string name,string post,string company,string region,string source,string invoice,string telephone,string mobilephone,int number,int monthCount,int totalMoney,int averageMoney,int monthMoney,DateTime startDate,DateTime endDate,DateTime giveDate)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["ImportExportDataCatalog"];
			currentContainerMapping.CurrentCommandName = "InsertIntoStatInfoTable";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			SubscribeInfo subscribeInfo = new SubscribeInfo();

			subscribeInfo.NewName = name;
			subscribeInfo.Post = post;
			subscribeInfo.NewCompany = company;
			subscribeInfo.Region = region;
			subscribeInfo.Source = source;
			subscribeInfo.Invoice = invoice;
			subscribeInfo.Telephone = telephone;
			subscribeInfo.MobilePhone = mobilephone;
			subscribeInfo.Number = number;
			subscribeInfo.MonthCount = monthCount;
			subscribeInfo.TotalMoney = totalMoney;
			subscribeInfo.AverageMoney = averageMoney;
			subscribeInfo.MonthMoney = monthMoney;
			subscribeInfo.StartDate = startDate;
			subscribeInfo.EndDate = endDate;
			subscribeInfo.GiveDate = giveDate;

			spc.Execute(subscribeInfo);

		}
		//�������еĵ���
		public static DataTable RetrieveRegions()
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "GetRegions";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			Region regions = new Region();
			
			spc.Execute(regions);

			return regions.ResultSet.Tables[0];

		}
		//���һ������
		public static int CreateRegion(string name)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "CreateRegion";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			Region region = new Region();

			region.Name = name;
			
			spc.Execute(region);
			
			return region.ReturnValue;


		}
		//ɾ��һ������
		public static void DeleteRegion(int id)
		{
			ContainerMapping currentContainerMapping = CMPConfigurationHandler.ContainerMaps["SubscribeInfoCatalog"];
			currentContainerMapping.CurrentCommandName = "DeleteRegion";
			
			SqlPersistenceContainer spc = new SqlPersistenceContainer(currentContainerMapping);
			Region region = new Region();

			region.Id = id;
			
			spc.Execute(region);

		}


	}
}
