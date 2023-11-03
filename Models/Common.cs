using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservices_app.Models
{
    public class Common
    {
        public int GenrateOTP()
        {
        
            Random random = new Random();
            int OTP = 0;        
            int tempval = random.Next(09999);
            OTP += tempval;     
            return OTP;
        }
    }
}