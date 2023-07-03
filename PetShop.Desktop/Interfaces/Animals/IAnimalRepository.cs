using PetShop.Desktop.Entitys;
using PetShop.Desktop.ViewModels.Animals;
using System.Threading.Tasks;

namespace PetShop.Desktop.Interfaces.Animals;

public interface IAnimalRepository :IRepository<Animal , AnimalViewModel>
{
    public Task<int> CountAsync();
}
