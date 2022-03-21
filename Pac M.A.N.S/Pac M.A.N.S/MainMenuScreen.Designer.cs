
namespace Pac_M.A.N.S
{
	partial class MainMenuScreen
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.startButt = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.BlueViolet;
			this.label1.Location = new System.Drawing.Point(184, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(383, 74);
			this.label1.TabIndex = 0;
			this.label1.Text = "Pac M.A.N.S.";
			// 
			// startButt
			// 
			this.startButt.BackColor = System.Drawing.Color.BlueViolet;
			this.startButt.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.startButt.Location = new System.Drawing.Point(179, 145);
			this.startButt.Name = "startButt";
			this.startButt.Size = new System.Drawing.Size(388, 100);
			this.startButt.TabIndex = 1;
			this.startButt.Text = "Start Game";
			this.startButt.UseVisualStyleBackColor = false;
			this.startButt.Click += new System.EventHandler(this.startButt_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.BlueViolet;
			this.button1.Font = new System.Drawing.Font("Showcard Gothic", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.button1.Location = new System.Drawing.Point(179, 251);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(388, 100);
			this.button1.TabIndex = 2;
			this.button1.Text = "Exit";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainMenuScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ClientSize = new System.Drawing.Size(782, 383);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.startButt);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MainMenuScreen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pac M.A.N.S";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button startButt;
		private System.Windows.Forms.Button button1;
	}
}

