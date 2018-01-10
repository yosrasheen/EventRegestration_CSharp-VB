using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

 
   public class Events_workshops
   {
       public static SqlDataAdapter da = new SqlDataAdapter();
      public Int64 Workshop_ID{ get; set;}
      public String Workshop_Name{ get; set;}
      public Boolean Isdelete{ get; set;}
      public Int64 Event_Id{ get; set;}
      public Events_workshops()
      {
      }
      public bool GetAllEvents_workshops()
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
                  com.CommandText = "GetAllEvents_workshops";
                  com.Parameters.AddWithValue("Workshop_ID", Workshop_ID);

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
                          Workshop_Name = ds.Tables[0].Rows[0]["Workshop_Name"].ToString();
                          Event_Id = int.Parse(ds.Tables[0].Rows[0]["Event_Id"].ToString());

                      }
                  }
                  com.Parameters.Clear();
                  conn.Close();
              }
              return success;
          }
      }
      public Int32 InsertEvents_workshops(Events_workshops objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddEvents_workshops]";
          
               objCmd.Parameters.Add(new SqlParameter("@Workshop_Name", objRecord.Workshop_Name));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.Parameters.Add(new SqlParameter("@Event_Id", objRecord.Event_Id));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateEvents_workshops(Events_workshops objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateEvents_workshops]";
               objCmd.Parameters.Add(new SqlParameter("@Workshop_ID", objRecord.Workshop_ID));
               objCmd.Parameters.Add(new SqlParameter("@Workshop_Name", objRecord.Workshop_Name));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.Parameters.Add(new SqlParameter("@Event_Id", objRecord.Event_Id));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteEvents_workshops(Events_workshops objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteEvents_workshops]";
               objCmd.Parameters.Add(new SqlParameter("@Workshop_ID",objRecord. Workshop_ID));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }
