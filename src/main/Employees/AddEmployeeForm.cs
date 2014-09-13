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

	public class AddEmployeeForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;

		private System.ComponentModel.Container components = null;

		public AddEmployeeForm()
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddEmployeeForm));
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "ҵ��Ա����";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(88, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(112, 21);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(224, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(48, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "ȷ��";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "����ҵ��Ա";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(88, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(113, 20);
			this.comboBox1.TabIndex = 4;
			// 
			// AddEmployeeForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(288, 93);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "AddEmployeeForm";
			this.Text = "���ҵ��Ա";
			this.Load += new System.EventHandler(this.AddEmployeeForm_Load);
			this.ResumeLayout(false);

		}
		#endregion


		private void BindToComboBox()
		{
			DataTable tblEmployees = EmployeeManager.RetrieveAllEmployees();
			this.comboBox1.DataSource = tblEmployees;
			this.comboBox1.DisplayMember = "name";
			this.comboBox1.ValueMember = "Id";

		}

		
		private void button1_Click(object sender, System.EventArgs e)
		{
			if(this.textBox1.Text.Trim().Length == 0)
			{
				MessageBox.Show("��������Ϊ��!");
				return;
			}
			int i = EmployeeManager.CreateEmployee(this.textBox1.Text.Trim());
			if(i == -1)
			{
				MessageBox.Show("��ҵ��Ա�Ѿ�����!");
				return;
			}

			this.Close();
		}

		
		private void AddEmployeeForm_Load(object sender, System.EventArgs e)
		{
			BindToComboBox();
		}
	}
}
