using MVCData.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MVCData.Controllers
{
    public class PeopleController : Controller     
    {
        // GET: People
        static IList<People> student = new List<People>  //Mosh Hamadani Method , 
                                                         //IList = more control over a collection: Add, Delete, etc
{
    new People()  {PersonId=1, Name=" Waseem  ", City="Stockholm ", Telephone=343444434 },       //  new List object
    new People() {PersonId=2, Name="Mylah", City="Damascus", Telephone=10234567 },
    new People() {PersonId=3, Name="Andreas", City="Jonkoping", Telephone=3343 },
    new People() {PersonId=4, Name="Maher", City="Nassjo", Telephone=322321 },
    new People() {PersonId=5, Name="Wassim ", City="Malmo", Telephone=10234572 },
};

        [HttpGet]       
        public ActionResult IndexPeople()
        {
            return View(student.ToList());      // to show the above List of information 
        }

        [HttpPost]      //submits users entry
        public ActionResult IndexPeople(string searchBy, string searchByLetter)
        {
            if (searchBy == "city")
                return View(student.Where(n => n.City.ToLower().StartsWith(searchByLetter.ToLower()) || searchByLetter == null).ToList());      
            else
                return View(student.Where(n => n.Name.ToLower().StartsWith(searchByLetter.ToLower()) || searchByLetter == null).ToList());
               
        }
               
        [HttpGet]
        public ActionResult Create()        //add name, city and telephone # , done together with Mylah . 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)  
        {
            People people = new People();       // Creating an object for People Class
            people.PersonId = Convert.ToInt32(formCollection["PersonId"]);
            people.Name = formCollection["Name"];
            people.City = formCollection["City"];
            people.Telephone = Convert.ToInt32(formCollection["Telephone"]);

            student.Add(people);        //adding new person (name, city and telephone #
            return RedirectToAction("IndexPeople"); 
        }

        [HttpGet]
        public ActionResult Delete(int id)     
        {
            try
            {
                People person = student.Single(p => p.PersonId == id);     
                return View(person);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)  
        {
            People ppl = student.Single(p => p.PersonId == id);        //with Lambda expression (copied online and I need a time to understand it better ) 
            ppl.PersonId = Convert.ToInt32(collection["PersonId"]);
            ppl.Name = collection["Name"];
            ppl.City = collection["City"];
            ppl.Telephone = Convert.ToInt32(collection["Telephone"]);

            student.Remove(ppl);                                       //deleting Id/row
            return RedirectToAction("IndexPeople");                    //directing back to main (People) page
        }

        public ActionResult IndexPeoplePartialView()
        {
            return View(student);
        }
    }
}



