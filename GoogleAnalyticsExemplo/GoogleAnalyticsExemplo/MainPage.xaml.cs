using GoogleAnalyticsExemplo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoogleAnalyticsExemplo
{
    public partial class MainPage : ContentPage
    {
        private int contador = 0;

        public MainPage()
        {
            //ira enviar o valor de acordo com a plataforma
            //Android 
            
            if (Device.RuntimePlatform == Device.Android)
            {
                AnalyticsService.RastrearPage("Android HomePage");
            }
            // iOS
            else
            {
                AnalyticsService.RastrearPage("iOS HomePage");
            }

            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            AnalyticsService.RastrearEvento("Contador", "Botão apertado " + contador++);
        }
    }
}
