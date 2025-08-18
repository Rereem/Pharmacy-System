using Microsoft.EntityFrameworkCore;
using Pharmacy1.Data;
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

namespace Pharmacy1.Pages
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Page
    {
        PharmDB db => App.db;
        private CollectionViewSource itemviewsource;
        public Items()
        {
            InitializeComponent();
            itemviewsource = (CollectionViewSource)FindResource(nameof(itemviewsource));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            //dataGrid.Items.Refresh();

        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //db.Database.EnsureCreated();
            db.Items.Load();
            itemviewsource.Source = db.Items.Local.ToObservableCollection();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {

        }
    }
}
