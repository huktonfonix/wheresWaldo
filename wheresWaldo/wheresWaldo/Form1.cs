/*
 * Created by SharpDevelop.
 * User: janderson
 * Date: 11/8/2011
 * Time: 5:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions; 
using System.IO;

namespace wheresWaldo
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		string localDataBasePath;
		
		public Form1(string dataBasePath)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			localDataBasePath = dataBasePath;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			//create new database object
			dbResult resumeFilter = new dbResult();
			
			//send object to filter to fill in values
			filterResume(resumeFilter);

			//show add person form
			ExtractionForm extractForm = new ExtractionForm(localDataBasePath, resumeFilter);
   			extractForm.Show();
		}
		
		void filterResume(dbResult filterResults)
		{
			//get the name and address and remove newlines
			string temp = richTextBox1.Text.Replace('\n',' ');
			temp = temp.Replace('.',' ');
			temp = temp.Replace(',',' ');
			
			//use regex to check for address, get index of start of address and then assume name precedes it
			//looking for format 5503 West Seminary Rd #1897 falls church VA 22041
			Regex exp = new Regex(@"\d+\s+\w+(\s+\w+)?\s+[a-z]+(\s+\D+\d+)?\s+[a-z]+(\s+[a-z]+)?\s+[a-z]+\s+\d\d\d\d\d",
    					RegexOptions.IgnoreCase);
			
			MatchCollection MatchList = exp.Matches(temp);
			if (MatchList.Count == 1)
			{
				Match FirstMatch = MatchList[0];
				filterResults.SetAddress(FirstMatch.Value+":");
				string nameTemp = temp.Substring(0,temp.IndexOf(FirstMatch.Value)-1);
				string[] nameArray = nameTemp.Split(' ');
				int count = 0;
				
				//there are better ways to do this, but I needed an easy way to get rid of hidden spaces
				foreach (string name in nameArray) {
					if (name != "")
						count++;
				}
				if (count >= 3)
				{
					filterResults.SetFirstName(nameArray[0]);
					filterResults.SetMiddleName(nameArray[1]);
					filterResults.SetLastName(nameArray[2]);
				}
				else if (count >= 2)
				{
					filterResults.SetFirstName(nameArray[0]);
					filterResults.SetLastName(nameArray[1]);
				}
			}
			
			//now work on education portion of form
			string educText = richTextBox2.Text;
			
			//find degrees, then colleges, then fields of study
			//first two can be found by using regex to filter keywords
			Regex educExp = new Regex(@"((((bachelor(s)?(,|\s+of)\s+)|(b\.?))|((master(s)?(,|\s+of)\s+)|(m\.?))|((doctorate(,|\s+of)\s+)|(d\.?)))(((s\.?(\s+|,))|(science(,|\s+)))|((e\.?(\s+|,))|(engineering(,|\s+)))|((a\.?(\s+|,))|(art(,|\s+)))|((t\.?(\s+|,))|(tech[a-z]+(,|\s+)))))|((doctorate\s+of\s+philosophy(,|\s+))|(p\.?h\.?d\.?(,|\s+)))",
    						RegexOptions.IgnoreCase);
			MatchCollection MatchListEduc = educExp.Matches(educText);
			Regex univExp = new Regex(@"((University\s+of\s+([A-Z][a-z]+(\s+|,))+(\s+|,)?)|(([A-Z][a-z]+\s+)+University(\s+|,)?))|((College\s+of\s+([A-Z][a-z]+(\s+|,))+(\s+|,)?)|(([A-Z][a-z]+\s+)+College(\s+|,)?))|((Institute\s+of\s+([A-Z][a-z]+(\s+|,))+(\s+|,)?)|(([A-Z][a-z]+\s+)+Institute(\s+|,)?))");
			MatchCollection MatchListUniv = univExp.Matches(educText);
			
			//need to use degree data to split into substrings
			//then use regex to find field of study in substring for each degree
			//Regex fosExp = new Regex(@"",
			//                          RegexOptions.IgnoreCase);
			//MatchCollection MatchListFos = fosExp.Matches(educText);
			//foreach (Match FirstMatchEduc in MatchListUniv)
			//	filterResults.SetEducation(FirstMatchEduc.Value+":"+"university"+":"+"fos");
			
			//format <university>:<degree>:<field of study> sent to object to get passed to extranctionform 
			for(int i = 0; i < MatchListEduc.Count; i++)
			{
				filterResults.SetEducation(MatchListUniv[i].Value+":"+MatchListEduc[i].Value+":"+"fos");
			}	
			
			//now get associates info from teh box; go for the low hanging fruit first.  :)
			string[] assArray = richTextBox4.Text.Split('\n');
			foreach(string assoc in assArray)
				filterResults.SetAssociates(assoc);
			
			//now get technologies from education and emplyment history;  once again, low hanging fruit.  :)
			//open keyword file and pull keywords inot array; then look through education and employment text for keywords
			string textIn = File.ReadAllText("techWords.cfg");
			string [] textArray = textIn.Split(new string [] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string keyword in textArray)
			{
				if (richTextBox3.Text.Contains(keyword) || richTextBox2.Text.Contains(keyword))
					filterResults.SetTechnology(keyword);
			}
		}
	}
}
