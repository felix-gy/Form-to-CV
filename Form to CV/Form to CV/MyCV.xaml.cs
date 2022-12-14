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
        public MyCV(string Name, string Age, string Number,string Email, List<String> Experience, List<String> Skill, List<String> Edu)
        {
            InitializeComponent();
            
            //name.Text = Name;
            //age.Text = Age;
            //number.Text = Number;

            foreach(var i in Experience)
            {
                var label = new Label { Text = i };
            }

            foreach (var i in Skill)
            {
                var label = new Label { Text = i };

            }

            foreach (var i in Edu)
            {
                var label = new Label { Text = i };
            }


        }


        private async void Button_Clicked_GeneratePDF(object sender, EventArgs e)
        {
            // Convertimos nuestro GRID en PDF 
            var pdf = PDFManager.GeneratePDFFromView(CV_Content);

            //Nombre con el que se guardara el pdf
            string filename = "myCV.pdf";

            //Direccion donde se guardara
            string path = System.IO.Path.Combine(FileSystem.CacheDirectory, filename);

           //Guardando lo que convertimos en la direccion(path)
            pdf.Save(path);


            //var mensaje = new EmailMessage("My CV", "", "gordilloyucra@gmail.com");
            //await Email.ComposeAsync(mensaje);
            //pdf.Save(FileSystem.CacheDirectory);
            //MemoryStream pdfStream = new MemoryStream();
            //pdf.Save(pdfStream);
            //File.WriteAllText(file, "Hello World");



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