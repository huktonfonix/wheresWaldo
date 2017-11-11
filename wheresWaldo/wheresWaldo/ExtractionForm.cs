/*
 * Created by SharpDevelop.
 * User: janderson
 * Date: 11/8/2011
 * Time: 6:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace wheresWaldo
{
	/// <summary>
	/// Description of ExtractionForm.
	/// </summary>
	public partial class ExtractionForm : Form
	{
		public System.Data.OleDb.OleDbConnection conn3 = new System.Data.OleDb.OleDbConnection();
		string localDataBasePath;
		
		public ExtractionForm(string dataBasePath, dbResult initWindow)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			localDataBasePath = dataBasePath;
			
			//fill in textbox values from the initWindow object
//			textBox13.Text = initWindow.GetName(0);			//never uncomment this again.  it breaks the form.
			textBox1.Text = initWindow.GetLastName();
			textBox2.Text = initWindow.GetFirstName();
			textBox3.Text = initWindow.GetMiddleName();
			textBox14.Text = initWindow.GetPics();
			textBox6.Text = initWindow.GetCountry();
			textBox5.Text = initWindow.GetPassport();
			richTextBox1.Text = initWindow.GetNotes();
			textBox10.Text = initWindow.GetEyecolor();
			textBox9.Text = initWindow.GetHaircolor();
			textBox8.Text = initWindow.GetHeight();
			textBox7.Text = initWindow.GetWeight();
			textBox4.Text = initWindow.GetEthnicity();
			textBox12.Text = initWindow.GetDOB();
			textBox11.Text = initWindow.GetPOB();		
			
			string entriesString = "";
			for (int i = 0; i < initWindow.GetEntriesCount(); i++)
				entriesString = entriesString + initWindow.GetEntries(i) + "\n";
			richTextBox8.Text = entriesString; 
			
			string linksString = "";
			for (int i = 0; i < initWindow.GetLinksCount(); i++)
				linksString = linksString + initWindow.GetLinks(i) + "\n";
			richTextBox7.Text = linksString; 
			
			string tempString = "";
			for (int i = 0; i < initWindow.GetAddressCount(); i++)
				tempString = tempString + initWindow.GetAddress(i) + "\n";
			richTextBox2.Text = tempString;
			
			tempString = "";
			for (int i = 0; i < initWindow.GetTechnologyCount(); i++)
				tempString = tempString + initWindow.GetTechnology(i) + "\n";
			richTextBox5.Text = tempString;
				
			string[] educString = new String[3];
			string substring = "";
			
			for (int i = 0; i < initWindow.GetEducationCount(); i++)
			{
				//since adding and editing a person's info creates different delimiters in the object, replace 
				//with common delimiter before working string
				substring = initWindow.GetEducation(i).Replace("\t\t",":");
				string[] temp = substring.Split(':');
				
				for(int j=0; j<3; j++)
					educString[j] = educString[j] + temp[j] + "\n";
			}
			richTextBox3.Text = educString[0];
			richTextBox9.Text = educString[1];
			richTextBox10.Text = educString[2];
			
			string[] busString = new String[2];
			for (int i = 0; i < initWindow.GetBusinessesCount(); i++)
			{
				//since adding and editing a person's info creates different delimiters in the object, replace 
				//with common delimiter before working string
				substring = initWindow.GetBusinesses(i).Replace("\t\t",":");
				string[] temp = substring.Split(':');
				for(int j=0; j<2; j++)
					busString[j] = busString[j] + temp[j] + "\n";
			}
			richTextBox4.Text = busString[0];
			richTextBox11.Text = busString[1];
			
			string[] addyString = new String[2];
			for (int i = 0; i < initWindow.GetAddressCount(); i++)
			{
				//since adding and editing a person's info creates different delimiters in the object, replace 
				//with common delimiter before working string
				substring = initWindow.GetAddress(i).Replace("\t\t",":");
				string[] temp = substring.Split(':');
				for(int j=0; j<2; j++)
					addyString[j] = addyString[j] + temp[j] + "\n";
			}
			richTextBox2.Text = addyString[0];
			richTextBox12.Text = addyString[1];
			
			string assocString = "";
			for (int i = 0; i < initWindow.GetAssociatesCount(); i++)
				assocString = assocString + initWindow.GetAssociates(i) + "\n";
			richTextBox6.Text = assocString;
			
			string techString = "";
			for (int i = 0; i < initWindow.GetTechnologyCount(); i++)
				techString = techString + initWindow.GetTechnology(i) + "\n";
			richTextBox5.Text = techString;
		}
		
		public void ConnectToAccess3(string connectPath)
		{          
    		// TODO: Modify the connection string and include any
    		// additional required properties for your database.
    		//string connectPath = "c:\\richDatabase\\richDatabase.accdb";
    		conn3.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+connectPath+";Persist Security Info=False;";
    		try
    		{
        		conn3.Open();
        		// Insert code to process data.
    		}
        	catch (Exception ex)
    		{
        		MessageBox.Show("Failed to connect to data source");
    		}
		}
		
		public void insertDatabase(dbResult findResult, string myIndex, System.Data.OleDb.OleDbConnection conn)
		{
				//create INSERT command
				string insertCols1 = "PersonName, LastName, FirstName, MiddleName, Country, Photo, PlaceOfBirth, DateOfBirth, Passport, Notes, EyeColor, HairColor, Height, Weight, Ethnicity, MyNumber";
				string sqlString = "INSERT INTO tblPeeps ("+insertCols1+") VALUES (";
				string insertVals1 = "'"+findResult.GetName(0)+"', '"+findResult.GetLastName()+"', '"+findResult.GetFirstName()+"', '"+
									findResult.GetMiddleName()+"', '"+findResult.GetCountry()+"', '"+findResult.GetPics()+"', '"+
									findResult.GetPOB()+"', '"+findResult.GetDOB()+"', '"+findResult.GetPassport()+"', '"+
									findResult.GetNotes()+"', '"+findResult.GetEyecolor()+"', '"+findResult.GetHaircolor()+"', '"+
									findResult.GetHeight()+"', '"+findResult.GetWeight()+"', '"+findResult.GetEthnicity()+"', '"+myIndex+"'";
				sqlString = sqlString+insertVals1+")";
				
				//set up connection and run command for 1st table
            	OleDbCommand Com = new OleDbCommand(); 
            	Com.CommandText = sqlString; 
            	Com.Connection = conn;
            	OleDbDataReader objDataReader = null;
            	objDataReader = Com.ExecuteReader();
    			objDataReader.Close();
    			
    			//set up sql strings for each insertion to the second table
    			int maxLines = findResult.GetEntriesCount();
    			if (findResult.GetAddressCount() > maxLines)
    				maxLines = findResult.GetAddressCount();
    			if (findResult.GetAssociatesCount() > maxLines)
    				maxLines = findResult.GetAssociatesCount();
    			if (findResult.GetBusinessesCount() >  maxLines)
    				maxLines = findResult.GetBusinessesCount();
    			if (findResult.GetEducationCount() > maxLines)
    				maxLines = findResult.GetEducationCount();
    			if (findResult.GetEntriesCount() > maxLines)
    				maxLines = findResult.GetEntriesCount();
    			if (findResult.GetLinksCount() > maxLines)
    				maxLines = findResult.GetLinksCount();
    			if (findResult.GetTechnologyCount() > maxLines)
    				maxLines = findResult.GetTechnologyCount();
    			
    			//set up sql command, connection and run command for second table
    			OleDbCommand Com2 = new OleDbCommand();
    			Com2.Connection = conn;
    			OleDbDataReader objDataReader2 = null;
    			
    			string insertCols2 = "Entries, Addresses, DateOfAddresses, Technologies, " +
    				"Associates, Universities, Degrees, FieldOfStudies, PlaceOfBiz, RoleInBiz, Links, PersonID";
    			string valueString = ""; 
    			
    			//create individual rows and send them one at a time to DB
    			for (int i = 0; i < maxLines; i++)
    			{
    				//create strings using values from form
    				valueString = "";
    				if (i < findResult.GetEntriesCount())
    					valueString = valueString + "'" + findResult.GetEntries(i) + "', ";
    				else
    					valueString = valueString + "'', ";
    				
    				string[] words = findResult.GetAddress(0).Split(':');
    				if (i < findResult.GetAddressCount())
    				{
    					words = findResult.GetAddress(i).Split(':');
    					valueString = valueString + "'" + words[0] + "', '" + words[1] + "', ";
    				}
    				else
    					valueString = valueString + "'', '', ";
    				
    				if (i < findResult.GetTechnologyCount())
    					valueString = valueString + "'" + findResult.GetTechnology(i) + "', ";
    				else
    					valueString = valueString + "'', ";
    				
    				
    				if (i < findResult.GetAssociatesCount())
    					valueString = valueString + "'" + findResult.GetAssociates(i) + "', ";
    				else
    					valueString = valueString + "'', ";
    				
    				if (i < findResult.GetEducationCount())
    				{
    					words = findResult.GetEducation(i).Split(':');
    					valueString = valueString + "'" + words[0] + "', '" + words[1] + "', '" + words[2] + "', ";
    				}
    				else
    					valueString = valueString + "'', '', '', ";
    				
    				if (i < findResult.GetBusinessesCount())
    				{
    					words = findResult.GetBusinesses(i).Split(':');
    					valueString = valueString + "'" + words[0] + "', '" + words[1] + "', ";
    				}
    				else
    					valueString = valueString + "'', '', ";
    			
    				if (i < findResult.GetLinksCount())
    					valueString = valueString + "'" + findResult.GetLinks(i) + "', ";
    				else
    					valueString = valueString + "'', ";
    				
    				valueString = valueString + "'"+myIndex+"'";
    				
    			//put together SQL string and send to database
    				sqlString = "INSERT INTO tblOtherInfo ("+insertCols2+") VALUES (" + valueString + ")"; 
            		Com2.CommandText = sqlString;  
            		objDataReader2 = Com2.ExecuteReader();
            		objDataReader2.Close();
            		objDataReader2 = null;
    			}   			
		}
		
		void Button1Click(object sender, EventArgs e)
		{	
			string fromRichTextBox;
			dbResult localResult = new dbResult();
			
			//connect to database
			ConnectToAccess3(localDataBasePath);
			
			//find the last number added
			string sqlString = "SELECT MyNumber, ID FROM tblPeeps WHERE (ID=(SELECT MAX(ID) FROM tblPeeps))";
			string myNumber = "33";
			OleDbCommand Com = new OleDbCommand(); 
            Com.CommandText = sqlString; 
            Com.Connection = conn3;
            OleDbDataReader objDataReader = null;
            objDataReader = Com.ExecuteReader();
            if (objDataReader == null)
					return;
    		while(objDataReader.Read())
			{
    			myNumber = objDataReader["MyNumber"].ToString();
    			int num = int.Parse(myNumber);
				myNumber = (++num).ToString();
    		}
    		objDataReader.Close();
    			
			//fill query object with values from form
			
			localResult.SetName(textBox13.Text);
			localResult.SetLastName(textBox1.Text);
			localResult.SetFirstName(textBox2.Text);
			localResult.SetMiddleName(textBox3.Text);
			localResult.SetCountry(textBox6.Text);
			localResult.SetPassport(textBox5.Text);
			localResult.SetPics(textBox14.Text);
			localResult.SetEyecolor(textBox10.Text);
			localResult.SetHaircolor(textBox9.Text);
			localResult.SetHeight(textBox8.Text);
			localResult.SetWeight(textBox7.Text);
			localResult.SetEthnicity(textBox4.Text);
			localResult.SetNotes(richTextBox1.Text);
			localResult.SetPOB(textBox11.Text);
			localResult.SetDOB(textBox12.Text);
			
			//for the second table, take each row and add to localResult separating by :
			fromRichTextBox = richTextBox8.Text;
			string[] words = fromRichTextBox.Split('\n');
			foreach (string word in words)
			{
				//if (word.Contains()
					localResult.SetEntries(word);
			}			
			fromRichTextBox = richTextBox2.Text;
			words = fromRichTextBox.Split('\n');
			string[] words2 = richTextBox12.Text.Split('\n');
			int i = 0;
			foreach (string word in words)
			{
				//if (!word.Contains(""))
					localResult.SetAddress(word+":"+words2[i++]);
			}
			fromRichTextBox = richTextBox3.Text;
			words = fromRichTextBox.Split('\n');
			words2 = richTextBox9.Text.Split('\n');
			string[] words3 = richTextBox10.Text.Split('\n');
			i = 0;
			foreach (string word in words)
			{
				//if (!word.Contains(""))
					localResult.SetEducation(word+":"+words2[i]+":"+words3[i++]);
			}
			fromRichTextBox = richTextBox4.Text;
			words = fromRichTextBox.Split('\n');
			words2 = richTextBox11.Text.Split('\n');
			i = 0;
			foreach (string word in words)
			{
				//if (!word.Contains(""))
					localResult.SetBusinesses(word+":"+words2[i++]);
			}
			fromRichTextBox = richTextBox5.Text;
			words = fromRichTextBox.Split('\n');
			foreach (string word in words)
			{
				//if (!word.Contains(""))
					localResult.SetTechnology(word);
			}
			fromRichTextBox = richTextBox6.Text;
			words = fromRichTextBox.Split('\n');
			foreach (string word in words)
			{
				//if (!word.Contains(""))
					localResult.SetAssociates(word);
			}
			fromRichTextBox = richTextBox7.Text;
			words = fromRichTextBox.Split('\n');
			foreach (string word in words)
			{
				//if (word != "")
					localResult.SetLinks(word);
			}
			
			//insert object values into database
			insertDatabase(localResult, myNumber, conn3);
			MessageBox.Show("Successfully added to database.");
		}
	}
}
