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
    /// Interaction logic for repair.xaml
    /// </summary>
    public partial class repair : Window
    {
        STOEntities db;
        public repair()
        {
            InitializeComponent();
            db = new STOEntities();
            db.cCar.Load();
            car_cb.ItemsSource = db.cCar.Local.ToBindingList();
            db.cClient.Load();
            client_cb.ItemsSource = db.cClient.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db = new STOEntities();
            int result;
            if (start_date.SelectedDate.Value > end_date.SelectedDate.Value || end_date.SelectedDate.Value > gua.SelectedDate.Value)
            {
                MessageBox.Show("Enter correct dates. ", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else if (!Int32.TryParse(price_tb.Text, out result))
            {
                MessageBox.Show("Enter correct price, without letters and symbols. ", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (Int32.Parse(price_tb.Text) < 0)
                {
                    MessageBox.Show("Enter correct price. ", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
                vRepair new_repair = new vRepair
                {
                    Reason_of_problem = reason_tb.Text,
                    Start_Date = start_date.SelectedDate.Value,
                    End_Date = end_date.SelectedDate.Value,
                    Guarantee = gua.SelectedDate.Value,
                    Price = Int32.Parse(price_tb.Text),
                    Car_ID = ((cCar)car_cb.SelectedItem).ID,
                    Client_ID = ((cClient)client_cb.SelectedItem).ID
                };
                db.vRepair.Add(new_repair);
                db.SaveChanges();
                MessageBox.Show("Repair will be added. Please update table.", "Adding repair", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            
            
        }
    }
}
