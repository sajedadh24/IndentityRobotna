using Microsoft.AspNetCore.Mvc;
using RoyalCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalCars.ViewComponents
{
    public class CompanyViewComponent : ViewComponent
     {
        private readonly RoyalDbContext _db;

        public CompanyViewComponent(RoyalDbContext db)
        {
            _db = db;
        }
        public IViewComponentHelper Invoke()
        {
            _db.Companies;
            return View(data)
        }

    }
}
