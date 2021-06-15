using WishListDB;

namespace WishListRepository
{
    internal class DatabaseManager
    {
        // Initialize and open the database connection
        static DatabaseManager()
        {
            Instance = new WishListContext();
        }

        // Provide an accessor to the database
        public static WishListContext Instance { get; private set; }
    }
}
