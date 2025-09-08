using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pharmacy1.Data;
using Pharmacy1.Pages;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmacy1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //PharmDB db = new PharmDB();
        //var cc = db.Companies.ToList();
        //var bb = Encoding.ASCII.GetBytes(cc[0].comp_name_ar);
        //var st = Encoding.UTF8.GetString(bb);
        
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=eph;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        string query = "SELECT * FROM Item_Catalog";
        string outputFilePath = "Items.csv";


        //ExportToCsv(connectionString, query, outputFilePath);

        InsertItem ins = new InsertItem();
        ins.Show();
    }

    public void ExportToCsv(string connectionString, string query, string outputFilePath)
    {
        try
        {
            // Connect to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Execute the query
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a StreamWriter to write the CSV file
                    using (StreamWriter writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
                    {
                        // Write the header row
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            writer.Write(reader.GetName(i));
                            if (i < reader.FieldCount - 1)
                                writer.Write(",");
                        }
                        writer.WriteLine();

                        // Write the data rows
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.Write("\"" +
                                    reader[i].ToString()?.Replace("\"", "\\\"") // Escape quotes
                                    + "\"");
                                if (i < reader.FieldCount - 1)
                                    writer.Write(",");
                            }
                            writer.WriteLine();
                        }
                    }
                }
            }

            // Notify success
            MessageBox.Show("Data exported successfully to " + outputFilePath);
        }
        catch (Exception ex)
        {
            // Handle errors
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }

    //private void Button_Click_1(object sender, RoutedEventArgs e)
    //{
    //    //frame.Navigate(new Uri("Pharmacy1\\Pharmacy1\\MainWindow.xaml", UriKind.Relative));
    //}

    //private void Button_Click_2(object sender, RoutedEventArgs e)
    //{
    //    frame.Navigate(new Uri("Pages\\AddItemPage.xaml", UriKind.Relative));

    //}

    private void Button_Companies(object sender, RoutedEventArgs e)
    {
        frame.Navigate(new Uri("Pages\\Companies.xaml", UriKind.Relative));
    }

    private void Button_Items(object sender, RoutedEventArgs e)
    {
        frame.Navigate(new Uri("Pages\\Items.xaml", UriKind.Relative));
    }

    private void Button_Suppliers(object sender, RoutedEventArgs e)
    {
        frame.Navigate(new Uri("Pages\\Suppliers.xaml", UriKind.Relative));
    }
}