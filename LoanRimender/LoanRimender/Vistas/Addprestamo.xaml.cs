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
    public partial class Addprestamo : ContentPage
    {
        private string name;


        public Addprestamo()
        {
            InitializeComponent();

        }

        //codigo anterior picker

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            PickerName.ItemsSource = await App.Database.GetListNewLoan();
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
                double MI = double.Parse(MontoI.Text);
                var INTE = int.Parse(porcentageinteres.Text);
                var interes = (INTE / 100);
                MI += MI * interes;
                
                var MF = MI;
                MontoF.Text = Convert.ToString(MF);

                

            }

        }
        private void SelectClieneOption(object sender, EventArgs e)
        {

            name = PickerName.Items[PickerName.SelectedIndex];

        }
        async void BtnAddprestamo(object sender, EventArgs e)
        {
            var prestamo = (LoanRimender.Modelos.Prestamo)BindingContext;
            prestamo.Nombre = name;
            prestamo.FechaI = Convert.ToDateTime(startDatePicker);
            prestamo.FechaF = Convert.ToDateTime(endDatePicker);
            prestamo.MontoI = Convert.ToInt32(MontoI.Text);
            prestamo.MontoF = Convert.ToInt32(MontoF.Text);
            prestamo.interes = Convert.ToInt32(interes.Text);
            prestamo.porcentageinteres = Convert.ToInt32(porcentageinteres.Text);

            await App.Database.SavePrestamoAsync(prestamo);
            await Navigation.PopAsync();

            DisplayAlert("Aviso", "El prestamo re realizo correctamente", "OK");


        }




    }
}