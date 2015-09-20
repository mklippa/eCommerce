using SQLite;

namespace eCommerce
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}