using PetShop.Desktop.Entitys.Types;
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
    /// Interaction logic for ChipsControl.xaml
    /// </summary>
    public partial class ChipsControl : UserControl
    {
        public Func<long, Task> Refresh { get; set; }

        private Typee type = new Typee();
        public ChipsControl()
        {
            InitializeComponent();
        }

        public void SetData(Typee type)
        {
            this.type = type;
            lbCourse.Content = type.Name;
        }

        private async void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            await Refresh(type.Id);
        }





    }
}
