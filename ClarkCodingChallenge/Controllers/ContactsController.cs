using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace ClarkCodingChallenge.Controllers {
    public class ContactsController : Controller {

        private readonly IProfilesRepository _profileRepository;
        public ContactsController(IProfilesRepository profilesRepository) {
            _profileRepository = profilesRepository ?? throw new ArgumentNullException(nameof(profilesRepository));

            }
        public ViewResult Confirmation() {
            return View();
            }
        public IActionResult Index() {
            return View();
            }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }


        public ActionResult SubmitProfile(string firstName, string lastName, string email) {
            var result = _profileRepository.AddProfile(firstName, lastName, email);
            return Json(new { success = true, reponseText = nameof(result) });

            }
        }
    }
