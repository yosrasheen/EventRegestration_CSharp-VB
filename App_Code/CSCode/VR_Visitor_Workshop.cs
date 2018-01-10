using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;

 
   public class VR_Visitor_Workshop
   {
      public Int64 ID{ get; set;}
      public Int64 Workshop_ID{ get; set;}
      public Int64 Visitor_ID{ get; set;}
      public String Visit_Date{ get; set;}
      public DateTime Create_Date{ get; set;}
      public Int32 USER_ID{ get; set;}
      public Boolean Isdelete{ get; set;}
      public VR_Visitor_Workshop()
      {
      }
      public List<VR_Visitor_Workshop> GetVR_Visitor_Workshops()
      {
         List<VR_Visitor_Workshop> objRet = new List<VR_Visitor_Workshop>();
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[GetAllVR_Visitor_Workshop]";
               using (SqlDataReader objDR = objCmd.ExecuteReader())
               {
                  while (objDR.Read())
                  {
                     VR_Visitor_Workshop objRec = new VR_Visitor_Workshop();
                     if (objDR.IsDBNull(objDR.GetOrdinal("ID")))
                        objRec.ID = 0;
                     else
                        objRec.ID = objDR.GetInt64(objDR.GetOrdinal("ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Workshop_ID")))
                        objRec.Workshop_ID = 0;
                     else
                        objRec.Workshop_ID = objDR.GetInt64(objDR.GetOrdinal("Workshop_ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visitor_ID")))
                        objRec.Visitor_ID = 0;
                     else
                        objRec.Visitor_ID = objDR.GetInt64(objDR.GetOrdinal("Visitor_ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Visit_Date")))
                        objRec.Visit_Date = "";
                     else
                        objRec.Visit_Date = objDR.GetString(objDR.GetOrdinal("Visit_Date"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Create_Date")))
                        objRec.Create_Date = DateTime.Now;
                     else
                        objRec.Create_Date = objDR.GetDateTime(objDR.GetOrdinal("Create_Date"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("USER_ID")))
                        objRec.USER_ID = 0;
                     else
                        objRec.USER_ID = objDR.GetInt32(objDR.GetOrdinal("USER_ID"));
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
      public Int32 InsertVR_Visitor_Workshop(VR_Visitor_Workshop objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddVR_Visitor_Workshop]";
               objCmd.Parameters.Add(new SqlParameter("@ID", objRecord.ID));
               objCmd.Parameters.Add(new SqlParameter("@Workshop_ID", objRecord.Workshop_ID));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_ID", objRecord.Visitor_ID));
               objCmd.Parameters.Add(new SqlParameter("@Visit_Date", objRecord.Visit_Date));
               objCmd.Parameters.Add(new SqlParameter("@Create_Date", objRecord.Create_Date));
               objCmd.Parameters.Add(new SqlParameter("@USER_ID", objRecord.USER_ID));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateVR_Visitor_Workshop(VR_Visitor_Workshop objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateVR_Visitor_Workshop]";
               objCmd.Parameters.Add(new SqlParameter("@ID", objRecord.ID));
               objCmd.Parameters.Add(new SqlParameter("@Workshop_ID", objRecord.Workshop_ID));
               objCmd.Parameters.Add(new SqlParameter("@Visitor_ID", objRecord.Visitor_ID));
               objCmd.Parameters.Add(new SqlParameter("@Visit_Date", objRecord.Visit_Date));
               objCmd.Parameters.Add(new SqlParameter("@Create_Date", objRecord.Create_Date));
               objCmd.Parameters.Add(new SqlParameter("@USER_ID", objRecord.USER_ID));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteVR_Visitor_Workshop(VR_Visitor_Workshop objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteVR_Visitor_Workshop]";
               objCmd.Parameters.Add(new SqlParameter("@ID",objRecord. ID));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }
 
