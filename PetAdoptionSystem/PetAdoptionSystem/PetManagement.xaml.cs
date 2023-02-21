using Newtonsoft.Json;
using PetAdoptionREST.Models;
using System;
using System.Collections.Generic;
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
        }
        private void Connection_Refresh_Click(object sender, RoutedEventArgs e)
        {
            this.displayPet();
        }
        private async void displayPet()
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
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            this.InsertPet();
            displayPet();
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
            ServerStatus.Content = response.StatusCode.ToString();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            this.UpdatePet();
            displayPet();
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

            HttpResponseMessage response = await client.PostAsJsonAsync<Pet>("UpdatePet", pet);
            ServerStatus.Content = response.StatusCode.ToString();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            this.SearchPet();
        }
        private void SearchPet()
        {
            HttpResponseMessage responseMessage = await client.GetAsync("GetAllPetById/" + petIdT.Text);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            this.DeletePet();
            displayPet();
        }
        private async void DeletePet()
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync("DeletePetById/" + int.Parse(petIdT.Text));
            responseMessage.EnsureSuccessStatusCode();
            string response = await responseMessage.Content.ReadAsStringAsync();
            Response res = JsonConvert.DeserializeObject<Response>(response);
        }

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
