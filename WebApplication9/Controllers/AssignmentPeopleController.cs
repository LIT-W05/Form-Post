using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class AssignmentPeopleController : Controller
    {
        public ActionResult ShowAll()
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeopleConStr);

            return View(mgr.GetAll());
        }

        public ActionResult ShowAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person person, string foobar)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeopleConStr);
            mgr.AddPerson(person);
            return Redirect("/assignmentpeople/showall");
        }

        public ActionResult ShowEdit(int id)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeopleConStr);
            Person person = mgr.GetPerson(id);
            if (person == null)
            {
                return Redirect("/assignmentpeople/showall");
            }

            return View(person);
        }

        [HttpPost]
        public ActionResult Update(Person person)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeopleConStr);
            mgr.Update(person);
            return Redirect("/assignmentpeople/showall");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PeopleManager mgr = new PeopleManager(Properties.Settings.Default.PeopleConStr);
            mgr.Delete(id);
            return Redirect("/assignmentpeople/showall");
        }
    }
}