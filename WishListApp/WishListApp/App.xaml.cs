using System.Windows;

namespace WishListApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static WishListRepository.WishListRepository wishListRepository;

        static App()
        {
            wishListRepository = new WishListRepository.WishListRepository();
        }

        public static WishListRepository.WishListRepository WishListRepository
        {
            get
            {
                return wishListRepository;
            }
        }
    }
}
