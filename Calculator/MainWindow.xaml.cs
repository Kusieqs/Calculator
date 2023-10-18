using System;
using System.Collections.Generic;
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
        string oldOutput = "";
        string output = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberMethod(object sender, RoutedEventArgs e)
        {
            
            string name = ((Button)sender).Name;
            if (output.Length < 8)
            {
                switch (name)
                {
                    case "One":
                        output += "1";
                        OutputTextBlock.Text = output;
                        break;
                    case "Two":
                        output += "2";
                        OutputTextBlock.Text = output;
                        break;
                    case "Three":
                        output += "3";
                        OutputTextBlock.Text = output;
                        break;
                    case "Four":
                        output += "4";
                        OutputTextBlock.Text = output;
                        break;
                    case "Five":
                        output += "5";
                        OutputTextBlock.Text = output;
                        break;
                    case "Six":
                        output += "6";
                        OutputTextBlock.Text = output;
                        break;
                    case "Seven":
                        output += "7";
                        OutputTextBlock.Text = output;
                        break;
                    case "Eight":
                        output += "8";
                        OutputTextBlock.Text = output;
                        break;
                    case "Nine":
                        output += "9";
                        OutputTextBlock.Text = output;
                        break;
                    case "Zero":
                        output += "0";
                        OutputTextBlock.Text = output;
                        break;


                }

            }
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            oldOutput = "";
            output = "";
            OutputTextBlock.Text = "0";
            TextToRead.Text = oldOutput;
        }
        private void Plus(object sender, RoutedEventArgs e)
        {
            if(oldOutput == "")
            {
                oldOutput = output + " +";
                TextToRead.Text = oldOutput;
                output = "";
                OutputTextBlock.Text = "0";
            }
            else
            {
                string[] numbers = oldOutput.Split(' ');
                double oldData = double.Parse(numbers[0]);
                double newData = double.Parse(output);
                oldOutput = (oldData+newData).ToString() + " +";
                TextToRead.Text = oldOutput;
                output = "";
                OutputTextBlock.Text = "0";
            }
        }
        private void Minus(object sender, RoutedEventArgs e)
        {

        }

        private void Element(object sender, RoutedEventArgs e)
        {

        }

        private void MinusOrPlus(object sender, RoutedEventArgs e)
        {

        }

        private void Division(object sender, RoutedEventArgs e)
        {

        }

        private void Multiplication(object sender, RoutedEventArgs e)
        {

        }



        private void Equal(object sender, RoutedEventArgs e)
        {

        }

        private void Comma(object sender, RoutedEventArgs e)
        {

        }
    }
}
