using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFSPraise.Abstract;

namespace TFSPraise.Controllers
{
    public class PraiseController : Controller
    {
        private IPraiseRepository praiseRepo;
        public PraiseController(IPraiseRepository praiseRepository)
        {
            praiseRepo = praiseRepository;
        }
        // GET: Praise
        public ActionResult Index()
        {
            var praises = praiseRepo.GetPraises().FirstOrDefault().Receivers;
            return View(praises);
        }

    }
}