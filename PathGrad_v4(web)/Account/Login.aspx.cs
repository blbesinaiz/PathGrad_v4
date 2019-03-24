using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PathGrad_v4_web_.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Displays register link
            RegisterHyperLink.NavigateUrl = "Register";

            //Displays forgot password link
            ForgotPasswordHyperLink.NavigateUrl = "Reset";
        }

        protected void LogIn(object sender, EventArgs e)
        {

        }
    }
}