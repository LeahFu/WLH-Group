using Newtonsoft.Json;
using PetAdoptionREST.Models;
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
    /// Interaction logic for PetManagement.xaml
    /// </summary>
    public partial class PetManagement : Window
    {
        HttpClient client = new HttpClient();
        public PetManagement()
        {
            client.BaseAddress = new Uri("https://localhost:7227/api/Pet/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
               );
            InitializeComponent();

            this.GetPetData();
            petIdT.Clear();
            petNameT.Clear();
            petAgeT.Clear();
            petGenderT.Clear();
            petClassT.Clear();
            isAdoptionT.Clear();
        }

        private async void GetPetData()
        {
            Response response = client.GetFromJsonAsync<Response>("GetAllPet/").Result;

            //Response res = JsonConvert.DeserializeObject<Response>(response.ToString());
            //this.ServerStatus.Content = response..ToString();
            List<Pet> listPet = response.listPet;

            DataTable dt = new DataTable();
            dt.Columns.Add("petId", typeof(int));
            dt.Columns.Add("petName", typeof(string));
            dt.Columns.Add("petAge", typeof(int));
            dt.Columns.Add("petGender", typeof(string));
            dt.Columns.Add("petClass", typeof(string));
            dt.Columns.Add("isAdoption", typeof(int));

            for (int i = 0; i < listPet.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["petId"] = listPet[i].petId;
                row["petName"] = listPet[i].petName;
                row["petAge"] = listPet[i].petAge;
                row["petGender"] = listPet[i].petGender;
                row["petClass"] = listPet[i].petClass;
                row["isAdoption"] = listPet[i].isAdoption;
                dt.Rows.Add(row);
            }

            this.dataGrid.ItemsSource = dt.DefaultView;
        }

        private void Connection_Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.GetPetData();
            petIdT.Clear();
            petNameT.Clear();
            petAgeT.Clear();
            petGenderT.Clear();
            petClassT.Clear();
            isAdoptionT.Clear();
        }
       /* private async void displayPet()
        {
            await Task.Run(async () =>
            {
                HttpResponseMessage responseMessage = await client.GetAsync("GetAllPet");
                responseMessage.EnsureSuccessStatusCode();
                string response = await responseMessage.Content.ReadAsStringAsync();
                Response res = JsonConvert.DeserializeObject<Response>(response);
                List<Pet> pets = res.listPet;
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    dataGrid.ItemsSource = pets;
                }));
            });
        }*/
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            this.InsertPet();
            petIdT.Clear();
            petNameT.Clear();
            petAgeT.Clear();
            petGenderT.Clear();
            petClassT.Clear();
            isAdoptionT.Clear();
        }
        private async void InsertPet()
        {
            Pet pet = new Pet();
            pet.petId = int.Parse(petIdT.Text);
            pet.petName = petNameT.Text;
            pet.petAge = int.Parse(petAgeT.Text);
            pet.petGender = petGenderT.Text;
            pet.petClass = petClassT.Text;
            pet.isAdoption = int.Parse(isAdoptionT.Text);
            HttpResponseMessage response = await client.PostAsJsonAsync<Pet>("AddPet", pet);
            if (response.StatusCode.ToString().Equals("OK"))
            {
                MessageBox.Show("Inserted perfectly to the Database");
            }
            else
            {
                MessageBox.Show("Insert Fail!");
            }
            ServerStatus.Content = response.StatusCode.ToString();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            this.UpdatePet();
            petIdT.Clear();
            petNameT.Clear();
            petAgeT.Clear();
            petGenderT.Clear();
            petClassT.Clear();
            isAdoptionT.Clear();
        }
        private async void UpdatePet()
        {
            Pet pet = new Pet();
            pet.petId = int.Parse(petIdT.Text);
            pet.petName = petNameT.Text;
            pet.petAge = int.Parse(petAgeT.Text);
            pet.petGender = petGenderT.Text;
            pet.petClass = petClassT.Text;
            pet.isAdoption = int.Parse(isAdoptionT.Text);

            HttpResponseMessage response = await client.PostAsJsonAsync<Pet>("UpdatePet/", pet);
            if (response.StatusCode.ToString().Equals("OK"))
            {
                MessageBox.Show("Update Successfully");
            }
            else
            {
                MessageBox.Show("Update Fail!");
            }
            ServerStatus.Content = response.StatusCode.ToString();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            this.SearchPet();
        }
        private async void SearchPet()
        {
            // HttpResponseMessage responseMessage = await client.GetAsync("GetAllPetById/" + petIdT.Text);
            string Id = petIdT.Text;

            Response response = client.GetFromJsonAsync<Response>("GetPetByID/" + Id).Result;

            Pet pet = response.pet;

            if (pet != null)
            {
                petNameT.Text = pet.petName;
                petAgeT.Text = pet.petAge.ToString();
                petGenderT.Text = pet.petGender;
                petClassT.Text = pet.petClass;
                isAdoptionT.Text = pet.isAdoption.ToString();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            this.DeletePet();
            petIdT.Clear();
            petNameT.Clear();
            petAgeT.Clear();
            petGenderT.Clear();
            petClassT.Clear();
            isAdoptionT.Clear();
        }
        private async void DeletePet()
        {
            Pet pet = new Pet();
            pet.petId = int.Parse(petIdT.Text);

            HttpResponseMessage responseMessage = await client.DeleteAsync("DeletePetById/" + pet.petId);

            // responseMessage.EnsureSuccessStatusCode();
            // string response = await responseMessage.Content.ReadAsStringAsync();
            // Response res = JsonConvert.DeserializeObject<Response>(response);
            if (responseMessage.StatusCode.ToString().Equals("OK"))
            {
                MessageBox.Show("Delete Successfully");
            }
            else
            {
                MessageBox.Show("Delete Fail!");
            }
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
