using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private BowlingDbContext _context { get; set; }

        //Constructor
        public HomeController(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index(int teamid)
        {
            var bowling = _context.Bowlers
                .Where(b => b.TeamID == teamid || teamid == 0)
                .ToList();
            if (teamid == 0)
            {
                ViewBag.Header = "All Teams";
            }
            else
            {
                ViewBag.Header = _context.Teams.Single(x => x.TeamID == teamid).TeamName;
            }

            var blah = _context.Bowlers
                //.FromSqlRaw("SELECT * FROM bowlers WHERE BowlerFirstName = 'Barbara'")
                .Where(b => b.TeamID == teamid || teamid == 0)
                .ToList();

            return View(bowling);
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
            //return View("Index");
            return RedirectToAction("Index", b);
        }

        [HttpGet]
        public IActionResult Edit(int BowlerID)
        {
            ViewBag.Bowler = _context.Bowlers.ToList();
            var bowler = _context.Bowlers.Single(b => b.BowlerID == BowlerID);

            return View("Edit", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();

            return RedirectToAction("Index", b);
            
        }

        [HttpGet]
        public IActionResult DeleteConfirmation(int bowlerid)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View();
        }

        [HttpPost]
        public IActionResult DeleteConfirmation(Bowler bowler)
        {
            _context.Bowlers.Where(b => b.BowlerID == bowler.BowlerID);

            _context.Bowlers.Remove(bowler);
            _context.SaveChanges();

            return RedirectToAction("Index");
            //return View("Index");

        }

    }
}