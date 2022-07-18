using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Microsoft.Win32;
using Newtonsoft.Json;
using RestSharp;

namespace WpfAppSHOPkop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Product _selectedProduct;

        private ObservableCollection<Product> prod;
        public ObservableCollection<Product> Prod
        {
            get { return prod; }
            set { prod = value; }
        }

           private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value;  }
        }
        public MainWindow()
        {
            InitializeComponent();
            ListBoxProducts.DataContext = this;
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "JOHNNIE WALKER BLACK LABEL VİSKİ 1 LT",
                    Quantity = 200,
                    Price = 82.69,
                    ImagePath = "Images/BLACK LABEL VİSKİ 1.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "CAPTAIN MORGAN JAMAICA ROM 1 LT",
                    Quantity = 200,
                    Price = 53.35,
                    ImagePath = "Images/CAPTAIN MORGAN JAMAICA ROM 1 LT.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "CAPTAIN MORGAN SPICED GOLD ROM 1 LT",
                    Quantity = 200,
                    Price = 53.35,
                    ImagePath = "Images/CAPTAIN MORGAN SPICED GOLD ROM 1 LT.jpg"
                },
                
                new Product
                {
                    Id =4,
                    Name = "CHIVAS REGAL 12 İLLİK VİSKİ 0.7 LT",
                    Quantity = 200,
                    Price = 69.35,
                    ImagePath = "Images/CHIVAS REGAL 12 İLLİK VİSKİ 0.7 LT.jpg"
                },
                
                new Product
                {
                    Id = 5,
                    Name = "JACK DANIEL'S TENNESSEE VİSKİ 0.7 LT",
                    Quantity = 200,
                    Price = 60,
                    ImagePath = "Images/JACK DANIEL'S TENNESSEE VİSKİ 0.7 LT.jpg"
                },
                
                new Product
                {
                    Id = 6,
                    Name = "JOHNNIE WALKER BLACK LABEL VİSKİ 1 LT",
                    Quantity = 200,
                    Price = 82.69,
                    ImagePath = "Images/JOHNNIE WALKER RED LABEL VİSKİ 1 LT.jpg"
                },
                
                new Product
                {
                    Id = 7,
                    Name = "TULLAMORE DEW VİSKİ 0.7 LT",
                    Quantity = 200,
                    Price = 52.99,
                    ImagePath = "Images/TULLAMORE DEW VİSKİ 0.7 LT.jpg"
                },


            };
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ObservableCollection<Product> itemsToRemove = new ObservableCollection<Product>();
            foreach (Product item in ListBoxProducts.SelectedItems)
            {
                itemsToRemove.Add(item);
            }
            foreach (Product item in itemsToRemove)
            {
                ((ObservableCollection<Product>)ListBoxProducts.ItemsSource).Remove(item);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void RefreshListBox(ObservableCollection<Product> products)
        {
            ListBoxProducts.ItemsSource = null;
            ListBoxProducts.ItemsSource = products;
        }
        private void TextBoxSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
           //TextBoxSearch.Text = string.Empty;
            if (String.IsNullOrWhiteSpace(TextBoxSearch.Text))
            {
                Prod = Products ;
            }
            else
            {
                Prod = FilterByKeyword(TextBoxSearch.Text);
            }
            RefreshListBox(Prod);
        }
        private ObservableCollection<Product> FilterByKeyword(string keyword)
        {
            keyword = keyword.ToLower();
            var list = new List<Product>(Products);
            list = list.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
            ObservableCollection<Product> products = new ObservableCollection<Product>(list);
            return products;
        }
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
           _selectedProduct = (Product)ListBoxProducts.SelectedItem;
            Edit editt = new Edit();
            editt.Produ = ListBoxProducts.SelectedItem as Product;
                this.WindowState = WindowState.Normal;
                editt.Show();
        }
        private void DELETE_ELEMENT(object sender, MouseEventArgs e)
        {
           _selectedProduct = (Product)ListBoxProducts.SelectedItem;
            Edit editt = new Edit();
            editt.Produ = ListBoxProducts.SelectedItem as Product;
                this.WindowState = WindowState.Normal;
                editt.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your Order Taken,Thanks a lot","Information", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> itemsToRemove = new ObservableCollection<Product>();
            foreach (Product item in ListBoxProducts.SelectedItems)
            {
                itemsToRemove.Add(item);
            }
            foreach (Product item in itemsToRemove)
            {
                ((ObservableCollection<Product>)ListBoxProducts.ItemsSource).Remove(item);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Product> itemsToRemove = new ObservableCollection<Product>();
            foreach (Product item in ListBoxProducts.SelectedItems)
            {
                itemsToRemove.Add(item);
            }
            foreach (Product item in itemsToRemove)
            {
                ((ObservableCollection<Product>)ListBoxProducts.ItemsSource).Remove(item);
            }
        }
    }
}
