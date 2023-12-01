using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculatorapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnDigitClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            calculatorInput.Text += button.Text;
        }
        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(calculatorInput.Text))
            {
                // Remove the last character from the input text
                calculatorInput.Text = calculatorInput.Text.Substring(0, calculatorInput.Text.Length - 1);
            }
        }
        private void OnEqualsClicked(object sender, EventArgs e)
        {
            try
            {
                // Evaluate the expression using the EvaluateExpression method
                double result = EvaluateExpression(calculatorInput.Text);

                // Display the result in the calculator input field
                calculatorInput.Text = result.ToString();
            }
            catch (Exception ex)
            {
                // Handle errors during evaluation (for example, division by zero)
                calculatorInput.Text = "Error";
            }
        }
        private double EvaluateExpression(string expression)
        {
            return Convert.ToDouble(new System.Data.DataTable().Compute(expression, string.Empty));
        }




    }
}

