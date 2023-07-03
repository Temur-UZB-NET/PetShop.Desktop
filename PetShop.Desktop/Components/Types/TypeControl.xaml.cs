using PetShop.Desktop.Entitys.Types;
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

namespace PetShop.Desktop.Components.Types
{
    /// <summary>
    /// Interaction logic for TypeControl.xaml
    /// </summary>
    public partial class TypeControl : UserControl
    {

        public Func<Task> Refresh { get;set;}

        public Typee types { get; set; }
        public TypeControl()
        {
            InitializeComponent();
        }

        public void SetDate(Typee type)
        {
            types = type;
            imgTypeControl.ImageSource = new BitmapImage(new Uri(type.ImagePath, UriKind.Relative));
            NameTB.Text = type.Name;  
        }

        private async void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Delete delete = new Delete();
            delete.SatData(types);
            delete.ShowDialog();
            await Refresh();
        }
    }
}
