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
	public class OtherSearchForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.ComboBox cmbDateType;
		private int searchDateType = -1;

		private System.ComponentModel.Container components = null;

		public OtherSearchForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OtherSearchForm));
			this.lblName = new System.Windows.Forms.Label();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.cmbDateType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(16, 32);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(144, 24);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "��ѡ��ֵΪ�յ���������";
			// 
			// btnSubmit
			// 
			this.btnSubmit.Location = new System.Drawing.Point(320, 26);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(48, 23);
			this.btnSubmit.TabIndex = 10;
			this.btnSubmit.Text = "ȷ ��";
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// cmbDateType
			// 
			this.cmbDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDateType.Location = new System.Drawing.Point(176, 28);
			this.cmbDateType.Name = "cmbDateType";
			this.cmbDateType.Size = new System.Drawing.Size(120, 20);
			this.cmbDateType.TabIndex = 11;
			// 
			// OtherSearchForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(386, 80);
			this.Controls.Add(this.cmbDateType);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.lblName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "OtherSearchForm";
			this.Text = "��Ϣ��ѯ";
			this.Load += new System.EventHandler(this.StatSubscribeForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(this.cmbDateType.SelectedIndex >= 0)
			{
				switch (this.cmbDateType.Items[this.cmbDateType.SelectedIndex].ToString())
				{
					case "��������":
						searchDateType = 0;
						break;
					case "��ʼ����":
						searchDateType = 1;
						break;
					case "��������":
						searchDateType = 2;
						break;
				}
				if(searchDateType != -1)
				{
					DataSet infoSet = SubscribeInfoManager.RetrieveNullInfo(searchDateType);

					MainForm.Form.CurrentDataSet = infoSet;

					this.DialogResult = DialogResult.OK;
			
					this.Close();

				}

			}
		}

		private void StatSubscribeForm_Load(object sender, System.EventArgs e)
		{
			this.cmbDateType.Items.Add("��������");
			this.cmbDateType.Items.Add("��ʼ����");
			this.cmbDateType.Items.Add("��������");
			this.cmbDateType.SelectedIndex = 0;
		}

	}
}
