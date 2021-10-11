// MainWindow.xaml.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: Oct 10 2021
//    Written By: Tyler Henry 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Lab2_TylerHenry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a worker object. If the worker is valid, displays their pay and disables input controls.
        /// </summary>
        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            labelNameError.Content = "";
            labelMessageError.Content = "";

            try
            {
                //Create worker object
                var myWorker = new PieceworkWorker(textBoxWorkerName.Text, textBoxMessagesSent.Text);
                //If the workers pay is calcualted
                if (myWorker.Pay > 0)
                {
                    //Add worker details to textboxes
                    textBoxTotalWorkerPay.Text = myWorker.Pay.ToString("C2");
                    

                    //Disable calculate button and textboxes, set focus to clear button
                    textBoxWorkerName.IsEnabled = false;
                    textBoxMessagesSent.IsEnabled = false;
                    buttonCalculate.IsEnabled = false;
                    buttonClear.Focus();



                }
            }
            //catches exception
            catch (ArgumentException error)
            {
                //Catches excetions involving worker name
                if (error.ParamName == PieceworkWorker.NameParameter)
                {
                    textBoxWorkerName.SelectAll();
                    textBoxWorkerName.Focus();
                    textBoxWorkerName.Background = Brushes.Pink;
                    textBoxWorkerName.BorderBrush = Brushes.Red;
                    labelNameError.Content = error.Message; 
                    
                    

                }
                //Catches Exceptions involving amount of messages
                else if (error.ParamName == PieceworkWorker.MessageParameter)
                {
                    textBoxMessagesSent.SelectAll();
                    textBoxMessagesSent.Focus();
                    textBoxMessagesSent.Background = Brushes.Pink;
                    textBoxMessagesSent.BorderBrush = Brushes.Red;
                    labelMessageError.Content = error.Message;

                }
                      

            }
            
            
        }

        /// <summary>
        /// Clears all input fields and sets the form to its default state.
        /// </summary>
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            //Call method to clear 
            SetDefaults();
        }

        /// <summary>
        /// Clear all input fields and re-enable all controls that may be disabled.
        /// </summary>
        private void SetDefaults()
        {
            //Clear all inputed text box and current workers total pay
            textBoxMessagesSent.Text = "";
            textBoxWorkerName.Text = "";
            textBoxTotalWorkerPay.Clear();
            labelNameError.Content = "";
            labelMessageError.Content = "";
            textBoxWorkerName.Background = Brushes.White;
            textBoxWorkerName.BorderBrush = Brushes.Black;
            textBoxMessagesSent.Background = Brushes.White;
            textBoxMessagesSent.BorderBrush = Brushes.Black;

            //Reanable textboxes and buttons, set focus to worker name
            textBoxMessagesSent.IsEnabled = true;
            textBoxWorkerName.IsEnabled = true;
            buttonCalculate.IsEnabled = true;
            textBoxWorkerName.Focus();


        }
        /// <summary>
        /// Button that opens the summary window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSummary_Click(object sender, RoutedEventArgs e)
        {
            
          //Open summary window
          new summaryWindow().ShowDialog();
                
        }

        

    }



}