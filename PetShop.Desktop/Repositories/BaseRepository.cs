using Npgsql;
using PetShop.Desktop.Constants;

namespace PetShop.Desktop.Repositories;

public abstract class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }
}
