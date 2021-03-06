using System.Collections.Generic;
using System.Linq;
using WishListDB;

namespace WishListRepository
{
    public class WishListModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public bool InStock { get; set; }
        public int Qty { get; set; }
        public string Notes { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }

    public class WishListRepository
    {
        public static WishListModel Add(WishListModel wishListModel)
        {
            Wishlist wishListDb = ToDbModel(wishListModel);
            DatabaseManager.Instance.Wishlist.Add(wishListDb);
            DatabaseManager.Instance.SaveChanges();

            wishListModel = new WishListModel
            {
                Brand = wishListDb.WishListBrand,
                CreatedDate = wishListDb.WishListCreatedDate,
                Description = wishListDb.WishListDescription,
                Id = wishListDb.WishListId,
                InStock = wishListDb.WishListInStock,
                Notes = wishListDb.WishListNotes,
                Price = wishListDb.WishListPrice,
                Qty = wishListDb.WishListQty,
                Sku = wishListDb.WishListSku
            };
            return wishListModel;
        }

        public static List<WishListModel> GetAll()
        {
            // Use .Select() to map the database wishLists to WishListModel
            List<WishListModel> items = DatabaseManager.Instance.Wishlist
              .Select(t => new WishListModel
              {
                  Brand = t.WishListBrand,
                  CreatedDate = t.WishListCreatedDate,
                  Description = t.WishListDescription,
                  Id = t.WishListId,
                  InStock = t.WishListInStock,
                  Notes = t.WishListNotes,
                  Price = t.WishListPrice,
                  Qty = t.WishListQty,
                  Sku = t.WishListSku
              }).ToList();
            return items;
        }

        public static bool Update(WishListModel wishListModel)
        {
            Wishlist original = DatabaseManager.Instance.Wishlist.Find(wishListModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(wishListModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Remove(int wishListId)
        {
            IQueryable<Wishlist> items = DatabaseManager.Instance.Wishlist
                                .Where(t => t.WishListId == wishListId);

            if (!items.Any())
            {
                return false;
            }

            DatabaseManager.Instance.Wishlist.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();
            return true;
        }

        private static Wishlist ToDbModel(WishListModel wishListModel)
        {
            Wishlist wishListDb = new()
            {
                WishListBrand = wishListModel.Brand,
                WishListCreatedDate = wishListModel.CreatedDate,
                WishListDescription = wishListModel.Description,
                WishListId = wishListModel.Id,
                WishListInStock = wishListModel.InStock,
                WishListNotes = wishListModel.Notes,
                WishListPrice = wishListModel.Price,
                WishListQty = wishListModel.Qty,
                WishListSku = wishListModel.Sku
            };
            return wishListDb;
        }
    }
}
