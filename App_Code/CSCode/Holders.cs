using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;


   public class Holders
   {
       public static SqlDataAdapter da = new SqlDataAdapter();
      public Int32 Holder_Id{ get; set;}
      public String Holder_Name{ get; set;}
      public String User_Name{ get; set;}
      public String Password{ get; set;}
      public String HolderDetailes{ get; set;}
      public Boolean Isdelete{ get; set;}
      public Holders()
      {
      }
      public bool GetAllHolders()
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
                  com.CommandText = "GetAllHolders";
                  com.Parameters.AddWithValue("Holder_Id", Holder_Id);

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
                          Holder_Name = ds.Tables[0].Rows[0]["Holder_Name"].ToString();
                          User_Name = ds.Tables[0].Rows[0]["User_Name"].ToString();
                          Password = ds.Tables[0].Rows[0]["Password"].ToString();

                          HolderDetailes = ds.Tables[0].Rows[0]["HolderDetailes"].ToString();

                      }
                  }
                  com.Parameters.Clear();
                  conn.Close();
              }
              return success;
          }
      }
      public Int32 InsertHolders(Holders objRecord)
      {
         Int32 objRet = 0;
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[AddHolders]";
           
               objCmd.Parameters.Add(new SqlParameter("@Holder_Name", objRecord.Holder_Name));
               objCmd.Parameters.Add(new SqlParameter("@User_Name", objRecord.User_Name));
               objCmd.Parameters.Add(new SqlParameter("@Password", objRecord.Password));
               objCmd.Parameters.Add(new SqlParameter("@HolderDetailes", objRecord.HolderDetailes));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               object obj = objCmd.ExecuteScalar();
               if (obj != null)
                  objRet = Convert.ToInt32(obj);
            }
         }
         return objRet;
      }
      public void UpdateHolders(Holders objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[UpdateHolders]";
               objCmd.Parameters.Add(new SqlParameter("@Holder_Id", objRecord.Holder_Id));
               objCmd.Parameters.Add(new SqlParameter("@Holder_Name", objRecord.Holder_Name));
               objCmd.Parameters.Add(new SqlParameter("@User_Name", objRecord.User_Name));
               objCmd.Parameters.Add(new SqlParameter("@Password", objRecord.Password));
               objCmd.Parameters.Add(new SqlParameter("@HolderDetailes", objRecord.HolderDetailes));
               objCmd.Parameters.Add(new SqlParameter("@Isdelete", objRecord.Isdelete));
               objCmd.ExecuteNonQuery();
            }
         }
      }
      public void DeleteHolders(Holders objRecord)
      {
         ConnectionStringSettings objCSS = ConfigurationManager.ConnectionStrings["EventRegConnectionString"];
         using (SqlConnection objCnn = new SqlConnection(objCSS.ConnectionString))
         {
            objCnn.Open();
             using (SqlCommand objCmd = objCnn.CreateCommand())
            {
               objCmd.CommandType = System.Data.CommandType.StoredProcedure;
               objCmd.CommandText = "[DeleteHolders]";
               objCmd.Parameters.Add(new SqlParameter("@Holder_Id",objRecord. Holder_Id));
               objCmd.ExecuteNonQuery();
            }
         }
      }
   }
 