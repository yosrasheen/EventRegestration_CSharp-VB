using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;

 
   public class SYS_USER
   {
      public Int64 USER_ID{ get; set;}
      public String USER_FULLNAME{ get; set;}
      public String USER_EMAIL{ get; set;}
      public String USER_NAME{ get; set;}
      public String USER_PASSWORD{ get; set;}
      public Boolean Isdelete{ get; set;}
      public SYS_USER()
      {
      }
      public List<SYS_USER> GetSYS_USERs()
      {
         List<SYS_USER> objRet = new List<SYS_USER>();
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[GetAllSYS_USER]";
               using (SqlDataReader objDR = objCmd.ExecuteReader())
               {
                  while (objDR.Read())
                  {
                     SYS_USER objRec = new SYS_USER();
                     if (objDR.IsDBNull(objDR.GetOrdinal("USER_ID")))
                        objRec.USER_ID = 0;
                     else
                        objRec.USER_ID = objDR.GetInt64(objDR.GetOrdinal("USER_ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("USER_FULLNAME")))
                        objRec.USER_FULLNAME = "";
                     else
                        objRec.USER_FULLNAME = objDR.GetString(objDR.GetOrdinal("USER_FULLNAME"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("USER_EMAIL")))
                        objRec.USER_EMAIL = "";
                     else
                        objRec.USER_EMAIL = objDR.GetString(objDR.GetOrdinal("USER_EMAIL"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("USER_NAME")))
                        objRec.USER_NAME = "";
                     else
                        objRec.USER_NAME = objDR.GetString(objDR.GetOrdinal("USER_NAME"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("USER_PASSWORD")))
                        objRec.USER_PASSWORD = "";
                     else
                        objRec.USER_PASSWORD = objDR.GetString(objDR.GetOrdinal("USER_PASSWORD"));
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
      public Int32 InsertSYS_USER(SYS_USER objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddSYS_USER]";
               objCmd.Parameters.Add(new SqlParameter("@USER_ID", objRecord.USER_ID));
               objCmd.Parameters.Add(new SqlParameter("@USER_FULLNAME", objRecord.USER_FULLNAME));
               objCmd.Parameters.Add(new SqlParameter("@USER_EMAIL", objRecord.USER_EMAIL));
               objCmd.Parameters.Add(new SqlParameter("@USER_NAME", objRecord.USER_NAME));
               objCmd.Parameters.Add(new SqlParameter("@USER_PASSWORD", objRecord.USER_PASSWORD));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateSYS_USER(SYS_USER objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateSYS_USER]";
               objCmd.Parameters.Add(new SqlParameter("@USER_ID", objRecord.USER_ID));
               objCmd.Parameters.Add(new SqlParameter("@USER_FULLNAME", objRecord.USER_FULLNAME));
               objCmd.Parameters.Add(new SqlParameter("@USER_EMAIL", objRecord.USER_EMAIL));
               objCmd.Parameters.Add(new SqlParameter("@USER_NAME", objRecord.USER_NAME));
               objCmd.Parameters.Add(new SqlParameter("@USER_PASSWORD", objRecord.USER_PASSWORD));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteSYS_USER(SYS_USER objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteSYS_USER]";
               objCmd.Parameters.Add(new SqlParameter("@USER_ID",objRecord. USER_ID));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }
 
