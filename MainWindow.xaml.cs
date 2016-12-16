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
using System.Data.Entity;

namespace STO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        STOEntities db;

        public MainWindow()
        {
            InitializeComponent();

            db = new STOEntities();
            db.vRepair.Load(); // загружаем данные
            repairGrid.ItemsSource = db.vRepair.Local.ToBindingList(); // устанавливаем привязку к кэшу

            db.cCar.Load(); // загружаем данные
            carGrid.ItemsSource = db.cCar.Local.ToBindingList(); // устанавливаем привязку к кэшу

            db.cClient.Load(); // загружаем данные
            clientGrid.ItemsSource = db.cClient.Local.ToBindingList(); // устанавливаем привязку к кэшу
            db.cDetail.Load(); // загружаем данные
            detailGrid.ItemsSource = db.cDetail.Local.ToBindingList(); // устанавливаем привязку к кэшу
            db.vUsed_Detail.Load(); // загружаем данные
            usedGrid.ItemsSource = db.vUsed_Detail.Local.ToBindingList(); // устанавливаем привязку к кэшу
        }
       
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int Tab_open = tabs.SelectedIndex;
            switch (Tab_open)
            {
                case 0:
                    repair add_new_rep = new repair();
                    add_new_rep.Show(); // показать форму добавления ремонта
                    break;
                case 1:
                    car add_new_car = new car();
                    add_new_car.Show(); // показать форму добавления авто
                    break;
                case 2:
                    client add_new_client = new client();
                    add_new_client.Show(); // показать форму добавления клиента
                    break;
                case 3:
                    detail add_new_detail = new detail();
                    add_new_detail.Show(); // показать форму добавления детали
                    break;
            } 
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db = new STOEntities();
            int Tab_open = tabs.SelectedIndex;
            switch (Tab_open)
            {
                case 0:
                    db.vRepair.Load();// загружаем данные
                    repairGrid.ItemsSource = db.vRepair.Local.ToBindingList();// устанавливаем привязку к кэшу
                    break;
                case 1:
                    db.cCar.Load();// загружаем данные
                    carGrid.ItemsSource = db.cCar.Local.ToBindingList();// устанавливаем привязку к кэшу
                    break;
                case 2:
                    db.cClient.Load();// загружаем данные
                    clientGrid.ItemsSource = db.cClient.Local.ToBindingList();// устанавливаем привязку к кэшу
                    break;
                case 3:
                    db.cDetail.Load();// загружаем данные
                    detailGrid.ItemsSource = db.cDetail.Local.ToBindingList();// устанавливаем привязку к кэшу
                    break;
                case 4:
                    db.vUsed_Detail.Load();// загружаем данные
                    usedGrid.ItemsSource = db.vUsed_Detail.Local.ToBindingList();// устанавливаем привязку к кэшу
                    break;
            } 
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int Tab_open = tabs.SelectedIndex;
            switch (Tab_open)
            {
                case 0:
                    if (repairGrid.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < repairGrid.SelectedItems.Count; i++)
                        {
                            vRepair repair = repairGrid.SelectedItems[i] as vRepair;
                            if (repair !=null)
                                db.vRepair.Remove(repair);// удаление элемента из таблицы базы данных
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose element to delete it.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    break;
                case 1:
                    if (carGrid.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < carGrid.SelectedItems.Count; i++)
                        {
                            cCar car = carGrid.SelectedItems[i] as cCar;
                            if (car != null)
                                db.cCar.Remove(car);// удаление элемента из таблицы базы данных
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose element to delete it.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    break;
                case 2:
                    if (clientGrid.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < clientGrid.SelectedItems.Count; i++)
                        {
                            cClient client = clientGrid.SelectedItems[i] as cClient;
                            if (client != null)
                            {
                                db.cClient.Remove(client); // удаление элемента из таблицы базы данных
                            }
                               
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose element to delete it.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    break;
                case 3:
                    if (detailGrid.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < detailGrid.SelectedItems.Count; i++)
                        {
                            cDetail detail = detailGrid.SelectedItems[i] as cDetail;
                            if (detail != null)
                                db.cDetail.Remove(detail);// удаление элемента из таблицы базы данных
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose element to delete it.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    break;
                case 4:
                    if (usedGrid.SelectedItems.Count > 0) // если элемент таблицы выбран
                    {
                        for (int i = 0; i < usedGrid.SelectedItems.Count; i++)
                        { 
                            vUsed_Detail used = usedGrid.SelectedItems[i] as vUsed_Detail;
                            if (used != null)
                                db.vUsed_Detail.Remove(used);// удаление элемента из таблицы базы данных
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Choose element to delete it.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }
                    break;
            }
            try
            {
                db.SaveChanges();
            }
            catch
            {
                int Tab = tabs.SelectedIndex;
                switch (Tab)
                {
                    case 0:
                        MessageBox.Show("You can not delete this repair, because it uses in Used Details!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        db = new STOEntities();
                        db.vRepair.Load();// загружаем данные
                        repairGrid.ItemsSource = db.vRepair.Local.ToBindingList();// устанавливаем привязку к кэшу
                        break;
                    case 1:
                        MessageBox.Show("You can not delete this car, because it uses in Repairs!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        db = new STOEntities();
                        db.cCar.Load();// загружаем данные
                        carGrid.ItemsSource = db.cCar.Local.ToBindingList();// устанавливаем привязку к кэшу
                        break;
                    case 2:
                        MessageBox.Show("You can not delete this client, because it uses in Repairs and Cars!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        db = new STOEntities();
                        db.cClient.Load();// загружаем данные
                        clientGrid.ItemsSource = db.cClient.Local.ToBindingList();// устанавливаем привязку к кэшу
                        break;
                    case 3:
                        MessageBox.Show("You can not delete this detail, because it uses in Used Details!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        db = new STOEntities();
                        db.cDetail.Load();// загружаем данные
                        detailGrid.ItemsSource = db.cDetail.Local.ToBindingList();// устанавливаем привязку к кэшу
                        break;
                } 

                
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

      }

    }

