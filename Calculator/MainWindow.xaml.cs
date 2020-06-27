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
        double lastNumber, result;
        OperatorType selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            
            
            acButton.Click += AcButton_Click;
            negateButton.Click += NegateButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equaltoButton.Click += EqualtoButton_Click;
            decimalButton.Click += DecimalButton_Click;

            /*
            The slightly more efficient way to define number buttons, but it should be done in XAML.

            nineButton.Click += NumberButton_Click;
            eightButton.Click += NumberButton_Click;
            sevenButton.Click += NumberButton_Click;
            sixButton.Click += NumberButton_Click;
            fiveButton.Click += NumberButton_Click;
            fourButton.Click += NumberButton_Click;
            threeButton.Click += NumberButton_Click;
            twoButton.Click += NumberButton_Click;
            oneButton.Click += NumberButton_Click;
            zeroButton.Click += NumberButton_Click;
            */

            /*
            Inefficient way to define number buttons.

            nineButton.Click += NineButton_Click;
            eightButton.Click += EightButton_Click;
            sevenButton.Click += SevenButton_Click;
            sixButton.Click += SixButton_Click;
            fiveButton.Click += FiveButton_Click;
            fourButton.Click += FourButton_Click;
            threeButton.Click += ThreeButton_Click;
            twoButton.Click += TwoButton_Click;
            oneButton.Click += OneButton_Click;
            zeroButton.Click += ZeroButton_Click;
            */
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if(sender == addButton)
            {
                selectedOperator = OperatorType.Addition;
            }
            if (sender == subtractButton)
            {
                selectedOperator = OperatorType.Subtraction;
            }
            if (sender == multiplyButton)
            {
                selectedOperator = OperatorType.Multiplication;
            }
            if (sender == divideButton)
            {
                selectedOperator = OperatorType.Division;
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
                selectedValue = 0;
            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

        /*
        Inefficient way to define number buttons.

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "0";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}0";
            }
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "1";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}1";
            }
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "2";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}2";
            }
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "3";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}3";
            }
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "4";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}4";
            }
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "5";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}5";
            }
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "6";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}6";
            }
        }

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "7";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}7";
            }
        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "8";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}8";
            }
        }

        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = "9";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}9";
            }
        }
        */

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString().Contains("."))
            {
                //Do Nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void EqualtoButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case OperatorType.Addition:
                        result = SimpleMath.Addition(lastNumber, newNumber);
                        break;
                    case OperatorType.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, newNumber);
                        break;
                    case OperatorType.Multiplication:
                        result = SimpleMath.Multiplication(lastNumber, newNumber);
                        break;
                    case OperatorType.Division:
                        result = SimpleMath.Division(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }
        }
        
        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber /= 100;
                if(lastNumber != 0)
                {
                    tempNumber *= lastNumber;
                }
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegateButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }
    }

    public enum OperatorType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Addition(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public static double Subtraction(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        public static double Multiplication(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public static double Division(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                MessageBox.Show("Cannot Divide by Zero", "Invalid Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return firstNumber / secondNumber;
        }
    }
}
