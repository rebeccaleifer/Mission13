using Microsoft.AspNetCore.Mvc;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private BowlingDbContext _context { get; set; }

        public TeamsViewComponent(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];

            var teams = _context.Teams
                //.Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }
}
