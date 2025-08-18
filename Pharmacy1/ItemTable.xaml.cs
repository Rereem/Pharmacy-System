using Microsoft.EntityFrameworkCore;
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

namespace Pharmacy1.Data
{
    /// <summary>
    /// Interaction logic for ItemTable.xaml
    /// </summary>
    public partial class ItemTable : UserControl
    {
        PharmDB edb = new PharmDB();
        private CollectionViewSource itemviewsource;
        public ItemTable()
        {
            InitializeComponent();
            itemviewsource = (CollectionViewSource)FindResource(nameof(itemviewsource));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            edb.SaveChanges();
            dataGrid.Items.Refresh();
      
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            edb.Database.EnsureCreated();
            edb.Items.Load();
            itemviewsource.Source = edb.Items.Local.ToObservableCollection();
        }

        public void refresh()
        {
            edb.Items.Load();
            itemviewsource.Source = edb.Items.Local.ToObservableCollection();
            dataGrid.Items.Refresh();
        
        }
    }
}
