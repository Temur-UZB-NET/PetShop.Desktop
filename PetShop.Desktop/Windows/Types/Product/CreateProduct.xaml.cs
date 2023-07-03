using EduCenter.Desktop.Constants;
using Microsoft.Win32;
using PetShop.Desktop.Entitys;
using PetShop.Desktop.Helpers;
using PetShop.Desktop.Repositories.Animals;
using PetShop.Desktop.Repositories.Types;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PetShop.Desktop.Windows.Types.Product
{
    /// <summary>
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window
    {
        private readonly TypeRepository _typeRepository;
        private readonly AnimalRepository _animalRepository;

        public CreateProduct()
        {
            InitializeComponent();
            _typeRepository = new TypeRepository();
            _animalRepository = new AnimalRepository();
        }

        private void CencelBrd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private async void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animal animal = new Animal();
            animal.Name = tbNameProduct.Text;

            string imagepath = ImgBImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(imagepath))
                animal.ImagePath = await CopyImageAsync(imagepath,
                    ContentConstants.IMAGE_CONTENTS_PATH);


            animal.TypeId = (long)cbCreatePr.SelectedValue;
            animal.Age = int.Parse(tbAgeProduct.Text);


            if(rdMaleBtn.IsChecked == true)
            {
                animal.Gender = rdMaleBtn.Content.ToString();
            }
            else
            {
                animal.Gender = rdFamaleBtn.Content.ToString();
            }
            animal.Breed = tbBreed.Text;



            animal.CreatedAt = animal.UpdatedAt = TimeHelper.GetDateTime();
            



            var result = await _animalRepository.CreateAsync(animal);
            if (result > 0)
            {
                MessageBox.Show("Muvaffaqqiyatli saqlandi");
                this.Close();
            }
        }

        private async Task<string> CopyImageAsync(string imgPath, string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            var imageName = ContentNameMaker.GetImageName(imgPath);

            string path = System.IO.Path.Combine(destinationDirectory, imageName);

            byte[] image = await File.ReadAllBytesAsync(imgPath);

            await File.WriteAllBytesAsync(path, image);

            return path;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var types = await _typeRepository.GetAllAsync(new Utils.PaginationParams()
            {
                PageNumber = 1,
                PageSize = 100
            });
            cbCreatePr.ItemsSource = types;
        }

        private void ImgPathPr_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var openFileDialog = GetImageDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                ImgBImage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }

        private OpenFileDialog GetImageDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            return openFileDialog;
        }
    }
}
