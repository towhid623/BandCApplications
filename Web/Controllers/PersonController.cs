using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class PersonController : Controller
    {
        private BandCApplicationsEntities1 db = new BandCApplicationsEntities1();
        // GET: Person
        public ActionResult Applied()
        {
            ViewBag.BoardCommissionList = db.M_BoardsandCommissions.Select(s => new VmSelectList
            {
                Id = s.BoardCommissionKey,
                Name = s.Board_or_Commission_Name
            });
            return View();
        }

        public ActionResult AjaxAppliedPersonList(int? boardCommission)
        {
            var persons = db.People;
            var boardCommissions = db.M_BoardsandCommissions;
            var allValues = db.Person_Applications.AsQueryable();
            if (boardCommission > 0)
            {
                allValues = allValues.Where(w => w.BoardCommissionKey == boardCommission);
            }
            var result = allValues.AsEnumerable().Where(w => w.Appointed != true).Select(s => new
            {
                Name = persons.Find(s.PersonKey) != null ? persons.Find(s.PersonKey).FirstName + " " + persons.Find(s.PersonKey).MiddleName + " " + persons.Find(s.PersonKey).LastName : "",
                AppliedDate = s.ApplicationDate.ToString("dd MMM yyyy"),
                BoardSeat = boardCommissions.Find(s.BoardCommissionKey) != null ? boardCommissions.Find(s.BoardCommissionKey).Board_or_Commission_Name : "",
                Id = s.PersonKey,
                BoardCommissionId = s.BoardCommissionKey
            });
            return Json(new
            {
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Appointed()
        {
            ViewBag.BoardCommissionList = db.M_BoardsandCommissions.Select(s => new VmSelectList
            {
                Id = s.BoardCommissionKey,
                Name = s.Board_or_Commission_Name
            });
            return View();
        }

        public ActionResult AjaxAppointedPersonList(int? boardCommission)
        {
            var persons = db.People;
            var boardCommissions = db.M_BoardsandCommissions;
            var allValues = db.Person_Applications.AsQueryable();
            if (boardCommission > 0)
            {
                allValues = allValues.Where(w => w.BoardCommissionKey == boardCommission);
            }
            var result = allValues.AsEnumerable().Where(w => w.Appointed == true).Select(s => new
            {
                Name = persons.Find(s.PersonKey) != null ? persons.Find(s.PersonKey).FirstName + " " + persons.Find(s.PersonKey).MiddleName + " " + persons.Find(s.PersonKey).LastName : "",
                AppliedDate = s.ApplicationDate.ToString("dd MMM yyyy"),
                BoardSeat = boardCommissions.Find(s.BoardCommissionKey) != null ? boardCommissions.Find(s.BoardCommissionKey).Board_or_Commission_Name : "",
                TermExpirationDate = boardCommissions.Find(s.BoardCommissionKey) != null ? boardCommissions.Find(s.BoardCommissionKey).TermLength : 0,
                Id = s.PersonKey,
                BoardCommissionId = s.BoardCommissionKey
            });
            return Json(new
            {
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ContactInfo(int id)
        {
            VmContactInfo model = new VmContactInfo();
            var data = db.People.Find(id);
            if (data != null)
            {
                model.Address = "Street: " + data.StreetAddress ?? "N/A" + " Ward: " + data.Ward ?? "N/A" + " City: " + data.City ?? "N/A";
                model.Email = data.EmailAddress;
                model.Name = data.FirstName + " " + data.MiddleName + " " + data.LastName;
                model.PhoneNumber = data.CellPhone;
            }
            return View(model);
        }

        public ActionResult AppQuestions(int id)
        {
            VmQuesAns model = new VmQuesAns();
            var data = db.M_BoardsandCommissions.Find(id);
            if (data != null)
            {
                

                XDocument doc = XDocument.Parse(data.ApplicationXML);
                model.ApplicationXml = doc.ToString();
            }
            return View(model);
        }
    }
}