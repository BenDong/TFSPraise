using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Abstract;
using TFSPraise.Models;
using TFSPraise.Entities;

namespace TFSPraise.Controllers
{
    public class PraiseController : Controller
    {
        private RepositoryBase<Praise> praiseRepo;
        readonly int PageSize = 4;
        public PraiseController(RepositoryBase<Praise> _praiseRepo)
        {
            praiseRepo = _praiseRepo;
        }
   
        public ActionResult PraiseList(int page = 1)
        {
            ListViewModel<Praise> praiseListViewModel = new ListViewModel<Praise>
            {
                List = praiseRepo.GetAll().Skip(PageSize * (page - 1)).Take(PageSize).ToList(),
                PageInfo = new PageInfo {
                    TotalItems = praiseRepo.GetAll().ToList().Count,
                    CurrentPage = page,
                    ItemsPerPage = PageSize }
            };
            return View(praiseListViewModel);
        }
    }
}