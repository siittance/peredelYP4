using DataSetPrakt4YP.PetShopDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DataSetPrakt4YP
{
    /// <summary>
    /// Логика взаимодействия для CltStranica.xaml
    /// </summary>
    public partial class CltStranica : Page
    {
        ClientsTableAdapter cl = new ClientsTableAdapter();
        public CltStranica()
        {
            InitializeComponent();
            ClientDataGrid.ItemsSource = cl.GetData();
            COmba.ItemsSource = cl.GetData();
            COmba.DisplayMemberPath = "ClientName";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientDataGrid.ItemsSource = (cl.PoiskClit(PoiskCL.Text));
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientDataGrid.ItemsSource = cl.GetData();
        }

        private void PoiskCL_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender is TextBox textBox)
                {
                    textBox.Text = null;
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (COmba.SelectedItem as DataRowView).Row[2].ToString();
            ClientDataGrid.ItemsSource = cl.GetDataBy(id);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            Window window = Window.GetWindow(this);
            window.Close();
        }
    }
}
