namespace Dnd.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Core.Model.Character;
    using Core.Repositories;
    using Dal.Repositories;
    using Mappers;
    using ViewModels;
    using Vornia.Character;

    public class CharacterController : Controller
    {
        private ICharacterRepository _repository;

        private IMapper<ICharacter, CharacterViewModel> _mapper;

        public CharacterController()
            : this(default(ICharacterRepository), default(IMapper<ICharacter, CharacterViewModel>)) {
        }

        public CharacterController(ICharacterRepository repository, IMapper<ICharacter, CharacterViewModel> mapper) {
            _repository = repository ?? new CharacterEfRepository();
            _mapper = mapper ?? new CharacterMapper();
        }

        public ActionResult Index() {
            var allCharacters = _repository.GetAll().ToList();
            var viewModel = new CharacterIndexViewModel();
            viewModel.Characters = _mapper.Map(allCharacters);
            return View(viewModel);
        }

        public ActionResult Details(int id) {
            return View();
        }

        public ActionResult Create() {
            var maswari = VorniaCharacterCreator.CreateMaswari();
            _repository.Add(maswari);
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public ActionResult Edit(int id) {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public ActionResult Delete(int id) {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
