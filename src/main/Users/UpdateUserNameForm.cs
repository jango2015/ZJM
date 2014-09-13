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
	public class UpdateUserNameForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.TextBox txtName;

		private System.ComponentModel.Container components = null;

		public UpdateUserNameForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(UpdateUserNameForm));
			this.lblName = new System.Windows.Forms.Label();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(16, 32);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(96, 24);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "�������µ�����";
			// 
			// btnSubmit
			// 
			this.btnSubmit.Location = new System.Drawing.Point(240, 24);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(48, 23);
			this.btnSubmit.TabIndex = 10;
			this.btnSubmit.Text = "�� ��";
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(120, 24);
			this.txtName.Name = "txtName";
			this.txtName.TabIndex = 0;
			this.txtName.Text = "";
			// 
			// UpdateUserNameForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(304, 79);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.lblName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "UpdateUserNameForm";
			this.Text = "�û���������";
			this.Load += new System.EventHandler(this.UserUpdateNameForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(this.txtName.Text.Trim().Length > 0)
			{
				if(MessageBox.Show("ȷ���Ƿ�Ҫ��������?","����",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
				{
					ManagerManager.UpdateManagerName(MainForm.Form.CurrentManager.Id,this.txtName.Text.Trim());

					this.DialogResult = DialogResult.OK;

					this.Close();
				}
			}
			else
			{
				MessageBox.Show("��������Ϊ��!");
			}

		}

		private void UserUpdateNameForm_Load(object sender, System.EventArgs e)
		{

		}
	}
}
