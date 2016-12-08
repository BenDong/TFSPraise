using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Abstract;
using TFSPraise.Models;

namespace TFSPraise.Controllers
{
    public class PraiseController : Controller
    {
        private IPraiseRepository praiseRepo;
        readonly int PageSize = 4;
        public PraiseController(IPraiseRepository praiseRepository)
        {
            praiseRepo = praiseRepository;
        }
   
        public ActionResult PraiseList(int page = 1)
        {
            PraiseListViewModel listViewModel = new PraiseListViewModel
            {
                PraiseList = praiseRepo.GetPraises().Skip(PageSize * (page - 1)).Take(PageSize).ToList(),
                PageInfo = new PageInfo {
                    TotalItems = praiseRepo.GetPraises().ToList().Count,
                    CurrentPage = page,
                    ItemsPerPage = PageSize }
            };
            return View(listViewModel);
        }
    }
}