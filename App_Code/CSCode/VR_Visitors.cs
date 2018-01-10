using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;

 
   public class VR_Visitors
   {
      public Int64 Visitor_ID{ get; set;}
      public String Visitor_Name{ get; set;}
      public Int32 Visitor_Gender{ get; set;}
      public String Nick_Name{ get; set;}
      public Int32 Visitor_Age{ get; set;}
      public String Country_Name{ get; set;}
      public String Side_Name{ get; set;}
      public String Job_Name{ get; set;}
      public String Visitor_Mobile{ get; set;}
      public String Visitor_Phone{ get; set;}
      public String Visitor_Fax{ get; set;}
      public String Visitor_POBox{ get; set;}
      public String Visitor_ZipCode{ get; set;}
      public String Visitor_City{ get; set;}
      public String Visitor_Country{ get; set;}
      public String Visitor_Email{ get; set;}
      public String Visitor_Photo{ get; set;}
      public Int32 USER_ID{ get; set;}
      public DateTime Created_Date{ get; set;}
      public Boolean Isdelete{ get; set;}
      public String User_Name{ get; set;}
      public String Password{ get; set;}
      public VR_Visitors()
      {
      }
      public List<VR_Visitors> GetVR_Visitorss()
      {
         List<VR_Visitors> objRet = new List<VR_Visitors>();
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[GetAllVR_Visitors]";
               using (SqlDataReader objDR = objCmd.ExecuteReader())
               {
                  while (objDR.Read())
                  {
                     VR_Visitors objRec = new VR_Visitors();
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_ID")))
                        objRec.Visitor_ID = 0;
                     else
                        objRec.Visitor_ID = objDR.GetInt64(objDR.GetOrdinal("Visitor_ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_Name")))
                        objRec.Visitor_Name = "";
                     else
                        objRec.Visitor_Name = objDR.GetString(objDR.GetOrdinal("Visitor_Name"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_Gender")))
                        objRec.Visitor_Gender = 0;
                     else
                        objRec.Visitor_Gender = objDR.GetInt32(objDR.GetOrdinal("Visitor_Gender"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Nick_Name")))
                        objRec.Nick_Name = "";
                     else
                        objRec.Nick_Name = objDR.GetString(objDR.GetOrdinal("Nick_Name"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_Age")))
                        objRec.Visitor_Age = 0;
                     else
                        objRec.Visitor_Age = objDR.GetInt32(objDR.GetOrdinal("Visitor_Age"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Country_Name")))
                        objRec.Country_Name = "";
                     else
                        objRec.Country_Name = objDR.GetString(objDR.GetOrdinal("Country_Name"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Side_Name")))
                        objRec.Side_Name = "";
                     else
                        objRec.Side_Name = objDR.GetString(objDR.GetOrdinal("Side_Name"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Job_Name")))
                        objRec.Job_Name = "";
                     else
                        objRec.Job_Name = objDR.GetString(objDR.GetOrdinal("Job_Name"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_Mobile")))
                        objRec.Visitor_Mobile = "";
                     else
                        objRec.Visitor_Mobile = objDR.GetString(objDR.GetOrdinal("Visitor_Mobile"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_Phone")))
                        objRec.Visitor_Phone = "";
                     else
                        objRec.Visitor_Phone = objDR.GetString(objDR.GetOrdinal("Visitor_Phone"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_Fax")))
                        objRec.Visitor_Fax = "";
                     else
                        objRec.Visitor_Fax = objDR.GetString(objDR.GetOrdinal("Visitor_Fax"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_POBox")))
                        objRec.Visitor_POBox = "";
                     else
                        objRec.Visitor_POBox = objDR.GetString(objDR.GetOrdinal("Visitor_POBox"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_ZipCode")))
                        objRec.Visitor_ZipCode = "";
                     else
                        objRec.Visitor_ZipCode = objDR.GetString(objDR.GetOrdinal("Visitor_ZipCode"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_City")))
                        objRec.Visitor_City = "";
                     else
                        objRec.Visitor_City = objDR.GetString(objDR.GetOrdinal("Visitor_City"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_Country")))
                        objRec.Visitor_Country = "";
                     else
                        objRec.Visitor_Country = objDR.GetString(objDR.GetOrdinal("Visitor_Country"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_Email")))
                        objRec.Visitor_Email = "";
                     else
                        objRec.Visitor_Email = objDR.GetString(objDR.GetOrdinal("Visitor_Email"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_Photo")))
                        objRec.Visitor_Photo = "";
                     else
                        objRec.Visitor_Photo = objDR.GetString(objDR.GetOrdinal("Visitor_Photo"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("USER_ID")))
                        objRec.USER_ID = 0;
                     else
                        objRec.USER_ID = objDR.GetInt32(objDR.GetOrdinal("USER_ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Created_Date")))
                        objRec.Created_Date = DateTime.Now;
                     else
                        objRec.Created_Date = objDR.GetDateTime(objDR.GetOrdinal("Created_Date"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Isdelete")))
                        objRec.Isdelete = false;
                     else
                        objRec.Isdelete = objDR.GetBoolean(objDR.GetOrdinal("Isdelete"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("User_Name")))
                        objRec.User_Name = "";
                     else
                        objRec.User_Name = objDR.GetString(objDR.GetOrdinal("User_Name"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Password")))
                        objRec.Password = "";
                     else
                        objRec.Password = objDR.GetString(objDR.GetOrdinal("Password"));
                     objRet.Add(objRec);
                  }
               }
            }
         }
         return objRet;
      }
      public Int32 InsertVR_Visitors(VR_Visitors objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddVR_Visitors]";
               objCmd.Parameters.Add(new SqlParameter("@Visitor_ID", objRecord.Visitor_ID));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Name", objRecord.Visitor_Name));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Gender", objRecord.Visitor_Gender));
               objCmd.Parameters.Add(new SqlParameter("@Nick_Name", objRecord.Nick_Name));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Age", objRecord.Visitor_Age));
               objCmd.Parameters.Add(new SqlParameter("@Country_Name", objRecord.Country_Name));
               objCmd.Parameters.Add(new SqlParameter("@Side_Name", objRecord.Side_Name));
               objCmd.Parameters.Add(new SqlParameter("@Job_Name", objRecord.Job_Name));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Mobile", objRecord.Visitor_Mobile));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Phone", objRecord.Visitor_Phone));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Fax", objRecord.Visitor_Fax));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_POBox", objRecord.Visitor_POBox));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_ZipCode", objRecord.Visitor_ZipCode));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_City", objRecord.Visitor_City));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Country", objRecord.Visitor_Country));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Email", objRecord.Visitor_Email));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Photo", objRecord.Visitor_Photo));
               objCmd.Parameters.Add(new SqlParameter("@USER_ID", objRecord.USER_ID));
               objCmd.Parameters.Add(new SqlParameter("@Created_Date", objRecord.Created_Date));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.Parameters.Add(new SqlParameter("@User_Name", objRecord.User_Name));
               objCmd.Parameters.Add(new SqlParameter("@Password", objRecord.Password));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateVR_Visitors(VR_Visitors objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateVR_Visitors]";
               objCmd.Parameters.Add(new SqlParameter("@Visitor_ID", objRecord.Visitor_ID));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Name", objRecord.Visitor_Name));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Gender", objRecord.Visitor_Gender));
               objCmd.Parameters.Add(new SqlParameter("@Nick_Name", objRecord.Nick_Name));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Age", objRecord.Visitor_Age));
               objCmd.Parameters.Add(new SqlParameter("@Country_Name", objRecord.Country_Name));
               objCmd.Parameters.Add(new SqlParameter("@Side_Name", objRecord.Side_Name));
               objCmd.Parameters.Add(new SqlParameter("@Job_Name", objRecord.Job_Name));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Mobile", objRecord.Visitor_Mobile));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Phone", objRecord.Visitor_Phone));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Fax", objRecord.Visitor_Fax));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_POBox", objRecord.Visitor_POBox));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_ZipCode", objRecord.Visitor_ZipCode));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_City", objRecord.Visitor_City));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Country", objRecord.Visitor_Country));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Email", objRecord.Visitor_Email));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_Photo", objRecord.Visitor_Photo));
               objCmd.Parameters.Add(new SqlParameter("@USER_ID", objRecord.USER_ID));
               objCmd.Parameters.Add(new SqlParameter("@Created_Date", objRecord.Created_Date));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.Parameters.Add(new SqlParameter("@User_Name", objRecord.User_Name));
               objCmd.Parameters.Add(new SqlParameter("@Password", objRecord.Password));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteVR_Visitors(VR_Visitors objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteVR_Visitors]";
               objCmd.Parameters.Add(new SqlParameter("@Visitor_ID",objRecord. Visitor_ID));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }
 
