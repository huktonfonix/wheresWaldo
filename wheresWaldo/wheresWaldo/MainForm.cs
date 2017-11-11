/*
 * Created by SharpDevelop.
 * User: janderson
 * Date: 9/21/2011
 * Time: 7:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace wheresWaldo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public String dataBasePath;
		public System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
		public bool isConnected;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			isConnected = false;
		}
		
		public void ConnectToAccess(string connectPath)
		{          
    		// TODO: Modify the connection string and include any
    		// additional required properties for your database.
    		//string connectPath = "c:\\richDatabase\\richDatabase.accdb";
    		conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+connectPath+";Persist Security Info=False;";
    		try
    		{
        		conn.Open();
        		// Insert code to process data.
    		}
        	catch (Exception ex)
    		{
        		MessageBox.Show("Failed to connect to data source");
    		}
		}
	}
}
