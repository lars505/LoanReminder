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
        int name;


        public Addprestamo()
        {
            InitializeComponent();

        }

        //new codigo de prueba

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetListNewLoan();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ACliente
            {
                BindingContext = new Rimender()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            await Navigation.PushAsync(new RPrestamo
            {
                BindingContext = e.SelectedItem as Rimender
            });
        }
    





            // codigo anterior picker

            //        protected override async void OnAppearing()
            //        {
            //            base.OnAppearing();

            //            PickerName.ItemsSource = await App.Database.GetClientesAsync();
            //        }
            //        private void OnDateSelected(object sender, DateChangedEventArgs e)
            //        {
            //            DateTime NuevaFecha = Convert.ToDateTime(startDatePicker.Date);

            //            NuevaFecha = NuevaFecha.AddDays(24);
            //            endDatePicker.Date = NuevaFecha;
            //            // String.Format("{0:dd-MM-yyyy}", NuevaFecha);
            //            //fin.Text =  Convert.ToDateTime(NuevaFecha).ToString("dd-MM-yyyy");
            //        }
            //        private void Monto(object sender, TextChangedEventArgs e)
            //        {
            //            if (string.IsNullOrWhiteSpace(MontoI.Text))
            //            {
            //                DisplayAlert("Aviso!", "El cliente debe tener un Nombre y un Numero de cedula", "OK");
            //            }
            //            else
            //            {
            //                var MI = double.Parse(MontoI.Text);
            //                MI += MI * 0.20;

            //                var MF = MI;
            //                MontoF.Text = Convert.ToString(MF);
            //            }

            //        }
            //        private async void SelectClieneOption(object sender, EventArgs e)
            //        {

            //         name  = Convert.ToInt32(  PickerName.Items[PickerName.SelectedIndex]);

            //           //BindingContext = e. as Rimender;

            ////            DisplayAlert(name, "selected value", "ok")
            //        // nombre.Text = name;
            //        }
            //         async void BtnAddprestamo(object sender, EventArgs e)
            //                {
            //                   var cliente = (Rimender)BindingContext;
            //                    cliente.ID = name;
            //            cliente.Nombre = "Angelito";

            //                //    cliente.FechaI = Convert.ToDateTime(startDatePicker);
            //                //    cliente.FechaF = Convert.ToDateTime(endDatePicker);
            //                //    cliente.MontoI = Convert.ToInt32(MontoI.Text);
            //                //    cliente.MontoF = Convert.ToInt32(MontoF.Text);

            //                 await App.Database.SaveClienteAsync(cliente);
            //                await Navigation.PopAsync();


            //                }



        
    }
}