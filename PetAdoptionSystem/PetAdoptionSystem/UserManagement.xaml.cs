using Newtonsoft.Json;
using PetAdoptionSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PetAdoptionSystem
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Window
    {
        static HttpClient client = new HttpClient();
        public UserManagement()
        {
            client.BaseAddress = new Uri("https://localhost:7227/api/User/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
               );
            InitializeComponent();
            ListUser();
        }

        private async void ListUser()
        {
            await Task.Run(async () =>
            {
                HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7227/api/User/GetAllUsers");
                responseMessage.EnsureSuccessStatusCode();
                string response = await responseMessage.Content.ReadAsStringAsync();
                Response res = JsonConvert.DeserializeObject<Response>(response);
                List<User> userList = res.listUser;
                DataTable dt = new DataTable();
                dt.Columns.Add("UserId", typeof(int));
                dt.Columns.Add("UserName", typeof(string));
                dt.Columns.Add("UserPwd", typeof(string));
                dt.Columns.Add("UserAddress", typeof(string));
                dt.Columns.Add("UserAge", typeof(int));
                dt.Columns.Add("UserEmail", typeof(string));
                dt.Columns.Add("IsAdmin", typeof(int));

                for (int i = 0; i < userList.Count; i++)
                {
                    DataRow row = dt.NewRow();
                    row["UserId"] = userList[i].userId;
                    row["UserName"] = userList[i].userName;
                    row["UserPwd"] = userList[i].userPwd;
                    row["UserAddress"] = userList[i].userAddress;
                    row["UserAge"] = userList[i].userAge;
                    row["UserEmail"] = userList[i].userEmail;
                    row["IsAdmin"] = userList[i].isAdmin;

                    dt.Rows.Add(row);
                }

                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    DataGrid_User.ItemsSource = dt.DefaultView;
                }));

            });
        }

        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mWin = new MainWindow();
            this.Close();
            mWin.Show();
        }

        private void AddUser_btn_Click(object sender, RoutedEventArgs e)
        {
            addUser();
            ListUser();
        }

        private async void addUser()
        {
            User user = new User();
            user.userId = int.Parse(UserID_tbx.Text);
            user.userName = UserName_tbx.Text;
            user.userPwd = UserPwd_tbx.Text;
            user.userAddress = UserAdd_tbx.Text;
            user.userAge = int.Parse(UserAge_tbx.Text);
            user.userEmail = UserEmail_tbx.Text;
            user.isAdmin = int.Parse(UserIsAdmin_tbx.Text);

            HttpResponseMessage response = await client.PostAsJsonAsync("AddUser/", user);
            if (response.StatusCode.ToString().Equals("OK"))
            {
                MessageBox.Show("Insert successful!");
            }
            else
            {
                MessageBox.Show("Insert Fail!");
            }
        }


        private void UpdateUser_btn_Click(object sender, RoutedEventArgs e)
        {
            updateUser();
            ListUser();
        }

        private async void updateUser()
        {
            User user = new User();
            user.userId = int.Parse(UserID_tbx.Text);
            user.userName = UserName_tbx.Text;
            user.userPwd = UserPwd_tbx.Text;
            user.userAddress = UserAdd_tbx.Text;
            user.userAge = int.Parse(UserAge_tbx.Text);
            user.userEmail = UserEmail_tbx.Text;
            user.isAdmin = int.Parse(UserIsAdmin_tbx.Text);

            HttpResponseMessage response = await client.PutAsJsonAsync("UpdateUser/", user);
            if (response.StatusCode.ToString().Equals("OK"))
            {
                MessageBox.Show("Update successful!");
            }
            else
            {
                MessageBox.Show("Update Fail!");
            }
        }


        private void SearchUser_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteUser_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_User_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DataGrid_User.Items.Count > 0)
                {
                    UserID_tbx.Text = ((DataRowView)DataGrid_User.SelectedItem).Row["UserId"].ToString();
                    UserName_tbx.Text = ((DataRowView)DataGrid_User.SelectedItem).Row["UserName"].ToString();
                    UserPwd_tbx.Text = ((DataRowView)DataGrid_User.SelectedItem).Row["UserPwd"].ToString();
                    UserAdd_tbx.Text = ((DataRowView)DataGrid_User.SelectedItem).Row["UserAddress"].ToString();
                    UserAge_tbx.Text = ((DataRowView)DataGrid_User.SelectedItem).Row["UserAge"].ToString();
                    UserEmail_tbx.Text = ((DataRowView)DataGrid_User.SelectedItem).Row["UserEmail"].ToString();
                    UserIsAdmin_tbx.Text = ((DataRowView)DataGrid_User.SelectedItem).Row["IsAdmin"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

