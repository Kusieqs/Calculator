﻿using System;
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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberMethod(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string name = ((Button)sender).Name;
            if (OutputTextBlock.Text.Length <= 8)
            {
                OutputTextBlock.Text += btn.Content;
                OutputTextBlock.Text = Convert.ToDouble(OutputTextBlock.Text).ToString();
            }
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
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
            }
        }

        private void Comma(object sender, RoutedEventArgs e)
        {
            if (OutputTextBlock.Text.Length < 9 && !OutputTextBlock.Text.Contains(',')) 
            {
                if(OutputTextBlock.Text== "")
                {
                    return;
                }
                else
                {
                    OutputTextBlock.Text += ',';
                }
            }
        }
        private void NumberEqual(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(OutputTextBlock.Text) && TextToRead.Text.Split(' ').Length != 1)
            {
                Calculate();
            }
            else
            {
                TextToRead.Text = TextToRead.Text.Split(' ')[0];
            }
            
            OutputTextBlock.Text = "";

        }
        private void Operation(object sender, RoutedEventArgs e)
        {

            string operation = ((Button)sender).Content.ToString();

            if (OutputTextBlock.Text == "0" && TextToRead.Text.Split(' ')[1] == "/")
            {
                MessageBox.Show("You can't devide by zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (OutputTextBlock.Text == "")
                return;


            if (TextToRead.Text.Split(' ').Length == 2)
            {
                Calculate();
                TextToRead.Text = TextToRead.Text + " " + operation;
            }
            else
            {
                TextToRead.Text = OutputTextBlock.Text + " " + operation;
            }
            OutputTextBlock.Text = "";
        }
        private void Calculate()
        {   
            double a = double.Parse(TextToRead.Text.Split(' ')[0]);
            double b = double.Parse(OutputTextBlock.Text);

            string operation = TextToRead.Text.Split(' ')[1];
            switch(operation)
            {
                case "+":
                    TextToRead.Text = (a + b).ToString();
                    break;
                case "-":
                    TextToRead.Text = (a - b).ToString();
                    break;
                case "/":
                    TextToRead.Text = (a / b).ToString();
                    break;
                case "x":
                    TextToRead.Text = (a * b).ToString();
                    break;
            }
        }
    }
}
