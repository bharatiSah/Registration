using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using registration.Entities;
using registration.Models;
using registration.CommonOperation;
using PagedList;

namespace registration.Controllers
{
    public class UserdatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        Common common = new Common();

        // GET: Userdatas
        public async Task<ActionResult> Index(string Sorting_Order, int? page)
        {
            int pageSize = 2;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "FName" : "";
            ViewBag.LastName = Sorting_Order == "LastName" ? "LNameD" : "LastName";
            ViewBag.Email = Sorting_Order == "Email" ? "EmailD" : "Email";
            var users = await db.Userdatas.ToListAsync();
            IPagedList <Userdata> userData = null;
            switch (Sorting_Order)
            {

                case "FName":
                    users = users.OrderByDescending(x => x.firstName).ToList();
                    break;
                case "LastName":
                    users = users.OrderBy(x => x.lastName).ToList();
                    break;
                case "LNameD":
                    users = users.OrderByDescending(x => x.lastName).ToList();
                    break;
                case "Email":
                    users = users.OrderBy(x => x.email).ToList();
                    break;
                case "EmailD":
                    users = users.OrderByDescending(x => x.email).ToList();
                    break;
                default:
                    users = users.OrderBy(x => x.firstName).ToList();
                    break;
            }
            userData = users.ToPagedList(pageIndex, pageSize);
            return View(userData);
        }

        // GET: Userdatas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdata userdata = await db.Userdatas.FindAsync(id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        [HttpGet]
        // GET: Userdatas/Create
        public ActionResult Create()
        {
            Userdata user = new Userdata();
            user.cityList = new SelectList( common.GetCityList(), "Id" , "city");
            return View(user);
        }

        // POST: Userdatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Userdata userdata )
        {
            HttpPostedFileBase file = Request.Files["file"];
            userdata.Image = common.ConvertToBytes(file);
            int n = Convert.ToInt32(userdata.city);
            userdata.city = common.GetCityList().Where(x => x.Id == n).FirstOrDefault().city;
            userdata.cityList = new SelectList(common.GetCityList(), "Id", "city");
            if (ModelState.IsValid)
            {
                db.Userdatas.Add(userdata);
                await db.SaveChangesAsync();
                return RedirectToAction("Index" , "Home");
            }

            return View(userdata);
        }

        // GET: Userdatas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdata userdata = await db.Userdatas.FindAsync(id);
            userdata.cityList = new SelectList(common.GetCityList(), "Id", "city");
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        // POST: Userdatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Userdata userdata)
        {
            HttpPostedFileBase file = Request.Files["file"];
            userdata.Image = common.ConvertToBytes(file);
            int n = Convert.ToInt32(userdata.city);
            userdata.city = common.GetCityList().Where(x => x.Id == n).FirstOrDefault().city;
            userdata.cityList = new SelectList(common.GetCityList(), "Id", "city");

            if (ModelState.IsValid)
            {
                db.Entry(userdata).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userdata);
        }

        // GET: Userdatas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userdata userdata = await db.Userdatas.FindAsync(id);
            
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        // POST: Userdatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Userdata userdata = await db.Userdatas.FindAsync(id);
            db.Userdatas.Remove(userdata);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> GetImage(int id)
        {
            var item = await db.Userdatas.FindAsync(id);

            byte[] photoBack = item.Image;

            return File(photoBack, "image/png");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
