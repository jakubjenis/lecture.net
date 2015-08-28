using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using Smart.Models;

namespace Smart.Controllers
{
    public class CustomerController : Controller
    {
        readonly Contract _contract = new Contract
            {
                Amount = 1200.53m,
                Buyer = new Person
                {
                    Address = new Address
                    {
                        City = "Praha",
                        Street = "Ve smeckach 15",
                        Zip = "11000"
                    },
                    BirthDate = new DateTime(1985, 5, 8),
                    Employment = new EmploymentInfo
                    {
                        Employer = "CN Group, s.r.o",
                        Income = 4500,
                        Type = EmploymentType.Regular
                    },
                    Name = "John",
                    Surname = "Smith",
                    Ssn = "14530648/5435"
                },
                Seller = new Person
                {
                    Address = new Address
                    {
                        City = "Praha",
                        Street = "Vaclavske namesti",
                        Zip = "11000"
                    },
                    BirthDate = new DateTime(1985, 5, 8),
                    Employment = new EmploymentInfo
                    {
                        Employer = "CN Group, s.r.o",
                        Income = 10200,
                        Type = EmploymentType.Regular
                    },
                    Name = "Peter",
                    Surname = "Wayne",
                    Ssn = "65465432/5535"
                },
                DateCreated = DateTime.Now
            };
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            SetLanguage("en");
            return View(_contract);
        }

        //
        // GET: /Customer/Create
        public ActionResult Edit()
        {
            SetLanguage("en");
            return View(_contract);
        }

        private static void SetLanguage(string langCode)
        {
            var ci = new CultureInfo(langCode);
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }


        // POST: /Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            SetLanguage("en");
            if (TryUpdateModel(_contract, form))
            {
                return View("Index", _contract);
            }
            return View("Edit");
        }

        // POST: /Customer/Create
//        [HttpPost]
//        public ActionResult Create(Contract contract)
//        {
//            SetLanguage("en");
//            if (ModelState.IsValid)
//            {
//                return View("Index", contract);
//            }
//            return View("Edit");
//        }
    }
}
