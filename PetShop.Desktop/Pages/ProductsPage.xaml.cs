using PetShop.Desktop.Components.Products;
using PetShop.Desktop.Components.Types;
using PetShop.Desktop.Entitys.Types;
using PetShop.Desktop.Interfaces;
using PetShop.Desktop.Interfaces.Types;
using PetShop.Desktop.Repositories.Animals;
using PetShop.Desktop.Repositories.Types;
using PetShop.Desktop.Utils;
using PetShop.Desktop.ViewModels.Animals;
using PetShop.Desktop.Windows.Types.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PetShop.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private readonly ITypeRepository _repository;

        private readonly AnimalRepository _animalRepository;

        public ProductsPage()
        {
            InitializeComponent();
            _repository = new TypeRepository();
            _animalRepository = new AnimalRepository();

        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateProduct createProduct = new CreateProduct();
            createProduct.ShowDialog();
            await RefreshAsync(0);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            stpTypesChips.Children.Clear();

            var pageParam = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30,
            };

            var types = await _repository.GetAllAsync(pageParam);


            // for all
            ChipsControl allforship = new ChipsControl();
            allforship.SetData(new Entitys.Types.Typee() { Id = 0, Name = "All" });
            allforship.Refresh = RefreshAsync;
            stpTypesChips.Children.Add(allforship);
            foreach (var type in types)
            {
                ChipsControl chipsControl = new ChipsControl();
                chipsControl.Refresh = RefreshAsync;
                chipsControl.SetData(type);
                stpTypesChips.Children.Add(chipsControl);
            }

            await RefreshAsync(0);
        }



        public async Task RefreshAsync(long typeId)
        {
            wrpProduct.Children.Clear();
            IList<AnimalViewModel> animals;
            if (typeId == 0)
            {
                animals = await _animalRepository.GetAllAsync(new Utils.PaginationParams()
                {
                    PageNumber = 1,
                    PageSize = 30
                });
            }
            else
            {
                animals = await _animalRepository.GetAllByTypesIdAsync(typeId);
            }

            foreach (var animal in animals)
            {
                ProductControl productControl = new ProductControl();
                productControl.SetData(animal);
                productControl.Refreshsh = RefreshAsync;
                wrpProduct.Children.Add(productControl);
            }
        }


    }
}
