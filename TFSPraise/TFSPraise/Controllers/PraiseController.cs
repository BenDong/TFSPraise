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
        private IPraiseRepository repo;
        readonly int PageSize = 4;
        public PraiseController(IPraiseRepository praiseRepository)
        {
            repo = praiseRepository;
        }
   
        public ActionResult PraiseList(int page = 1)
        {
            ListViewModel<Praise> praiseListViewModel = new ListViewModel<Praise>
            {
                ItemList = repo.GetPraises().Skip(PageSize * (page - 1)).Take(PageSize).ToList(),
                PageInfo = new PageInfo {
                    TotalItems = repo.GetPraises().ToList().Count,
                    CurrentPage = page,
                    ItemsPerPage = PageSize }
            };
            return View(praiseListViewModel);
        }
    }
}