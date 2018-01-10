using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;


   public class Attend_FeedBack
   {
      public Int32 Attend_feedBack_Id{ get; set;}
      public Int32 Event_Id{ get; set;}
      public String title{ get; set;}
      public String details{ get; set;}
      public String FeedDate{ get; set;}
      public Attend_FeedBack()
      {
      }
   
      public Int32 InsertAttend_FeedBack(Attend_FeedBack objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddAttend_FeedBack]";
              
               objCmd.Parameters.Add(new SqlParameter("@Event_Id", objRecord.Event_Id));
               objCmd.Parameters.Add(new SqlParameter("@title", objRecord.title));
               objCmd.Parameters.Add(new SqlParameter("@details", objRecord.details));
               objCmd.Parameters.Add(new SqlParameter("@FeedDate", objRecord.FeedDate));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateAttend_FeedBack(Attend_FeedBack objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateAttend_FeedBack]";
               objCmd.Parameters.Add(new SqlParameter("@Attend_feedBack_Id", objRecord.Attend_feedBack_Id));
               objCmd.Parameters.Add(new SqlParameter("@Event_Id", objRecord.Event_Id));
               objCmd.Parameters.Add(new SqlParameter("@title", objRecord.title));
               objCmd.Parameters.Add(new SqlParameter("@details", objRecord.details));
               objCmd.Parameters.Add(new SqlParameter("@FeedDate", objRecord.FeedDate));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteAttend_FeedBack(Attend_FeedBack objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteAttend_FeedBack]";
               objCmd.Parameters.Add(new SqlParameter("@Attend_feedBack_Id",objRecord. Attend_feedBack_Id));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }

