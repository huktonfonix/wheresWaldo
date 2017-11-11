/*
 * Created by SharpDevelop.
 * User: janderson
 * Date: 9/21/2011
 * Time: 10:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace wheresWaldo
{
	/// <summary>
	/// Description of dbForm.
	/// </summary>
	public partial class dbForm : Form
	{
		public System.Data.OleDb.OleDbConnection conn2 = new System.Data.OleDb.OleDbConnection();
		List<string> localIndex = new List<string>();
		List<string> localName = new List<string>();
		dbResult myResult = new dbResult();
		dbResult editResult = new dbResult();
		string myDBPath = "";
		int comboIndex;
		
		public dbForm(dbResult findResult, string dataBasePath)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.localIndex.Clear();
			this.localName.Clear();
			
			for(int i = 0; i < findResult.GetIndexCount(); i++)
			{
				this.localIndex.Add(findResult.GetIndex(i));
				this.localName.Add(findResult.GetName(i));
			}
			
			myDBPath = dataBasePath;
			myResult = findResult;
			ConnectToAccess2(dataBasePath);
			populateForm(findResult,findResult.GetNameCount()-1);
		}
		
		void clearForm()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox5.Text = "";
			textBox6.Text = "";
			textBox9.Text = "";
			textBox10.Text = "";
			textBox8.Text = "";
			textBox7.Text = "";
			textBox4.Text = "";
			richTextBox1.Text = "";
			textBox12.Text = "";
			textBox11.Text = "";
			pictureBox1.ImageLocation = "";
			comboBox1.Items.Clear();
			comboBox2.Items.Clear();
			comboBox3.Items.Clear();
			comboBox6.Items.Clear();
			comboBox5.Items.Clear();
			comboBox7.Items.Clear();
			comboBox8.Items.Clear();
			comboBox4.Items.Clear();
		}
		
		void populateForm(dbResult findResult,int nameBoxSel)
		{
			textBox1.Text = findResult.GetLastName();
			textBox2.Text = findResult.GetFirstName();
			textBox3.Text = findResult.GetMiddleName();
			textBox5.Text = findResult.GetPassport();
			textBox6.Text = findResult.GetCountry();
			textBox9.Text = findResult.GetHaircolor();
			textBox10.Text = findResult.GetEyecolor();
			textBox8.Text = findResult.GetHeight();
			textBox7.Text = findResult.GetWeight();
			textBox4.Text = findResult.GetEthnicity();
			richTextBox1.Text = findResult.GetNotes();
			textBox12.Text = findResult.GetDOB();
			textBox11.Text = findResult.GetPOB();
			pictureBox1.ImageLocation = findResult.GetPics();
			for(int i = 0; i < findResult.GetNameCount(); i++)
				comboBox1.Items.Add(findResult.GetName(i));
			comboBox1.SelectedIndex=nameBoxSel;
			for(int i = 0; i < findResult.GetEntriesCount(); i++)
				comboBox2.Items.Add(findResult.GetEntries(i));
			comboBox2.SelectedIndex=findResult.GetEntriesCount()-1;
			for(int i = 0; i < findResult.GetAddressCount(); i++)
				comboBox3.Items.Add(findResult.GetAddress(i));
			comboBox3.SelectedIndex=findResult.GetAddressCount()-1;
			for(int i = 0; i < findResult.GetTechnologyCount(); i++)
				comboBox6.Items.Add(findResult.GetTechnology(i));
			comboBox6.SelectedIndex=findResult.GetTechnologyCount()-1;
			for(int i = 0; i < findResult.GetBusinessesCount(); i++)
				comboBox5.Items.Add(findResult.GetBusinesses(i));
			comboBox5.SelectedIndex=findResult.GetBusinessesCount()-1;
			for(int i = 0; i < findResult.GetAssociatesCount(); i++)
				comboBox7.Items.Add(findResult.GetAssociates(i));
			comboBox7.SelectedIndex=findResult.GetAssociatesCount()-1;
			for(int i = 0; i < findResult.GetLinksCount(); i++)
				comboBox8.Items.Add(findResult.GetLinks(i));
			comboBox8.SelectedIndex=findResult.GetLinksCount()-1;
			for(int i = 0; i < findResult.GetEducationCount(); i++)
				comboBox4.Items.Add(findResult.GetEducation(i));
			comboBox4.SelectedIndex=findResult.GetEducationCount()-1;
	}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			//take the new index of the combobox and look up the index of the local list.
			//use the local list value to search the database user IDs.
			//then repopulate the form.
			//access connections have already been set up and everything.
			//TODO:after quert, point editResult to the localResult for use when button2 is pressed
			
			string selectedIndex = "";
			string selectedName = "";
			int myIndex = comboBox1.SelectedIndex;
			comboIndex = myIndex;
			dbResult localResult = new dbResult();
			
			selectedIndex = localIndex[myIndex];
			selectedName = localName[myIndex];
			localResult.queryDatabase("WHERE ((MyNumber='"+selectedIndex+"')",")",localResult,conn2);
			
			localResult.ClearIndex();
			localResult.ClearName();
			for (int i = 0; i < localIndex.Count; i++)
			{
				localResult.SetIndex(localIndex[i]);
				localResult.SetName(localName[i]);
			}
			//editResult = localResult;
			clearForm();
			populateForm(localResult,myIndex);
			//localResult = null;
		}
		
		
		public void ConnectToAccess2(string dataBasePath)
		{          
    		// TODO: Modify the connection string and include any
    		// additional required properties for your database.
    		conn2.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+dataBasePath+";Persist Security Info=False;";
    		try
    		{
        		conn2.Open();
        		// Insert code to process data.
    		}
        	catch (Exception ex)
    		{
        		MessageBox.Show("Failed to connect to data source");
    		}
		}
		
		void Button2Click(object sender, System.EventArgs e)
		{
			int myIndex = comboBox1.SelectedIndex;
			string selectedIndex = "";
			string selectedName = "";
			dbResult localResult = new dbResult();
			
			selectedIndex = localIndex[myIndex];
			selectedName = localName[myIndex];
			localResult.queryDatabase("WHERE ((MyNumber='"+selectedIndex+"')",")",localResult,conn2);
			
			localResult.ClearIndex();
			localResult.ClearName();
			for (int i = 0; i < localIndex.Count; i++)
			{
				localResult.SetIndex(localIndex[i]);
				localResult.SetName(localName[i]);
			}
			
			//delete the entry we're going to edit
			localResult.deleteFromDatabase(localIndex[myIndex], conn2);
			
			//set up the extraction form and show
    		ExtractionForm editForm = new ExtractionForm(myDBPath, localResult);
   			editForm.Show();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//TODO:  creat afunction; need a new structure to get results into and pass to display sindow			
			string sqlSimpleQuery = "";
			string sqlJoinQuery = "";
			string whereClause = "";
			string totalWheres = "";
			bool needAnd = false;
			customQuery analyze = new customQuery();
			dbResult test = new dbResult();
			
			//access connection has already been made
			//look over checkboxes and use combobox selections to create SQL statement
			if (checkBox1.Checked)
			{
				string[] comboArray = comboBox4.Text.ToString().Split(new string[] {"\t"},StringSplitOptions.RemoveEmptyEntries);
				whereClause = "(Universities='" + comboArray[0] + "')";
				totalWheres = totalWheres + whereClause + "\n";
				sqlSimpleQuery = "SELECT DISTINCT PersonID FROM tblOtherInfo WHERE " + whereClause;
				needAnd = true;
				sqlJoinQuery = "SELECT PersonID, Universities FROM tblOtherInfo WHERE "+whereClause;
			}
			if (checkBox2.Checked)
			{
				string[] comboArray = comboBox4.Text.ToString().Split(new string[] {"\t"},StringSplitOptions.RemoveEmptyEntries);
				whereClause = "(Degrees='" + comboArray[1] + "')";
				totalWheres = totalWheres + whereClause + "\n";
				sqlSimpleQuery = "SELECT DISTINCT PersonID FROM tblOtherInfo WHERE " + whereClause;
				if (needAnd == false)
				{
					needAnd = true;
					sqlJoinQuery = "SELECT PersonID, Degrees FROM tblOtherInfo WHERE "+whereClause;
				}
				else
				{
					sqlJoinQuery = "SELECT DegreesJoinPrev.PersonID FROM ("+sqlJoinQuery+")DegreesJoinPrev INNER JOIN ("+sqlSimpleQuery+")DegreesJoin ON DegreesJoinPrev.PersonID=DegreesJoin.PersonID";
				}
			}
			if (checkBox3.Checked)
			{
				string[] comboArray = comboBox4.Text.ToString().Split(new string[] {"\t"},StringSplitOptions.RemoveEmptyEntries);
				whereClause = "(FieldOfStudies='" + comboArray[2] + "')";
				totalWheres = totalWheres + whereClause + "\n";
				sqlSimpleQuery = "SELECT DISTINCT PersonID FROM tblOtherInfo WHERE " + whereClause;
				if (needAnd == false)
				{
					needAnd = true;
					sqlJoinQuery = "SELECT PersonID, FieldOfStudies FROM tblOtherInfo WHERE "+whereClause;
				}
				else
				{
					sqlJoinQuery = "SELECT FOSJoinPrev.PersonID FROM ("+sqlJoinQuery+")FOSJoinPrev INNER JOIN ("+sqlSimpleQuery+")FOSJoin ON FOSJoinPrev.PersonID=FOSJoin.PersonID";
				}
			}
			if (checkBox4.Checked)
			{
				string[] comboArray = comboBox5.Text.ToString().Split(new string[] {"\t"},StringSplitOptions.RemoveEmptyEntries);
				whereClause = "(PlaceOfBiz='" + comboArray[0] + "')";
				totalWheres = totalWheres + whereClause + "\n";
				sqlSimpleQuery = "SELECT DISTINCT PersonID FROM tblOtherInfo WHERE " + whereClause;
				if (needAnd == false)
				{
					needAnd = true;
					sqlJoinQuery = "SELECT PersonID, PlaceOfBiz FROM tblOtherInfo WHERE "+whereClause;
				}
				else
				{
					sqlJoinQuery = "SELECT POBJoinPrev.PersonID FROM ("+sqlJoinQuery+")POBJoinPrev INNER JOIN ("+sqlSimpleQuery+")POBJoin ON POBJoinPrev.PersonID=POBJoin.PersonID";
				}
			}
			if (checkBox5.Checked)
			{
				string[] comboArray = comboBox5.Text.ToString().Split(new string[] {"\t"},StringSplitOptions.RemoveEmptyEntries);
				whereClause = "(RoleInBiz='" + comboArray[1] + "')";
				totalWheres = totalWheres + whereClause + "\n";
				sqlSimpleQuery = "SELECT DISTINCT PersonID FROM tblOtherInfo WHERE " + whereClause;
				if (needAnd == false)
				{
					needAnd = true;
					sqlJoinQuery = "SELECT PersonID, RoleInBiz FROM tblOtherInfo WHERE "+whereClause;
					
				}
				else
				{
					sqlJoinQuery = "SELECT RIBJoinPrev.PersonID FROM ("+sqlJoinQuery+")RIBJoinPrev INNER JOIN ("+sqlSimpleQuery+")RIBJoin ON RIBJoinPrev.PersonID=RIBJoin.PersonID";
				}
			}
			if (checkBox6.Checked)
			{
				whereClause = "(Technologies='" + comboBox6.Text.ToString() + "')";
				totalWheres = totalWheres + whereClause + "\n";
				sqlSimpleQuery = "SELECT DISTINCT PersonID FROM tblOtherInfo WHERE " + whereClause;
				if (needAnd == false)
				{
					needAnd = true;
					sqlJoinQuery = "SELECT PersonID, Technologies FROM tblOtherInfo WHERE "+whereClause;
				}
				else
				{
					sqlJoinQuery = "SELECT TechJoinPrev.PersonID FROM ("+sqlJoinQuery+")TechJoinPrev INNER JOIN ("+sqlSimpleQuery+")TechJoin ON TechJoinPrev.PersonID=TechJoin.PersonID";
				}
			}
			if (checkBox7.Checked)
			{
				whereClause = "(Associates='" + comboBox7.Text.ToString() + "')";
				totalWheres = totalWheres + whereClause + "\n";
				sqlSimpleQuery = "SELECT DISTINCT PersonID FROM tblOtherInfo WHERE " + whereClause;
				if (needAnd == false)
				{
					needAnd = true;
					sqlJoinQuery = "SELECT PersonID, Associates FROM tblOtherInfo WHERE "+whereClause;
				}	
				else
				{
					sqlJoinQuery = "SELECT AssJoinPrev.PersonID FROM ("+sqlJoinQuery+")AssJoinPrev INNER JOIN ("+sqlSimpleQuery+")AssJoin ON AssJoinPrev.PersonID=AssJoin.PersonID";
				}
			}
			//end query
			
			//send statement to database and get results
			analyze.queryDatabase(sqlJoinQuery, analyze, conn2);
				
			//set up the form and show with results
			displayForm analyzeDisplay = new displayForm(analyze, totalWheres);
   			analyzeDisplay.Show();
			
		}
	}}
