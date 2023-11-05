using System;
using System.Collections.Generic;
using System.IO;
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
            Button btn = (Button)sender;
            string name = ((Button)sender).Name;
            if (output.Length <= 8)
            {
                output += btn.Content;
                output = Convert.ToDouble(output).ToString();
                OutputTextBlock.Text = output;
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
            if(double.Parse(OutputTextBlock.Text) >=0)
            {
                double sqrtTwo = double.Parse(OutputTextBlock.Text);
                sqrtTwo = Math.Sqrt(sqrtTwo);
                OutputTextBlock.Text = Math.Round(sqrtTwo, 2).ToString();
                output = OutputTextBlock.Text;
            }
            else
            {
                MessageBox.Show("You can't element a minus number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void Comma(object sender, RoutedEventArgs e)
        {
            if (OutputTextBlock.Text.Length < 9 && !OutputTextBlock.Text.Contains(',')) 
            {
                output += ',';
                OutputTextBlock.Text = output;
            }
        }

        private string ConvertComma(string number)
        {
            if (number[number.Length - 1] == ',')
                number = number.Remove(number.Length - 1);
            return number;
        }
        private void NumberEqual(object sender, RoutedEventArgs e)
        {
            if(output != "")
            {
                string convertedNumber = ConvertComma(output);
                output = convertedNumber;
            }
            else
            {
                output = "0";
            }

            string[] numbers = TextToRead.Text.Split(' ');
            string equal = ((Button)sender).Name;
            string historyOutPut = numbers[0];
            double a = double.Parse(numbers[0]);
            double b = double.Parse(OutputTextBlock.Text);

            if(equal == "equal")
            {
                if(numbers.Length < 2 || TextToRead.Text == "0")
                {
                    output = "0";
                    OutputTextBlock.Text = output;
                    return;
                }
                else
                {

                    switch(numbers[1])
                    {
                        case "+":
                            readOutput = (a + b).ToString();
                            break;
                        case "-":
                            readOutput = (a - b).ToString();
                            break;
                        case "x":
                            readOutput = (a * b).ToString();
                            break;
                        case "/":
                            if (double.Parse(OutputTextBlock.Text) == 0)
                            {
                                MessageBox.Show("You can't devide by zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                output = "";
                                return;
                            }

                            readOutput = (a / b).ToString();
                            break;
                    }

                    if (readOutput.Length < 18)
                        TextToRead.Text = readOutput;
                    else
                        readOutput = historyOutPut;

                    output = "0";
                    OutputTextBlock.Text = output;

                }
            }
            else
            {
                if (numbers.Length == 2)
                {
                    switch (operation)
                    {
                        case "plus":
                            readOutput = (a + b).ToString();
                            break;
                        case "minus":
                            readOutput = (a - b).ToString();
                            break;
                        case "division":
                            if (double.Parse(OutputTextBlock.Text) == 0)
                            {
                                MessageBox.Show("You can't devide by zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                output = "";
                                return;
                            }
                            readOutput = (a / b).ToString();
                            break;
                        case "multiplication":
                            readOutput = (a * b).ToString();
                            break;
                    }

                    switch (((Button)sender).Name)
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
                    switch (((Button)sender).Name)
                    {
                        case "plus":
                            readOutput = output.ToString() + " +";
                            break;
                        case "minus":
                            readOutput = output.ToString() + " -";
                            break;
                        case "division":
                            readOutput = output.ToString() + " /";
                            break;
                        case "multiplication":
                            readOutput = output.ToString() + " x";
                            break;
                    }
                }

                if(readOutput.Length <= 17)
                {
                    TextToRead.Text = readOutput;
                    OutputTextBlock.Text = "0";
                }
                else
                {
                    TextToRead.Text = historyOutPut;
                    readOutput = historyOutPut;
                    MessageBox.Show("Length of numbers are to big", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    OutputTextBlock.Text = "0";
                }
                output = "0";
                operation = ((Button)sender).Name;
            }
        }
    }
}
