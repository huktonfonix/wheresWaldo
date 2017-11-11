/*
 * Created by SharpDevelop.
 * User: janderson
 * Date: 10/17/2011
 * Time: 3:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace wheresWaldo
{
	/// <summary>
	/// Description of customQuery.
	/// </summary>
	public class customQuery
	{
		List<string> education = new List<string>();
		List<string> businesses = new List<string>();
		List<string> technologies = new List<string>();
		List<string> associates = new List<string>();
		List<string> name = new List<string>();
		List<string> index = new List<string>();
		
		public customQuery()
		{
			this.education.Clear();
			this.businesses.Clear();
			this.technologies.Clear();
			this.associates.Clear();
			this.index.Clear();
			this.name.Clear();
		}
		
		public string GetEducation(int i) { return this.education[i]; }
		public void SetEducation(string name) { this.education.Add(name); }
		public int GetEducationCount() { return this.education.Count; }
		public string GetBusinesses(int i) { return this.businesses[i]; }
		public void SetBusinesses(string name) { this.businesses.Add(name); }
		public int GetBusinessesCount() { return this.businesses.Count; }
		public string GetTechnology(int i) { return this.technologies[i]; }
		public void SetTechnology(string name) { this.technologies.Add(name); }
		public int GetTechnologyCount() { return this.technologies.Count; }
		public string GetAssociates(int i) { return this.associates[i]; }
		public void SetAssociates(string name) { this.associates.Add(name); }
		public void SetIndex(string number) { this.index.Add(number); }
		public int GetIndexCount() { return this.index.Count; }
		public string GetIndex(int i) { return this.index[i]; }
		public void ClearIndex() { this.index.Clear(); }
		public void SetName(string name) { this.name.Add(name); }
		public int GetNameCount() { return this.name.Count; }
		public string GetName(int i) { return this.name[i]; }
		public void ClearName() { this.name.Clear(); }
		
		public void queryDatabase(string sqlString, customQuery findResult, System.Data.OleDb.OleDbConnection conn)
		{
            	OleDbCommand Com = new OleDbCommand(); 
            	Com.CommandText = sqlString; 
            	Com.Connection = conn; 
  
            	OleDbDataReader objDataReader = null;
            	objDataReader = Com.ExecuteReader();
				if (objDataReader == null)
					return;
    			while(objDataReader.Read())
    				findResult.SetIndex(objDataReader["PersonID"].ToString());
    			objDataReader.Close();
    			
    			string whereClause = "(MyNumber='"+findResult.GetIndex(0)+"') ";
    			for(int i = 1; i < findResult.GetIndexCount(); i++)
    				whereClause = whereClause + "OR (MyNumber='" + findResult.GetIndex(i) + "') ";
    			string localsqlString = "SELECT PersonName FROM tblPeeps WHERE ("+ whereClause +")";

    			OleDbCommand Com2 = new OleDbCommand(); 
            	Com2.CommandText = localsqlString; 
            	Com2.Connection = conn; 
  
            	OleDbDataReader objDataReader2 = null;
            	objDataReader2 = Com2.ExecuteReader();
    			
				if (objDataReader2 == null)
					return;
    			while(objDataReader2.Read())
    			{
    				findResult.SetName(objDataReader2["PersonName"].ToString());
    			}
    			objDataReader2.Close();
		}
	}
}
