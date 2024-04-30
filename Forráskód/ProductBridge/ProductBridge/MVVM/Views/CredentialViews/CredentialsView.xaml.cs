using Newtonsoft.Json;
using ProductBridge.MVVM.Model;
using ProductBridge.Sync;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProductBridge.MVVM.View
{
    public partial class CredentialsView : Page
    {
        public string ApiKey { get; set; }
        public string WebsiteUrl { get; set; }

        public CredentialsView()
        {
            InitializeComponent();

            DataContext = this;

            // Utolsó mentett API kulcs és URL lekérdezése az adatbázisból
            RefreshLastWoosyncAuth();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string apiKey = ApiKey;
            string websiteUrl = WebsiteUrl;

            try
            {
                // Adatok mentése az adatbázisba
                ProductBridge.DataAccess.DataAccess dataAccess = new ProductBridge.DataAccess.DataAccess(App.Server, App.Database, App.Username, App.Password);
                dataAccess.InsertWoosyncAuth(apiKey, websiteUrl);

                // Inicializálás és szinkronizáció a WooCommerceSync osztállyal
                WooCommerceSync syncClient = new WooCommerceSync(websiteUrl, apiKey);
                await SyncData(syncClient);

                MessageBox.Show("Az adatok sikeresen mentve és szinkronizálva lettek.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok mentése és szinkronizálása közben: {ex.Message}");
            }
        }

        private async Task SyncData(WooCommerceSync syncClient)
        {
            // Itt lehet hívni a termékek és felhasználók szinkronizációját
           
            List<Product> productsToSync = new List<Product>(); // Ezt kell feltölteni a szinkronizálni kívánt termékekkel
            await syncClient.SyncProducts(productsToSync);

            
            List<User> usersToSync = new List<User>(); // Ezt kell feltölteni a szinkronizálni kívánt felhasználókkal
            await syncClient.SyncUsers(usersToSync);
        }

        private void RefreshLastWoosyncAuth()
        {
            try
            {
                // Utolsó mentett API kulcs és URL lekérdezése az adatbázisból
                ProductBridge.DataAccess.DataAccess dataAccess = new ProductBridge.DataAccess.DataAccess(App.Server, App.Database, App.Username, App.Password);
                (ApiKey, WebsiteUrl) = dataAccess.GetWoosyncAuth();

                // Ha üres az ApiKey vagy WebsiteUrl, inicializáljuk őket üres stringgel
                ApiKey ??= "";
                WebsiteUrl ??= "";

                // Utolsó mentett API kulcs és URL beállítása a megfelelő TextBox-okba
                ApiKeyTextBox.Text = ApiKey;
                WebsiteUrlTextBox.Text = WebsiteUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok lekérdezésekor: {ex.Message}");
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Adatok törlése az adatbázisból
                ProductBridge.DataAccess.DataAccess dataAccess = new ProductBridge.DataAccess.DataAccess(App.Server, App.Database, App.Username, App.Password);
                dataAccess.ResetData();

                ApiKey = "";
                WebsiteUrl = "";

                MessageBox.Show("Az adatok sikeresen törölve lettek.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok törlésekor: {ex.Message}");
            }
        }
    }
}
