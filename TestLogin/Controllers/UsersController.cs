using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TestLogin.Models;

namespace TestLogin.Controllers
{
  public class UsersController : Controller
  {
    private readonly UserContext _context;

    public UsersController(UserContext context)
    {
      _context = context;
    }
    public async Task<IActionResult> Index()
    {
      //await _context.User_list.ToListAsync()
      //User userTest = new User();
      //userTest.Password = (new PasswordHandler("Sasha280920")).GetHashedPassword();
      //userTest
      return View();
    }


    // GET: Users
    public async Task<IActionResult> Login()
    {
      //await _context.User_list.ToListAsync()
      //User userTest = new User();
      //userTest.Password = (new PasswordHandler("Sasha280920")).GetHashedPassword();
      //userTest
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login([FromBody]User userData)
    {
      //
      var user = from u in _context.User_list where u.UserName == userData.UserName select u;
      if (user.Count() == 0)
      {
        //return Content(Json(userData).ToString());
        return ErrorLogin();
      }
      PasswordHandler passwordhandler = new PasswordHandler(userData.Password, user.ToList()[0].Password);
      if (passwordhandler.ValidatePassword())
      {
        //return RedirectToAction("Create");
        //Create();
        return Content("ok");
      }
      else
      {
        //return Content("not ok");
        return ErrorLogin();
      }
      //return View(await _context.User_list.ToListAsync());
    }
    public PartialViewResult ErrorLogin()
    {

      //await _context.User_list.ToListAsync()
      return PartialView("_Error");


    }
    public async Task<IActionResult> ChooseDoctor()
    {
      var _e = _context.Employees.Include(x => x.Msp).ToListAsync();
      return View(await _e);
    }
    [HttpPost]
    public async Task<IActionResult> CreateDeclaration([FromForm]int EmployeeId)
    {
      //[FromBody] Employees employee

      //    [FromBody]
      Employees employee = new Employees();
      employee.EmployeeId = EmployeeId;
      //    employee
      return View(employee);
    }
    [HttpPost]
    public async Task<IActionResult> CreateDeclaration1([FromBody]CreateDeclarationViewModel declarationData)
    {
      if (_context.User_list.FirstOrDefault(x => x.UserName == declarationData.Declaration.Patient.Phone) != null)
      {
        return StatusCode(200, Json("such user already exists"));
      }
      Employees employee = _context.Employees.Include(i => i.Msp).Single(x => x.EmployeeId == declarationData.Declaration.Employee.EmployeeId);
      User newUser = new User();
      newUser.UserName = declarationData.Declaration.Patient.Phone;
      newUser.UserGroup = 1;
      PasswordHandler passwordhandler = new PasswordHandler(declarationData.Password);
      newUser.Password = passwordhandler.GetHashedPassword();
      PatientList newPatient = new PatientList();
      newPatient = declarationData.Declaration.Patient;
      Declarations newDeclaration = new Declarations();
      newDeclaration.CreateDate = declarationData.Declaration.CreateDate.Date;
      newDeclaration.Status = "active";
      newDeclaration.Employee = employee;
      newDeclaration.Msp = employee.Msp;
      newPatient.Declarations = newDeclaration;
      newUser.PatientList = newPatient;
      _context.User_list.Add(newUser);
      _context.SaveChanges();
      return StatusCode(200, Json("ok"));
    }
    //// GET: Users/Details/5
    //public async Task<IActionResult> Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var user = await _context.User_list
    //        .FirstOrDefaultAsync(m => m.UserID == id);
    //    if (user == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(user);
    //}

    //// GET: Users/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Users/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("UserID,UserName,Password,UserGroup")] User user)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(user);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(user);
    //    }

    //    // GET: Users/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var user = await _context.User_list.FindAsync(id);
    //        if (user == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(user);
    //    }

    //    // POST: Users/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("UserID,UserName,Password,UserGroup")] User user)
    //    {
    //        if (id != user.UserID)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(user);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!UserExists(user.UserID))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(user);
    //    }

    //    // GET: Users/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var user = await _context.User_list
    //            .FirstOrDefaultAsync(m => m.UserID == id);
    //        if (user == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(user);
    //    }

    //    // POST: Users/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var user = await _context.User_list.FindAsync(id);
    //        _context.User_list.Remove(user);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool UserExists(int id)
    //    {
    //        return _context.User_list.Any(e => e.UserID == id);
    //    }
    //}
  }
}
