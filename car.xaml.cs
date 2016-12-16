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
using System.Data.Entity;
namespace STO
{
    /// <summary>
    /// Interaction logic for car.xaml
    /// </summary>
    public partial class car : Window
    {
        STOEntities db;
        public car()
        {
            InitializeComponent();
            db = new STOEntities();
            db.cClient.Load();
            client_cb.ItemsSource = db.cClient.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db = new STOEntities();
            cCar new_car = new cCar
            {
                Number = number.Text,
                Brand_Model = brand.Text,
                IDOwner = ((cClient)client_cb.SelectedItem).ID,
            };
            db.cCar.Add(new_car);
            db.SaveChanges();
            MessageBox.Show("Car will be added. Please update table.", "Adding Car", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
