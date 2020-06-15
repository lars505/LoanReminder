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
    public partial class RPrestamo : ContentPage
    {
        public RPrestamo()
        {
            InitializeComponent();
        }

       
        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime NuevaFecha = Convert.ToDateTime(startDatePicker.Date);

            NuevaFecha = NuevaFecha.AddDays(24);
            endDatePicker.Date = NuevaFecha;
            // String.Format("{0:dd-MM-yyyy}", NuevaFecha);
            //fin.Text =  Convert.ToDateTime(NuevaFecha).ToString("dd-MM-yyyy");
        }
        private void Monto(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MontoI.Text))
            {
                DisplayAlert("Aviso!", "El cliente debe tener un Nombre y un Numero de cedula", "OK");
            }
            else
            {
                var MI = double.Parse(MontoI.Text);
                MI += MI * 0.20;

                var MF = MI;
                MontoF.Text = Convert.ToString(MF);
            }

        }
       
        async void BtnAddprestamo(object sender, EventArgs e)
        {
            var cliente = (Rimender)BindingContext;
            cliente.debe = true;
           cliente.FechaI = Convert.ToDateTime(startDatePicker.Date);
           cliente.FechaF = Convert.ToDateTime(endDatePicker.Date);
            //fechap.Text = fechai;
            //DisplayAlert("mensaje", fechai, "ok");
            cliente.MontoI = Convert.ToInt32(MontoI.Text);
            cliente.MontoF = Convert.ToInt32(MontoF.Text);

            await App.Database.SaveClienteAsync(cliente);
            await Navigation.PopAsync();

        }






    }
}