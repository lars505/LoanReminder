using System;
using System.IO;
using Xamarin.Forms;
using LoanRimender.Models;
using LoanRimender;

namespace LoanRimender
{
    public partial class ACliente : ContentPage
    {
        public ACliente()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Rimender)BindingContext;
            
            await App.Database.SaveClienteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Rimender)BindingContext;
            await App.Database.DeleteClienteAsync(note);
            await Navigation.PopAsync();
        }
    }
}