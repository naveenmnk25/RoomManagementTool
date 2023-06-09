﻿using Microsoft.AspNetCore.Mvc;
using RoomManagement.Models;
using RoomManagement.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RoomManagement.Controllers
{
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HappyHomeContext _context;

        public HomeController(ILogger<HomeController> logger, HappyHomeContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new IndexViewModel(_context).GetModel());
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Access");
        }

        public IActionResult Expance()
        {
            return View(new IndexViewModel(_context).GetModel());
        }

        private List<SelectListItem> Getsectionlist(int countryId = 1)
        {
            List<SelectListItem> MemberList = new List<SelectListItem>();
           
            var defItem = new SelectListItem()
            {
                Value = "1",
                Text = "March"
            };
            var defItem1 = new SelectListItem()
            {
                Value = "2",
                Text = "April"
            };

            MemberList.Insert(0, defItem);
            MemberList.Insert(1, defItem1);

            return MemberList;
        }

        public IActionResult FoodDetails(int Id)
        {
            ViewBag.sectionlist = Getsectionlist();   
            return View(new FoodDetailsViewModel(_context).GetModel(Id));
        }

        [HttpGet]
        public JsonResult getFooddata(int Id)
        {
            ViewBag.sectionlist = Getsectionlist();
            RedirectToAction("FoodDetails", new FoodDetailsViewModel(_context).GetModel(Id));
            return Json(new FoodDetailsViewModel(_context).GetModel(Id));
        }
        public IActionResult GetRent()
        {
            return View(new GetRentViewModel(_context).GetModel());
        }
        public IActionResult Advance()
        {
            return View(new AdvanceViewModel(_context).GetModel());
        }

        public IActionResult AmountDetail()
        {
            return View(new AmountDetailsViewModel(_context).GetModel());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Transaction/AddOrEdit 
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            return View(new Member());
            else
                return View(_context.Members.Find(id));
        }

        // GET: AddOrEditAmountDetail 
        public IActionResult AddOrEditAmountDetail(int id = 0)
        {
            if (id == 0)
                return View(new AmountDetail());
            else
                return View(_context.AmountDetails.Find(id));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foodDetail"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditAmountDetail([Bind("Id,RoomRentAmount,FootAmountAmount,DetectedAmt")] AmountDetail amountDetail)
        {
            if (ModelState.IsValid)
            {
                if (amountDetail.Id == 0)
                {
                    _context.Add(amountDetail);
                }
                else
                    _context.Update(amountDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AmountDetail));
            }
            return View(amountDetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Memberid"></param>
        /// <returns></returns>
        public IActionResult AddOrEditFoodDetails(int Id = 0, int Mid = 0, int Sid = 0, string name = "" ,int amountToGive=0)
        {
            ViewData["name"] = name;
            if (Id == 0)
                return View(new FoodDetail() { MemberId = Mid ,AmountToGive= amountToGive ,SectionId=Sid});
            else
                return View(_context.FoodDetails.Find(Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditFoodDetails([Bind("Id,MemberId,AmountToGive,AmountRecived,SectionId")] FoodDetail foodDetail)
        {
            if (ModelState.IsValid)
            {
                if (foodDetail.Id == 0)
                {
                    _context.Add(foodDetail);
                }
                else
                    _context.Update(foodDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(FoodDetails));
            }
            return View(foodDetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Mid"></param>
        /// <param name="name"></param>
        /// <param name="amountToGive"></param>
        /// <returns></returns>
        public IActionResult AddOrEditFoodAdvance(int Id = 0, int Mid = 0, string name = "")
        {
            ViewData["name"] = name;
            if (Id == 0)
                return View(new AdvanceCal() { MemberId = Mid });
            else
                return View(_context.AdvanceCals.Find(Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="advanceCal"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditFoodAdvance([Bind("Id,MemberId,AmountGiven,AmountReFund,RemAmtFromAd,DetectedAmt")] AdvanceCal advanceCal)
        {
            if (ModelState.IsValid)
            {
                if (advanceCal.Id == 0)
                {
                    _context.Add(advanceCal);
                }
                else
                    _context.Update(advanceCal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Advance));
            }
            return View(advanceCal);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit( Member member)
        {
            if (member.Id == 0)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _context.Update(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        private List<SelectListItem> GetMemberList(int countryId = 1)
        {
            List<SelectListItem> MemberList = _context.Members.Where(x => x.IsFood == true).Select(n =>
               new SelectListItem
               {
                   Value = n.Id.ToString(),
                   Text = n.Name
               }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Name----"
            };

            MemberList.Insert(0, defItem);

            return MemberList;
        }

        // GET: Transaction/AddOrEdit
        public IActionResult AddOrEditExpance(int id = 0)
        {
           

            ViewBag.MemberId = GetMemberList();
            if (id == 0)
                return View(new AdvViewModel(_context).GetModel(0));
            else
                return View(new AdvViewModel(_context).GetModel(id));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditExpance( Expance expance) //[Bind("Id,Item,Price,Date")]
        {
            if (ModelState.IsValid)
            {
                if (expance.Id == 0)
                {
                    _context.Add(expance);
                }
                else
                    _context.Update(expance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Expance));
            }
            return View(expance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expance"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetAmt() 
        {
            var productTreeString = _context.ExecuteResult.FromSqlRaw("Execute dbo.ResetAmt");
            return RedirectToAction(nameof(Expance));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("DeleteExpance")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExpanceConfirmed(int id)
        {
            var expance = await _context.Expances.FindAsync(id);
            _context.Expances.Remove(expance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Expance));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("DeleteAmountDetail")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAmountDetailConfirmed(int id)
        {
            var amountDetail = await _context.AmountDetails.FindAsync(id);
            _context.AmountDetails.Remove(amountDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AmountDetail));
        }
    }
}
