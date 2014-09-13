using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using NetFocus.MagzineSubscribe.Business;


namespace NetFocus.MagzineSubscribe.UI
{
	
	public class BatchUpdateForm : System.Windows.Forms.Form
	{
		
		#region һЩ����

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.TextBox txtNumber;
		private System.Windows.Forms.Label lblStartDate;
		private System.Windows.Forms.Label lblStartYear;
		private System.Windows.Forms.ComboBox cmbStartYear;
		private System.Windows.Forms.Label lblStartMonth;
		private System.Windows.Forms.ComboBox cmbStartMonth;
		private System.Windows.Forms.Label lblEndDate;
		private System.Windows.Forms.ComboBox cmbEndMonth;
		private System.Windows.Forms.Label lblEndMonth;
		private System.Windows.Forms.ComboBox cmbEndYear;
		private System.Windows.Forms.Label lblEndYear;
		private System.Windows.Forms.ComboBox cmbSubscription;
		private System.Windows.Forms.Label lblSubscription;
		private System.Windows.Forms.Label lblNumber;
		private System.Windows.Forms.Label lblNumber1;
		private System.Windows.Forms.Label lblHead;
		private System.Windows.Forms.ComboBox cmbClient;
		private System.Windows.Forms.Label lblClient;
		private System.Windows.Forms.Label lblGiveDate;
		private System.Windows.Forms.Label lblGiveYear;
		private System.Windows.Forms.ComboBox cmbGiveYear;
		private System.Windows.Forms.Label lblGiveMonth;
		private System.Windows.Forms.ComboBox cmbGiveMonth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMonthCount;
		private System.Windows.Forms.TextBox txtTotalMoney;

		DateTime startDateTemp;
		DateTime endDateTemp;
		DateTime giveDateTemp;
		int numberTemp;
		int monthCountTemp;
		int totalMoneyTemp;
		string oldNameTemp;
		string newNameTemp;
		string localAddressTemp;
		string oldCompanyTemp;
		string newCompanyTemp;
		string regionTemp;
		string subscriptionTemp;
		string postTemp;
		string addressTemp;
		string postcodeTemp;
		string  mobilePhoneTemp;
		string telephoneTemp;
		string inscribeTemp;
		string sourceTemp;
		string paymentTemp;
		string invoiceTemp;
		string clientTemp;
		string operator1Temp;
		string bonusTemp;

		DateTime startDate = DateTime.Parse("1000-1-1");
		DateTime endDate = DateTime.Parse("1000-1-1");
		DateTime giveDate = DateTime.Parse("1000-1-1");
		int number = -1;
		int monthCount = -1;
		int totalMoney = -1;
		string subscription = "��";
		string client = "��";

