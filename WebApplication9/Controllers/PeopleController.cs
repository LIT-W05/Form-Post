using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeopleConStr);
            PeopleViewModel vm = new PeopleViewModel
            {
                Count = mgr.GetPeopleCount()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeopleConStr);
            mgr.AddPerson(person);
            return Redirect("/people/index");
        }
    }
}

//create a page that has displays a table of people (or whatever else interests you)
//on top of that page, have a link that says "Add Person". When that link is clicked
//the user should be taken to a page that has a form with textboxes for first name
//last name and age. When that form is submitted, the person should get added to the 
//database, and the user should get taken back to the home page (the list of people)
//Good luck!