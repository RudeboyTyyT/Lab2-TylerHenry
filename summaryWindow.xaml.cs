// summaryWindow.xaml.cs
//         Title: IncInc Payroll (Piecework) Summary Page
// Last Modified: Sept 10 2021
//    Written By: Tyler Henry 
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab2_TylerHenry
{
    /// <summary>
    /// Interaction logic for summaryWindow.xaml
    /// </summary>
    public partial class summaryWindow : Window
    {

        public summaryWindow()
        {
            InitializeComponent();
            //Runs populate summary method on start up
            PopulateSummary();
        }

        /// <summary>
        /// Closes summary window when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCloseSummary_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Method fill the textboxes in summary window with values
        /// </summary>
        private void PopulateSummary()
        {
            //Assign textboxes on summary page with total and average values
            textBoxTotalWorkers.Text = PieceworkWorker.TotalWorkers.ToString();
            textBoxTotalMessages.Text = PieceworkWorker.TotalMessages.ToString();
            textBoxTotalPay.Text = PieceworkWorker.TotalPay.ToString("C2");
            textBoxAveragePay.Text = PieceworkWorker.AveragePay.ToString("C2");
        }

        private void buttonResetSummary_Click(object sender, RoutedEventArgs e)
        {
            PieceworkWorker.ResetTotals();
            PopulateSummary();
        }

       

    }

}
