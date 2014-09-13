using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace NetFocus.MagzineSubscribe.UI
{

	public class TempForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private DataSet currentDataSet;

		private System.ComponentModel.Container components = null;

		public DataSet CurrentDataSet
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

		public TempForm()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}
		public TempForm(string label1Caption)
		{

			InitializeComponent();
			
			this.label1.Text = label1Caption;

		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TempForm));
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("����", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 40);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.RowHeaderWidth = 30;
			this.dataGrid1.Size = new System.Drawing.Size(724, 317);
			this.dataGrid1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("������", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(724, 40);
			this.label1.TabIndex = 1;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TempForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(724, 357);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "TempForm";
			this.Text = "������Ϣ";
			this.Load += new System.EventHandler(this.TempForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		void BindToDataGrid()
		{
			if(currentDataSet != null)
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
				this.dataGrid1.TableStyles[0].AllowSorting = false;
				this.dataGrid1.TableStyles[0].GridColumnStyles["�к�"].Width = 45;
				this.dataGrid1.TableStyles[0].GridColumnStyles["����"].Width = 60;
				this.dataGrid1.TableStyles[0].GridColumnStyles["��˾"].Width = 200;
				this.dataGrid1.TableStyles[0].GridColumnStyles["ְλ"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["��ַ"].Width = 250;
				this.dataGrid1.TableStyles[0].GridColumnStyles["�ʱ�"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["�绰"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["�ֻ�"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["��ʼ����"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["��������"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["��������"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["����"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["����"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["���"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["���"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["��Դ"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["֧����ʽ"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["��Ʊ��"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["�ͻ����"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["ҵ��Ա"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["������ȡ"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["�ؼ�����"].Width = 0;
				this.dataGrid1.TableStyles[0].GridColumnStyles["������ʽ"].Width = 0;
				if(this.label1.Text == "����" + currentDataSet.Tables[0].Rows.Count + "����¼��Excel�������ظ�,��˶Ժ��ٵ���")
				{
					this.dataGrid1.TableStyles[0].GridColumnStyles["����"].Width = 74;
					this.dataGrid1.TableStyles[0].GridColumnStyles["�ظ�����"].Width = 60;
				}
				else if(this.label1.Text == "����" + currentDataSet.Tables[0].Rows.Count + "����¼�����ݿ����Ѵ���,��˶Ժ��ٵ���")
				{
					this.dataGrid1.TableStyles[0].GridColumnStyles["����"].Width = 133;
					this.dataGrid1.TableStyles[0].GridColumnStyles["�ظ�����"].Width = 0;
				}
			}
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


		private void TempForm_Load(object sender, System.EventArgs e)
		{
			
			CreateSplitter();

			BindToDataGrid();
		}
	}
}
