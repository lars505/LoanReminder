using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using LoanRimender.Models;

namespace LoanRimender
{
    public partial class ListCliente : ContentPage
    {
        public ListCliente()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetClientesAsync();
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

            string res = await DisplayActionSheet("Desea Eliminar o Actualizar al Cliente.?", null, null, "Editar", "Eliminar");

            switch (res)
            {
                case "Editar":
                    await Navigation.PushAsync(new ACliente
                    {
                        BindingContext = e.SelectedItem as Rimender
                    });
                    break;
                case "Eliminar":
                    BindingContext = e.SelectedItem as Rimender;
                    var note = (Rimender)BindingContext;
                    await App.Database.DeleteClienteAsync(note);
                   await Navigation.PushAsync (new ListCliente(), true);
                    break;

            }

            //await Navigation.PushAsync(new NoteEntryPage
            //{
            //    BindingContext = e.SelectedItem as Note
            //});

        }
    }
}