using PetShop.Desktop.Entitys.Types;
using PetShop.Desktop.Repositories.Animals;
using PetShop.Desktop.Repositories.Types;
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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Typee delSave { get; set; }
        private readonly TypeRepository _typeRepository;

        private readonly AnimalRepository _animalRepository;

        public Delete()
        {
            InitializeComponent();
            _typeRepository = new TypeRepository();
            _animalRepository = new AnimalRepository();
        }

        public void SatData(Typee type)
        {
            delSave = type;
            tbUpdate.Text = type.Name;


        }

        private async void btnDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var nmadurr = await _animalRepository.DeleteByTypeIdAsync(delSave.Id);


                var nmadur = await _typeRepository.DeleteAsync(delSave.Id);
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
               delSave.Name = tbUpdate.Text;
               var nmadur = await _typeRepository.UpdateAsync(delSave.Id, delSave);
               if (nmadur > 0)
               {
                   MessageBox.Show("Updated");
                   this.Close();
               }
        }
    }
}
