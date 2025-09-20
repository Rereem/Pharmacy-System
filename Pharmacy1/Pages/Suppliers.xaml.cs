using Microsoft.EntityFrameworkCore;

using Pharmacy1.Data;
using System;
using System.Collections;
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
    /// Interaction logic for Suppliers.xaml
    /// </summary>
    public partial class Suppliers : Page
    {
        PharmDB db => App.db;
        private CollectionViewSource supviewsource;
        public Suppliers()
        {
            InitializeComponent();
            supviewsource = (CollectionViewSource)FindResource(nameof(supviewsource));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //edb.Database.EnsureCreated();
            db.Suppliers.Load();
            var t = db.Suppliers.Local.ToObservableCollection();
            supviewsource.Source = t;
            t.CollectionChanged += T_CollectionChanged;
        }

        private void T_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show(e.Action.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            //dataGrid.Companies.Refresh();

        }



        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AddSupplier addSupplier = new AddSupplier();
            addSupplier.ShowDialog();

        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {

            var currentItem =supviewsource.View.CurrentItem as Supplier;
            if(currentItem != null)
            {
                    if (MessageBox.Show("Are you sure", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    db.Suppliers.Remove(currentItem);
                    db.SaveChanges();
                        }
            }
           
        }
    }
}

