using System;
using System.Linq;
using System.Web.Mvc;
using MessangerFirst.Core.Model;
using MessangerFirst.Core.Repository;
using MessangerFirst.WebUI.Mappers;
using MessangerFirst.WebUI.ViewModels;

namespace MessangerFirst.WebUI.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IRepo<History> _repo;
        private readonly IMapper _mapper;

        public HistoryController(IRepo<History> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Create()
        {
            return View(new HistoryViewModel());
        }

        [HttpPost]
        public ActionResult Create(HistoryViewModel viewModel)
        {
            viewModel.Id = Guid.NewGuid();
            viewModel.CreateOn = DateTime.Now;

            if (ModelState.IsValid)
            {
                var history = (History)_mapper.Map(viewModel, typeof(HistoryViewModel), typeof(History));
                _repo.Insert(history);
                _repo.Save();
                return RedirectToAction("Display");
            }

            return View();
        }

        public ActionResult Display()
        {
            var histories = _repo.GetAll().OrderByDescending(x => x.CreateOn).ToList();
            return View(histories);
        }
    }
}