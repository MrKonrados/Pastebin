using Pastebin.Models;
using Pastebin.Utils;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Pastebin.Controllers
{
    public class PasteController : Controller
    {
        private readonly PastebinContext _context;

        public PasteController()
        {
            _context = new PastebinContext();
        }

        public ActionResult Index()
        {
            var pasteList = _context.Pastes.ToList();
            return View(pasteList);
        }

        public ActionResult Create()
        {
            var lang = _context.Languages.Select(_ => new SelectListItem
            {
                Text = _.Name,
                Value = _.Id.ToString(),
            });

            var viewModel = new PasteVM()
            {
                Languages = lang,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PasteVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var uri = GenerateUri.RandomString();
            while (_context.Pastes.Any(_ => _.URI == uri))
            {
                uri = GenerateUri.RandomString();
            }

            var paste = new Paste()
            {
                Title = viewModel.Title,
                URI = uri,
                Content = viewModel.Content,
                LanguageId = viewModel.LanguageId
            };

            _context.Pastes.Add(paste);
            _context.SaveChanges();

            return RedirectToAction("Detail", new { url = uri });
        }

        public ActionResult Detail(string url)
        {
            if (url == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //            var paste = _context.Pastes.SingleOrDefault(p => p.URI == url);
            var paste = _context.Pastes.Include(_ => _.Language).SingleOrDefault(p => p.URI == url);
            if (paste == null)
                return HttpNotFound("URL nie może być pusty");

            return View(paste);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}