/*
 * Created by SharpDevelop.
 * User: janderson
 * Date: 10/17/2011
 * Time: 12:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace wheresWaldo
{
	/// <summary>
	/// Description of displayForm.
	/// </summary>
	public partial class displayForm : Form
	{
		customQuery localQuery = new customQuery();
		string root;
		
		public displayForm(customQuery results, string queryRoot)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			localQuery = results;
			root = queryRoot;
		}
		
		void paintForm(object sender, PaintEventArgs e)
		{
			//init all arrays
			Point[] pointarray1 = new Point[300];
			Point[] pointarray2 = new Point[300];
			string[] stringArray = new String[300];
			
			//create all drawing toolsa needed
			System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
   			System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
			Form displayForm = (Form)sender;
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Blue, 2);
            
            //draw root and then go thru object array and draw rect, text and lines
            g.DrawString(root, drawFont, drawBrush, 0, 200);
            string [] rootLength = root.Split(new string [] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < localQuery.GetNameCount(); i++)
            {
            	pointarray1[i].X = rootLength[0].Length*7;
            	pointarray1[i].Y = 210;
            }
            
            for (int i = 0; i < localQuery.GetNameCount(); i++)
            {
            	pointarray2[i].X = 500;
            	pointarray2[i].Y = (400/(localQuery.GetNameCount()+1))*(i+1)+10;
            	g.DrawLine(p, pointarray1[i], pointarray2[i]);
            }
            
            for (int i = 0; i < localQuery.GetNameCount(); i++)
            {
            	g.DrawString(localQuery.GetName(i), drawFont, drawBrush, 500, (400/(localQuery.GetNameCount()+1))*(i+1));
            }
            
            //dispose of all drawing objects
            drawFont.Dispose();
   			drawBrush.Dispose();
            p.Dispose();
            g.Dispose();
		}
			
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
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
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			//open the dialog box so user can choose path
			saveFileDialog1.ShowDialog();
			string path = saveFileDialog1.FileName;
			string outputFile = "###   This file is used by the connectMap form on Where's Waldo.   ###\n###   Do not modify   ###\n";
			
			//get text of root connection
			outputFile = outputFile+"<rootText>"+root+"<EOL>";
			
			//get text of each branch
			for (int i = 0; i < localQuery.GetNameCount(); i++)
            {
            	outputFile = outputFile+"<branchText>"+localQuery.GetName(i)+"<EOL>";
            }
			
			//write to the output file
			File.WriteAllText(path+".cmp", outputFile);
			
		}
	}
}
