using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Webservices_app.Models;
using Dapper;
using System.Data.SqlClient;
namespace Webservices_app.Models
{
    public class LogicClass
    {
        Connectiondb Condbo = new Connectiondb();
        public Response RegisterUser(UserEntry req)
        {
            Response obj = new Response();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Action", 1);
            parameters.Add("@Userid", req.UserID);
            parameters.Add("@Name", req.Password);
            parameters.Add("@Password", req.Name);
            parameters.Add("@Mobileno", req.Mobile);
            obj.responses = Condbo.ReturnListTypeData<Response>("Proc_UserRegistration", parameters);
            if (obj != null)
                return obj;
            else
                return null;
        }
        public DataSet Register(UserEntry req)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Action",1),
                new SqlParameter("@Userid",req.UserID),
                new SqlParameter("@Name",req.Name),
                new SqlParameter("@Password",req.Password),
                new SqlParameter("@Mobileno",req.Mobile),
           };
            DataSet ds = Condbo.ExcuteQuery("Proc_UserRegistration", Param);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            else
                return null;
        }
        public DataTable CheckLogin(userlogin req)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                  new SqlParameter("@Mobileno",req.MobileNo),
            };
            DataTable dt = Condbo.ExcutedatatbaseQuery("sp_CheckUserlogin_Api", parameters);
            return dt;
        }
    }

}