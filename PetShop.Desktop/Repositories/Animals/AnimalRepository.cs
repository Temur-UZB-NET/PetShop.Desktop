using Npgsql;
using PetShop.Desktop.Entitys;
using PetShop.Desktop.Entitys.Types;
using PetShop.Desktop.Interfaces.Animals;
using PetShop.Desktop.Utils;
using PetShop.Desktop.ViewModels.Animals;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace PetShop.Desktop.Repositories.Animals;

public sealed class AnimalRepository : BaseRepository, IAnimalRepository
{
    public async Task<int> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            int n = 0;
            string query = "select count(*) from product;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    if(await reader.ReadAsync()) 
                    {
                        n = reader.GetInt32(0);
                    }
                }


            }
            return n; 
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

    public async Task<int> CreateAsync(Animal obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO product (typeid, name, age, gender, breed, image_path, created_at, updated_at) " +
                "VALUES (@typeid, @name, @age, @gender, @breed, @image_path, @created_at, @updated_at );";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("typeid", obj.TypeId);
                command.Parameters.AddWithValue("name", obj.Name);
                command.Parameters.AddWithValue("age", obj.Age);
                command.Parameters.AddWithValue("gender", obj.Gender);
                command.Parameters.AddWithValue("breed", obj.Breed);
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

            string query = $"DELETE FROM product  WHERE  id = {id};";

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

    public async Task<IList<AnimalViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<AnimalViewModel>();
            string query = $"Select product.id, product.typeid, product.name, product.age, product.gender, product.breed, " +
                $"product.image_path, product.created_at, product.updated_at, typess.name  from product " +
                $" inner join typess on typess.id = product.typeid order by id offset {@params.SkipCount} limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        AnimalViewModel animal = new AnimalViewModel();
                        animal.Id = reader.GetInt64(0);
                        animal.TypeId = reader.GetInt64(1);
                        animal.Name = reader.GetString(2);
                        animal.Age = reader.GetInt64(3);    
                        animal.Gender = reader.GetString(4);
                        animal.Breed = reader.GetString(5);
                        animal.ImagePath = reader.GetString(6);
                        animal.CreatedAt = reader.GetDateTime(7);
                        animal.UpdatedAt = reader.GetDateTime(8);
                        animal.Type = reader.GetString(9);
                        list.Add(animal);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<AnimalViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<AnimalViewModel> GetAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Animal editedObj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE product SET typeid =@typeid, name =@name, age =@age, gender =@gender, breed =@breed, image_path =@image_path, updated_at =@updated_at  WHERE  id = {id};";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("typeid", editedObj.TypeId);
                command.Parameters.AddWithValue("name", editedObj.Name);
                command.Parameters.AddWithValue("age", editedObj.Age);
                command.Parameters.AddWithValue("gender", editedObj.Gender);
                command.Parameters.AddWithValue("breed", editedObj.Breed);
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


    public async Task<IList<AnimalViewModel>> GetAllByTypesIdAsync(long typeId)
    {
        try
        {
            var list = new List<AnimalViewModel>();
            await _connection.OpenAsync();
            string query = $"Select product.id, product.typeid, product.name, product.age, product.gender," +
                $" product.breed, product.image_path, product.created_at, product.updated_at, typess.name " +
                $" from product  inner join typess on typess.id = product.typeid where TypeId={typeId} order by id";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        AnimalViewModel animal = new AnimalViewModel();
                        animal.Id = reader.GetInt64(0);
                        animal.TypeId = reader.GetInt64(1);
                        animal.Name = reader.GetString(2);
                        animal.Age = reader.GetInt64(3);
                        animal.Gender = reader.GetString(4);
                        animal.Breed = reader.GetString(5);
                        animal.ImagePath = reader.GetString(6);
                        animal.CreatedAt = reader.GetDateTime(7);
                        animal.UpdatedAt = reader.GetDateTime(8);
                        animal.Type = reader.GetString(9);
                        list.Add(animal);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<AnimalViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }


    }



    public async Task<int> DeleteByTypeIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"DELETE FROM product  WHERE  typeid = {id};";

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
}
