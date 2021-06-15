using System.ComponentModel;

namespace WishListApp.Models
{
    public class WishListModel : IDataErrorInfo, INotifyPropertyChanged
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

        private string ErrorBrand { get; set; }
        private string ErrorDescription { get; set; }
        private string ErrorSku { get; set; }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo interface
        public string Error => "Never Used";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Brand":
                        {
                            BrandError = "";
                            if (Brand == null || string.IsNullOrEmpty(Brand))
                            {
                                BrandError = "Name cannot be empty.";
                            }
                            else if (Brand.Length > 12)
                            {
                                BrandError = "Name cannot be longer than 12 characters.";
                            }
                            return BrandError;
                        }
                    case "Description":
                        {
                            DescriptionError = "";
                            if (Description == null || string.IsNullOrEmpty(Description))
                            {
                                DescriptionError = "Description cannot be empty.";
                            }
                            else if (Description.Length > 50)
                            {
                                DescriptionError = "Description cannot be longer than 50 characters.";
                            }
                            return DescriptionError;
                        }
                    case "Sku":
                        {
                            SkuError = "";
                            if (Sku == null || string.IsNullOrEmpty(Sku))
                            {
                                SkuError = "Sku number cannot be empty.";
                            }
                            else if (Sku.Length < 4)
                            {
                                SkuError = "Sku number cannot be less than 4 numbers.";
                            }
                            else if (Sku.Length > 4)
                            {
                                SkuError = "Sku number cannot be longer than 4 numbers.";
                            }
                            return SkuError;
                        }
                }
                return null;
            }
        }

        public string BrandError
        {
            get => ErrorBrand;
            set
            {
                if (ErrorBrand != value)
                {
                    ErrorBrand = value;
                    OnPropertyChanged(nameof(BrandError));
                }
            }
        }

        public string DescriptionError
        {
            get => ErrorDescription;
            set
            {
                if (ErrorDescription != value)
                {
                    ErrorDescription = value;
                    OnPropertyChanged(nameof(DescriptionError));
                }
            }
        }

        public string SkuError
        {
            get => ErrorSku;
            set
            {
                if (ErrorSku != value)
                {
                    ErrorSku = value;
                    OnPropertyChanged(nameof(SkuError));
                }
            }
        }

        public WishListRepository.WishListModel ToRepositoryModel()
        {
            WishListRepository.WishListModel repositoryModel = new()
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
            WishListModel wishListModel = new WishListModel
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
            return (WishListModel)MemberwiseClone();
        }
    }
}
