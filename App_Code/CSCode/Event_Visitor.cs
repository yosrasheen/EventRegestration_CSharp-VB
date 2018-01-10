using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;


   public class Event_Visitor
   {
      public Int64 Event_Visitor_ID{ get; set;}
      public Int64 Event_ID{ get; set;}
      public Int64 Visitor_ID{ get; set;}
      public DateTime Registration_Date{ get; set;}
      public Int32 USER_ID{ get; set;}
      public DateTime Created_Date{ get; set;}
      public Boolean Isdelete{ get; set;}
      public Event_Visitor()
      {
      }
      public List<Event_Visitor> GetEvent_Visitors()
      {
         List<Event_Visitor> objRet = new List<Event_Visitor>();
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[GetAllEvent_Visitor]";
               using (SqlDataReader objDR = objCmd.ExecuteReader())
               {
                  while (objDR.Read())
                  {
                     Event_Visitor objRec = new Event_Visitor();
                     if (objDR.IsDBNull(objDR.GetOrdinal("Event_Visitor_ID")))
                        objRec.Event_Visitor_ID = 0;
                     else
                        objRec.Event_Visitor_ID = objDR.GetInt64(objDR.GetOrdinal("Event_Visitor_ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Event_ID")))
                        objRec.Event_ID = 0;
                     else
                        objRec.Event_ID = objDR.GetInt64(objDR.GetOrdinal("Event_ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_ID")))
                        objRec.Visitor_ID = 0;
                     else
                        objRec.Visitor_ID = objDR.GetInt64(objDR.GetOrdinal("Visitor_ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Registration_Date")))
                        objRec.Registration_Date = DateTime.Now;
                     else
                        objRec.Registration_Date = objDR.GetDateTime(objDR.GetOrdinal("Registration_Date"));
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
                     objRet.Add(objRec);
                  }
               }
            }
         }
         return objRet;
      }
      public Int32 InsertEvent_Visitor(Event_Visitor objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddEvent_Visitor]";
               objCmd.Parameters.Add(new SqlParameter("@Event_Visitor_ID", objRecord.Event_Visitor_ID));
               objCmd.Parameters.Add(new SqlParameter("@Event_ID", objRecord.Event_ID));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_ID", objRecord.Visitor_ID));
               objCmd.Parameters.Add(new SqlParameter("@Registration_Date", objRecord.Registration_Date));
               objCmd.Parameters.Add(new SqlParameter("@USER_ID", objRecord.USER_ID));
               objCmd.Parameters.Add(new SqlParameter("@Created_Date", objRecord.Created_Date));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateEvent_Visitor(Event_Visitor objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateEvent_Visitor]";
               objCmd.Parameters.Add(new SqlParameter("@Event_Visitor_ID", objRecord.Event_Visitor_ID));
               objCmd.Parameters.Add(new SqlParameter("@Event_ID", objRecord.Event_ID));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_ID", objRecord.Visitor_ID));
               objCmd.Parameters.Add(new SqlParameter("@Registration_Date", objRecord.Registration_Date));
               objCmd.Parameters.Add(new SqlParameter("@USER_ID", objRecord.USER_ID));
               objCmd.Parameters.Add(new SqlParameter("@Created_Date", objRecord.Created_Date));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteEvent_Visitor(Event_Visitor objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteEvent_Visitor]";
               objCmd.Parameters.Add(new SqlParameter("@Event_Visitor_ID",objRecord. Event_Visitor_ID));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }

