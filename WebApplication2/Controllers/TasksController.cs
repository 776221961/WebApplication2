using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TasksController : Controller
    {
        private jxcEntities1 db = new jxcEntities1();

        // GET: Tasks
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Task.ToListAsync());
        //}

        public ActionResult Index(int pageindex = 1,int pagesize=20)
        {
            ViewBag.pageindex = pageindex;
            ViewBag.pagesize = pagesize;
            ViewBag.Model = db.Task.OrderBy(t => t.TaskID)
                                 .Skip(pagesize * (pageindex - 1))
                                 .Take(pagesize).AsEnumerable();
            return View(db.Users.ToList());
        }

        // GET: Tasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Task task = await db.Task.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TaskID,TaskName,StationID,OrderID,ItemID,EmployeeID,planDate,OutCount,PlanCount,EndCount,DSL,ZSL,XSL,SZ,SZ1,CustomerID,ProjectName,ProjectCmpy,ShipToAdd1,ShipToContact,RecipeNo,ProjectPart,WorkMethod,ShipVia,CementID,Memo1,Memo2,Distance,Ustate,SZ2,CustomerName,TaskCodeERP,prjno,lshao,DSLst,ZSLst,XSLst,SZst,SZ1st,intensityLevelt,tldt")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                db.Task.Add(task);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Task task = await db.Task.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TaskID,TaskName,StationID,OrderID,ItemID,EmployeeID,planDate,OutCount,PlanCount,EndCount,DSL,ZSL,XSL,SZ,SZ1,CustomerID,ProjectName,ProjectCmpy,ShipToAdd1,ShipToContact,RecipeNo,ProjectPart,WorkMethod,ShipVia,CementID,Memo1,Memo2,Distance,Ustate,SZ2,CustomerName,TaskCodeERP,prjno,lshao,DSLst,ZSLst,XSLst,SZst,SZ1st,intensityLevelt,tldt")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Task task = await db.Task.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Models.Task task = await db.Task.FindAsync(id);
            db.Task.Remove(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
