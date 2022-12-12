using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
    }
}