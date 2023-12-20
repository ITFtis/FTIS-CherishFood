<%@ Application Language="C#" %>
<%@ Import Namespace="RSLRegisterWeb" %>
<%@ Import Namespace="System.Web.Http" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Swashbuckle.Application" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    } 

</script>
