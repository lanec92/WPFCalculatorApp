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

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNum, result;
        SelectedOperator selectOperator;

        public MainWindow()
        {
            InitializeComponent();

            btnAc.Click += BtnAc_Click;
            btnNegative.Click += BtnNegative_Click;
            btnPercent.Click += BtnPercent_Click;
            btnEqual.Click += BtnEqual_Click;
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            double newNum;

            if (double.TryParse(lblResult.Content.ToString(), out newNum))
            {
                switch(selectOperator)
                {
                    case SelectedOperator.Addition:
                        result = MathOperation.Add(lastNum, newNum);
                        break;
                    case SelectedOperator.Subtraction:
                        result = MathOperation.Subtract(lastNum, newNum);
                        break;
                    case SelectedOperator.Multiplication:
                        result = MathOperation.Multiply(lastNum, newNum);
                        break;
                    case SelectedOperator.Division:
                        result = MathOperation.Divide(lastNum, newNum);
                        break;

                }

                lblResult.Content = result.ToString();
            }
        }

        private void BtnPercent_Click(object sender, RoutedEventArgs e)
        {
            double temp;

            if (double.TryParse(lblResult.Content.ToString(), out temp))
            {
                temp = temp / 100;
                
                if(lastNum != 0)
                {
                    temp *= lastNum;
                }

                lblResult.Content = temp.ToString();
            }
        }

        private void BtnNegative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNum))
            {
                if (lastNum == 0)
                {
                    lblResult.Content = lastNum.ToString();
                }
                else
                {
                    lastNum = lastNum * -1;
                    lblResult.Content = lastNum.ToString();
                }
            }
        }

        private void BtnAc_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
        }

        private void OperatorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNum))
            {
                lblResult.Content = "0";
                result = 0;
                lastNum = 0;
            }

            if (sender == btnMultiply)
                selectOperator = SelectedOperator.Multiplication;
            if (sender == btnDivide)
                selectOperator = SelectedOperator.Division;
            if (sender == btnPlus)
                selectOperator = SelectedOperator.Addition;
            if (sender == btnSubtract)
                selectOperator = SelectedOperator.Subtraction;


        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content.ToString().Contains("."))
            {
                //Do Nothing
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}.";

            }
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {

            //int numPressed = int.Parse(((System.Windows.Controls.ContentControl)sender).Content.ToString()); //Would also work
            int numPressed = int.Parse((sender as Button).Content.ToString());

            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = $"{numPressed}";
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}{numPressed}";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
