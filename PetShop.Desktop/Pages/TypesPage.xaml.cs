using PetShop.Desktop.Components.Types;
using PetShop.Desktop.Interfaces.Types;
using PetShop.Desktop.Repositories.Types;
using PetShop.Desktop.Utils;
using PetShop.Desktop.Windows.Types;
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
    /// Interaction logic for TypesPage.xaml
    /// </summary>
    public partial class TypesPage : Page
    {

        private readonly ITypeRepository _repository;

        public TypesPage()
        {
            InitializeComponent();
            _repository = new TypeRepository();

        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateTypes createTypes = new CreateTypes();
            createTypes.ShowDialog();
            await RefreshAsync();
        }


        public async Task RefreshAsync()
        {
            wrpType.Children.Clear();

            var pageParam = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30,
            };

            var types = await _repository.GetAllAsync(pageParam);

            foreach (var type in types)
            {
                TypeControl typeControl = new TypeControl();
                typeControl.SetDate(type);
                typeControl.Refresh = RefreshAsync;
                wrpType.Children.Add(typeControl);
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshAsync();
        }
    }
}
