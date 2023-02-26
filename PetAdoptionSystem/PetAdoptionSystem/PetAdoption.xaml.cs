using Newtonsoft.Json;
using PetAdoptionSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for PetAdoption.xaml
    /// </summary>
    public partial class PetAdoption : Window
    {
        HttpClient client = new HttpClient();
        public PetAdoption()
        {
            client.BaseAddress = new Uri("https://localhost:7227/api/Pet/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
               );
            InitializeComponent();

            this.GetPetData();
        }

        private async void GetPetData()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("GetAllPet");
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();
            Response res = JsonConvert.DeserializeObject<Response>(response);
            List<Pet> listPet = res.listPet;

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
        }

        private void Clear_btn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        public void clearData()
        {
            petIdT.Clear();
            petNameT.Clear();
            petAgeT.Clear();
            petGenderT.Clear();
            petClassT.Clear();
            isAdoptionT.Clear();
        }

        private void Adopt_Click(object sender, RoutedEventArgs e)
        {
            this.AdoptPet();
        }
        private async void AdoptPet()
        {
            Pet pet = new Pet();
            pet.petId = int.Parse(petIdT.Text);
            pet.petName = petNameT.Text;
            pet.petAge = int.Parse(petAgeT.Text);
            pet.petGender = petGenderT.Text;
            pet.petClass = petClassT.Text;
            pet.isAdoption = int.Parse(isAdoptionT.Text);

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync("AdoptPet", pet);
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();
            Response res = JsonConvert.DeserializeObject<Response>(response);
            if (res.StatusMessage.Equals("Pet Added"))
            {
                MessageBox.Show("Pet adopted");
            }
            else
            {
                MessageBox.Show("Adopted Fail!");
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            this.SearchPet();
        }
        private async void SearchPet()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("GetAllPetById/" + int.Parse(petIdT.Text));
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();

            Response res = JsonConvert.DeserializeObject<Response>(response);

            Pet pet = res.pet;

            if (pet != null)
            {
                petNameT.Text = pet.petName;
                petAgeT.Text = pet.petAge.ToString();
                petGenderT.Text = pet.petGender;
                petClassT.Text = pet.petClass;
                isAdoptionT.Text = pet.isAdoption.ToString();
            }
            else
            {
                MessageBox.Show("Pet not found!");
            }
        }

        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mWin = new MainWindow();
            this.Close();
            mWin.Show();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dataGrid.Items.Count > 0)
                {
                    petIdT.Text = ((DataRowView)dataGrid.SelectedItem).Row["petId"].ToString();
                    petNameT.Text = ((DataRowView)dataGrid.SelectedItem).Row["petName"].ToString();
                    petAgeT.Text = ((DataRowView)dataGrid.SelectedItem).Row["petAge"].ToString();
                    petGenderT.Text = ((DataRowView)dataGrid.SelectedItem).Row["petGender"].ToString();
                    petClassT.Text = ((DataRowView)dataGrid.SelectedItem).Row["petClass"].ToString();
                    isAdoptionT.Text = ((DataRowView)dataGrid.SelectedItem).Row["isAdoption"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
