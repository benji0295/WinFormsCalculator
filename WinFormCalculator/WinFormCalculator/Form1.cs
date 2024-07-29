using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalculator
{
    public partial class Form1 : Form
    {
        private ICalculator calculator;
        private double firstNumber;
        private double secondNumber;
        private string operation;
        public Form1()
        {
            InitializeComponent();
            calculator = new Math();

            sevenButton.Click += NumberButton_Click;
            eightButton.Click += NumberButton_Click;
            nineButton.Click += NumberButton_Click;
            fourButton.Click += NumberButton_Click;
            fiveButton.Click += NumberButton_Click;
            sixButton.Click += NumberButton_Click;
            oneButton.Click += NumberButton_Click;
            twoButton.Click += NumberButton_Click;
            threeButton.Click += NumberButton_Click;
            zeroButton.Click += NumberButton_Click;
            decimalButton.Click += NumberButton_Click;

            addButton.Click += OperationButton_Click;
            subtractButton.Click += OperationButton_Click;
            multiplyButton.Click += OperationButton_Click;
            divideButton.Click += OperationButton_Click;
            equalsButton.Click += equalsButton_Click;
            clearButton.Click += clearButton_Click;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            outputText.Text += button.Text;
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (double.TryParse(outputText.Text, out firstNumber))
            {
                outputText.Clear();
                operation = button.Text;
            }
        }
        private void equalsButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(outputText.Text, out secondNumber))
            {
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = calculator.Add(firstNumber, secondNumber);
                        break;
                    case "-":
                        result = calculator.Subtract(firstNumber, secondNumber);
                        break;
                    case "*":
                        result = calculator.Multiply(firstNumber, secondNumber);
                        break;
                    case "/":
                        try
                        {
                            result = calculator.Divide(firstNumber, secondNumber);
                        }
                        catch (DivideByZeroException ex)
                        {
                            MessageBox.Show(ex.Message);
                            outputText.Clear();
                            return;
                        }
                        break;
                }

                outputText.Text = result.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            firstNumber = 0;
            secondNumber = 0;
            operation = string.Empty;
        }
    }
}
