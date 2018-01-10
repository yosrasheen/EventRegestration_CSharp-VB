using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;

 
   public class PLace
   {
      public Int32 PLace_ID{ get; set;}
      public String Place{ get; set;}
      public PLace()
      {
      }
      public List<PLace> GetPLaces()
      {
         List<PLace> objRet = new List<PLace>();
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[GetAllPLace]";
               using (SqlDataReader objDR = objCmd.ExecuteReader())
               {
                  while (objDR.Read())
                  {
                     PLace objRec = new PLace();
                     if (objDR.IsDBNull(objDR.GetOrdinal("PLace_ID")))
                        objRec.PLace_ID = 0;
                     else
                        objRec.PLace_ID = objDR.GetInt32(objDR.GetOrdinal("PLace_ID"));
                     if (objDR.IsDBNull(objDR.GetOrdinal("Place")))
                        objRec.Place = "";
                     else
                        objRec.Place = objDR.GetString(objDR.GetOrdinal("Place"));
                     objRet.Add(objRec);
                  }
               }
            }
         }
         return objRet;
      }
      public Int32 InsertPLace(PLace objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddPLace]";
               objCmd.Parameters.Add(new SqlParameter("@PLace_ID", objRecord.PLace_ID));
               objCmd.Parameters.Add(new SqlParameter("@Place", objRecord.Place));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdatePLace(PLace objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdatePLace]";
               objCmd.Parameters.Add(new SqlParameter("@PLace_ID", objRecord.PLace_ID));
               objCmd.Parameters.Add(new SqlParameter("@Place", objRecord.Place));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeletePLace(PLace objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeletePLace]";
               objCmd.Parameters.Add(new SqlParameter("@PLace_ID",objRecord. PLace_ID));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }
 
