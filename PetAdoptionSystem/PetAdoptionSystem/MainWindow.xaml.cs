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

namespace PetAdoptionSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void User_btn_Click(object sender, RoutedEventArgs e)
        {
            UserManagement userWin = new UserManagement();
            this.Close();
            userWin.Show();            
        }

        private void Pet_btn_Click(object sender, RoutedEventArgs e)
        {
            PetManagement petMagWin = new PetManagement();            
            this.Close();
            petMagWin.Show();
        }

        private void PetAdoption_btn_Click(object sender, RoutedEventArgs e)
        {
            PetAdoption petAdpWin = new PetAdoption();            
            this.Close();
            petAdpWin.Show();
        }
    }
}
