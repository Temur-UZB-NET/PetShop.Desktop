using PetShop.Desktop.Entitys;
using PetShop.Desktop.Entitys.Types;
using PetShop.Desktop.Helpers;
using PetShop.Desktop.Repositories.Animals;
using PetShop.Desktop.ViewModels.Animals;
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
using System.Windows.Shapes;

namespace PetShop.Desktop.Windows.Delete
{
    /// <summary>
    /// Interaction logic for DelProduct.xaml
    /// </summary>
    public partial class DelProduct : Window
    {

        public AnimalViewModel SaveDel { get; set; }

        private readonly AnimalRepository _animalRepository;

        public DelProduct()
        {
            InitializeComponent();
            _animalRepository = new AnimalRepository();
        }

       

        private async void btnDeleteProduct_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            try
            {

                var nmadur = await _animalRepository.DeleteAsync(SaveDel.Id);
                if (nmadur > 0)
                {
                    MessageBox.Show("Deleted");
                    this.Close();
                }
            }
            catch { }
        }

        private async void btnSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animal animal = new Animal();
            animal.Id = SaveDel.Id;
            animal.TypeId = SaveDel.TypeId;
            animal.Name = tbUpdateName.Text;
            animal.Age = long.Parse(tbUpdateAge.Text);
            animal.Gender = tbUpdateGender.Text;
            animal.Breed = SaveDel.Breed;
            animal.ImagePath = SaveDel.ImagePath;
            animal.UpdatedAt = TimeHelper.GetDateTime();
            var nmadurlar = await _animalRepository.UpdateAsync(animal.Id, animal);
            if (nmadurlar > 0)
            {
                MessageBox.Show("Updated");
                this.Close();
            }
        }

        public void SetData(AnimalViewModel animalName) {
            SaveDel = animalName;
            tbUpdateName.Text = animalName.Name;
            tbUpdateAge.Text = animalName.Age.ToString();
            tbUpdateGender.Text = animalName.Gender;

        }
    }
}
