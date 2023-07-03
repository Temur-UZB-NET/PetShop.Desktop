using PetShop.Desktop.Pages;
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

namespace PetShop.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void brDragable_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;

    }

    private void btnMaximize_Click(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Normal)
        {
            WindowState = WindowState.Maximized;
        }
        else
        {
            WindowState = WindowState.Normal;
        }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }


    private void rbOrders_Click(object sender, RoutedEventArgs e)
    {
        OrdersPage ordersPage = new OrdersPage();
        PageNavigator.Content = ordersPage;
    }

    private void PageNavigator_Navigated(object sender, NavigationEventArgs e)
    {

    }

    private void rbDashboard_Click(object sender, RoutedEventArgs e)
    {
        Dashboard dashboard = new Dashboard();
        PageNavigator.Content = dashboard;
    }

    private void rbProducts_Click(object sender, RoutedEventArgs e)
    {
        ProductsPage productsPage = new ProductsPage();
        PageNavigator.Content = productsPage;
    }

    private void rbCustomers_Click(object sender, RoutedEventArgs e)
    {
        CustomarsPage customarsPage = new CustomarsPage();  
        PageNavigator.Content = customarsPage;
    }


    private void rbTypes_Click(object sender, RoutedEventArgs e)
    {
        TypesPage typesPage = new TypesPage();
        PageNavigator.Content = typesPage;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Dashboard dashboard = new Dashboard();
        PageNavigator.Content = dashboard;
    }
}
