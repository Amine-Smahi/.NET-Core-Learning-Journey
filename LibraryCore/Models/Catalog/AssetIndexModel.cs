using System.Collections.Generic;

namespace LibraryCore.Models.Catalog
{
    public class AssetIndexModel
    {
        public IEnumerable<AssetIndexListingModel> Assets { get;set; }
    }
}