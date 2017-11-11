/*
 * Created by SharpDevelop.
 * User: janderson
 * Date: 9/21/2011
 * Time: 7:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 using System.IO;
 using System;
 using System.Windows.Forms;

namespace wheresWaldo
{
	partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lastName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.firstName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.middleName = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.findButton = new System.Windows.Forms.Button();
			this.exitButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem1,
									this.databaseToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(494, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem,
									this.saveToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
			this.toolStripMenuItem1.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.connectMapToolStripMenuItem,
									this.searchToolStripMenuItem});
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// connectMapToolStripMenuItem
			// 
			this.connectMapToolStripMenuItem.Name = "connectMapToolStripMenuItem";
			this.connectMapToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.connectMapToolStripMenuItem.Text = "ConnectMap";
			this.connectMapToolStripMenuItem.Click += new System.EventHandler(this.ConnectMapToolStripMenuItemClick);
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.searchToolStripMenuItem.Text = "Query";
			this.searchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItemClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.saveToolStripMenuItem.Text = "Save Query";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// databaseToolStripMenuItem
			// 
			this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.findToolStripMenuItem,
									this.connectToolStripMenuItem});
			this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
			this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.databaseToolStripMenuItem.Text = "Database";
			// 
			// findToolStripMenuItem
			// 
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.findToolStripMenuItem.Text = "Connect";
			this.findToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItemClick);
			// 
			// connectToolStripMenuItem
			// 
			this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
			this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
			this.connectToolStripMenuItem.Text = "Disconnect";
			this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItemClick);
			// 
			// lastName
			// 
			this.lastName.Location = new System.Drawing.Point(216, 81);
			this.lastName.Name = "lastName";
			this.lastName.Size = new System.Drawing.Size(158, 20);
			this.lastName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(110, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Last Name";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(110, 117);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "First Name";
			// 
			// firstName
			// 
			this.firstName.Location = new System.Drawing.Point(216, 117);
			this.firstName.Name = "firstName";
			this.firstName.Size = new System.Drawing.Size(158, 20);
			this.firstName.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(110, 151);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Middle Name";
			// 
			// middleName
			// 
			this.middleName.Location = new System.Drawing.Point(216, 151);
			this.middleName.Name = "middleName";
			this.middleName.Size = new System.Drawing.Size(158, 20);
			this.middleName.TabIndex = 5;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// findButton
			// 
			this.findButton.Location = new System.Drawing.Point(34, 258);
			this.findButton.Name = "findButton";
			this.findButton.Size = new System.Drawing.Size(107, 28);
			this.findButton.TabIndex = 7;
			this.findButton.Text = "Find Me";
			this.findButton.UseVisualStyleBackColor = true;
			this.findButton.Click += new System.EventHandler(this.FindButtonClick);
			// 
			// exitButton
			// 
			this.exitButton.Location = new System.Drawing.Point(190, 258);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(107, 28);
			this.exitButton.TabIndex = 8;
			this.exitButton.Text = "Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(349, 258);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(107, 28);
			this.addButton.TabIndex = 9;
			this.addButton.Text = "Add Me";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.AddButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 318);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.findButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.middleName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.firstName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lastName);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "wheresWaldo";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectMapToolStripMenuItem;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.Button findButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.TextBox middleName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox firstName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
		private System.Windows.Forms.TextBox lastName;
		private System.Windows.Forms.Label label1;
		
		void OpenToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			
		}
		
		void FindToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			openFileDialog1.ShowDialog();
			dataBasePath = openFileDialog1.FileName;
			ConnectToAccess(dataBasePath);
			isConnected = true;
		}
		
		void ConnectToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			conn.Close();
			isConnected = false;
		}
		
		void ExitButtonClick(object sender, System.EventArgs e)
		{
			conn.Close();
			this.Close();
		}
		
		void FindButtonClick(object sender, System.EventArgs e)
		{
			//create the form to show results, create teh SQL string, run the command and then show results on form
			dbResult findResult = new dbResult();
			string queryCriteria = "";
			string queryEnd = "";
			if (!isConnected)
				MessageBox.Show("Please connect to database prior to searching.");
			else
			{
				//last name must be entered prior to search.  entering * is a wildcard, and entering nothing actually searches for a blank criteria
				if (lastName.Text != ""){
					if (lastName.Text != "*")
					{
						queryEnd = ")";
						queryCriteria = "WHERE ((LastName='"+lastName.Text.ToString()+"')";
						if (firstName.Text != "")
							queryCriteria = queryCriteria + "AND "+"(FirstName='"+firstName.Text.ToString()+"')";
						if (middleName.Text != "")
							queryCriteria = queryCriteria + "AND "+"(middleName='"+middleName.Text.ToString()+"')";
					}
					findResult.queryDatabase(queryCriteria, queryEnd,findResult, conn);
    
    				//set up the form and show
    				dbForm findForm = new dbForm(findResult, dataBasePath);
   					findForm.Show();
				}
			}
		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			
		}
		
		void ConnectMapToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			customQuery newQuery = new customQuery();
			string newRoot = "";
				
			//open the dialog box so user can choose path
			openFileDialog1.ShowDialog();
			string path = openFileDialog1.FileName;
			
			//get root and branches from file
			string textIn = File.ReadAllText(path);
			string [] textArray = textIn.Split(new string [] {"###"}, StringSplitOptions.RemoveEmptyEntries);
			string [] contentsArray = textArray[3].Split(new string [] {"<EOL>"}, StringSplitOptions.RemoveEmptyEntries);
			string [] newRootArray = new string[2];
			string [] newBranchArray = new String[2];
			
			//check that an actual connectMap file has been selected
			if(textArray[0].Contains("connectMap"))
			{
				//grab teh root file
				newRootArray = contentsArray[0].Split(new string [] {">"}, StringSplitOptions.RemoveEmptyEntries);
				newRoot = newRootArray[1];
				
				//get the branches and set up the localQuery object
				for (int i = 1; i < contentsArray.Length; i++)
				{
					newBranchArray = contentsArray[i].Split(new string [] {">"}, StringSplitOptions.RemoveEmptyEntries);
					newQuery.SetName(newBranchArray[1]);
				}
			}
			
			//create new display and pass it the root and query objects
			displayForm analyzeDisplay = new displayForm(newQuery, newRoot);
   			analyzeDisplay.Show();
			
		}
		
		void SearchToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			//open the dialog box so user can choose path
			openFileDialog1.ShowDialog();
			string path = openFileDialog1.FileName;
			
			//get first middle and last name from file
			string textIn = File.ReadAllText(path);
			string [] textArray = textIn.Split(new string [] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
			string [] last = new string[2];
			string [] middle = new string[2];
			string [] first = new string[2];
			for (int i = 0; i < textArray.Length; i++)
			{
				if (textArray[i].Contains("<lastName>"))
					last = textArray[i].Split(new string [] {">"}, StringSplitOptions.RemoveEmptyEntries);
				else if (textArray[i].Contains("<firstName>"))
					first = textArray[i].Split(new string [] {">"}, StringSplitOptions.RemoveEmptyEntries);
				else if (textArray[i].Contains("<middleName>"))
					middle = textArray[i].Split(new string [] {">"}, StringSplitOptions.RemoveEmptyEntries);
				else if (textArray[i].Contains("connectMap"))
					break;
			}
			
			//fill in the text boxes with the data from the file
			lastName.Text = last[1];
			firstName.Text = first[1];
			middleName.Text = middle[1];
		}
		
		void SaveToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			//open the dialog box so user can choose path
			saveFileDialog1.ShowDialog();
			string path = saveFileDialog1.FileName;
			string outputFile = "###   This file is used by the query form on Where's Waldo.   ###\n###   Do not modify   ###\n";
			
			//get first middle and last name from text boxes
			outputFile = outputFile+"<lastName>"+lastName.Text.ToString()+"\n";
			outputFile = outputFile+"<middleName>"+middleName.Text.ToString()+"\n";
			outputFile = outputFile+"<firstName>"+firstName.Text.ToString()+"\n";
			
			//write to the output file
			File.WriteAllText(path+".qry", outputFile);
			
		}
		
		void AddButtonClick(object sender, EventArgs e)
		{
			//show add person form
			Form1 addForm = new Form1(dataBasePath);
   			addForm.Show();
		}
	}
}
