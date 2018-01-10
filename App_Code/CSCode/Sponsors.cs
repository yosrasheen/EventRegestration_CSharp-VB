using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

 
   public class Sponsors
   {
       public static SqlDataAdapter da = new SqlDataAdapter();
      public Int64 Sponsor_ID{ get; set;}
      public String Sponsors_Name{ get; set;}
      public String Sponsor_Logo{ get; set;}
      public Int64 Event_Id{ get; set;}
      public Boolean Isdelete{ get; set;}
      public Int32 arrange{ get; set;}
      public Sponsors()
      {
      }
      public bool GetAllSponsors()
      {
          bool success = false;
          ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
          using (SqlConnection conn = new SqlConnection(objCSS.ConnectionString))
          {

              using (SqlCommand com = conn.CreateCommand())
              {

                  success = false;
                  com.Parameters.Clear();
                  com.CommandType = CommandType.StoredProcedure;
                  com.CommandText = "GetAllSponsors";
                  com.Parameters.AddWithValue("Sponsor_ID", Sponsor_ID);

                  com.Connection = conn;
                  conn.Open();
                  da.SelectCommand = com;
                  DataSet ds = new DataSet();
                  da.Fill(ds);
                  if (ds.Tables.Count > 0)
                  {
                      if (ds.Tables[0].Rows.Count > 0)
                      {
                          success = true;
                          Sponsors_Name = ds.Tables[0].Rows[0]["Sponsors_Name"].ToString();
                          Sponsor_Logo = ds.Tables[0].Rows[0]["Sponsor_Logo"].ToString();
                          Event_Id = int.Parse(ds.Tables[0].Rows[0]["Event_Id"].ToString());

                          arrange = int.Parse(ds.Tables[0].Rows[0]["arrange"].ToString());

                      }
                  }
                  com.Parameters.Clear();
                  conn.Close();
              }
              return success;
          }
      }
      public Int32 InsertSponsors(Sponsors objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddSponsors]";
       
               objCmd.Parameters.Add(new SqlParameter("@Sponsors_Name", objRecord.Sponsors_Name));
               objCmd.Parameters.Add(new SqlParameter("@Sponsor_Logo", objRecord.Sponsor_Logo));
               objCmd.Parameters.Add(new SqlParameter("@Event_Id", objRecord.Event_Id));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.Parameters.Add(new SqlParameter("@arrange", objRecord.arrange));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateSponsors(Sponsors objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateSponsors]";
               objCmd.Parameters.Add(new SqlParameter("@Sponsor_ID", objRecord.Sponsor_ID));
               objCmd.Parameters.Add(new SqlParameter("@Sponsors_Name", objRecord.Sponsors_Name));
               objCmd.Parameters.Add(new SqlParameter("@Sponsor_Logo", objRecord.Sponsor_Logo));
               objCmd.Parameters.Add(new SqlParameter("@Event_Id", objRecord.Event_Id));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.Parameters.Add(new SqlParameter("@arrange", objRecord.arrange));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteSponsors(Sponsors objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteSponsors]";
               objCmd.Parameters.Add(new SqlParameter("@Sponsor_ID",objRecord. Sponsor_ID));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }
 
