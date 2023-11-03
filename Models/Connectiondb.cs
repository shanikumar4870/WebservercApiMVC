using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace Webservices_app.Models
{
    public class Connectiondb
    {
       

         SqlConnection   Constr =  new SqlConnection  (ConfigurationManager.ConnectionStrings["constring"].ToString());
        
        public List<T> ReturnListTypeData<T>(string procname, DynamicParameters parameters = null)  
        {
            Connectiondb obj = new Connectiondb();
            using (SqlConnection con = new SqlConnection(Constr.ConnectionString))
            {
                con.Open();
                return con.Query<T>(procname, parameters, commandType: CommandType.StoredProcedure).ToList();

            }
        }

        public  DataSet ExcuteQuery(string Procname ,SqlParameter[] Param)
        {
            try
            {
                SqlConnection con = new SqlConnection(Constr.ConnectionString);
                SqlCommand cmd = new SqlCommand(Procname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                 foreach(SqlParameter P in Param)
                {
                    cmd.Parameters.Add(P);
                }
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlData.Fill(ds);
                return ds;
           
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public DataTable ExcutedatatbaseQuery(string Procname, SqlParameter[] Param)
        {
            try
            {
                SqlConnection con = new SqlConnection(Constr.ConnectionString);
                SqlCommand cmd = new SqlCommand(Procname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;            
                foreach (SqlParameter P in Param)   
                {
                    cmd.Parameters.Add(P);
                }
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                sqlData.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
   
   
     


}