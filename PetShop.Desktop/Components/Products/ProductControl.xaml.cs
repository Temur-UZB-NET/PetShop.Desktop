using PetShop.Desktop.Entitys.Types;
using PetShop.Desktop.ViewModels.Animals;
using PetShop.Desktop.Windows.Buy;
using PetShop.Desktop.Windows.Delete;
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

namespace PetShop.Desktop.Components.Products
{
    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        public Func<Task> Refresh { get; set; }
        public Func<long, Task> Refreshsh { get; set; }


        public AnimalViewModel animalViewModel { get; set; }

        public ProductControl()
        {
            InitializeComponent();
        }


        public void SetData(AnimalViewModel animalViewModel)
        {
            this.animalViewModel = animalViewModel;
            imgProductControl.ImageSource = new BitmapImage(new Uri(animalViewModel.ImagePath, UriKind.Relative));
            tbProductControl.Text = animalViewModel.Name;
            tbProductControlAge.Text = animalViewModel.Age.ToString();
            tbProductControlGender.Text = animalViewModel.Gender;
        }

        private async void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DelProduct delProduct = new DelProduct();
            delProduct.SetData(animalViewModel);
            delProduct.ShowDialog();
            await Refreshsh(0);

        }

     

        private void BtnBuy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BuyWindow buyWindow = new BuyWindow();
            buyWindow.ShowDialog();
        }
    }
}
