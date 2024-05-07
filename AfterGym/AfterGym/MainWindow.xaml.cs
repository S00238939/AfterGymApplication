using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AfterGym
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Reps = 0;
        int Sets = 0;
        int Calories = 0;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            string ph;
            if (lbx_Workout.SelectedItem == null)
            {
                ph = "";
            }
            else
            {
                ph = lbx_Workout.SelectedItem.ToString();
            }
            int reps = int.Parse(ph.Substring(16, 15));
            int sets = int.Parse(ph.Substring(32, 15));
            Sets = Sets - sets;
            Reps = Reps - (reps * sets);
            Calories = Reps;
            string calories = Calories.ToString();
            tblk_Reps.Content = Reps;
            tblk_Sets.Content = Sets;
            tblk_Calories.Text = calories;
            lbx_Workout.Items.Remove(lbx_Workout.SelectedItem);
        }

        public string Workout()
        {
            string workoutType = tbx_Workouts.Text;
            int NoOfReps = int.Parse(tbx_Reps.Text);
            int NoOfSets = int.Parse(tbx_Sets.Text);
            string workoutFormat = $"{workoutType,-15}/{NoOfReps,-15}/{NoOfSets,-15}";
            Reps = Reps + (NoOfReps * NoOfSets);
            Sets = Sets + NoOfSets;
            Calories = Reps;
            string calories = Calories.ToString();
            tblk_Reps.Content = Reps;
            tblk_Sets.Content = Sets;
            tblk_Calories.Text = calories;
            return workoutFormat;
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            lbx_Workout.Items.Add(Workout().ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void tbx_Reps_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbx_Reps.Text = "";
        }

        private void tbx_Sets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbx_Sets.Text = "";
        }

        private void tbx_Workouts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbx_Workouts.Text = "";
        }

        private void btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double BMR = 0;
            int age = int.Parse(tbx_Age.Text);
            double height = double.Parse(tbx_Height.Text);
            double weight = double.Parse(tbx_Weight.Text);
            double bmi = weight / Math.Pow(height, 2);
            string bmiText = bmi.ToString();
            if (cb_Female.IsChecked == true)
            {
                BMR = (10 * weight) + (6.25 * (height * 100)) - (5 * age) - 161;
                tblk_sgender.Text = "Female";
            }
            else if (cb_Male.IsChecked == true)
            {
                BMR = (10 * weight) + (6.25 * (height * 100)) - (5 * age) + 5;
                tblk_sgender.Text = "Male";
            }
            string bmrText = BMR.ToString();
            if (bmi >= 25)
            {
                tblk_Results.Text = "A BMI greator than 25 means you are overweight, a diet of " + (BMR - 500) + " calories with a combination of more daily activity will make a difference!";
            }
            else if (bmi < 25)
            {
                tblk_Results.Text = "A BMI less than 25 means you are a healthy weight, maintaining a diet of " + BMR + "+ calories a day depending on your exercise level will stop you from gaining unwanted weight";
            }
            tblk_BMI.Text = bmiText;
            tblk_BMR.Text = bmrText;
            tblk_sBMI.Text = bmiText;
            tblk_dburn.Text = bmrText;
            tblk_sheight.Text = height.ToString();
            tblk_sweight.Text = weight.ToString();
            double pi = weight * 0.8;
            tblk_rprotien.Text = pi.ToString();
            if (tblk_wburn.Text != "")
            {
                int wb = int.Parse(tblk_wburn.Text);
                int db = int.Parse(tblk_dburn.Text);
                int tb = wb + db;
                tblk_tburn.Text = tb.ToString();
            }
        }

        private void tbx_Height_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbx_Height.Text = "";
        }

        private void tbx_Weight_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbx_Weight.Text = "";
        }

        private void cb_Male_Checked(object sender, RoutedEventArgs e)
        {
            cb_Female.IsChecked = false;
        }

        private void cb_Female_Checked(object sender, RoutedEventArgs e)
        {
            cb_Male.IsChecked = false;
        }

        private void tbx_Age_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            tbx_Age.Text = "";
        }

        private void btn_SaveWorkout_Click(object sender, RoutedEventArgs e)
        {
            int wburn = int.Parse(tblk_Calories.Text);
            tblk_wburn.Text = wburn.ToString();
            if (tblk_dburn.Text != "")
            {
                int wb = int.Parse(tblk_wburn.Text);
                int db = int.Parse(tblk_dburn.Text);
                int tb = wb + db;
                tblk_tburn.Text = tb.ToString();
            }
        }

        private void tblk_sheight_MouseEnter(object sender, MouseEventArgs e)
        {
            tblk_description.Text = "Height is important when it comes to measuring fitness levels as taller individuals burn more energy but also tend to have bigger bones that store more muscle and fat while shorter individuals are more efficient.";
        }

        private void tblk_sweight_MouseEnter(object sender, MouseEventArgs e)
        {
            tblk_description.Text = "Weight is probably the most important part of fitness as this statistic takes a large effect on an individual in many aspects of their life, weight can quiet literally weigh you down causing more energy to be used up for even basic actions this will leave the individual feeling fatigue.";
        }

        private void tblk_sgender_MouseEnter(object sender, MouseEventArgs e)
        {
            tblk_description.Text = "Gender makes a difference when it comes to your metabolic rate as gender determines different maintainance needs for example, a male would require more energy than a female because males tend to be larger than females and have different composition densities that take a factor in BMR.";
        }

        private void tblk_dburn_MouseEnter(object sender, MouseEventArgs e)
        {
            tblk_description.Text = "BMR stands for basic metabolic rate and this is the measurement of the total number of calories your body will burn just surviving on a daily basis this is useful as it allows us to control our bodies weight";
        }

        private void tblk_wburn_MouseEnter(object sender, MouseEventArgs e)
        {
            tblk_description.Text = "Working out isnt really a efficient way to burn calories but it is useful to keep track of extra calories burnt as this will make a difference on your weight maintainance";
        }

        private void tblk_tburn_MouseEnter(object sender, MouseEventArgs e)
        {
            int calories = 0;
            string cal;
            if (tblk_tburn.Text == "")
            {
                calories = 0;
                cal = calories.ToString();
            }
            else
            {
                calories = int.Parse(tblk_tburn.Text);
                cal = calories.ToString();
            }
            int deficit = calories - 500;
            tblk_description.Text = $"Total calories burnt this will allow us to determine how many calories we can eat a day and what calories we need to lose or gain weight for example: {cal}-500 = {deficit} will allow a weekly loss of 3500 calories a week which is equivelant to 1 pound of fat";
        }

        private void tblk_rprotien_MouseEnter(object sender, MouseEventArgs e)
        {
            tblk_description.Text = "Protein intake is essental as you will need to intake proteins that get broken down throughout the day + workout in order to actually build muscle, otherwise your body will be unable to maintain, nevermind grow muscle density.";
        }

        private void tblk_sBMI_MouseEnter(object sender, MouseEventArgs e)
        {
            tblk_description.Text = "BMI is very important to keep track of as it measures suitable weight to height ratio where your weight will not become troublesome in your day to day routine";
        }
    }
}