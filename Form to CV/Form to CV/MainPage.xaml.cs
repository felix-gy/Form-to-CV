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
            // Experience 
            List<String> exp_list = new List<String>();

            var expList = Layout_experience.Children.ToList();

            foreach (var i in expList)
            {
                var myEntry = i as Entry;
                exp_list.Add(myEntry.Text);
            }

            // Skills
            List<String> skill_list = new List<String>();

            var skillsList = Layout_skill.Children.ToList();

            foreach (var i in skillsList)
            {
                var myEntry = i as Entry;
                skill_list.Add(myEntry.Text);
            }

            // Education
            List<String> edu_list = new List<String>();

            var eduList = Layout_education.Children.ToList();

            foreach (var i in eduList)
            {
                var myEntry = i as Entry;
                edu_list.Add(myEntry.Text);
            }

            string name = EntryName.Text;
            string age = EntryAge.Text;
            string ocup = EntryOccupation.Text;
            string nat = EntryNationality.Text;
            string number = EntryNumber.Text;
            string email = EntryEmail.Text;
            /*
            string experience = EntryExperience.Text;
            string skill = EntrySkill.Text;
            string education = EntryEducation.Text;
            */
            Application.Current.MainPage.Navigation.PushModalAsync(new MyCV(name, age, ocup, nat, number, email, exp_list, skill_list, edu_list), true);
        }

        private void Button_Clicked_Experience(object sender, EventArgs e)
        {
            var entry = new Entry() { Placeholder = "Enter your experience" };
            Layout_experience.Children.Add(entry);

        }
        private void Button_Clicked_Skill(object sender, EventArgs e)
        {
            var entry = new Entry() { Placeholder = "Enter your skill" };
            Layout_skill.Children.Add(entry);
        }
        private void Button_Clicked_Education(object sender, EventArgs e)
        {
            var entry = new Entry() { Placeholder = "Enter your education" };
            Layout_education.Children.Add(entry);
        }
    }
}
