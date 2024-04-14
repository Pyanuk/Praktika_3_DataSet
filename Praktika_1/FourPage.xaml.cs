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
using Praktika_1.COFFEE_HOUSEDataSetTableAdapters;

namespace Praktika_1
{
 
    public partial class FourPage : Page
    {
        CUSTOMER_ORDERTableAdapter CUSTOMER_ORDER = new CUSTOMER_ORDERTableAdapter();
        NAME_COFFEETableAdapter NAME_COFFEE = new NAME_COFFEETableAdapter();
        CLIENTTableAdapter CLIENT = new CLIENTTableAdapter();
        ORDER_COFFEETableAdapter ORDER_COFFEE = new ORDER_COFFEETableAdapter();
        public FourPage()
        {
            InitializeComponent();
            CUSTOMER_ORDERDataGrid.ItemsSource = CUSTOMER_ORDER.GetData();

            CUSTOMER_ORDERComboBox.ItemsSource = NAME_COFFEE.GetData();
            CUSTOMER_ORDERComboBox.DisplayMemberPath = "ID_NAME_COFFEE_HOUSE";

            CUSTOMER_ORDERComboBox1.ItemsSource = CLIENT.GetData();
            CUSTOMER_ORDERComboBox1.DisplayMemberPath = "ID_CLIENT";

            CUSTOMER_ORDERComboBox2.ItemsSource = ORDER_COFFEE.GetData();
            CUSTOMER_ORDERComboBox2.DisplayMemberPath = "ID_ORDER_COFFEE";


        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            int NAME_COFFEE_ID = int.Parse(adres.Text);
            int CLIENT_ID= int.Parse(clietn.Text);
            int ORDER_COFFEE_ID = int.Parse(cofee.Text);

            CUSTOMER_ORDER.InsertQuery(NAME_COFFEE_ID, CLIENT_ID, ORDER_COFFEE_ID);
            CUSTOMER_ORDERDataGrid.ItemsSource = CUSTOMER_ORDER.GetData();

        }
        private void delete_Click1(object sender, RoutedEventArgs e)
        {
            object ID = (CUSTOMER_ORDERDataGrid.SelectedItem as DataRowView).Row[0];
            CUSTOMER_ORDER.DeleteQuery(Convert.ToInt32(ID));
            CUSTOMER_ORDERDataGrid.ItemsSource = CUSTOMER_ORDER.GetData();

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            int NAME_COFFEE_ID = int.Parse(adres.Text);
            int CLIENT_ID = int.Parse(clietn.Text);
            int ORDER_COFFEE_ID = int.Parse(cofee.Text);

            object ID = (CUSTOMER_ORDERDataGrid.SelectedItem as DataRowView).Row[0];
            CUSTOMER_ORDER.UpdateQuery(NAME_COFFEE_ID, CLIENT_ID, ORDER_COFFEE_ID, Convert.ToInt32(ID));
            CUSTOMER_ORDERDataGrid.ItemsSource = CUSTOMER_ORDER.GetData();
        }

        private void CUSTOMER_ORDERComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (CUSTOMER_ORDERComboBox.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(cell.ToString());
        }

        private void CUSTOMER_ORDERComboBox_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            object a = (CUSTOMER_ORDERComboBox1.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(a.ToString());
        }

        private void CUSTOMER_ORDERComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            object b = (CUSTOMER_ORDERComboBox2.SelectedItem as DataRowView).Row[1];
            MessageBox.Show(b.ToString());
        }
    }
}