		#endregion
		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(BatchUpdateForm));
			this.lblNumber1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.lblHead = new System.Windows.Forms.Label();
			this.txtNumber = new System.Windows.Forms.TextBox();
			this.lblStartDate = new System.Windows.Forms.Label();
			this.lblStartYear = new System.Windows.Forms.Label();
			this.cmbStartYear = new System.Windows.Forms.ComboBox();
			this.lblStartMonth = new System.Windows.Forms.Label();
			this.cmbStartMonth = new System.Windows.Forms.ComboBox();
			this.lblEndDate = new System.Windows.Forms.Label();
			this.cmbEndMonth = new System.Windows.Forms.ComboBox();
			this.lblEndMonth = new System.Windows.Forms.Label();
			this.cmbEndYear = new System.Windows.Forms.ComboBox();
			this.lblEndYear = new System.Windows.Forms.Label();
			this.lblSubscription = new System.Windows.Forms.Label();
			this.cmbSubscription = new System.Windows.Forms.ComboBox();
			this.lblNumber = new System.Windows.Forms.Label();
			this.cmbClient = new System.Windows.Forms.ComboBox();
			this.lblClient = new System.Windows.Forms.Label();
			this.lblGiveDate = new System.Windows.Forms.Label();
			this.lblGiveYear = new System.Windows.Forms.Label();
			this.cmbGiveYear = new System.Windows.Forms.ComboBox();
			this.lblGiveMonth = new System.Windows.Forms.Label();
			this.cmbGiveMonth = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMonthCount = new System.Windows.Forms.TextBox();
			this.txtTotalMoney = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblNumber1
			// 
			this.lblNumber1.Location = new System.Drawing.Point(152, 184);
			this.lblNumber1.Name = "lblNumber1";
			this.lblNumber1.Size = new System.Drawing.Size(16, 16);
			this.lblNumber1.TabIndex = 61;
			this.lblNumber1.Text = "��";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(184, 256);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 23);
			this.btnCancel.TabIndex = 60;
			this.btnCancel.Text = "ȡ ��";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSubmit
			// 
			this.btnSubmit.Location = new System.Drawing.Point(88, 256);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(56, 23);
			this.btnSubmit.TabIndex = 59;
			this.btnSubmit.Text = "ȷ ��";
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// lblHead
			// 
			this.lblHead.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblHead.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblHead.Location = new System.Drawing.Point(0, 0);
			this.lblHead.Name = "lblHead";
			this.lblHead.Size = new System.Drawing.Size(338, 32);
			this.lblHead.TabIndex = 58;
			this.lblHead.Text = "�����޸Ķ�����Ϣ";
			this.lblHead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtNumber
			// 
			this.txtNumber.Location = new System.Drawing.Point(96, 176);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new System.Drawing.Size(48, 21);
			this.txtNumber.TabIndex = 57;
			this.txtNumber.Text = "";
			// 
			// lblStartDate
			// 
			this.lblStartDate.Location = new System.Drawing.Point(24, 48);
			this.lblStartDate.Name = "lblStartDate";
			this.lblStartDate.Size = new System.Drawing.Size(56, 16);
			this.lblStartDate.TabIndex = 42;
			this.lblStartDate.Text = "��ʼ����";
			// 
			// lblStartYear
			// 
			this.lblStartYear.Location = new System.Drawing.Point(96, 48);
			this.lblStartYear.Name = "lblStartYear";
			this.lblStartYear.Size = new System.Drawing.Size(16, 16);
			this.lblStartYear.TabIndex = 43;
			this.lblStartYear.Text = "��";
			// 
			// cmbStartYear
			// 
			this.cmbStartYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStartYear.Location = new System.Drawing.Point(120, 40);
			this.cmbStartYear.Name = "cmbStartYear";
			this.cmbStartYear.Size = new System.Drawing.Size(72, 20);
			this.cmbStartYear.TabIndex = 44;
			// 
			// lblStartMonth
			// 
			this.lblStartMonth.Location = new System.Drawing.Point(208, 48);
			this.lblStartMonth.Name = "lblStartMonth";
			this.lblStartMonth.Size = new System.Drawing.Size(16, 16);
			this.lblStartMonth.TabIndex = 45;
			this.lblStartMonth.Text = "��";
			// 
			// cmbStartMonth
			// 
			this.cmbStartMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStartMonth.Location = new System.Drawing.Point(232, 40);
			this.cmbStartMonth.Name = "cmbStartMonth";
			this.cmbStartMonth.Size = new System.Drawing.Size(56, 20);
			this.cmbStartMonth.TabIndex = 46;
			// 
			// lblEndDate
			// 
			this.lblEndDate.Location = new System.Drawing.Point(24, 80);
			this.lblEndDate.Name = "lblEndDate";
			this.lblEndDate.Size = new System.Drawing.Size(56, 16);
			this.lblEndDate.TabIndex = 47;
			this.lblEndDate.Text = "��ֹ����";
			// 
			// cmbEndMonth
			// 
			this.cmbEndMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEndMonth.Location = new System.Drawing.Point(232, 72);
			this.cmbEndMonth.Name = "cmbEndMonth";
			this.cmbEndMonth.Size = new System.Drawing.Size(56, 20);
			this.cmbEndMonth.TabIndex = 51;
			// 
			// lblEndMonth
			// 
			this.lblEndMonth.Location = new System.Drawing.Point(208, 80);
			this.lblEndMonth.Name = "lblEndMonth";
			this.lblEndMonth.Size = new System.Drawing.Size(16, 16);
			this.lblEndMonth.TabIndex = 50;
			this.lblEndMonth.Text = "��";
			// 
			// cmbEndYear
			// 
			this.cmbEndYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEndYear.Location = new System.Drawing.Point(120, 72);
			this.cmbEndYear.Name = "cmbEndYear";
			this.cmbEndYear.Size = new System.Drawing.Size(72, 20);
			this.cmbEndYear.TabIndex = 49;
			// 
			// lblEndYear
			// 
			this.lblEndYear.Location = new System.Drawing.Point(96, 80);
			this.lblEndYear.Name = "lblEndYear";
			this.lblEndYear.Size = new System.Drawing.Size(16, 16);
			this.lblEndYear.TabIndex = 48;
			this.lblEndYear.Text = "��";
			// 
			// lblSubscription
			// 
			this.lblSubscription.Location = new System.Drawing.Point(24, 144);
			this.lblSubscription.Name = "lblSubscription";
			this.lblSubscription.Size = new System.Drawing.Size(56, 16);
			this.lblSubscription.TabIndex = 52;
			this.lblSubscription.Text = "������ʽ";
			// 
			// cmbSubscription
			// 
			this.cmbSubscription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSubscription.Location = new System.Drawing.Point(96, 136);
			this.cmbSubscription.Name = "cmbSubscription";
			this.cmbSubscription.Size = new System.Drawing.Size(96, 20);
			this.cmbSubscription.TabIndex = 53;
			// 
			// lblNumber
			// 
			this.lblNumber.Location = new System.Drawing.Point(24, 184);
			this.lblNumber.Name = "lblNumber";
			this.lblNumber.Size = new System.Drawing.Size(56, 16);
			this.lblNumber.TabIndex = 56;
			this.lblNumber.Text = "��������";
			// 
			// cmbClient
			// 
			this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClient.Location = new System.Drawing.Point(248, 176);
			this.cmbClient.Name = "cmbClient";
			this.cmbClient.Size = new System.Drawing.Size(56, 20);
			this.cmbClient.TabIndex = 120;
			// 
			// lblClient
			// 
			this.lblClient.Location = new System.Drawing.Point(184, 184);
			this.lblClient.Name = "lblClient";
			this.lblClient.Size = new System.Drawing.Size(56, 16);
			this.lblClient.TabIndex = 119;
			this.lblClient.Text = "�ͻ����";
			// 
			// lblGiveDate
			// 
			this.lblGiveDate.Location = new System.Drawing.Point(24, 112);
			this.lblGiveDate.Name = "lblGiveDate";
			this.lblGiveDate.Size = new System.Drawing.Size(56, 23);
			this.lblGiveDate.TabIndex = 121;
			this.lblGiveDate.Text = "��������";
			// 
			// lblGiveYear
			// 
			this.lblGiveYear.Location = new System.Drawing.Point(96, 112);
			this.lblGiveYear.Name = "lblGiveYear";
			this.lblGiveYear.Size = new System.Drawing.Size(16, 16);
			this.lblGiveYear.TabIndex = 122;
			this.lblGiveYear.Text = "��";
			// 
			// cmbGiveYear
			// 
			this.cmbGiveYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGiveYear.Location = new System.Drawing.Point(120, 104);
			this.cmbGiveYear.Name = "cmbGiveYear";
			this.cmbGiveYear.Size = new System.Drawing.Size(72, 20);
			this.cmbGiveYear.TabIndex = 123;
			// 
			// lblGiveMonth
			// 
			this.lblGiveMonth.Location = new System.Drawing.Point(208, 112);
			this.lblGiveMonth.Name = "lblGiveMonth";
			this.lblGiveMonth.Size = new System.Drawing.Size(16, 16);
			this.lblGiveMonth.TabIndex = 124;
			this.lblGiveMonth.Text = "��";
			// 
			// cmbGiveMonth
			// 
			this.cmbGiveMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGiveMonth.Location = new System.Drawing.Point(232, 104);
			this.cmbGiveMonth.Name = "cmbGiveMonth";
			this.cmbGiveMonth.Size = new System.Drawing.Size(56, 20);
			this.cmbGiveMonth.TabIndex = 125;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 216);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 126;
			this.label1.Text = "����";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(184, 216);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 127;
			this.label2.Text = "���";
			// 
			// txtMonthCount
			// 
			this.txtMonthCount.Location = new System.Drawing.Point(96, 208);
			this.txtMonthCount.Name = "txtMonthCount";
			this.txtMonthCount.Size = new System.Drawing.Size(48, 21);
			this.txtMonthCount.TabIndex = 128;
			this.txtMonthCount.Text = "";
			// 
			// txtTotalMoney
			// 
			this.txtTotalMoney.Location = new System.Drawing.Point(248, 208);
			this.txtTotalMoney.Name = "txtTotalMoney";
			this.txtTotalMoney.Size = new System.Drawing.Size(56, 21);
			this.txtTotalMoney.TabIndex = 129;
			this.txtTotalMoney.Text = "";
			// 
			// BatchUpdateForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(338, 304);
			this.Controls.Add(this.txtTotalMoney);
			this.Controls.Add(this.txtMonthCount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbGiveMonth);
			this.Controls.Add(this.lblGiveMonth);
			this.Controls.Add(this.cmbGiveYear);
			this.Controls.Add(this.lblGiveYear);
			this.Controls.Add(this.lblGiveDate);
			this.Controls.Add(this.cmbClient);
			this.Controls.Add(this.lblClient);
			this.Controls.Add(this.txtNumber);
			this.Controls.Add(this.lblNumber1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.lblHead);
			this.Controls.Add(this.lblStartDate);
			this.Controls.Add(this.lblStartYear);
			this.Controls.Add(this.cmbStartYear);
			this.Controls.Add(this.lblStartMonth);
			this.Controls.Add(this.cmbStartMonth);
			this.Controls.Add(this.lblEndDate);
			this.Controls.Add(this.cmbEndMonth);
			this.Controls.Add(this.lblEndMonth);
			this.Controls.Add(this.cmbEndYear);
			this.Controls.Add(this.lblEndYear);
			this.Controls.Add(this.lblSubscription);
			this.Controls.Add(this.cmbSubscription);
			this.Controls.Add(this.lblNumber);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "BatchUpdateForm";
			this.Text = "�޸Ķ�����Ϣ";
			this.Load += new System.EventHandler(this.BatchUpdateForm_Load);
			this.ResumeLayout(false);

		}
		#endregion
		private System.ComponentModel.Container components = null;
		public BatchUpdateForm()
		{
			InitializeComponent();

		}

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


		void InitData()
		{
			//add items to subscription comboBox
			this.cmbSubscription.Items.Add("  ");
			this.cmbSubscription.Items.Add("��");
			this.cmbSubscription.Items.Add("����");
			this.cmbSubscription.Items.Add("����");
			this.cmbSubscription.SelectedIndex = 0;

			//add items to clientCategory comboBox
			this.cmbClient.Items.Add("  ");
			this.cmbClient.Items.Add("��");
			this.cmbClient.Items.Add("A");
			this.cmbClient.Items.Add("B");
			this.cmbClient.Items.Add("C");
			this.cmbClient.SelectedIndex = 0;

			//add years items
			this.cmbStartYear.Items.AddRange(new string[]{"","1900","2000","2001","2002","2003","2004","2005","2006","2007","2008","2009","2010","2011","2012","2013","2014","2015"});
			this.cmbEndYear.Items.AddRange(new string[]{"","1900","2000","2001","2002","2003","2004","2005","2006","2007","2008","2009","2010","2011","2012","2013","2014","2015"});
			this.cmbGiveYear.Items.AddRange(new string[]{"","1900","2000","2001","2002","2003","2004","2005","2006","2007","2008","2009","2010","2011","2012","2013","2014","2015"});

			//add month items
			this.cmbStartMonth.Items.AddRange(new string[]{"","1","2","3","4","5","6","7","8","9","10","11","12"});
			this.cmbEndMonth.Items.AddRange(new string[]{"","1","2","3","4","5","6","7","8","9","10","11","12"});
			this.cmbGiveMonth.Items.AddRange(new string[]{"","1","2","3","4","5","6","7","8","9","10","11","12"});

			this.cmbStartYear.SelectedIndex = 0;
			this.cmbEndYear.SelectedIndex = 0;
			this.cmbGiveYear.SelectedIndex = 0;
			this.cmbStartMonth.SelectedIndex = 0;
			this.cmbEndMonth.SelectedIndex = 0;
			this.cmbGiveMonth.SelectedIndex = 0;

		}

		void AssignValueToData()
		{
			//���ָ���˶��ķ���
			if(this.txtNumber.Text.Trim().Length > 0)
			{
				try
				{
					number = Int32.Parse(this.txtNumber.Text.Trim());
				}
				catch
				{
					throw new Exception("������ʽ����ȷ!");
				}
			}
			//���ָ���˶�������
			if(this.txtMonthCount.Text.Trim().Length > 0)
			{
				try
				{
					monthCount = Int32.Parse(this.txtMonthCount.Text.Trim());
				}
				catch
				{
					throw new Exception("������ʽ����ȷ!");
				}
			}
			//���ָ���˶��Ľ��
			if(this.txtTotalMoney.Text.Trim().Length > 0)
			{
				try
				{
					totalMoney = Int32.Parse(this.txtTotalMoney.Text.Trim());
				}
				catch
				{
					throw new Exception("����ʽ����ȷ!");
				}
			}
			//���ָ��������
			if(this.cmbStartYear.SelectedIndex > 0 && this.cmbStartMonth.SelectedIndex > 0)
			{
				if(this.cmbStartYear.Items[this.cmbStartYear.SelectedIndex].ToString().Length > 0)
				{
					if(this.cmbStartMonth.Items[this.cmbStartMonth.SelectedIndex].ToString().Length > 0)
					{
						startDate = DateTime.Parse(this.cmbStartYear.Items[this.cmbStartYear.SelectedIndex].ToString() + "-" + this.cmbStartMonth.Items[this.cmbStartMonth.SelectedIndex].ToString() + "-1");
					}
				}
			}
			if(this.cmbEndYear.SelectedIndex > 0 && this.cmbEndMonth.SelectedIndex > 0)
			{
				if(this.cmbEndYear.Items[this.cmbEndYear.SelectedIndex].ToString().Length > 0)
				{
					if(this.cmbEndMonth.Items[this.cmbEndMonth.SelectedIndex].ToString().Length > 0)
					{
						endDate = DateTime.Parse(this.cmbEndYear.Items[this.cmbEndYear.SelectedIndex].ToString() + "-" + this.cmbEndMonth.Items[this.cmbEndMonth.SelectedIndex].ToString() + "-1");
					}
				}
			}
			if(this.cmbGiveYear.SelectedIndex > 0 && this.cmbGiveMonth.SelectedIndex > 0)
			{
				if(this.cmbGiveYear.Items[this.cmbGiveYear.SelectedIndex].ToString().Length > 0)
				{
					if(this.cmbGiveMonth.Items[this.cmbGiveMonth.SelectedIndex].ToString().Length > 0)
					{
						giveDate = DateTime.Parse(this.cmbGiveYear.Items[this.cmbGiveYear.SelectedIndex].ToString() + "-" + this.cmbGiveMonth.Items[this.cmbGiveMonth.SelectedIndex].ToString() + "-1");
					}
				}
			}
			//���ָ���˶�����ʽ
			if(this.cmbSubscription.SelectedIndex >= 0)
			{
				subscription = this.cmbSubscription.Items[this.cmbSubscription.SelectedIndex].ToString().Trim() == "" ? "��" : this.cmbSubscription.Items[this.cmbSubscription.SelectedIndex].ToString().Trim();
			}
			//���ָ���˿ͻ����
			if(this.cmbClient.SelectedIndex >= 0)
			{
				client = this.cmbClient.Items[this.cmbClient.SelectedIndex].ToString().Trim() == "" ? "��" : this.cmbClient.Items[this.cmbClient.SelectedIndex].ToString().Trim();
			}
		}


		private void BatchUpdateForm_Load(object sender, System.EventArgs e)
		{
			InitData();	
		
		}
		
		void GetRowValue(DataRow row)
		{

			//�ȶ�ȡ���е�����
			if(row["��ʼ����"] == DBNull.Value)
			{
				startDateTemp = DateTime.Parse("1900-1-1");
			}
			else
			{
				startDateTemp = (DateTime)row["��ʼ����"];
			}
			if(row["��������"] == DBNull.Value)
			{
				endDateTemp = DateTime.Parse("1900-1-1");
			}
			else
			{
				endDateTemp = (DateTime)row["��������"];
			}
			if(row["��������"] == DBNull.Value)
			{
				giveDateTemp = DateTime.Parse("1900-1-1");
			}
			else
			{
				giveDateTemp = (DateTime)row["��������"];
			}
			if(row["����"] == DBNull.Value)
			{
				numberTemp = -1;
			}
			else
			{
				numberTemp = (int)row["����"];
			}
			if(row["����"] == DBNull.Value)
			{
				monthCountTemp = -1;
			}
			else
			{
				monthCountTemp = (int)row["����"];
			}
			if(row["���"] == DBNull.Value)
			{
				totalMoneyTemp = -1;
			}
			else
			{
				totalMoneyTemp = (int)row["���"];
			}
			
			oldNameTemp = row["����"].ToString();
			newNameTemp = row["����"].ToString();
			localAddressTemp = row["�ؼ�����"].ToString();
			regionTemp = row["����"].ToString();
			oldCompanyTemp = row["��˾"].ToString();
			newCompanyTemp = row["��˾"].ToString();
			subscriptionTemp = row["������ʽ"].ToString();
			postTemp = row["ְλ"].ToString();
			addressTemp = row["��ַ"].ToString();
			postcodeTemp = row["�ʱ�"].ToString();
			mobilePhoneTemp = row["�ֻ�"].ToString();
			telephoneTemp = row["�绰"].ToString();
			inscribeTemp = row["���"].ToString();
			sourceTemp = row["��Դ"].ToString();
			paymentTemp = row["֧����ʽ"].ToString();
			invoiceTemp = row["��Ʊ��"].ToString();
			clientTemp = row["�ͻ����"].ToString();
			operator1Temp = row["ҵ��Ա"].ToString();
			bonusTemp = row["������ȡ"].ToString();

			if(this.number != -1)
			{
				numberTemp = number;
			}
			if(this.monthCount != -1)
			{
				monthCountTemp = monthCount;
			}
			if(this.totalMoney != -1)
			{
				totalMoneyTemp = totalMoney;
			}
			if(this.subscription != "��")
			{
				subscriptionTemp = subscription == "��" ? "  " : subscription;
			}
			if(this.client != "��")
			{
				clientTemp = client = client == "��" ? "  " : client;
			}
			if(this.startDate != DateTime.Parse("1000-1-1"))
			{
				startDateTemp = startDate;
			}
			if(this.endDate != DateTime.Parse("1000-1-1"))
			{
				endDateTemp = endDate;
			}
			if(this.giveDate != DateTime.Parse("1000-1-1"))
			{
				giveDateTemp = giveDate;
			}
		}
		void BatchUpdateSelectedRows()
		{
			for(int i = 0;i < MainForm.Form.CurrentDataSet.Tables[0].Rows.Count;i++)
			{
				if(MainForm.Form.ShowResultDataGrid.IsSelected(i) == true)
				{
					GetRowValue(MainForm.Form.CurrentDataSet.Tables[0].Rows[i]);

					SubscribeInfoManager.UpdateSubscribeInfo(oldNameTemp,newNameTemp,postTemp,oldCompanyTemp,newCompanyTemp,addressTemp,regionTemp,postcodeTemp,telephoneTemp,mobilePhoneTemp,startDateTemp,endDateTemp,giveDateTemp,numberTemp,monthCountTemp,totalMoneyTemp,inscribeTemp,sourceTemp,paymentTemp,invoiceTemp,clientTemp,operator1Temp,bonusTemp,localAddressTemp,subscriptionTemp);
				}
			}
		}

		
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				AssignValueToData();
			}
			catch (Exception e1)
			{
				MessageBox.Show(e1.Message);
				return;
			}
			if(this.number == -1 && this.monthCount == -1 && this.totalMoney == -1 && this.subscription == "��" && this.client == "��" && this.startDate == DateTime.Parse("1000-1-1") && this.endDate == DateTime.Parse("1000-1-1") && this.giveDate == DateTime.Parse("1000-1-1"))
			{
				MessageBox.Show("������һ��Ҫ�����޸ĵ�ֵ!");
				return;
			}
			
			if(MessageBox.Show("�Ƿ�ȷ��Ҫ�����޸ģ�","����",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				BatchUpdateSelectedRows();

				MainForm.Form.CurrentDataSet = SubscribeInfoManager.RetriveDataFromTempInfo();

				this.DialogResult = DialogResult.OK;

				this.Close();
			}
		}

		
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			
			this.Close();
		}

	}
}
