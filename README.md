# C# encapsuled and decopled Bundles
This project results a assembly that encapsulates CSSs and JavaScripts, useful at large farms with hundred of developers that needs ensure to maintain the defined UI Patterns.
It's can be used like a decople Api that contains assembly isolation where process the JavaScript and CSS minification. The response from HTTP request is very simple!

![From: https://github.com/antonio-leonardo/CustomResourceBundles](https://github.com/antonio-leonardo/CustomResourceBundles/blob/master/bundle_result.png)

It's can be consumed by any Asp.Net Project (Asp.Net, Asp.Net Web Forms, Asp.Net MVC), adding this line of code bellow:
```cs
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

//Namespace example of bundle encapsulation
using Custom.Bundles.Minification.Core;

namespace WebApplicationTestCustomBundle
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ///The default (and commented) Bundle at Asp.NET project application created by Visual Studio:
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            ///Here is the Custom (assembled and encapsulated) Bundle:
            CustomBundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
```

Add two assertions to render CSS and execute JS Scripts at _Layouts.cstml, and that's all:
![From: https://github.com/antonio-leonardo/CustomResourceBundles](https://github.com/antonio-leonardo/CustomResourceBundles/blob/master/_layouts_cshtml.PNG)

## Dependecies
To compile and consume this Assembly or like classes inner in your Visual Studio project, you'll need to install [System.Web.Optimization](https://docs.microsoft.com/pt-br/previous-versions/aspnet/hh195125(v=vs.110)) library, that can be installed by [nuget](https://www.nuget.org/packages/microsoft.aspnet.web.optimization) reference or execute command on Nuget Package Console (Install-Package Microsoft.AspNet.Web.Optimization).

----------------------
## License

[View MIT license](https://github.com/antonio-leonardo/CustomResourceBundles/blob/master/LICENSE)
