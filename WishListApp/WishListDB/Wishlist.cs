using System;
using System.Collections.Generic;

namespace WishListDB
{
    public partial class Wishlist
    {
        public int WishListId { get; set; }
        public string WishListBrand { get; set; }
        public string WishListDescription { get; set; }
        public decimal WishListPrice { get; set; }
        public int WishListSku { get; set; }
        public bool WishListInStock { get; set; }
        public int WishListQty { get; set; }
        public string WishListNotes { get; set; }
        public DateTime WishListCreatedDate { get; set; }
    }
}
