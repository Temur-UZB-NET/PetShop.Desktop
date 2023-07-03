using PetShop.Desktop.Entitys.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.Desktop.Interfaces.Types;

public interface ITypeRepository : IRepository<Typee, Typee>
{
    public Task<int> CountAsync();

    public  Task<IList<Typee>> GetAllByTypesIdAsync(long typeId);
}
