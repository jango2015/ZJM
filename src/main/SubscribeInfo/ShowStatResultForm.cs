using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using NetFocus.MagzineSubscribe.Business;


namespace NetFocus.MagzineSubscribe.UI
{

	public class ShowStatResultForm : System.Windows.Forms.Form
	{
		#region һЩ����

		DateTime startDate;
		DateTime endDate;
		DateTime giveDate;
		int number;
		int monthCount;
		int totalMoney;
		int averageMoney;
		int monthMoney;
		string name;
		string post;
		string company;
		string region;
		string source;
		string invoice;
		string telephone;
		string mobilephone;

		string fileName;

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private DataTable tbl = null;
		private DateTime inputDate;
		private int totalRealMoney;
		private int totalShouldMoney;

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnExport1;
		private System.Windows.Forms.Button btnExport2;
		private System.Windows.Forms.Panel pnlHavePaid;
		private System.Windows.Forms.Panel pnlUnPaid;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;

		private DataTable tempTable = new DataTable();
		private DataTable tempTable1 = new DataTable();

		#endregion
		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ShowStatResultForm));
			this.label1 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.label3 = new System.Windows.Forms.Label();
			this.btnExport1 = new System.Windows.Forms.Button();
			this.btnExport2 = new System.Windows.Forms.Button();
			this.pnlHavePaid = new System.Windows.Forms.Panel();
			this.pnlUnPaid = new System.Windows.Forms.Panel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.pnlHavePaid.SuspendLayout();
			this.pnlUnPaid.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("����", 13F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(818, 39);
			this.label1.TabIndex = 0;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataGrid1
			// 
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 303);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(818, 296);
			this.dataGrid1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(743, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "�Ѹ���Ĺ�˾����";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataGrid2
			// 
			this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid2.CaptionFont = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Bold);
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Top;
			this.dataGrid2.FlatMode = true;
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(0, 63);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(818, 216);
			this.dataGrid2.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("����", 11F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(743, 24);
			this.label3.TabIndex = 5;
			this.label3.Text = "δ����Ĺ�˾����";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnExport1
			// 
			this.btnExport1.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnExport1.Location = new System.Drawing.Point(743, 0);
			this.btnExport1.Name = "btnExport1";
			this.btnExport1.Size = new System.Drawing.Size(75, 24);
			this.btnExport1.TabIndex = 6;
			this.btnExport1.Text = "�� ��";
			this.btnExport1.Click += new System.EventHandler(this.btnExport1_Click);
			// 
			// btnExport2
			// 
			this.btnExport2.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnExport2.Location = new System.Drawing.Point(743, 0);
			this.btnExport2.Name = "btnExport2";
			this.btnExport2.Size = new System.Drawing.Size(75, 24);
			this.btnExport2.TabIndex = 7;
			this.btnExport2.Text = "�� ��";
			this.btnExport2.Click += new System.EventHandler(this.btnExport2_Click);
			// 
			// pnlHavePaid
			// 
			this.pnlHavePaid.Controls.Add(this.label2);
			this.pnlHavePaid.Controls.Add(this.btnExport1);
			this.pnlHavePaid.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHavePaid.Location = new System.Drawing.Point(0, 39);
			this.pnlHavePaid.Name = "pnlHavePaid";
			this.pnlHavePaid.Size = new System.Drawing.Size(818, 24);
			this.pnlHavePaid.TabIndex = 8;
			// 
			// pnlUnPaid
			// 
			this.pnlUnPaid.Controls.Add(this.label3);
			this.pnlUnPaid.Controls.Add(this.btnExport2);
			this.pnlUnPaid.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlUnPaid.Location = new System.Drawing.Point(0, 279);
			this.pnlUnPaid.Name = "pnlUnPaid";
			this.pnlUnPaid.Size = new System.Drawing.Size(818, 24);
			this.pnlUnPaid.TabIndex = 9;
			// 
			// ShowStatResultForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(818, 599);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.pnlUnPaid);
			this.Controls.Add(this.dataGrid2);
			this.Controls.Add(this.pnlHavePaid);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ShowStatResultForm";
			this.Text = "ͳ�ƽ��";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.ShowStatResultForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.pnlHavePaid.ResumeLayout(false);
			this.pnlUnPaid.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}



		public ShowStatResultForm(DataTable tbl,DateTime inputDate)
		{

			InitializeComponent();

			this.tbl = tbl;
			this.inputDate = inputDate;
		}

		
		void AddRowToTable(DataTable tbl,DataRow row,int moneyOfThisMonth)
		{
			DataRow newRow = tbl.NewRow();
			for(int i=0;i<tbl.Columns.Count-1;i++)
			{
				if(tbl.Columns[i].ColumnName == "��ʼ����" || tbl.Columns[i].ColumnName == "��������" || tbl.Columns[i].ColumnName == "��������")
				{
					if(row[i] != DBNull.Value)
					{
						newRow[i] = DateTime.Parse(row[i].ToString()).Year.ToString() + "-" + DateTime.Parse(row[i].ToString()).Month.ToString() + "-1";
					}
				}
				else
				{
					newRow[i] = row[i];
				}
			}
			newRow[tbl.Columns.Count-1] = moneyOfThisMonth;  //���һ���ֶ�������ű�����ȡ

			tbl.Rows.Add(newRow);

		}

		DataTable CreateTable(DataTable sourceTable)
		{
			DataTable tbl = new DataTable();

			foreach(DataColumn col in sourceTable.Columns)
			{
				tbl.Columns.Add(col.ColumnName);
			}

			return tbl;
		}

		void InitData()
		{
			if(tbl == null)
			{
				this.label1.Text = "û��ͳ�ƽ��!";
				return;
			}
			//�������ű�,�ֱ����Ѹ��˾��δ���˾
			//��ʾ:�����tbl�е����ݵ��ص���ֻ������ʼ���ںͽ������ڰ�����ǰ���ڵ�ֵ,����������,��û�������ж�
			tempTable = CreateTable(tbl);//���δ����ļ�¼
			tempTable1 = CreateTable(tbl);//����Ѹ���ļ�¼

			if(tbl.Rows.Count <= 0)
			{
				this.label1.Text = "û��ͳ�ƽ��!";
				return;
			}

			foreach(DataRow row in tbl.Rows)
			{
				//�������������������һ��Ϊ��,����Ϊ������͵�
				if(row["���"] == DBNull.Value || row["����"] == DBNull.Value)
				{
					AddRowToTable(tempTable,row,0);
					continue;
				}
				//�����������������Ϊ��,����������Ϊ��
				if(row["��������"] == DBNull.Value)
				{
					AddRowToTable(tempTable,row,0);
					totalShouldMoney = totalShouldMoney + Int32.Parse(row["ƽ�����"].ToString());
					continue;
				}

				//�����ǽ��,����,�������ڶ���Ϊ�յ����																	 
				DateTime giveDate = DateTime.Parse(row["��������"].ToString());
				//1.����������Ϊֹ,�õ�λ��δ����
				if((giveDate.Year == inputDate.Year && giveDate.Month > inputDate.Month) || giveDate.Year > inputDate.Year)  //���������Ϊֹ��δ����
				{
					AddRowToTable(tempTable,row,0);
					totalShouldMoney = totalShouldMoney + Int32.Parse(row["ƽ�����"].ToString());
					continue;
				}
				//2.���������ڱ��¸���
				if(giveDate.Year == inputDate.Year && giveDate.Month == inputDate.Month) 
				{
					int n = 0; //���ڴ��ǰ�漸���°�������Ӧ�ñ��ۼ�����,���㵽����µ�����
					DateTime startDate = DateTime.Parse(row["��ʼ����"].ToString());
					while((startDate.Year == giveDate.Year && startDate.Month <= giveDate.Month) || startDate.Year < giveDate.Year)
					{
						n = n + 1;
						startDate = startDate.AddMonths(1);
					}
					int money = n * Int32.Parse(row["ƽ�����"].ToString());
					totalRealMoney = totalRealMoney + money;
					totalShouldMoney = totalShouldMoney + money;
					AddRowToTable(tempTable1,row,money);
					continue;
				}
				//3.�����ڱ���֮ǰ���Ѿ�����
				totalRealMoney = totalRealMoney + Int32.Parse(row["ƽ�����"].ToString());
				totalShouldMoney = totalShouldMoney + Int32.Parse(row["ƽ�����"].ToString());

				AddRowToTable(tempTable1,row,Int32.Parse(row["ƽ�����"].ToString()));
					

			}
			this.label1.Text = "����ʵ��������Ϊ: " + totalRealMoney.ToString() + " Ԫ" + "      Ӧ��������Ϊ: " + totalShouldMoney.ToString() + " Ԫ" + "     ��ѯ�·�Ϊ: " + inputDate.Year.ToString() + "��" + inputDate.Month.ToString() + "��";
		}

		private void ShowStatResultForm_Load(object sender, System.EventArgs e)
		{
			InitData();
			DataSet ds = new DataSet();
			ds.Tables.Add(tempTable);
			ds.Tables.Add(tempTable1);
			ds.Tables[0].TableName = "tempTable";
			ds.Tables[1].TableName = "tempTable1";

			this.dataGrid1.DataSource = null;

			this.dataGrid1.SetDataBinding(ds,"tempTable");
				
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
			this.dataGrid1.TableStyles[0].GridColumnStyles["ƽ�����"].Width = 0;
			this.dataGrid1.TableStyles[0].GridColumnStyles["��˾"].Width = 186;



			this.dataGrid2.DataSource = null;

			this.dataGrid2.SetDataBinding(ds,"tempTable1");
				
			DataGridTableStyle ts1 = new DataGridTableStyle();
			ts1.MappingName = this.dataGrid2.DataMember;
			if(this.dataGrid2.TableStyles.Count > 0 )
			{
				this.dataGrid2.TableStyles.Clear();	
			}
					
			this.dataGrid2.TableStyles.Add(ts1);
			this.dataGrid2.TableStyles[0].RowHeaderWidth = 45;
			this.dataGrid2.TableStyles[0].AllowSorting = false;
			this.dataGrid2.TableStyles[0].GridColumnStyles["����"].Width = 60;
			this.dataGrid2.TableStyles[0].GridColumnStyles["ƽ�����"].Width = 0;
			this.dataGrid2.TableStyles[0].GridColumnStyles["��˾"].Width = 186;

			this.label2.Text = this.label2.Text + "(��" + tempTable1.Rows.Count.ToString() + "����¼)";
			this.label3.Text = this.label3.Text + "(��" + tempTable.Rows.Count.ToString() + "����¼)";


		}

		void AssignValues(DataRow row)
		{
			name = row["����"].ToString().Trim();
			post = row["ְλ"].ToString().Trim();
			company = row["��˾"].ToString().Trim();
			region = row["����"].ToString().Trim();
			source = row["��Դ"].ToString().Trim();
			invoice = row["��Ʊ��"].ToString().Trim();
			telephone = row["�绰"].ToString().Trim();
			mobilephone = row["�ֻ�"].ToString().Trim();

			if(row["��ʼ����"] != DBNull.Value)
			{
				startDate = DateTime.Parse(row["��ʼ����"].ToString());
			}
			else
			{
				startDate = DateTime.Parse("1900-1-1");
			}
			if(row["��������"] != DBNull.Value)
			{
				endDate = DateTime.Parse(row["��������"].ToString());
			}
			else
			{
				endDate = DateTime.Parse("1900-1-1");
			}
			if(row["��������"] != DBNull.Value)
			{
				giveDate = DateTime.Parse(row["��������"].ToString());
			}
			else
			{
				giveDate = DateTime.Parse("1900-1-1");
			}
			if(row["����"] != DBNull.Value)
			{
				number = Int32.Parse(row["����"].ToString());
			}
			else
			{
				number = -1;
			}
			if(row["����"] != DBNull.Value)
			{
				monthCount = Int32.Parse(row["����"].ToString());
			}
			else
			{
				monthCount = -1;
			}
			if(row["���"] != DBNull.Value)
			{
				totalMoney = Int32.Parse(row["���"].ToString());
			}
			else
			{
				totalMoney = -1;
			}
			if(row["ƽ�����"] != DBNull.Value)
			{
				averageMoney = Int32.Parse(row["ƽ�����"].ToString());
			}
			else
			{
				averageMoney = -1;
			}
			if(row["������ȡ"] != DBNull.Value)
			{
				monthMoney = Int32.Parse(row["������ȡ"].ToString());
			}
			else
			{
				monthMoney = -1;
			}
		}
		void ExportData(DataTable tbl)
		{
			this.openFileDialog1.Filter = "Excel�����ļ�|*.xls";
			this.openFileDialog1.RestoreDirectory = true;
			if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//�Ȼ�ȡһ��Ҫ������Excel�ļ���
				fileName = this.openFileDialog1.FileName;
				string path = Path.GetDirectoryName(fileName);
				if(!path.EndsWith(@"\"))
				{
					path = path + @"\";
				}
				string name1 = Path.GetFileName(fileName);

				//��ձ���ͳ����Ϣ�ı��еļ�¼
				SubscribeInfoManager.ClearStatInfoTable();
				//����¼���뵽StatInfoTable��
				foreach(DataRow row in tbl.Rows)
				{
					AssignValues(row);
					SubscribeInfoManager.InsertIntoStatInfoTable(name,post,company,region,source,invoice,telephone,mobilephone,number,monthCount,totalMoney,averageMoney,monthMoney,startDate,endDate,giveDate);
				}
				//��StatInfoTable���еļ�¼������Excel�ļ���
				SubscribeInfoManager.OutputDataToExcel(path,name1,"StatInfoTable");

				foreach(Process process in Process.GetProcessesByName("EXCEL"))
				{
					process.Kill();
				}

				MessageBox.Show("�����ѳɹ����浽 " + fileName);
			}
		}
		private void btnExport1_Click(object sender, System.EventArgs e)//�����Ѹ���ļ�¼
		{
			ExportData(tempTable1);

		}

		private void btnExport2_Click(object sender, System.EventArgs e)//����δ����ļ�¼
		{
			ExportData(tempTable);

		}

	}
}
