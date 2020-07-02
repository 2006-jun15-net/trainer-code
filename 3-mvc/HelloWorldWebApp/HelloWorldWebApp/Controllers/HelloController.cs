using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldWebApp.Controllers
{
    public class HelloController : Controller
    {
        // this class can contain action methods and non-action methods...
        public IActionResult Hello1()
        {
            var result = new ContentResult
            {
                StatusCode = 200, // default anyway
                ContentType = "text/html",
                Content = "<html>\n" +
                          "  <head></head>\n" +
                          "  <body>\n" +
                          "    Hello controller\n" +
                          "  </body>\n" +
                          "</html>\n"
            };
            return result;
        }

        // when the action method is called,
        // asp.net attempts to fill in the parameters from a variety of sources:
        //  - query string (at the end of the URL)
        //  - route parameters (in the path of the URL, and defined in the route)
        //  - request body
        public IActionResult Hello2(string who)
        {
            var result = new ContentResult
            {
                StatusCode = 200, // default anyway
                ContentType = "text/html",
                Content = "<html>\n" +
                          "  <head></head>\n" +
                          "  <body>\n" +
                         $"    Hello {who}\n" +
                          "  </body>\n" +
                          "</html>\n"
            };
            return result;
        }

        [NonAction] // by defualt any instance method in this class might get called to handle a request
                    // (might be an action method)
        public void HelperMethod()
        {

        }
    }
}
