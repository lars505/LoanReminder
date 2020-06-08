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
    public partial class NPass : ContentPage
    {
        public NPass()
        {
            InitializeComponent();
        }

        private void Savepass(object sender, EventArgs e)
        {
            if(CPass.Text != Pass.Text)
            {
                message.Text = "Contaseña Incorrecta";
            }
            else
            {
                message.Text = "Contraseña correcta";
            }
        }
    }
}