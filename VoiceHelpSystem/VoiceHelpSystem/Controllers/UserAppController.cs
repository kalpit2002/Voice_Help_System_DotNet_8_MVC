using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VoiceHelpSystem.Data;
using VoiceHelpSystem.Models;

namespace VoiceHelpSystem.Controllers
{
    public class UserAppController : Controller
    {
        private readonly AppDbContext _db;
        public UserAppController(AppDbContext db) {  _db = db; }
        public IActionResult Index()
        {
            List<UserFamilyInfo> entries = _db.UserFamilyInfos.ToList();
            return View(entries);
        }
        public IActionResult Userinfo()
        {
            List<UserFamilyInfo> entries = _db.UserFamilyInfos.ToList();
            return View(entries);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserFamilyInfo userFamilyInfo)
        {
            if (ModelState.IsValid)
            {
                // Save to the database (context example)
                _db.UserFamilyInfos.Add(userFamilyInfo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userFamilyInfo);
        }

        [HttpGet]
        public IActionResult Edit(int? id) {

            if (id == null || id == 0)
            {
                return NotFound();
                
            }
            UserFamilyInfo? userFamilyInfo = _db.UserFamilyInfos.Find(id);
            return View(userFamilyInfo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserFamilyInfo userFamilyInfo)
        {
            if (ModelState.IsValid)
            {
                // Save to the database (context example)
                _db.UserFamilyInfos.Update(userFamilyInfo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userFamilyInfo);
        }

    }
}
