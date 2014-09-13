using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.Reflection;
using System.Threading;
using System.Resources;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.OleDb;

using NetFocus.MagzineSubscribe.Business;
using NetFocus.MagzineSubscribe.Data;
using Crownwood.Magic.Menus;


namespace NetFocus.MagzineSubscribe.UI
{

	public class MainForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		private DataGrid dataGrid1;
		private ToolBar bar = null;
		private static MainForm mainForm = null;
		private System.Data.DataSet currentDataSet = null;
		private DataTable statResultTable = null;
		private DateTime currentInputDate;
		private Manager currentManager = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private Crownwood.Magic.Menus.MenuControl topMenu = null;

		public static MainForm Form
		{
			get
			{
				return mainForm;
			}
			set
			{
				mainForm = value;
			}
		}
		
		public System.Data.DataSet CurrentDataSet
		{
			get
			{
				return currentDataSet;
			}
			set
			{
				currentDataSet = value;
			}
		}

		public DataTable StatResultTable
		{
			get
			{
				return statResultTable;
			}
			set
			{
				statResultTable = value;
			}
		}
		public DateTime CurrentInputDate
		{
			get
			{
				return currentInputDate;
			}
			set
			{
				currentInputDate = value;
			}
		}
		public Manager CurrentManager
		{
			get
			{
				return currentManager;
			}
			set
			{
				currentManager = value;
			}
		}
		public DataGrid ShowResultDataGrid
		{
			get
			{
				return dataGrid1;
			}
			set
			{
				dataGrid1 = value;
			}
		}

		
		private MainForm()
		{

			InitializeComponent();

		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		#region Windows ������������ɵĴ���
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.AllowSorting = false;
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.BackColor = System.Drawing.Color.White;
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("����", 10F);
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.Black;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 100;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(704, 453);
			this.dataGrid1.TabIndex = 2;
			this.dataGrid1.DataSourceChanged += new System.EventHandler(this.dataGrid1_DataSourceChanged);
			this.dataGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseUp);
			this.dataGrid1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGrid1_Paint);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(704, 453);
			this.Controls.Add(this.dataGrid1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "��־���Ĺ���ϵͳ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			mainForm = new MainForm();
			ConfigurationSettings.GetConfig("MyConfig");//��ȡ�Զ������ý�,����������л��ʼ�����е��й���������

			LoginForm loginForm = new LoginForm();
			loginForm.StartPosition = FormStartPosition.CenterScreen;
			if(loginForm.ShowDialog() == DialogResult.OK)
			{
				Application.Run(mainForm);//����������
			}
		}


		#region MenuCommands

		void AddUser(object sender,EventArgs e)
		{
			AddUserForm userForm = new AddUserForm();
			userForm.StartPosition = FormStartPosition.CenterParent;
			if(userForm.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("����û��ɹ�!");
			}
		}
		void DeleteUser(object sender,EventArgs e)
		{
			DeleteUserForm userForm = new DeleteUserForm();
			userForm.StartPosition = FormStartPosition.CenterParent;
			if(userForm.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("ɾ���û��ɹ�!");
			}
		}
		void ModifyUserPassword(object sender,EventArgs e)
		{
			ModifyUserPasswordForm userForm = new ModifyUserPasswordForm();
			userForm.StartPosition = FormStartPosition.CenterParent;
			if(userForm.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("�����޸ĳɹ�!");
			}
		}
		void ModifyUserName(object sender,EventArgs e)
		{
			UpdateUserNameForm userForm = new UpdateUserNameForm();
			userForm.StartPosition = FormStartPosition.CenterParent;
			if(userForm.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("�����޸ĳɹ�!");
			}
		}
		void ModifyUserProperty(object sender,EventArgs e)
		{
			UpdateUserPropertyForm userForm = new UpdateUserPropertyForm();
			userForm.StartPosition = FormStartPosition.CenterParent;
			if(userForm.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("Ȩ���޸ĳɹ�!");
			}
		}
		void UserExit(object sender,EventArgs e)
		{
			this.Close();
		}

		
		void AddEmployee(object sender,EventArgs e)
		{
			AddEmployeeForm employeeForm = new AddEmployeeForm();
			employeeForm.StartPosition = FormStartPosition.CenterParent;
			employeeForm.ShowDialog();

		}
		void DeleteEmployee(object sender,EventArgs e)
		{
			DeleteEmployeeForm employeeForm = new DeleteEmployeeForm();
			employeeForm.StartPosition = FormStartPosition.CenterParent;
			employeeForm.ShowDialog();
		}
		void ModifyEmployee(object sender,EventArgs e)
		{
			UpdateEmployeeForm employeeForm = new UpdateEmployeeForm();
			employeeForm.StartPosition = FormStartPosition.CenterParent;
			employeeForm.ShowDialog();
		}

		
		void AddSubscribe(object sender,EventArgs e)
		{
			AddForm addForm = new AddForm();
			addForm.StartPosition = FormStartPosition.CenterParent;
			if(addForm.ShowDialog() == DialogResult.OK)
			{
				RebindToDataGrid();
			}
		}
		void DeleteSubscribe(object sender,EventArgs e)
		{
			if(DeleteSelectedRows() == true)
			{
				RebindToDataGrid();
			}
		}

		void ModifySubscribe(object sender,EventArgs e)
		{
			UpdateForm updateForm = new UpdateForm();
			updateForm.StartPosition = FormStartPosition.CenterParent;
			if(updateForm.ShowDialog() == DialogResult.OK)
			{
				RebindToDataGrid();
			}
		}
		void BatchModifySubscribe(object sender,EventArgs e)
		{
			if(TestSelectedRows() == false)
			{
				MessageBox.Show("��û��ѡ���κ��У�");
				return;
			}

			BatchUpdateForm batchUpdateForm = new BatchUpdateForm();
			batchUpdateForm.StartPosition = FormStartPosition.CenterParent;
			if(batchUpdateForm.ShowDialog() == DialogResult.OK)
			{
				RebindToDataGrid();
			}
			
		}
		void OtherSearch(object sender,EventArgs e)
		{
			OtherSearchForm searchForm = new OtherSearchForm();
			searchForm.StartPosition = FormStartPosition.CenterParent;
			if(searchForm.ShowDialog() == DialogResult.OK)
			{
				RebindToDataGrid();
			}
		}
		void SearchSubscribe(object sender,EventArgs e)
		{
			SearchForm searchForm = new SearchForm();
			searchForm.StartPosition = FormStartPosition.CenterParent;
			if(searchForm.ShowDialog() == DialogResult.OK)
			{
				RebindToDataGrid();
			}
		}
		void InputSubscribe(object sender,EventArgs e)
		{
			//if(MessageBox.Show("����ǰ���ȱ��沢�ر����д򿪵�Excel�ĵ�!","����",MessageBoxButtons.OKCancel,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1) == DialogResult.OK)
			//{
				if(ImportExcelData() == true)
				{
					RebindToDataGrid();
				}
			//}
		}
		void OutputSubscribe(object sender,EventArgs e)
		{
			ExportDataToExcel();
		}

		void StatSubscribe(object sender,EventArgs e)
		{
			StatSubscribeForm statSubscribeForm = new StatSubscribeForm();
			statSubscribeForm.StartPosition = FormStartPosition.CenterParent;
			if(statSubscribeForm.ShowDialog() == DialogResult.OK)
			{
				ShowStatResultForm form = new ShowStatResultForm(this.statResultTable,this.currentInputDate);
				form.StartPosition = FormStartPosition.CenterParent;
				form.ShowDialog();
			}
		}


		void AddRegion(object sender,EventArgs e)
		{
			AddRegionForm regionForm = new AddRegionForm();
			regionForm.StartPosition = FormStartPosition.CenterParent;
			regionForm.ShowDialog();
		}
		void DeleteRegion(object sender,EventArgs e)
		{
			DeleteRegionForm regionForm = new DeleteRegionForm();
			regionForm.StartPosition = FormStartPosition.CenterParent;
			regionForm.ShowDialog();
		}


		#endregion

		DataSet GetData(string fileName)    //��Excel�ļ��е����ݴ����һ��DataSet��
		{
			string file=openFileDialog1.FileName;
			string cmdText;
			string conStr=@" Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + file + ";Extended Properties=Excel 8.0" ; 
			string tableName = "";
			DataSet ds = null;
			OleDbConnection objConn = new OleDbConnection(conStr);
			
			try
			{
				if(objConn.State == ConnectionState.Open)
				{
					objConn.Close();
				}

				objConn.Open();
				
				DataTable schemaTable = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,null);
				tableName = schemaTable.Rows[0][2].ToString().Trim(); 
				
				if(tableName.EndsWith("$"))
				{
					cmdText="select * from [" + tableName + "]";
				}
				else
				{
					cmdText="select * from [" + tableName + "$]";
				}

				OleDbDataAdapter a = new OleDbDataAdapter(cmdText,conStr);
				
				ds = new DataSet();

				a.Fill(ds);//�Ƚ����ݷ���һ��DataSet��

			}
			catch(Exception e)
			{
				throw new Exception(e.Message);
			}
			finally
			{
				objConn.Close();
				objConn.Dispose();
			}

			DataTable tbl = ds.Tables[0];

			if(tbl.Columns.Count != 23)
			{
				throw new Exception("Excel�д��ڿձ��,���߸�ʽ����ȷ,����!");
			}
				
			//����һ���µ�DataSet,���е�һ�ű��а���һ���Զ�������
			DataSet returnDs = new DataSet();//�½�һ����¼��
			DataTable returnTable = new DataTable();//�½�һ�ű�
			returnDs.Tables.Add(returnTable);//���ñ���ӵ�DatSet��

			DataColumn col1 = returnTable.Columns.Add("�к�");//���½�һ���Զ�������,������ʾExcel���е��к�
			col1.AutoIncrement = true;
			col1.AutoIncrementSeed = 2;//������ΪExcel���е�һ���Ǳ�����,�����к��Ǵ�1��ʼ��
			col1.AutoIncrementStep = 1;

			foreach(DataColumn col in tbl.Columns)//Ϊ�ñ��������Excel���е���
			{
				returnTable.Columns.Add(col.ColumnName);
			}

			foreach(DataRow row in tbl.Rows) //��Excel���е����е�����ӵ��ñ���
			{
				DataRow newRow = returnTable.NewRow();
				for(int i=1;i<returnTable.Columns.Count;i++)
				{
					newRow[i] = row[i-1];
				}
				returnTable.Rows.Add(newRow);

			}

			foreach(Process process in Process.GetProcessesByName("EXCEL"))
			{
				process.Kill();
			}

			return returnDs;

		}
		
		DataTable CreateTable(DataTable sourceTable)
		{
			DataTable tbl = new DataTable();

			foreach(DataColumn col in sourceTable.Columns)
			{
				tbl.Columns.Add(col.ColumnName);
			}
			tbl.Columns.Add("�ظ�����");  //����һ��,������ʾ�ظ�����
			tbl.PrimaryKey = new DataColumn[]{tbl.Columns["����"],tbl.Columns["��˾"]};  //��������,��������
			return tbl;
		}
		void AddRowToTable(DataTable tbl,DataRow row)
		{
			if(!tbl.Rows.Contains(new object[]{row["����"].ToString(),row["��˾"].ToString()}))  //������в�������ǰ��
			{
				DataRow newRow = tbl.NewRow();
				for(int i=0;i<tbl.Columns.Count - 1;i++)
				{
					newRow[i] = row[i];
				}
				newRow["�ظ�����"] = 1;
				tbl.Rows.Add(newRow);
			}
			else  //�����ظ����� + 1
			{
				DataRow row1 = tbl.Rows.Find(new object[]{row["����"].ToString(),row["��˾"].ToString()});
				row1["�ظ�����"] = Int32.Parse(row1["�ظ�����"].ToString()) + 1;  
			}
		}
		
		void CheckTableFormat(DataTable table)
		{
			string[] fieldsArray = new string[]{
									"��ʼ����","��������","��������","����","����","���","����","�ؼ�����",
									"����","��˾","������ʽ","ְλ","��ַ","�ʱ�","�ֻ�","�绰","���","��Դ",
									"֧����ʽ","��Ʊ��","�ͻ����","ҵ��Ա","������ȡ"};
			foreach(string fieldString in fieldsArray)
			{
				if(table.Columns[fieldString] == null)
				{
					throw new Exception("Excel�����ֶ� \"" + fieldString + "\" �����Ʋ���ȷ,������ֶ����Ƿ��ж���Ŀո���������Ƿ���ȷ!");
				}
			}

		}
		DataTable CheckDataReduplicateInExcel(DataTable sourceTable)   //�����Excel�����Ƿ����ظ��ļ�¼,�����,����DataSet������
		{
			DataTable tbl = CreateTable(sourceTable);

			DataRow[] sourceRows = sourceTable.Select("","����");  //�Ȱ���������
			int i;
			for(i = 0;i<sourceRows.Length -1;i++)  //�ӵ�һ����¼�����ڶ�����¼���е���
			{
				string name1 = sourceRows[i]["����"].ToString().Trim();
				string company1 = sourceRows[i]["��˾"].ToString().Trim();
				string name2 = sourceRows[i+1]["����"].ToString().Trim();
				string company2 = sourceRows[i+1]["��˾"].ToString().Trim();

				if(name1 == "")
				{
					sourceRows[i]["����"] = "  ";
				}
				if(company1 == "")
				{
					sourceRows[i]["��˾"] = "  ";
				}
				if( name1 == name2 && company1 == company2)
				{
					AddRowToTable(tbl,sourceRows[i]);//����,�п��ܽ��ӵ����ڶ�����¼֮ǰ�����м�¼����ӵ�tbl��
				}
			}

			return tbl;

		}
		DataTable CheckDataReduplicateWithDatabase(DataTable sourceTable)   //�����Excel�����Ƿ��������ݿ��ظ��ļ�¼,�����,����DataTable������
		{
			DataTable tbl = CreateTable(sourceTable);
			
			foreach(DataRow row in sourceTable.Rows)
			{
				int count = SubscribeInfoManager.CheckSubscribeExist(row["����"].ToString().Trim(),row["��˾"].ToString().Trim());
				if(count >=1)  //˵����ǰ��¼�����ݿ��������Ѿ�����
				{
					if(row["����"].ToString().Trim() == "")
					{
						row["����"] = "  ";
					}
					if(row["��˾"].ToString().Trim() == "")
					{
						row["��˾"] = "  ";
					}
					AddRowToTable(tbl,row);
				}
			}
			return tbl;
		}
		
		void ImportDataToDatabase(DataTable sourceTable)
		{

			SubscribeInfoManager.ClearTempInfo();

			foreach(DataRow row in sourceTable.Rows)
			{

				DateTime startDate = DateTime.Parse("1900-1-1");
				DateTime endDate = DateTime.Parse("1900-1-1");
				DateTime giveDate = DateTime.Parse("1900-1-1");

				int number = -1;
				int monthCount = -1;
				int totalMoney = -1;
				string name;
				string localAddress;
				string company;
				string subscription;
				string post;
				string region;
				string address;
				string postcode;
				string mobilePhone;
				string telephone;
				string inscribe;
				string source;
				string payment;
				string invoice;
				string client;
				string operator1;
				string bonus;

				if(row["��ʼ����"] != DBNull.Value)
				{
					startDate = DateTime.Parse(row["��ʼ����"].ToString().Trim());//ע��:����һ���ܹ�ת��,��Ϊ�����ʽ����ȷ������ֵ�ض�ΪDBNull.Value
				}
				if(row["��������"] != DBNull.Value)
				{
					endDate = DateTime.Parse(row["��������"].ToString().Trim());//ͬ��
				}
				if(row["��������"] != DBNull.Value)
				{
					giveDate = DateTime.Parse(row["��������"].ToString().Trim());//ͬ��
				}
				if(row["����"] != DBNull.Value)
				{
					number = Int32.Parse(row["����"].ToString());//ͬ��
				}
				if(row["����"] != DBNull.Value)
				{
					monthCount = Int32.Parse(row["����"].ToString());//ͬ��
				}
				if(row["���"] != DBNull.Value)
				{
					totalMoney = Int32.Parse(row["���"].ToString());//ͬ��
				}
				
				name = row["����"].ToString().Trim() == String.Empty ? "  " : row["����"].ToString().Trim();
				localAddress = row["�ؼ�����"].ToString().Trim() == String.Empty ? "  " : row["�ؼ�����"].ToString().Trim();
				region = row["����"].ToString().Trim() == String.Empty ? "  " : row["����"].ToString().Trim();
				company = row["��˾"].ToString().Trim() == String.Empty ? "  " : row["��˾"].ToString().Trim();
				subscription = row["������ʽ"].ToString().Trim() == String.Empty ? "  " : row["������ʽ"].ToString().Trim();
				post = row["ְλ"].ToString().Trim() == String.Empty ? "  " : row["ְλ"].ToString().Trim();
				address = row["��ַ"].ToString().Trim() == String.Empty ? "  " : row["��ַ"].ToString().Trim();
				postcode = row["�ʱ�"].ToString().Trim() == String.Empty ? "  " : row["�ʱ�"].ToString().Trim();
				mobilePhone = row["�ֻ�"].ToString().Trim() == String.Empty ? "  " : row["�ֻ�"].ToString().Trim();
				telephone = row["�绰"].ToString().Trim() == String.Empty ? "  " : row["�绰"].ToString().Trim();
				inscribe = row["���"].ToString().Trim() == String.Empty ? "  " : row["���"].ToString().Trim();
				source = row["��Դ"].ToString().Trim() == String.Empty ? "  " : row["��Դ"].ToString().Trim();
				payment = row["֧����ʽ"].ToString().Trim() == String.Empty ? "  " : row["֧����ʽ"].ToString().Trim();
				invoice = row["��Ʊ��"].ToString().Trim() == String.Empty ? "  " : row["��Ʊ��"].ToString().Trim();
				client = row["�ͻ����"].ToString().Trim() == String.Empty ? "  " : row["�ͻ����"].ToString().Trim();
				operator1 = row["ҵ��Ա"].ToString().Trim() == String.Empty ? "  " : row["ҵ��Ա"].ToString().Trim();
				bonus = row["������ȡ"].ToString().Trim() == String.Empty ? "  " : row["������ȡ"].ToString().Trim();
				
				SubscribeInfoManager.CreateSubscribeInfo(name,post,company,address,region,postcode,telephone,mobilePhone,startDate,endDate,giveDate,number,monthCount,totalMoney,inscribe,source,payment,invoice,client,operator1,bonus,localAddress,subscription);
			}
		}
		

		bool ImportExcelData()
		{
			openFileDialog1.Filter = "Excel�����ļ�|*.xls";
			openFileDialog1.RestoreDirectory = true;
			if(openFileDialog1.ShowDialog()==DialogResult.OK)
			{
				DataSet ds = null;
				DataTable tempTable = null;
				try
				{
					ds = GetData(openFileDialog1.FileName);
					
					CheckTableFormat(ds.Tables[0]);
				}
				catch(Exception e)
				{
					MessageBox.Show(e.Message);
					return false;
				}
				//������Ϊֹ,˵��Excel�����ֶεĽṹ�Ѿ���ȷ
				
				//1.���Excel���Ƿ����ظ��ļ�¼
				tempTable = CheckDataReduplicateInExcel(ds.Tables[0]);

				if(tempTable.Rows.Count > 0)
				{
					DataSet tempDs = new DataSet();
					tempDs.Tables.Add(tempTable);
					//����һ������,��ʾExcel������ظ��ļ�¼
					TempForm tempForm = new TempForm("����" + tempDs.Tables[0].Rows.Count + "����¼��Excel�������ظ�,��˶Ժ��ٵ���");
					tempForm.CurrentDataSet = tempDs;
					tempForm.StartPosition = FormStartPosition.CenterParent;
					tempForm.ShowDialog();

					return false;
				}
				//2.���Excel���Ƿ��к����ݿ��ظ��ļ�¼
				tempTable = CheckDataReduplicateWithDatabase(ds.Tables[0]);

				if(tempTable.Rows.Count > 0)
				{
					DataSet tempDs = new DataSet();
					tempDs.Tables.Add(tempTable);
					//����һ������,��ʾ�����ݿ��м�¼�ظ��ļ�¼
					TempForm tempForm = new TempForm("����" + tempDs.Tables[0].Rows.Count + "����¼�����ݿ����Ѵ���,��˶Ժ��ٵ���");
					tempForm.CurrentDataSet = tempDs;
					tempForm.StartPosition = FormStartPosition.CenterParent;
					tempForm.ShowDialog();

					return false;
				}

				//��������԰�ȫ�Ľ����ݵ��뵽���ݿ�
				ImportDataToDatabase(ds.Tables[0]);
				
				this.currentDataSet = SubscribeInfoManager.RetriveDataFromTempInfo();
							
				return true;
				
			}
			return false;
		}
		
		void ExportDataToExcel()
		{
			string fileName;
			this.openFileDialog1.Filter = "Excel�����ļ�|*.xls";
			this.openFileDialog1.RestoreDirectory = true;
			if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				fileName = this.openFileDialog1.FileName;
				string path = Path.GetDirectoryName(fileName);
				if(!path.EndsWith(@"\"))
				{
					path = path + @"\";
				}
				string name = Path.GetFileName(fileName);

				SubscribeInfoManager.OutputDataToExcel(path,name,"TempInfo");

				foreach(Process process in Process.GetProcessesByName("EXCEL"))
				{
					process.Kill();
				}

				MessageBox.Show("�����ѳɹ����浽 " + fileName);
			}
		}

		void CreateMainMenu()
		{
			this.SuspendLayout();
			topMenu = new MenuControl();
			//����û��˵�
			Crownwood.Magic.Menus.MenuCommand itemUserManage = new MenuCommand("�û�����");
			Crownwood.Magic.Menus.MenuCommand itemAddUser = new MenuCommand("������û�",new EventHandler(AddUser));
			Crownwood.Magic.Menus.MenuCommand itemModifyUserNameAndProperty = new MenuCommand("�����û�Ȩ��",new EventHandler(ModifyUserProperty));
			Crownwood.Magic.Menus.MenuCommand itemModifyUserName = new MenuCommand("�û���������",new EventHandler(ModifyUserName));
			Crownwood.Magic.Menus.MenuCommand itemModifyUserPassword = new MenuCommand("�û���������",new EventHandler(ModifyUserPassword));
			Crownwood.Magic.Menus.MenuCommand itemDeleteUser = new MenuCommand("ɾ���û�",new EventHandler(DeleteUser));
			Crownwood.Magic.Menus.MenuCommand itemUserExit = new MenuCommand("�û��˳�",new EventHandler(UserExit));

			itemUserManage.MenuCommands.AddRange(new MenuCommand[]{itemAddUser,itemModifyUserNameAndProperty,itemModifyUserName,itemModifyUserPassword,itemDeleteUser,itemUserExit});
			//���ҵ��Ա����˵�
			Crownwood.Magic.Menus.MenuCommand itemEmployeeManage = new MenuCommand("ҵ��Ա����");
			Crownwood.Magic.Menus.MenuCommand itemAddEmployee = new MenuCommand("���ҵ��Ա",new EventHandler(AddEmployee));
			Crownwood.Magic.Menus.MenuCommand itemModifyEmployee = new MenuCommand("����ҵ��Ա",new EventHandler(ModifyEmployee));
			Crownwood.Magic.Menus.MenuCommand itemDeleteEmployee = new MenuCommand("ɾ��ҵ��Ա",new EventHandler(DeleteEmployee));

			itemEmployeeManage.MenuCommands.AddRange(new MenuCommand[]{itemAddEmployee,itemModifyEmployee,itemDeleteEmployee});

			//��Ӷ���ϵͳ�˵�
			Crownwood.Magic.Menus.MenuCommand itemSubscribeManage = new MenuCommand("���Ĺ���");
			Crownwood.Magic.Menus.MenuCommand itemAddSubscribe = new MenuCommand("��Ӷ���",new EventHandler(AddSubscribe));
			Crownwood.Magic.Menus.MenuCommand itemBatchModifySubscribe = new MenuCommand("�����޸�",new EventHandler(BatchModifySubscribe));

			Crownwood.Magic.Menus.MenuCommand itemModifySubscribe = new MenuCommand("�޸Ķ���",new EventHandler(ModifySubscribe));
			Crownwood.Magic.Menus.MenuCommand itemDeleteSubscribe = new MenuCommand("ɾ������",new EventHandler(DeleteSubscribe));
			Crownwood.Magic.Menus.MenuCommand itemSearchSubscribe = new MenuCommand("��ѯ����",new EventHandler(SearchSubscribe));
			Crownwood.Magic.Menus.MenuCommand itemOtherSearch = new MenuCommand("������ѯ",new EventHandler(OtherSearch));
			Crownwood.Magic.Menus.MenuCommand itemInputSubscribe = new MenuCommand("���ݵ���",new EventHandler(InputSubscribe));
			Crownwood.Magic.Menus.MenuCommand itemOutputSubscribe = new MenuCommand("���ݵ���",new EventHandler(OutputSubscribe));
			Crownwood.Magic.Menus.MenuCommand itemStatSubscribe = new MenuCommand("ͳ�ƽ��",new EventHandler(StatSubscribe));

			itemSubscribeManage.MenuCommands.AddRange(new MenuCommand[]{itemAddSubscribe,itemModifySubscribe,itemBatchModifySubscribe,itemDeleteSubscribe,itemSearchSubscribe,itemOtherSearch,itemInputSubscribe,itemOutputSubscribe,itemStatSubscribe});
			
			//��������˵�
			Crownwood.Magic.Menus.MenuCommand itemOtherInfoManage = new MenuCommand("��������");
			Crownwood.Magic.Menus.MenuCommand itemAddRegion = new MenuCommand("��ӵ���",new EventHandler(AddRegion));
			Crownwood.Magic.Menus.MenuCommand itemDeleteRegion = new MenuCommand("ɾ������",new EventHandler(DeleteRegion));

			itemOtherInfoManage.MenuCommands.AddRange(new MenuCommand[]{itemAddRegion,itemDeleteRegion});

			
			topMenu.MenuCommands.AddRange(new MenuCommand[]{itemUserManage,itemEmployeeManage,itemSubscribeManage,itemOtherInfoManage});
			topMenu.Dock = DockStyle.Top;
			
			this.Controls.Add(topMenu);
			this.ResumeLayout();
			this.Menu = null;
			topMenu.Style = Crownwood.Magic.Common.VisualStyle.IDE;
			topMenu.MdiContainer = this;

		}

		void CreateToolbar()
		{
			bar = new ToolBar();
			ImageList imgList = new ImageList();
			ResourceManager iconsManager    = null;
			iconsManager = new ResourceManager("main.BitmapResources",Assembly.GetEntryAssembly());

			imgList.Images.Add((Bitmap)iconsManager.GetObject("AddButton"));
			imgList.Images.Add((Bitmap)iconsManager.GetObject("SearchButton"));
			imgList.Images.Add((Bitmap)iconsManager.GetObject("ModifyButton"));
			imgList.Images.Add((Bitmap)iconsManager.GetObject("InputButton"));
			imgList.Images.Add((Bitmap)iconsManager.GetObject("OutputButton"));
			imgList.Images.Add((Bitmap)iconsManager.GetObject("DeleteButton"));
			imgList.Images.Add((Bitmap)iconsManager.GetObject("ClearButton"));
			imgList.Images.Add((Bitmap)iconsManager.GetObject("SelectAllButton"));
			imgList.Images.Add((Bitmap)iconsManager.GetObject("StatButton"));
			
			bar.AutoSize  = true;
			bar.ButtonClick += new ToolBarButtonClickEventHandler(ToolBarButtonClick);
			
			bar.Appearance = ToolBarAppearance.Flat;
			bar.TextAlign = ToolBarTextAlign.Right;
			//��Ӷ��İ�ť
			ToolBarButton btnAddSubscribe = new ToolBarButton();
			btnAddSubscribe.ImageIndex = 0;
			btnAddSubscribe.ToolTipText = "��Ӷ�����Ϣ";
			btnAddSubscribe.Text = "���";
			//ɾ�����İ�ť
			ToolBarButton btnDeleteSubscribe = new ToolBarButton();
			btnDeleteSubscribe.ImageIndex = 5;
			btnDeleteSubscribe.ToolTipText = "ɾ����ǰ�Ķ�����Ϣ";
			btnDeleteSubscribe.Text = "ɾ��";
			//��ѯ���İ�ť
			ToolBarButton btnSearchSubscribe = new ToolBarButton();
			btnSearchSubscribe.ImageIndex = 1;
			btnSearchSubscribe.ToolTipText = "��������ѯ������Ϣ";
			btnSearchSubscribe.Text = "��ѯ";
			//�޸Ķ��İ�ť
			ToolBarButton btnModifySubscribe = new ToolBarButton();
			btnModifySubscribe.ImageIndex = 2;
			btnModifySubscribe.ToolTipText = "�޸ĵ�ǰ�Ķ�����Ϣ";
			btnModifySubscribe.Text = "�޸�";
			//���ݵ��밴ť
			ToolBarButton btnInputSubscribe = new ToolBarButton();
			btnInputSubscribe.ImageIndex = 3;
			btnInputSubscribe.ToolTipText = "��Excel�ļ��е��붩����Ϣ";
			btnInputSubscribe.Text = "����";
			//���ݵ�����ť
			ToolBarButton btnOutputSubscribe = new ToolBarButton();
			btnOutputSubscribe.ImageIndex = 4;
			btnOutputSubscribe.ToolTipText = "��������Ϣ������Excel�ļ�";
			btnOutputSubscribe.Text = "����";

			//���ذ�ť
			ToolBarButton btnClearSubscribe = new ToolBarButton();
			btnClearSubscribe.ImageIndex = 6;
			btnClearSubscribe.ToolTipText = "���ص�ǰ��ʾ�ļ�¼";
			btnClearSubscribe.Text = "����";

			//ȫѡ��ť
			ToolBarButton btnSelectAllSubscribe = new ToolBarButton();
			btnSelectAllSubscribe.ImageIndex = 7;
			btnSelectAllSubscribe.ToolTipText = "ѡ�����еĶ�����Ϣ";
			btnSelectAllSubscribe.Text = "ȫѡ";

			//ͳ�ư�ť
			ToolBarButton btnStatSubscribe = new ToolBarButton();
			btnStatSubscribe.ImageIndex = 8;
			btnStatSubscribe.ToolTipText = "ͳ�Ʒ��������Ķ�����Ϣ�Ľ����������ϸ���";
			btnStatSubscribe.Text = "ͳ��";

			bar.Buttons.AddRange(new ToolBarButton[]{btnAddSubscribe,btnDeleteSubscribe,btnSelectAllSubscribe,btnSearchSubscribe,btnModifySubscribe,btnInputSubscribe,btnOutputSubscribe,btnStatSubscribe,btnClearSubscribe});
			bar.ImageList = imgList;

			this.SuspendLayout();
			this.Controls.Add(bar);
			bar.BringToFront();
			this.ResumeLayout();
		}

		void CreateSplitter()
		{
			this.SuspendLayout();
			
			System.Windows.Forms.Splitter splitter = new Splitter();
			splitter.Dock = DockStyle.Top;
			splitter.BackColor = SystemColors.ControlDark;
			splitter.Enabled = false;
			splitter.Height = 1;

			this.Controls.Add(splitter);

			this.ResumeLayout();

			splitter.BringToFront();
			this.dataGrid1.BringToFront();

		}

		void SetButtonEnabled()
		{
			if(currentManager.Property == 0)  //�����һ���û�
			{
				this.topMenu.MenuCommands["�û�����"].MenuCommands["������û�"].Enabled = false;
				this.topMenu.MenuCommands["�û�����"].MenuCommands["�����û�Ȩ��"].Enabled = false;
				this.topMenu.MenuCommands["�û�����"].MenuCommands["�û���������"].Enabled = true;
				this.topMenu.MenuCommands["�û�����"].MenuCommands["ɾ���û�"].Enabled = false;


				this.topMenu.MenuCommands["ҵ��Ա����"].Enabled = false;
				this.topMenu.MenuCommands["��������"].Enabled = false;
				this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["��Ӷ���"].Enabled = false;
				this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["�޸Ķ���"].Enabled = false;
				this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["�����޸�"].Enabled = false;
				this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["ɾ������"].Enabled = false;
				this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["���ݵ���"].Enabled = false;
				this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["���ݵ���"].Enabled = false;

				this.bar.Buttons[1].Enabled = false;
				this.bar.Buttons[2].Enabled = false;
				this.bar.Buttons[4].Enabled = false;
				this.bar.Buttons[6].Enabled = false;
				if(this.currentDataSet == null)
				{
					this.bar.Buttons[8].Enabled = false;

				}
				else if(this.currentDataSet.Tables[0].Rows.Count == 0)
				{
					this.bar.Buttons[8].Enabled = false;

				}
				else
				{
					this.bar.Buttons[8].Enabled = true;
				}
				this.bar.Buttons[5].Enabled = false;
				this.bar.Buttons[0].Enabled = false;
				this.bar.Buttons[3].Enabled = true;
			}
			else
			{
				if(this.currentDataSet == null)
				{
					this.bar.Buttons[1].Enabled = false;
					this.bar.Buttons[2].Enabled = false;
					this.bar.Buttons[4].Enabled = false;
					this.bar.Buttons[6].Enabled = false;
					this.bar.Buttons[8].Enabled = false;
					this.bar.Buttons[5].Enabled = true;
					this.bar.Buttons[0].Enabled = true;
					this.bar.Buttons[3].Enabled = true;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["�޸Ķ���"].Enabled = false;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["�����޸�"].Enabled = false;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["ɾ������"].Enabled = false;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["���ݵ���"].Enabled = false;
				}
				else if(this.currentDataSet.Tables[0].Rows.Count == 0)
				{
					this.bar.Buttons[1].Enabled = false;
					this.bar.Buttons[2].Enabled = false;
					this.bar.Buttons[4].Enabled = false;
					this.bar.Buttons[6].Enabled = false;
					this.bar.Buttons[8].Enabled = false;
					this.bar.Buttons[5].Enabled = true;
					this.bar.Buttons[0].Enabled = true;
					this.bar.Buttons[3].Enabled = true;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["�޸Ķ���"].Enabled = false;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["�����޸�"].Enabled = false;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["ɾ������"].Enabled = false;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["���ݵ���"].Enabled = false;
				}
				else
				{
					this.bar.Buttons[2].Enabled = true;
					this.bar.Buttons[4].Enabled = true;
					this.bar.Buttons[5].Enabled = true;
					this.bar.Buttons[1].Enabled = true;
					this.bar.Buttons[3].Enabled = true;
					this.bar.Buttons[0].Enabled = true;
					this.bar.Buttons[6].Enabled = true;
					this.bar.Buttons[7].Enabled = true;
					this.bar.Buttons[8].Enabled = true;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["�޸Ķ���"].Enabled = true;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["�����޸�"].Enabled = true;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["ɾ������"].Enabled = true;
					this.topMenu.MenuCommands["���Ĺ���"].MenuCommands["���ݵ���"].Enabled = true;
				}
				if(this.currentManager.Property == 1)
				{
					this.topMenu.MenuCommands["�û�����"].MenuCommands["�����û�Ȩ��"].Enabled = false;
				}
			}

		}
		

		void RebindToDataGrid()
		{
			if(currentDataSet != null)
			{
				if(currentDataSet.Tables[0] != null)
				{
					currentDataSet.Tables[0].TableName = "resultTable";

					this.dataGrid1.DataSource = null;

					this.dataGrid1.SetDataBinding(currentDataSet,"resultTable");
				
					DataGridTableStyle ts = new DataGridTableStyle();
					ts.MappingName = this.dataGrid1.DataMember;
					if(this.dataGrid1.TableStyles.Count > 0 )
					{
						this.dataGrid1.TableStyles.Clear();	
					}
					
					this.dataGrid1.TableStyles.Add(ts);
					this.dataGrid1.TableStyles[0].RowHeaderWidth = 45;
					this.dataGrid1.TableStyles[0].AllowSorting = false;
					this.dataGrid1.TableStyles[0].GridColumnStyles["����"].Width = 60;
					this.dataGrid1.TableStyles[0].GridColumnStyles["��˾"].Width = 170;
					this.dataGrid1.TableStyles[0].GridColumnStyles["��ַ"].Width = 200;

				}
			}
		}

		bool TestSelectedRows()
		{
			int i1;
			for(i1 = 0;i1<this.currentDataSet.Tables[0].Rows.Count;i1++)
			{
				if(this.dataGrid1.IsSelected(i1) == true)
				{
					break;
				}
			}
			if(i1 == this.currentDataSet.Tables[0].Rows.Count)
			{
				return false;
			}
			return true;
		}
		bool DeleteSelectedRows()
		{
			if(TestSelectedRows() == false)
			{
				MessageBox.Show("��ѡ��һ�н���ɾ����");
				return false;
			}
			if(MessageBox.Show("ɾ�����ָܻ�,�Ƿ�ɾ����","����",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				for(int i = 0;i<this.currentDataSet.Tables[0].Rows.Count;i++)  //ͨ��ѭ��ɾ�����б�ѡ�е���
				{
					if(this.dataGrid1.IsSelected(i) == true)
					{
						string name = this.currentDataSet.Tables[0].Rows[i]["����"].ToString();
						string company = this.currentDataSet.Tables[0].Rows[i]["��˾"].ToString();
						SubscribeInfoManager.DeleteSubscribeInfo(name,company);
					}
				}
				
				this.currentDataSet = SubscribeInfoManager.RetriveDataFromTempInfo();

				return true;
			}
			else
			{
				return false;
			}
		}

		void ToolBarButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Text) 
			{
				case "���":
					AddForm addForm = new AddForm();
					addForm.StartPosition = FormStartPosition.CenterParent;
					if(addForm.ShowDialog() == DialogResult.OK)
					{
						RebindToDataGrid();
					}
					break;
				case "ɾ��":
					if(DeleteSelectedRows() == true)
					{
						RebindToDataGrid();
					}
					break;
				case "�޸�":
					UpdateForm updateForm = new UpdateForm();
					updateForm.StartPosition = FormStartPosition.CenterParent;
					if(updateForm.ShowDialog() == DialogResult.OK)
					{
						RebindToDataGrid();
					}
					break;
				case "��ѯ":
					SearchForm searchForm = new SearchForm();
					searchForm.StartPosition = FormStartPosition.CenterParent;
					if(searchForm.ShowDialog() == DialogResult.OK)
					{
						RebindToDataGrid();
					}
					break;
				case "����":
					//if(MessageBox.Show("����ǰ���ȱ��沢�ر����д򿪵�Excel�ĵ�!","����",MessageBoxButtons.OKCancel,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1) == DialogResult.OK)
					//{
						if(ImportExcelData() == true)
						{
							RebindToDataGrid();
						}
					//}
					break;
				case "����":
					ExportDataToExcel();
					break;
				case "����":
					this.currentDataSet = null;
					this.dataGrid1.DataSource = null;
					break;
				case "ȫѡ":
					for(int i=0;i<this.currentDataSet.Tables[0].Rows.Count;i++)
					{
						this.dataGrid1.Select(i);
					}
					break;
				case "ͳ��":
					StatSubscribeForm statSubscribeForm = new StatSubscribeForm();
					statSubscribeForm.StartPosition = FormStartPosition.CenterParent;
					if(statSubscribeForm.ShowDialog() == DialogResult.OK)
					{
						ShowStatResultForm form = new ShowStatResultForm(this.statResultTable,this.currentInputDate);
						form.StartPosition = FormStartPosition.CenterParent;
						form.ShowDialog();
					}
					break;
			}
		}

		
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			CreateMainMenu();//�����˵���

			CreateToolbar();//����������

			CreateSplitter();//����һ���ָ���
			
			SetButtonEnabled();//���ù������ϰ�ť�Ļ״̬

			SubscribeInfoManager.ClearTempInfo();  //�����ʱ���е�����
			
			this.Text = this.Text + "     ��ǰ�û�:  " + this.currentManager.Name;


		}

		private void dataGrid1_DataSourceChanged(object sender, System.EventArgs e)
		{
			SetButtonEnabled();
		}

		
		private void dataGrid1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{

			int row =1;  
			int y = 0;
			if(this.currentDataSet != null)
			{
				int count =this.currentDataSet.Tables[0].Rows.Count; 

				while( row <= count)  
				{ 
					//get & draw the header text... 
 
					string text = string.Format(" {0}", row);

					y = this.dataGrid1.GetCellBounds(row - 1, 0).Y + 2;
 
					e.Graphics.DrawString(text,this.dataGrid1.Font, new SolidBrush(Color.Black),2,y); 

					row ++;  
				}
			}

		}


		void CreatePopUpMenu(object sender,MouseEventArgs e)
		{
			PopupMenu popup = new PopupMenu();
			DataGrid myGrid = (DataGrid) sender;
			popup.Style = Crownwood.Magic.Common.VisualStyle.IDE;

			Crownwood.Magic.Menus.MenuCommand itemAddSubscribe = new MenuCommand("��Ӷ���",new EventHandler(AddSubscribe));
			Crownwood.Magic.Menus.MenuCommand itemModifySubscribe = new MenuCommand("�޸Ķ���",new EventHandler(ModifySubscribe));
			Crownwood.Magic.Menus.MenuCommand itemDeleteSubscribe = new MenuCommand("ɾ������",new EventHandler(DeleteSubscribe));
			Crownwood.Magic.Menus.MenuCommand itemSearchSubscribe = new MenuCommand("��ѯ����",new EventHandler(SearchSubscribe));
			Crownwood.Magic.Menus.MenuCommand itemInputSubscribe = new MenuCommand("���ݵ���",new EventHandler(InputSubscribe));
			Crownwood.Magic.Menus.MenuCommand itemOutputSubscribe = new MenuCommand("���ݵ���",new EventHandler(OutputSubscribe));

			popup.MenuCommands.AddRange(new MenuCommand[]{itemAddSubscribe,itemModifySubscribe,itemDeleteSubscribe,itemSearchSubscribe,itemInputSubscribe,itemOutputSubscribe});

			if(this.currentManager.Property == 0)
			{
				popup.MenuCommands["��Ӷ���"].Enabled = false;
				popup.MenuCommands["�޸Ķ���"].Enabled = false;
				popup.MenuCommands["ɾ������"].Enabled = false;
				popup.MenuCommands["��ѯ����"].Enabled = true;
				popup.MenuCommands["���ݵ���"].Enabled = false;
				popup.MenuCommands["���ݵ���"].Enabled = false;

			}
			
			popup.TrackPopup(myGrid.PointToScreen(new Point(e.X, e.Y)));


		}
		
		private void dataGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			DataGrid myGrid = (DataGrid) sender;
			DataGrid.HitTestInfo hti = myGrid.HitTest(e.X,e.Y);
			if(e.Button == MouseButtons.Right)
			{
				if(hti.Type == DataGrid.HitTestType.RowHeader)
				{
					CreatePopUpMenu(sender,e);
				}
			}

		}


	}


}
