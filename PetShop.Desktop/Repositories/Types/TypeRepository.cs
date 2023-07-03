using Npgsql;
using PetShop.Desktop.Entitys;
using PetShop.Desktop.Entitys.Types;
using PetShop.Desktop.Interfaces.Types;
using PetShop.Desktop.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace PetShop.Desktop.Repositories.Types;

public sealed class TypeRepository : BaseRepository, ITypeRepository  
{
    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateAsync(Typee obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO typess (name, image_path, created_at, updated_at) " +
                "VALUES (@name, @image_path,  @created_at, @updated_at );";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", obj.Name);
                command.Parameters.AddWithValue("image_path", obj.ImagePath);
                command.Parameters.AddWithValue("created_at", obj.CreatedAt);
                command.Parameters.AddWithValue("updated_at", obj.UpdatedAt);

                return await command.ExecuteNonQueryAsync();
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }


    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"DELETE FROM typess  WHERE  id = {id};";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Typee>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            var list = new List<Typee>();
            await _connection.OpenAsync();
            string query = $"select * from typess order by id offset {@params.SkipCount} limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Typee teacher = new Typee();
                        teacher.Id = reader.GetInt64(0);
                        teacher.Name = reader.GetString(1);
                        teacher.ImagePath = reader.GetString(2);
                        teacher.CreatedAt = reader.GetDateTime(3);
                        teacher.UpdatedAt = reader.GetDateTime(4);
                        list.Add(teacher);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Typee>();
        }
        finally
        {
            await _connection.CloseAsync();
        }


    }

    public Task<Typee> GetAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Typee editedObj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.typess  SET  name = @name, image_path = @image_path, updated_at =@updated_at   WHERE  id = {id};";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", editedObj.Name);
                command.Parameters.AddWithValue("image_path", editedObj.ImagePath);
                command.Parameters.AddWithValue("updated_at", editedObj.UpdatedAt);

                return await command.ExecuteNonQueryAsync();
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Typee>> GetAllByTypesIdAsync(long typeId)
    {
        try
        {
            var list = new List<Typee>();
            await _connection.OpenAsync();
            string query = $"select * from typess where TypeId={typeId} order by id";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Typee teacher = new Typee();
                        teacher.Id = reader.GetInt64(0);
                        teacher.Name = reader.GetString(1);
                        teacher.ImagePath = reader.GetString(2);
                        teacher.CreatedAt = reader.GetDateTime(3);
                        teacher.UpdatedAt = reader.GetDateTime(4);
                        list.Add(teacher);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Typee>();
        }
        finally
        {
            await _connection.CloseAsync();
        }


    }

}
