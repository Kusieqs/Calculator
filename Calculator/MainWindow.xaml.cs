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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string readOutput = "";
        string output = "";

        string operation = "";
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
            readOutput = "";
            output = "";
            OutputTextBlock.Text = "0";
            TextToRead.Text = "0";
        }
        private void Element(object sender, RoutedEventArgs e)
        {
            double sqrtTwo = double.Parse(OutputTextBlock.Text);
            sqrtTwo = Math.Sqrt(sqrtTwo);
            OutputTextBlock.Text = Math.Round(sqrtTwo,2).ToString();
        }

        private void MinusOrPlus(object sender, RoutedEventArgs e)
        {
            if (OutputTextBlock.Text != "0")
            {
                double parse = double.Parse(OutputTextBlock.Text);
                parse = parse * -1;
                OutputTextBlock.Text = parse.ToString();
                output = parse.ToString();
            }
        }

        private void Equal(object sender, RoutedEventArgs e)
        {

        }

        private void Comma(object sender, RoutedEventArgs e)
        {
            output += ',';
            OutputTextBlock.Text = output;
        }

        private void NumberEqual(object sender, RoutedEventArgs e)
        {

            string[] numbers = TextToRead.Text.Split(' ');
            if (numbers.Length == 2)
            {
                double oldData = double.Parse(numbers[0]);
                double newData = double.Parse(output);
                switch (operation)
                {
                    case "plus":
                        readOutput = (oldData + newData).ToString();
                        break;
                    case "minus":
                        readOutput = (oldData - newData).ToString();
                        break;
                    case "division":
                        readOutput = (oldData / newData).ToString();
                        break;
                    case "multiplication":
                        readOutput = (oldData * newData).ToString();
                        break;
                }

                switch(((Button)sender).Name)
                {
                    case "plus":
                        readOutput += " +";
                        break;
                    case "minus":
                        readOutput += " -";
                        break;
                    case "division":
                        readOutput += " /";
                        break;
                    case "multiplication":
                        readOutput += " x";
                        break;
                }
            }
            else
            {
                switch(((Button)sender).Name)
                {
                    case "plus":
                        readOutput = OutputTextBlock.Text + " +";
                        break;
                    case "minus":
                        readOutput = OutputTextBlock.Text + " -";
                        break;
                    case "division":
                        readOutput = OutputTextBlock.Text + " /";
                        break;
                    case "multiplication":
                        readOutput = OutputTextBlock.Text + " x";
                        break;
                }
            }
            
            TextToRead.Text = readOutput;
            output = "";
            OutputTextBlock.Text = "0";
            operation = ((Button)sender).Name;
        }
    }
}
