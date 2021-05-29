using WishListDB;

namespace WishListRepository
{
    class DatabaseManager
    {
        private static readonly WishListContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new WishListContext();
        }

        // Provide an accessor to the database
        public static WishListContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
