using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            rdPostcard.IsChecked = true;
            
        }

        private void rdPostcard_Checked(object sender, RoutedEventArgs e)
        {
            txtPrice.Content = "Cena: 1.50 zł";

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"Images/postcard.png", UriKind.Relative);
            image.EndInit();
            imgTIcon.Source = image;
        }

        private void rdLetter_Checked(object sender, RoutedEventArgs e)
        {
            txtPrice.Content = "Cena: 2 zł";

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"Images/letter.png", UriKind.Relative);
            image.EndInit();
            imgTIcon.Source = image;
        }

        private void rdPackage_Checked(object sender, RoutedEventArgs e)
        {
            txtPrice.Content = "Cena: 10 zł";

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"Images/pack.png", UriKind.Relative);
            image.EndInit();
            imgTIcon.Source = image;
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string phoneNumber = txtNumber.Text;
            string pttnName = @"^[A-Za-z0-9._%+-]+@[a-zA-Z0-9._]+\.[a-zA-Z]{2,}$";
            string pttnNumber = @"^\+\d{2} \d{3}-\d{3}-\d{3}$";

            if (!Regex.IsMatch(email, pttnName))
            {
                MessageBox.Show("Adres e-mail jest niepoprawny", "BŁĄD", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (!Regex.IsMatch(phoneNumber, pttnNumber)) 
                {
                    MessageBox.Show("Numer telefonu jest niepoprawny", "BŁĄD", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    txtDesc.Text = Regex.Replace(txtDesc.Text, @"\s+", " ");
                    MessageBox.Show("Dane przesyłki zostały wprowadzone poprawnie", "SUKCES", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
 
        }
    }
}
