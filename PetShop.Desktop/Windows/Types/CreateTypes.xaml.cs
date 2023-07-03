using EduCenter.Desktop.Constants;
using Microsoft.Win32;
using PetShop.Desktop.Entitys.Types;
using PetShop.Desktop.Helpers;
using PetShop.Desktop.Interfaces.Types;
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

namespace PetShop.Desktop.Windows.Types
{
    /// <summary>
    /// Interaction logic for CreateTypes.xaml
    /// </summary>
    public partial class CreateTypes : Window
    {
        
        private readonly ITypeRepository _repository;

        public CreateTypes()
        {
            InitializeComponent();
            _repository = new TypeRepository();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
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

        private async void SaveBrd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Typee type = new Typee();
            type.Name = NameTb.Text;

            string imagepath = ImgBImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(imagepath))
                type.ImagePath = await CopyImageAsync(imagepath,
                    ContentConstants.IMAGE_CONTENTS_PATH);

            type.CreatedAt = type.UpdatedAt = TimeHelper.GetDateTime();

            var result = await _repository.CreateAsync(type);
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

        private void CencelBrd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

      
    }
}
