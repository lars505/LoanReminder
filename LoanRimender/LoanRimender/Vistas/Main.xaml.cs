using LoanRimender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoanRimender.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        public Main()
        {
            InitializeComponent();
        }

        async void Addnewuser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ACliente { BindingContext = new Rimender() });
        }

        private void ClientesList(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListCliente());
        }

       

        private void NPassword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NPass());
        }
    }
}