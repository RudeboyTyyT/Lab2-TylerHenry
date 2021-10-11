// PieceworkWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: Sept 26 2020
//    Written By: Tyler Henry 
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a class representing individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.

// This is currently incomplete; note the four comment blocks
// below that begin with "TO DO"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2_TylerHenry // Ensure this namespace matches your own
{
    class PieceworkWorker
    {

        #region "Variable declarations"

        // Instance variables
        private string employeeName;
        private int employeeMessages;
        private decimal employeePay;

        private bool isValid = true;
        private const int MINT1_MESSAGE = 1;
        private const int MINT2_MESSAGE = 1250;
        private const int MINT3_MESSAGE = 2500;
        private const int MINT4_MESSAGE = 3750;
        private const int MINT5_MESSAGE = 5000;
        private const int MAX_MESSAGE = 15000;
        private const double T1_PAY = 0.02;
        private const double T2_PAY = 0.024;
        private const double T3_PAY = 0.028;
        private const double T4_PAY = 0.034;
        private const double T5_PAY = 0.04;
        // Shared class variables
        private static int overallNumberOfEmployees;
        private static int overallMessages;
        private static decimal overallPayroll;
        private static decimal averagePay;
        public const string NameParameter = "name";
        public const string MessageParameter = "message";
        
        #endregion

        #region "Constructors"

        /// <summary>
        /// PieceworkWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate.
        /// </summary>
        /// <param name="nameValue">the worker's name</param>
        /// <param name="messageValue">a worker's number of messages sent</param>
        public PieceworkWorker(string nameValue, string messagesValue)
        {
            // Validate and set the worker's name
            this.Name = nameValue;
            // Validate Validate and set the worker's number of messages
           
            this.Messages = messagesValue;
            
            
            // Calculcate the worker's pay and update all summary values
            findPay();
        }

        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public PieceworkWorker()
        {

        }

        #endregion

        #region "Class methods"

        /// <summary>
        /// Currently called in the constructor, the findPay() method is
        /// used to calculate a worker's pay using threshold values to
        /// change how much a worker is paid per message. This also updates
        /// all summary values.
        /// </summary>
        private void findPay()
        {
           //If worker name and messages are valid
            if(isValid)
            {
                //Calculate worker pay dependsing on number of messages sent
                if (employeeMessages >= MINT1_MESSAGE && employeeMessages < MINT2_MESSAGE)
                {
                    employeePay = (decimal)(employeeMessages * T1_PAY);
                }
                else if (employeeMessages >= MINT2_MESSAGE && employeeMessages < MINT3_MESSAGE)
                {
                    employeePay = (decimal)(employeeMessages * T2_PAY);
                }
                else if (employeeMessages >= MINT3_MESSAGE && employeeMessages < MINT4_MESSAGE)
                {
                    employeePay = (decimal)(employeeMessages * T3_PAY);
                }
                else if (employeeMessages >= MINT4_MESSAGE && employeeMessages < MINT5_MESSAGE)
                {
                    employeePay = (decimal)(employeeMessages * T4_PAY);
                }
                else if (employeeMessages >= MINT5_MESSAGE && employeeMessages < MAX_MESSAGE)
                {
                    employeePay = (decimal)(employeeMessages * T5_PAY);
                }

                // Increment all shared summary values
                overallNumberOfEmployees++;
                overallMessages += employeeMessages;
                overallPayroll += employeePay;
            }

        }

        #endregion

        #region "Property Procedures"

        /// <summary>
        /// Gets and sets a worker's name
        /// </summary>
        /// <returns>an employee's name</returns>
        public string Name
        {
            get
            {
                //returns employee name
                return employeeName;
            }
            set
            {
                //if employee name is empty
                if (value == "")
                {
                    //Throw exception
                    throw new ArgumentNullException(NameParameter, "The entered name cannot be blank");
                    
                }

                //set employee name to value
                employeeName = value;
            }
        }

        /// <summary>
        /// Gets and sets the number of messages sent by a worker
        /// </summary>
        /// <returns>an employee's number of messages</returns>
        public string Messages
        {
            get
            {
                //Return employeeMessages
                return employeeMessages.ToString();
            }
            set
            {
                //Const declartion
                const decimal MINMESSAGES = 1;


                // If the messages sent are not an int, throw exception

                if (!int.TryParse(value, out employeeMessages))
                {
                    if (employeeMessages.ToString().Trim() == String.Empty)
                    {
                        throw new ArgumentNullException(MessageParameter, "The number of messages can't be blank");
                    }
                    else
                    {
                        throw new ArgumentException("The number of messages sent must be a numeric value", MessageParameter);
                    }
                }
                // If the messages sent are less then min or over max, throw exception
                else if (employeeMessages < MINMESSAGES || employeeMessages > MAX_MESSAGE)
                {
                    throw new ArgumentOutOfRangeException(MessageParameter, "The amount of messages sent must be between " + MINMESSAGES + " and " + MAX_MESSAGE);
                }
            }
        }

        /// <summary>
        /// Gets the worker's pay
        /// </summary>
        /// <returns>a worker's pay</returns>
        public decimal Pay
        {
            get
            {
                return Math.Round(employeePay,2);
            }
        }

        /// <summary>
        /// Gets the overall total pay among all workers
        /// </summary>
        /// <returns>the overall total pay among all workers</returns>
        public static decimal TotalPay
        {
            get
            {
                return overallPayroll;
            }
        }

        /// <summary>
        /// Gets the overall number of workers
        /// </summary>
        /// <returns>the overall number of workers</returns>
        public static int TotalWorkers
        {
            get
            {
                return overallNumberOfEmployees;
            }
        }

        /// <summary>
        /// Gets the overall number of messages sent
        /// </summary>
        /// <returns>the overall number of messages sent</returns>
        public static int TotalMessages
        {
            get
            {
                return overallMessages;
            }
        }

        /// <summary>
        /// Calculates and returns an average pay among all workers
        /// </summary>
        /// <returns>the average pay among all workers</returns>
        public static decimal AveragePay
        {
            get
            {
                
                if (overallNumberOfEmployees > 0)
                {
                    //Calculate average pay
                    averagePay = overallPayroll / overallNumberOfEmployees;

                    //Return averagePay rounded to 2 decimal places
                    return averagePay;
                }
                return 0;
            }
        }
        public static void ResetTotals()
        {
            averagePay = 0;
            overallMessages = 0;
            overallNumberOfEmployees = 0;
            overallPayroll = 0;

        }


        #endregion

    }
}
