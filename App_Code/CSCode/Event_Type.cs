using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;


   public class Event_Type
   {
       public static SqlDataAdapter da = new SqlDataAdapter();
      public Int32 Event_Type_Id{ get; set;}
      public String EventType{ get; set;}
      public Boolean IsDelete{ get; set;}
      public Event_Type()
      {
      }

      public bool GetAllEvent_Type()
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
                  com.CommandText = "GetAllEvent_Type";
                  com.Parameters.AddWithValue("Event_Type_Id", Event_Type_Id);

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


                          EventType = ds.Tables[0].Rows[0]["Event_Type"].ToString();

                      }
                  }
                  com.Parameters.Clear();
                  conn.Close();
              }
              return success;
          }
      }




      public Int32 InsertEvent_Type(Event_Type objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddEvent_Type]";
             
               objCmd.Parameters.Add(new SqlParameter("@Event_Type", objRecord.EventType));
               objCmd.Parameters.Add(new SqlParameter("@IsDelete", objRecord.IsDelete));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateEvent_Type(Event_Type objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateEvent_Type]";
               objCmd.Parameters.Add(new SqlParameter("@Event_Type_Id", objRecord.Event_Type_Id));
               objCmd.Parameters.Add(new SqlParameter("@Event_Type", objRecord.EventType));
               objCmd.Parameters.Add(new SqlParameter("@IsDelete", objRecord.IsDelete));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteEvent_Type(Event_Type objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteEvent_Type]";
               objCmd.Parameters.Add(new SqlParameter("@Event_Type_Id",objRecord. Event_Type_Id));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }

