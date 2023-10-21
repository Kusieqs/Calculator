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
            
            string name = ((Button)sender).Name;
            if (output.Length < 8)
            {
                switch (name)
                {
                    case "One":
                        output += "1";
                        break;
                    case "Two":
                        output += "2";
                        break;
                    case "Three":
                        output += "3";
                        break;
                    case "Four":
                        output += "4";
                        break;
                    case "Five":
                        output += "5";
                        break;
                    case "Six":
                        output += "6";
                        break;
                    case "Seven":
                        output += "7";
                        break;
                    case "Eight":
                        output += "8";
                        break;
                    case "Nine":
                        output += "9";
                        break;
                    case "Zero":
                        output += "0";
                        break;


                }
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

        private void Comma(object sender, RoutedEventArgs e)
        {
            output += ',';
            OutputTextBlock.Text = output;
        }

        private void NumberEqual(object sender, RoutedEventArgs e)
        {
            string[] numbers = TextToRead.Text.Split(' ');
            string equal = ((Button)sender).Name;

            double a = double.Parse(numbers[0]);
            double b = double.Parse(OutputTextBlock.Text);

            if(equal == "equal")
            {
                if(numbers.Length < 2)
                {
                    if(TextToRead.Text != "0")
                    {
                        OutputTextBlock.Text = numbers[0];
                        output = numbers[0];
                    }
                }
                else
                {
                    switch(numbers[1])
                    {
                        case "+":
                            output = (a + b).ToString();
                            break;
                        case "-":
                            output = (a - b).ToString();
                            break;
                        case "x":
                            output = (a * b).ToString();
                            break;
                        case "/":
                            if (double.Parse(OutputTextBlock.Text) == 0)
                            {
                                MessageBox.Show("You can't devide by zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                output = "";
                                return;
                            }

                            output = (a / b).ToString();
                            break;
                    }
                    OutputTextBlock.Text = output;
                    readOutput = "0";
                    TextToRead.Text = readOutput;
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
}
