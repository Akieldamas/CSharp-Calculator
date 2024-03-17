using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double number1 = 0;
        double number2 = 0;
        double result = 1;
        const double pi = 3.1416;
        char operation = '0';



        public MainWindow()
        {

            InitializeComponent();
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");
        }

        public void BUTTON_Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            String btnContent = btn.Content.ToString();
            if (btnContent == "π")
            {
                btnContent = pi.ToString();
            }
            Display(btnContent.ToString());
            Check_For_Point();
        }

        public void BUTTON_Operation_Click(object sender, RoutedEventArgs e)
        {

            if (TB_Display.Text == "")
            {
                Button btn = sender as Button;
                operation = char.Parse(btn.Content.ToString());
            }

            if (result == 0 && TB_Display.Text != "")
            {
                number1 = 0;
                TB_Display_Clear();
                Button btn = sender as Button;
                operation = char.Parse(btn.Content.ToString());
            }
            else if (result != 0 && TB_Display.Text != "")
            {
                number1 = double.Parse(TB_Display.Text);
                TB_Display_Clear();
                Button btn = sender as Button;
                operation = char.Parse(btn.Content.ToString());
            }
            Check_For_Point();
        }

        private void Check_For_Point()
        {
            if (TB_Display.Text.Contains(','))
            {
                BUTTON_Point.IsEnabled = false;
                BUTTON_Pi.IsEnabled = false;
            }
            else
            {
                BUTTON_Point.IsEnabled = true;
                BUTTON_Pi.IsEnabled = true;
            }
        }

        private void BUTTON_Clear_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            TB_Display.Text = "0";
            BUTTON_Point.IsEnabled = true;
            BUTTON_Pi.IsEnabled = true;
        }

        private void TB_Display_Clear()
        {
            TB_Display.Text = "";
        }


        private void FunctionResult(double number1, double number2, char operation)
        {
            TB_Display_Clear();
            switch (operation)
            {

                case '+':
                    result = number1 + number2;

                    break;

                case '-':
                    result = number1 - number2;
                    break;

                case '*':
                    result = number1 * number2;
                    break;

                case '/':
                    if (number2 == 0)
                    {
                        result = 0;
                        break;
                    }
                    else
                    {
                        result = number1 / number2;

                    }
                    break;

                case '^':
                    result = Math.Pow(number1, number2);
                    break;

                case '√':
                    result = Math.Sqrt(result);
                    break;
            }
            if (number2 == 0 && operation == '/')
            {
                Display("Un nombre ne peut pas être divisé par " + result);
            }
            else
            {
                Display(result.ToString());
                Check_For_Point();
            }
            operation = '0';

        }

        public void Display(string num)
        {
            if (TB_Display.Text == "0")
            {
                TB_Display.Text = num;
            }
            else if (TB_Display.Text != "0")
            {
                TB_Display.Text = TB_Display.Text + num;
            }
        }

        private void BUTTON_Equal_Click(object sender, RoutedEventArgs e)
        {

            number2 = double.Parse(TB_Display.Text);
            TB_Display_Clear();
            FunctionResult(number1, number2, operation);

        }

        private void TB_Display_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void BUTTON_SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                number1 = double.Parse(TB_Display.Text);
                result = Math.Sqrt(number1);
                TB_Display_Clear();
                Display(result.ToString());

                Check_For_Point();
            }
        }

        private void BUTTON_Sin_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                result = Math.Sin(double.Parse(TB_Display.Text));
                TB_Display_Clear();
                Display(result.ToString());
                Check_For_Point();
            }
        }
        private void BUTTON_Cos_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                result = Math.Cos(double.Parse(TB_Display.Text));
                TB_Display_Clear();
                Display(result.ToString());
                Check_For_Point();
            }
        }

        private void BUTTON_Tan_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                result = Math.Tan(double.Parse(TB_Display.Text));
                TB_Display_Clear();
                Display(result.ToString());
                Check_For_Point();
            }
        }
        private void BUTTON_Point_Click(object sender, RoutedEventArgs e)
        {
            Display(",");
            BUTTON_Point.IsEnabled = false;
            BUTTON_Pi.IsEnabled = false;
        }

        private void BUTTON_Exponential_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                result = Math.Exp(double.Parse(TB_Display.Text));
                TB_Display_Clear();
                Display(result.ToString());
                Check_For_Point();
            }
        }
        private void BUTTON_Log_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text != "")
            {
                result = Math.Log(double.Parse(TB_Display.Text));
                TB_Display_Clear();
                Display(result.ToString());
                Check_For_Point();
            }
        }

    }
}