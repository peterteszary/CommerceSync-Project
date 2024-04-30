/*
using WooCommerceNET.WooCommerce.v3;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProductBridge.MVVM.Model;

namespace ProductBridge.MVVM.View
{
    public partial class SyncPage : Page
    {
        private readonly string apiKey;
        private readonly string websiteUrl;
        private readonly WooCommerceAPI wooCommerceAPI;

        public SyncPage(string apiKey, string websiteUrl)
        {
            InitializeComponent();

            // Mentett API kulcs és weboldal URL elmentése
            this.apiKey = apiKey;
            this.websiteUrl = websiteUrl;

            // WooCommerceAPI inicializálása
            wooCommerceAPI = new WooCommerceAPI(websiteUrl, apiKey);
        }

        private async void PullProductsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Termékek lekérése a WooCommerce-ről
                List<Products> products = await wooCommerceAPI.Product.GetAll();

                // Termékek letöltése sikeres, itt lesz letöltött termékek listája
                // a products változó tartalmazza a letöltött termékeket
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a termékek letöltésekor: {ex.Message}");
            }
        }

        private async void PushProductsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Implementáld a termékek feltöltésének logikáját ide
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a termékek feltöltésekor: {ex.Message}");
            }
        }
    }
}
*/