using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Webservices_app.Models;
using System.Web;
using System.IO;

namespace Webservices_app.Controllers
{
    public class WebservicesController : ApiController
    {
        LogicClass GetLogic = new LogicClass();

        [Route("api/Webservices/GetOTP")]

        [HttpPost]    
        public IHttpActionResult GetOTP(userlogin req)
        {
            string response = null;
            Common common = new Common();
            try
            {   
                if(req.MobileNo!="" && req.MobileNo.Length == 10)
                {
                    DataTable dt = GetLogic.CheckLogin(req);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["response"].ToString() == "success")
                        {
                            int OTP = common.GenrateOTP();
                            return Ok(new { status = true, message = "success", response = OTP });
                        }
                        else
                            return Ok(new { status = false, message = "faild", response = "User Not Registerd !!" });

                    }
                    else
                        return Ok(new { status = false, message = "faild", response = response });
                }
                else
                {
                    return Ok(new { status = false, message = "Invalid Mobileno !!", response = response });
                }
                
                   
            }
            catch (Exception ex)
            {

                return Ok(new { status = false, ex.Message, response = response });
            }
        }

        [HttpPost]   
        public IHttpActionResult UserEntry(UserEntry req)
        {


            string Msessage = "";

            DataSet ds = GetLogic.Register(req);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Code"].ToString() == "1")
                {
                    Msessage = ds.Tables[0].Rows[0]["Msg"].ToString();
                    return Ok(new { status = true, Message = "success", Response = Msessage });
                }

                else
                {
                    Msessage = ds.Tables[0].Rows[0]["Msg"].ToString();
                    return Ok(new { status = false, Message = "faild", Response = Msessage });
                }
            }
            else
            {
                return Ok(new { status = true, Message = "success", Response = Msessage });
            }

        }
    }
}
