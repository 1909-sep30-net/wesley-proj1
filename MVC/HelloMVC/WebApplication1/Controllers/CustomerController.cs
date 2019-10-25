using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
 
    /// <summary>
    /// Just Try to Add some comment here
    /// pre-cheers to ouu projuct 2, boyz XD
    /// </summary>
    public class CustomerController : Controller
    {
        //this is an action method
        //each action method is going to correspond to one "URL" for website
        //  (if there are parameters in that URL, we can handle many values in one action method)
        public IActionResult Index()
        {
            //every action method's job is to react to fetch data/ push data/ whatever
            //"action" is represented by this URL that the user is sending a request to

            //then return some "result"
            //  a result is something that ASP.NET Core can "render" into an HTTP response
            //  within the MVC world, our results are either ViewResult or some kind of RedirectResult

            //views are the kind of result that renders into HTML
            //"View()" is a helper method from base class that looks for
            //view matching the name of this current action method ("Index"),
            //  for this controller ("Customer")

            var customers = new List<Customer>
            {
                new Customer{Id = 1, Name = "Nick Enscala"},
                new Customer{Id = 1, Name = "Fred Belotte"}
            };
            return View(customers); //this is how you give a view its model
        }

        /*[NonAction] //tells MVC this is not an action method
        private void DynamicTests()
        {
            dynamic dynamicValue;
            dynamicValue.Name = "abc";
        }*/
    }
}