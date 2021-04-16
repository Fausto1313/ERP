<%@ Application Language="C#" %>
<%@ Import Namespace="IOTComer" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    void Session_Start(object sender, EventArgs e) {
        //Response.Redirect("/Account/Login.aspx");
        Session["user2"] = "true";
    }

    void Session_End(object sender, EventArgs e)
    {
        Session.Remove("user2");
        //Response.Redirect("/Account/Login.aspx");
    }

</script>
