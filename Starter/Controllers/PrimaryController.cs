using System.Collections.Generic;
using System.Linq;
using Starter.DAO;
using Starter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Starter.Controllers
{
    public class Primary : Controller
    {
        private readonly StarterDbContext _context;
        public Primary(StarterDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

public IActionResult ViewAll()
        {
            return View(_context);
        }
        // view clubMember by ID
        public IActionResult ViewOne(int clubMemberID)
        {
            ClubMemberModel foundclubMember = _context.clubMembers.FirstOrDefault(clubMember => clubMember.id == clubMemberID);
            if (foundclubMember != null)
            {
                return View(foundclubMember);
            }
            else
            {
                ViewData["error"] = "No clubMember found";
                return View("Error");
            }
        }

        // Display a new clubMember form
        public IActionResult AddForm()
        {
            return View();
        }

        // add clubMember to db
        [HttpPost]
        public IActionResult AddclubMember(ClubMemberModel newclubMember)
        {
            if (ModelState.IsValid)
            {
                _context.clubMembers.Add(newclubMember);
                _context.SaveChanges();
                return RedirectToAction("ViewAll", "Primary");
            }
            else
            {
                ViewData["errors"] = "Please correct the following errors";
                return View("AddForm", newclubMember);
            }
        }

        // Display a edit clubMember form
        public IActionResult EditForm(int id)
        {
            // look up clubMember to populate form
            ClubMemberModel foundclubMember = _context.clubMembers.FirstOrDefault(clubMember => clubMember.id == id);
            if (foundclubMember != null)
            {
                return View(foundclubMember);
            }
            else
            {
                ViewData["error"] = ($"No clubMember found for ID {id}");
                return View("Error");
            }
        }

        // update clubMember in db by ID
        [HttpPost]
        public IActionResult UpdateClubMember(ClubMemberModel updatedclubMember)
        {
            ClubMemberModel foundclubMember = _context.clubMembers.FirstOrDefault(clubMember => clubMember.id == updatedclubMember.id);
            if (foundclubMember != null)
            {
                if (ModelState.IsValid)
                {
                    foundclubMember.nickName = updatedclubMember.nickName;
                    foundclubMember.firstName = updatedclubMember.firstName;
                    foundclubMember.lastName = updatedclubMember.lastName;
                    foundclubMember.clubRole = updatedclubMember.clubRole;
                    foundclubMember.email = updatedclubMember.email;
                    foundclubMember.phone = updatedclubMember.phone;
                    _context.SaveChanges();
                    return RedirectToAction("ViewAll", "Primary");
                }
                else
                {
                    ViewData["errors"] = "Please correct the following errors";
                    return View("EditForm", foundclubMember);
                }
            }
            else // no match found
            {
                ViewData["error"] = ($"No clubMember found for ID {updatedclubMember.id}");
                return View("Error");
            }
        }

        // Add clubMember

        // delete clubMember in db by ID
        [HttpGet]
        public IActionResult DeleteclubMember(int id)
        {
            ClubMemberModel foundclubMember = _context.clubMembers.FirstOrDefault(clubMember => clubMember.id == id);

            if (foundclubMember != null)
            {
                _context.Remove(foundclubMember);
                _context.SaveChanges();
                return RedirectToAction("ViewAll", "Primary");
            }
            else
            {
                ViewData["error"] = ($"No clubMember found for ID {id}");
                return View("Error");
            }
        }


        // method to capture model state validation errors
        public static List<string> GetErrorListFromModelState(ModelStateDictionary modelState)
        {
            IEnumerable<string> query = from state in modelState.Values
                                        from error in state.Errors
                                        select error.ErrorMessage;

            List<string> errorList = query.ToList();
            return errorList;
        }

    }
}