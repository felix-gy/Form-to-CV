using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Form_to_CV
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string name = EntryName.Text;
            string age = EntryAge.Text;
            string contact = EntryContact.Text;
            string occupation = EntryOccupation.Text;
            string skill = EntrySkill.Text;
            string education = EntryEducation.Text;
            Application.Current.MainPage.Navigation.PushModalAsync(new MyCV(name, age, contact, occupation, skill, education), true);
        }

        private void Button_Clicked_Ocupation(object sender, EventArgs e)
        {
            var entry = new Entry() { Placeholder = "Enter your occupation" };
            ocupation.Children.Add(entry);

        }
        private void Button_Clicked_Skill(object sender, EventArgs e)
        {
            var entry = new Entry() { Placeholder = "Enter your skill" };
            skill.Children.Add(entry);
        }
        private void Button_Clicked_Education(object sender, EventArgs e)
        {
            var entry = new Entry() { Placeholder = "Enter your Education" };
            education.Children.Add(entry);
        }
    }
}
