using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using IOTComer;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                //RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = new UserManager();
                Permisos permiso = new Permisos();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                if (user != null)
                {
                    if (permiso.userHabilitado(UserName.Text))
                    {
                        IdentityHelper.SignIn(manager, user, false);
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    }
                    else {
                        FailureText.Text = "Usuario deshabilitado de forma temporal.";
                        ErrorMessage.Visible = true;
                    }
                }
                else
                {
                    FailureText.Text = "Nombre de usuario o contraseña inválidos.";
                    ErrorMessage.Visible = true;
                }
            }
        }
}