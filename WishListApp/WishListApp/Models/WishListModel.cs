namespace WishListApp.Models
{
    public class WishListModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Sku { get; set; }
        public bool InStock { get; set; }
        public int Qty { get; set; }
        public string Notes { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public WishListRepository.WishListModel ToRepositoryModel()
        {
            var repositoryModel = new WishListRepository.WishListModel
            {
                Brand = Brand,
                CreatedDate = CreatedDate,
                Description = Description,
                Id = Id,
                InStock = InStock,
                Notes = Notes,
                Price = Price,
                Qty = Qty,
                Sku = Sku
            };

            return repositoryModel;
        }

        public static WishListModel ToModel(WishListRepository.WishListModel respositoryModel)
        {
            var wishListModel = new WishListModel
            {
                Brand = respositoryModel.Brand,
                CreatedDate = respositoryModel.CreatedDate,
                Description = respositoryModel.Description,
                Id = respositoryModel.Id,
                InStock = respositoryModel.InStock,
                Notes = respositoryModel.Notes,
                Price = respositoryModel.Price,
                Qty = respositoryModel.Qty,
                Sku = respositoryModel.Sku
            };

            return wishListModel;
        }

        // Exercise 2 - Fix update so background behaves correctly
        // adding Clone() method
        // so both objects do not point to the same data
        internal WishListModel Clone()
        {
            return (WishListModel)this.MemberwiseClone();
        }
    }
}
