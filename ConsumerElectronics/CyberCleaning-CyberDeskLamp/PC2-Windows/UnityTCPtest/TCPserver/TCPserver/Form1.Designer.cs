namespace TCPserver
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.txtDisp = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtSend = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtDisp
			// 
			this.txtDisp.Location = new System.Drawing.Point(12, 12);
			this.txtDisp.Multiline = true;
			this.txtDisp.Name = "txtDisp";
			this.txtDisp.Size = new System.Drawing.Size(360, 303);
			this.txtDisp.TabIndex = 1;
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(249, 321);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(123, 28);
			this.btnSend.TabIndex = 3;
			this.btnSend.Text = "送信";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtSend
			// 
			this.txtSend.Location = new System.Drawing.Point(12, 321);
			this.txtSend.Multiline = true;
			this.txtSend.Name = "txtSend";
			this.txtSend.Size = new System.Drawing.Size(231, 28);
			this.txtSend.TabIndex = 4;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 361);
			this.Controls.Add(this.txtSend);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtDisp);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtDisp;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox txtSend;
	}
}

