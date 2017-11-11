/*
 * Created by SharpDevelop.
 * User: janderson
 * Date: 9/28/2011
 * Time: 6:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace wheresWaldo
{
	/// <summary>
	/// Description of dbResult.
	/// </summary>
	public class dbResult
	{
		List<string> name = new List<string>();
		string lastName;
		string firstName;
		string middleName;
		string country;
		string passport;
		//string entries;
		List<string> entries = new List<string>();
		string eyeColor;
		string hairColor;
		string height;
		string weight;
		string ethnicity;
		string placeOfBirth;
		string dateOfBirth;
		List<string> address = new List<string>();
		string notes;
		List<string> education = new List<string>();
		List<string> businesses = new List<string>();
		List<string> technologies = new List<string>();
		List<string> associates = new List<string>();
		List<string> links = new List<string>();
		string picture;
		List<string> index = new List<string>();
		//private System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
		
		public dbResult()
		{
			this.name.Clear();
			this.lastName = "";
			this.firstName = "";
			this.middleName = "";
			this.country = "";
			this.passport = "";
			this.entries.Clear();
			this.eyeColor = "";
			this.hairColor = "";
			this.height = "";
			this.weight = "";
			this.ethnicity = "";
			this.placeOfBirth = "";
			this.dateOfBirth = "";
			this.address.Clear();
			this.notes = "";
			this.education.Clear();
			this.businesses.Clear();
			this.technologies.Clear();
			this.associates.Clear();
			this.links.Clear();
			this.picture = "c:\\Libraries\\Pictures\\modKoalaSmall.jpg";
			this.index.Clear();
		}
		
		//get/set functions for the object
		public string GetName(int i) { return this.name[i]; }
		public void SetName(string name) { this.name.Add(name); }
		public int GetNameCount() { return this.name.Count; }
		public string GetLastName() { return lastName; }
		public void SetLastName(string name) { this.lastName =name; }
		public string GetFirstName() { return firstName; }
		public void SetFirstName(string name) { this.firstName =name; }
		public string GetMiddleName() { return middleName; }
		public void SetMiddleName(string name) { this.middleName =name; }
		public string GetCountry() { return country; }
		public void SetCountry(string name) { this.country =name; }
		public string GetPassport() { return passport; }
		public void SetPassport(string name) { this.passport =name; }
		public string GetEntries(int i) { return this.entries[i]; }
		public void SetEntries(string name) { this.entries.Add(name); }
		public int GetEntriesCount() { return this.entries.Count; }
		public string GetEyecolor() { return eyeColor; }
		public void SetEyecolor(string name) { this.eyeColor =name; }
		public string GetHaircolor() { return hairColor; }
		public void SetHaircolor(string name) { this.hairColor =name; }
		public string GetHeight() { return height; }
		public void SetHeight(string name) { this.height =name; }
		public string GetWeight() { return weight; }
		public void SetWeight(string name) { this.weight =name; }
		public string GetEthnicity() { return ethnicity; }
		public void SetEthnicity(string name) { this.ethnicity =name; }
		public string GetPOB() { return placeOfBirth; }
		public void SetPOB(string name) { this.placeOfBirth =name; }
		public string GetDOB() { return dateOfBirth; }
		public void SetDOB(string name) { this.dateOfBirth =name; }
		public string GetAddress(int i) { return this.address[i]; }
		public void SetAddress(string name) { this.address.Add(name); }
		public int GetAddressCount() { return this.address.Count; }
		public string GetNotes() { return notes; }
		public void SetNotes(string name) { this.notes =name; }
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
		public int GetAssociatesCount() { return this.associates.Count; }
		public string GetLinks(int i) { return this.links[i]; }
		public void SetLinks(string name) { this.links.Add(name); }
		public int GetLinksCount() { return this.links.Count; }
		public string GetPics() { return picture; }
		public void SetPics(string name) { this.picture =name; }
		public string GetDateOfAddr() { return picture; }
		public void SetDateOfAddr(string name) { this.picture =name; }
		public string GetIndex(int i) { return this.index[i]; }
		public void SetIndex(string number) { this.index.Add(number); }
		public int GetIndexCount() { return this.index.Count; }
		public void ClearIndex() { this.index.Clear(); }
		public void ClearName() { this.name.Clear(); }
		
		public void deleteFromDatabase(string index, System.Data.OleDb.OleDbConnection conn)
		{
    			string localsqlString = "DELETE [tblPeeps.*] FROM tblPeeps WHERE (MyNumber='" + index + "')";
    			OleDbCommand Com2 = new OleDbCommand(); 
            	Com2.CommandText = localsqlString; 
            	Com2.Connection = conn; 
            	OleDbDataReader objDataReader2 = null;
            	objDataReader2 = Com2.ExecuteReader();
            	objDataReader2.Close();
            	
   
    			localsqlString = "DELETE [tblOtherInfo.*] FROM tblOtherInfo WHERE (PersonID='" + index + "')";
    			OleDbCommand Com = new OleDbCommand(); 
            	Com.CommandText = localsqlString; 
            	Com.Connection = conn;
    			OleDbDataReader objDataReader = null;
            	objDataReader = Com.ExecuteReader();
    			objDataReader.Close();
		}
		
		public void queryDatabase(string whereClause, string endClause, dbResult findResult, System.Data.OleDb.OleDbConnection conn)
		{
			bool foundData = false;
			string sqlString = "SELECT LastName, FirstName, MiddleName, PersonName, StreetAddress, " + 
					"Country, PlaceOfBirth, DateOfBirth, Passport, Notes, EyeColor, " + 
					"HairColor, Height, Weight, Ethnicity, MyNumber, Photo " + 
					"FROM tblPeeps "+whereClause+endClause;
            	OleDbCommand Com = new OleDbCommand(); 
            	Com.CommandText = sqlString; 
            	Com.Connection = conn; 
  
            	OleDbDataReader objDataReader = null;
            	objDataReader = Com.ExecuteReader();
				if (objDataReader == null)
					return;
    			while(objDataReader.Read())
				{
    				findResult.SetLastName(objDataReader["LastName"].ToString());
    				findResult.SetFirstName(objDataReader["FirstName"].ToString());
    				findResult.SetMiddleName(objDataReader["MiddleName"].ToString());
    				findResult.SetCountry(objDataReader["Country"].ToString());
    				findResult.SetPOB(objDataReader["PlaceOfBirth"].ToString());
    				findResult.SetDOB(objDataReader["DateOfBirth"].ToString());
    				findResult.SetPassport(objDataReader["Passport"].ToString());
    				findResult.SetNotes(objDataReader["Notes"].ToString());
    				findResult.SetEyecolor(objDataReader["EyeColor"].ToString());
    				findResult.SetHaircolor(objDataReader["HairColor"].ToString());
    				findResult.SetHeight(objDataReader["Height"].ToString());
    				findResult.SetWeight(objDataReader["Weight"].ToString());
    				findResult.SetEthnicity(objDataReader["Ethnicity"].ToString());
    				findResult.SetPics(objDataReader["Photo"].ToString());
    				findResult.SetName(objDataReader["PersonName"].ToString());
    				findResult.SetIndex(objDataReader["MyNumber"].ToString());
    				foundData = true;
    			}
    			objDataReader.Close();
    			
    			if (foundData)
    			{
    				sqlString = "SELECT Entries, Addresses, Technologies, DateOfAddresses, " +
    					"Associates, Universities, Degrees, FieldOfStudies, PlaceOfBiz, RoleInBiz, Links " +
						"FROM tblOtherInfo " +
    					"WHERE (PersonID='" +findResult.GetIndex(findResult.GetIndexCount()-1)+"')";
    				OleDbCommand Com2 = new OleDbCommand(); 
            		Com2.CommandText = sqlString; 
            		Com2.Connection = conn; 
  
            		OleDbDataReader objDataReader2 = null;
            		objDataReader2 = Com2.ExecuteReader();
    			
					if (objDataReader2 == null)
						return;
    				while(objDataReader2.Read())
    				{
    					findResult.SetEntries(objDataReader2["Entries"].ToString());
    					findResult.SetAddress(objDataReader2["Addresses"].ToString()+"\t\t"+objDataReader2["DateOfAddresses"].ToString());
    					findResult.SetEducation(objDataReader2["Universities"].ToString()+"\t\t"+objDataReader2["Degrees"].ToString()+"\t\t"+objDataReader2["FieldOfStudies"].ToString());
    					findResult.SetTechnology(objDataReader2["Technologies"].ToString());
    					findResult.SetBusinesses(objDataReader2["PlaceOfBiz"].ToString()+"\t\t"+objDataReader2["RoleInBiz"].ToString());
    					findResult.SetAssociates(objDataReader2["Associates"].ToString());
    					findResult.SetLinks(objDataReader2["Links"].ToString());
    				}
    				objDataReader2.Close();
    			}
    			else
    				MessageBox.Show("Search Returned 0 matches.\nEnter * in LastName field to see all entries.");
		}
	}
}
