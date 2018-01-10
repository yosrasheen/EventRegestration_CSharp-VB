using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

 
   public class Events
   {
       public static SqlDataAdapter da = new SqlDataAdapter();
      public Int64 Event_Id{ get; set;}
      public String Event_Name{ get; set;}
      public String Event_Type_Id{ get; set;}
      public String Event_Logo{ get; set;}
      public String Event_Brief{ get; set;}
      public String Event_Open{ get; set;}
      public String Event_End{ get; set;}
      public Boolean IsDelete{ get; set;}
      public String Event_Detailes{ get; set;}
      public Int32 holder_Id{ get; set;}
      public Boolean IsOpen{ get; set;}
      public Int32 PLace_Id{ get; set;}
      public Events()
      {
      }
      public bool GetAllEvents()
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
                  com.CommandText = "GetAllEvents";
                  com.Parameters.AddWithValue("Event_Id", Event_Id);

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
                          Event_Name = ds.Tables[0].Rows[0]["Event_Name"].ToString();
                          Event_Type_Id = ds.Tables[0].Rows[0]["Event_Type_Id"].ToString();
                          Event_Logo = ds.Tables[0].Rows[0]["Event_Logo"].ToString();
                          Event_Brief = ds.Tables[0].Rows[0]["Event_Brief"].ToString();
                          Event_Open = ds.Tables[0].Rows[0]["Event_Open"].ToString();
                          Event_End = ds.Tables[0].Rows[0]["Event_End"].ToString();
                          Event_Detailes = ds.Tables[0].Rows[0]["Event_Detailes"].ToString();
                          holder_Id =int.Parse( ds.Tables[0].Rows[0]["holder_Id"].ToString());
                          PLace_Id = int.Parse(ds.Tables[0].Rows[0]["PLace_Id"].ToString());
                          IsOpen =Boolean.Parse( ds.Tables[0].Rows[0]["IsOpen"].ToString());
                      }
                  }
                  com.Parameters.Clear();
                  conn.Close();
              }
              return success;
          }
      }
      public Int32 InsertEvents(Events objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddEvents]";
               
               objCmd.Parameters.Add(new SqlParameter("@Event_Name", objRecord.Event_Name));
               objCmd.Parameters.Add(new SqlParameter("@Event_Type_Id", objRecord.Event_Type_Id));
               objCmd.Parameters.Add(new SqlParameter("@Event_Logo", objRecord.Event_Logo));
               objCmd.Parameters.Add(new SqlParameter("@Event_Brief", objRecord.Event_Brief));
               objCmd.Parameters.Add(new SqlParameter("@Event_Open", objRecord.Event_Open));
               objCmd.Parameters.Add(new SqlParameter("@Event_End", objRecord.Event_End));
               objCmd.Parameters.Add(new SqlParameter("@IsDelete", objRecord.IsDelete));
               objCmd.Parameters.Add(new SqlParameter("@Event_Detailes", objRecord.Event_Detailes));
               objCmd.Parameters.Add(new SqlParameter("@holder_Id", objRecord.holder_Id));
               objCmd.Parameters.Add(new SqlParameter("@IsOpen", objRecord.IsOpen));
               objCmd.Parameters.Add(new SqlParameter("@PLace_Id", objRecord.PLace_Id));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateEvents(Events objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateEvents]";
               objCmd.Parameters.Add(new SqlParameter("@Event_Id", objRecord.Event_Id));
               objCmd.Parameters.Add(new SqlParameter("@Event_Name", objRecord.Event_Name));
               objCmd.Parameters.Add(new SqlParameter("@Event_Type_Id", objRecord.Event_Type_Id));
               objCmd.Parameters.Add(new SqlParameter("@Event_Logo", objRecord.Event_Logo));
               objCmd.Parameters.Add(new SqlParameter("@Event_Brief", objRecord.Event_Brief));
               objCmd.Parameters.Add(new SqlParameter("@Event_Open", objRecord.Event_Open));
               objCmd.Parameters.Add(new SqlParameter("@Event_End", objRecord.Event_End));
               objCmd.Parameters.Add(new SqlParameter("@IsDelete", objRecord.IsDelete));
               objCmd.Parameters.Add(new SqlParameter("@Event_Detailes", objRecord.Event_Detailes));
               objCmd.Parameters.Add(new SqlParameter("@holder_Id", objRecord.holder_Id));
               objCmd.Parameters.Add(new SqlParameter("@IsOpen", objRecord.IsOpen));
               objCmd.Parameters.Add(new SqlParameter("@PLace_Id", objRecord.PLace_Id));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteEvents(Events objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteEvents]";
               objCmd.Parameters.Add(new SqlParameter("@Event_Id",objRecord. Event_Id));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }
