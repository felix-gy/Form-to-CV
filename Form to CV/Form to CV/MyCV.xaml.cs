using PdfSharp.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Form_to_CV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCV : ContentPage
    {
        public MyCV(string Name, string Age, string Occupation, string Nationality,string Number,string Email, List<String> Experience, List<String> Skill, List<String> Edu)
        {
            InitializeComponent();

            LabelName.Text = Name;
            LabelAge.Text = Age;
            LabelOccupation.Text = Occupation;
            LabelNationality.Text = Nationality;
            LabelNumber.Text = Number;
            LabelEmail.Text = Email;

            foreach(var i in Experience)
            {
                var label = new Label { Text = i };
                StackExp.Children.Add(label);
            }

            foreach (var i in Skill)
            {
                var label = new Label { Text = i };
                StackSkill.Children.Add(label);
            }

            foreach (var i in Edu)
            {
                var label = new Label { Text = i };
                StackEducation.Children.Add(label);
            }

        }


        private async void Button_Clicked_GeneratePDF(object sender, EventArgs e)
        {
            // Convertimos nuestro el contenido del cv en Pdf 
            var pdf = PDFManager.GeneratePDFFromView(CV_Content);
            string filename = "MyCV.pdf";

            string path = System.IO.Path.Combine(FileSystem.CacheDirectory, filename);

           //Guardando lo que convertimos en la direccion(path)
            pdf.Save(path);
            
            //Emportar mediante mensaje de Email
            var message = new EmailMessage
            {
                Subject = "",
                Body = "",
            };

            message.Attachments.Add(new EmailAttachment(path));

            await Email.ComposeAsync(message);

        }

    }
}