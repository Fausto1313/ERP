using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;
     

        Response.AppendHeader("Cache-Control", "no-store");
        Response.AppendHeader("Pragma", "no-cache");
        if (Session.IsNewSession)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/Account/Login");
        }
      
    }
}