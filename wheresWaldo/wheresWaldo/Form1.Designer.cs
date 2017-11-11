/*
 * Created by SharpDevelop.
 * User: janderson
 * Date: 11/8/2011
 * Time: 5:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace wheresWaldo
{
	partial class Form1
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.richTextBox3 = new System.Windows.Forms.RichTextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.richTextBox4 = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.richTextBox1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(498, 156);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Name and Address";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(7, 20);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(485, 130);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.richTextBox2);
			this.groupBox2.Location = new System.Drawing.Point(13, 192);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(497, 168);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Education";
			// 
			// richTextBox2
			// 
			this.richTextBox2.Location = new System.Drawing.Point(7, 20);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(484, 142);
			this.richTextBox2.TabIndex = 0;
			this.richTextBox2.Text = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.richTextBox3);
			this.groupBox3.Location = new System.Drawing.Point(13, 383);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(497, 174);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Employment";
			// 
			// richTextBox3
			// 
			this.richTextBox3.Location = new System.Drawing.Point(7, 19);
			this.richTextBox3.Name = "richTextBox3";
			this.richTextBox3.Size = new System.Drawing.Size(484, 149);
			this.richTextBox3.TabIndex = 0;
			this.richTextBox3.Text = "";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.richTextBox4);
			this.groupBox4.Location = new System.Drawing.Point(13, 575);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(497, 126);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Associates";
			// 
			// richTextBox4
			// 
			this.richTextBox4.Location = new System.Drawing.Point(7, 19);
			this.richTextBox4.Name = "richTextBox4";
			this.richTextBox4.Size = new System.Drawing.Size(484, 101);
			this.richTextBox4.TabIndex = 0;
			this.richTextBox4.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(210, 723);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Extract Data";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(522, 758);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "Add Person";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox4;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RichTextBox richTextBox3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
