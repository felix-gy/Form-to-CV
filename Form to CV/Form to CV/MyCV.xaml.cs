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
        public MyCV(string Name, string Age, string Contact, string Occupation, string Skill, string Edu)
        {
            InitializeComponent();

            name.Text = Name;
            age.Text = Age;
            contact.Text = Contact;
            occupation.Text = Occupation;
            skill.Text = Skill;
            education.Text = Edu;

        }

        private async void Button_Clicked_GeneratePDF(object sender, EventArgs e)
        {
            var pdf = PDFManager.GeneratePDFFromView(CV_Content);
            string filename = "mypdf.pdf";
            string path = System.IO.Path.Combine(FileSystem.CacheDirectory, filename);
            pdf.Save(path);

            //var mensaje = new EmailMessage("My CV", "", "gordilloyucra@gmail.com");
            //await Email.ComposeAsync(mensaje);
            //pdf.Save(FileSystem.CacheDirectory);
            //MemoryStream pdfStream = new MemoryStream();
            //pdf.Save(pdfStream);
            //File.WriteAllText(file, "Hello World");

      
            var message = new EmailMessage
            {
                Subject = "Hello",
                Body = "World",
            };

            message.Attachments.Add(new EmailAttachment(path));

            await Email.ComposeAsync(message);
            

        }

    }
}