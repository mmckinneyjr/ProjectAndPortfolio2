using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;

namespace TimerTracker
{
    class Program
    {

        private static User currentUser = new User();

        static void Main(string[] args)
        {

            Console.Title = "Mark Mckinney - Time Tracker";
            currentUser._userId = User.UserLogin();

            Headers.MainMenu();
            Console.WriteLine(" Welecome " + Headers.userName(currentUser._userId) + "\r\n");

            bool programIsRunning = true;
            while (programIsRunning) {

                int mainInput = Validation.ValidateInt(0, 3, " Selection: ");

                switch (mainInput)  {

                    //Enter Activity
                    case 1: {
                            EnterActivity.EnterActivityMethod(currentUser._userId);
                        } break;

                    //View activity
                    case 2: {
                            Headers.ViewTracked();
                            bool viewingTrackedData = true;
                            while (viewingTrackedData) {
                                int input = Validation.ValidateInt(0, 3, " Selection: ");
                                switch (input) {

                                    //view by date
                                    case 1: {
                                            Headers.ViewTrackerByDate();
                                            ViewTracked.ByDate(currentUser._userId);
                                        } break;

                                    //view by category
                                    case 2: {
                                            ViewTracked.ByCategory(currentUser._userId);
                                        } break;

                                    //view by description
                                    case 3:  {
                                            ViewTracked.ByDescription(currentUser._userId);
                                        } break;

                                    case 0: {
                                            viewingTrackedData = false;
                                            Headers.MainMenu();
                                        } break;
                                }
                            }
                        }  break;
                    
                    //Calculations
                    case 3: {

                            Headers.CalculationsMainMenu();
                            bool running = true;
                            while (running) {
                                int input = Validation.ValidateInt(0, 10, " Selection: ");

                                switch (input) {
                                    case 1: { RunCalculations.Calc1_TimeSpentSleeping(currentUser._userId, input); }  break;
                                    case 2: { RunCalculations.Calc2_SleepPercent(currentUser._userId, input); } break;
                                    case 3: { RunCalculations.Calc3_TimeSpentOnHW(currentUser._userId, input); } break;
                                    case 4: { RunCalculations.Calc4_HWPercent(currentUser._userId, input); } break;
                                    case 5: { RunCalculations.Calc5(currentUser._userId, input); } break;
                                    case 6: { RunCalculations.Calc6(currentUser._userId, input); } break;
                                    case 7: { RunCalculations.Calc7(currentUser._userId, input); } break;
                                    case 8: { RunCalculations.Calc8(currentUser._userId, input); } break;
                                    case 9: { RunCalculations.Calc9(currentUser._userId, input); } break;
                                    case 10: { RunCalculations.Calc10(currentUser._userId, input); } break;
                                    case 0: { running = false; Headers.MainMenu(); } break;
                                }
                            }
                        } break;

                    //Calculations
                    case 0: {
                            programIsRunning = false;
                        } break;

                }     
            }
        }
    }
}
