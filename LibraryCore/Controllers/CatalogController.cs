using System.Linq;
using LibraryCore.LibraryData;
using LibraryCore.Models.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCore.Controllers
{
    public class CatalogController : Controller
    {
        private ILibraryAsset _assets;
        public CatalogController(ILibraryAsset assets)
        {
            _assets = assets;
        }

        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();
            var ListingResult = assetModels
                .Select(result => new AssetIndexListingModel{
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    AuthorOrDirector = _assets.GetAuthorOrDirector(result.Id),
                    DeweyCallNumber = _assets.GetDeweyIndex(result.Id),
                    Title = result.Title,
                    Type = _assets.GetType(result.Id)

                });

                var model = new AssetIndexModel()
                {
                    Assets = ListingResult
                };
                return View(model);
        }
    }
}