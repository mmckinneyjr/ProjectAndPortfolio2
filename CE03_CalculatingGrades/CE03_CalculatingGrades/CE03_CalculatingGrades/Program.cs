using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMckinney_CE03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mark Mckinney - CE03 Calculating Grades";

            //List of courses
            Course course1 = new Course("Art: Painting Coffee Beans");
            Course course2 = new Course("How to be a Barista");
            Course course3 = new Course("Ancient History of Coffee");
            Course course4 = new Course("Cooking with Coffee");
            Course course5 = new Course("Everybody Loves Esspresso");
            List<Course> Courses = new List<Course> { course1, course2, course3 , course4 , course5 };

            //Students grades
            List<decimal> student1Grades = new List<decimal> { 90.1m, 80m, 100m, 98.4m, 93.6m };
            List<decimal> student2Grades = new List<decimal> { 62.4m, 85m, 79.2m, 88.8m, 76.9m };
            List<decimal> student3Grades = new List<decimal> { 88.9m, 92.2m, 65.9m, 89.4m, 97.9m  };
            List<decimal> student4Grades = new List<decimal> { 96.5m, 78.2m, 91.9m, 99.1m, 87m };
            List<decimal> student5Grades = new List<decimal> { 90m, 55.2m, 87.9m, 92m, 84.4m };

            //List of students
            Student student1 = new Student("Tony", "Stark", student1Grades);
            Student student2 = new Student("Natasha", "Romanoff", student2Grades);
            Student student3 = new Student("Bruce", "Banner", student3Grades);
            Student student4 = new Student("Steve", "Rodgers", student4Grades);
            Student student5 = new Student("Scott", "Lang", student5Grades);
            List<Student> studentList = new List<Student>() { student1, student2, student3, student4, student5 };

            Headers.MainMenu();

            bool programIsRunning = true;
            while (programIsRunning) {
                int selection = Validation.ValidateInt(0, 4, " Selection: ");
                switch (selection) {

                    //View List of Students
                    case 1: {
                            Headers.MainMenu();
                            Console.WriteLine(" STUDENT LIST:\r\n");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("  #  Student Name                                                    Student Grade    Student GPA");
                            Console.ResetColor();
                            Headers.Linebreak2();
                            for (int i = 0; i < studentList.Count; i++) {
                                Console.WriteLine($" [{i + 1}] {studentList[i].FirstName + " " + studentList[i].LastName, -63} {LetterGrade(StudentAvgGrade(studentList, i)),-2} {StudentAvgGrade(studentList, i), 5} % {NumberGPA(studentList, i), 10}  ");
                            }

                            Headers.Linebreak();
                        } break;

                    //View List of Courses
                    case 2: {
                            Headers.MainMenu();
                            Console.WriteLine(" COURSE LIST:\r\n");                                                                 
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("  #  Course Name                                                     Course Avg       Course GPA");
                            Console.ResetColor();
                            Headers.Linebreak2();
                            for (int c = 0; c < Courses.Count; c++) {
                                Console.WriteLine($" [{c + 1}] {Courses[c].CourseName, -63} {LetterGrade(CourseAvgGrade(studentList, c)), -2} {CourseAvgGrade(studentList, c), 5} % {NumberGPA2(studentList, c), 10}");
                            }
                            Headers.Linebreak();
                        } break;

                    //Edit Student Grades
                    case 3: {
                            Headers.MainMenu();
                            Console.WriteLine(" EDIT STUDENT GRADES:\r\n");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("  #  Student Name:");
                            Console.ResetColor();
                            Headers.Linebreak2();

                            //List of students to select from
                            for (int i = 0; i < studentList.Count; i++) {
                                Console.WriteLine($" [{i + 1}] {studentList[i].FirstName} {studentList[i].LastName}: ");
                            }

                            Headers.Linebreak();

                            //Student Selection
                            int selectStudent = Validation.ValidateInt(0, studentList.Count, " Select a Student: ");

                            Headers.MainMenu();
                            Console.WriteLine(" EDIT STUDENT GRADES:\r\n");
                            Console.WriteLine($" {studentList[selectStudent - 1].FirstName} {studentList[selectStudent - 1].LastName}'s Courses: ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("  #  Course                                                          Grade");
                            Console.ResetColor();
                            Headers.Linebreak2();

                            //List of students courses
                            for (int g = 0; g < Courses.Count; g++) {
                                Console.WriteLine($" [{g + 1}] {Courses[g].CourseName, -62}  {LetterGrade(studentList[selectStudent - 1].Grad[g]), -1} {studentList[selectStudent - 1].Grad[g], 5}%");
                            }
        
                            Console.WriteLine($"\r\n GPA: {NumberGPA(studentList, selectStudent - 1)}");
                            Headers.Linebreak();
                            int courseToChange = Validation.ValidateInt(1, Courses.Count, " Select a course: ");
                            decimal newGrade = Validation.ValidateDec(0, 100, " Enter new grade: ");
                            studentList[selectStudent - 1].Grad[courseToChange - 1] = newGrade;

                            //Grades were updated
                            Headers.MainMenu();
                            Console.WriteLine(" GRADES HAVE BEEN UPDATED:\r\n");
                            Console.WriteLine($" {studentList[selectStudent - 1].FirstName} {studentList[selectStudent - 1].LastName}'s Courses: ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("  #  Course                                                          Grade");
                            Console.ResetColor();
                            Headers.Linebreak2();

                            for (int g = 0; g < Courses.Count; g++) {
                                Console.WriteLine($" [{g + 1}] {Courses[g].CourseName,-62}  {LetterGrade(studentList[selectStudent - 1].Grad[g]),-1} {studentList[selectStudent - 1].Grad[g],5}%");
                            }
                            Console.WriteLine($"\r\n GPA: {NumberGPA(studentList, selectStudent - 1)}");
                            Headers.Linebreak();
                        }
                        break;

                    //View all students courses
                    case 4: {
                            Headers.MainMenu();
                            Console.WriteLine(" ALL STUDENT COURSE GRADES:\r\n");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("  #  Student Name/Course                                             Grade");
                            Console.ResetColor();
                            Headers.Linebreak2();

                            for (int i = 0; i < studentList.Count; i++) {
                                Console.WriteLine($" [{i + 1}] {studentList[i].FirstName} {studentList[i].LastName}: ");
                                for (int x = 0; x < Courses.Count; x++) {
                                    Console.WriteLine($"    [{x + 1}] {Courses[x].CourseName, -60} {LetterGrade(studentList[i].Grad[x])} {studentList[i].Grad[x]}% ");
                                }
                                Console.WriteLine();
                            }
                        }
                        Headers.Linebreak();
                        break;

                    //Exit
                    case 0:

                        programIsRunning = false;
                        break;
                }
            }
        }

        //Course GPA method
        public static decimal CourseAvgGrade(List<Student> studentList, int c) {
            decimal GpaSum = 0;

            for (int i = 0; i < studentList.Count; i++) {
                decimal o = studentList[i].Grad[c];
                GpaSum = GpaSum + o;
            };
            return Math.Round((GpaSum / studentList.Count), 2);
        }

        //Student Avg Grade method
        public static decimal StudentAvgGrade(List<Student> studentList, int c)  {
            decimal GpaSum = 0;

            for (int i = 0; i < studentList.Count; i++) {
                decimal o = studentList[c].Grad[i];
                GpaSum = GpaSum + o;
            };
            return Math.Round((GpaSum / studentList.Count), 2);
        }

        //Letter grades
        public static string LetterGrade(decimal grade){

            String LetterGrade = "";
            if (grade <= 100m && grade >= 89.5m) {
                LetterGrade = "A";
            }
            else if (grade <= 89.4m && grade >= 79.5m) {
                LetterGrade = "B";
            }
            else if (grade <= 79.4m && grade >= 72.5m) {
                LetterGrade = "C";
            }
            else if (grade <= 72.4m && grade >= 69.5m) {
                LetterGrade = "D";
            }
            else {
                LetterGrade = "F";
            }
            return LetterGrade;
        }

        //Number GPA for Students
        public static decimal NumberGPA(List<Student> studentList, int c)  {
            decimal GpaSum = 0;
            decimal GPAGrade;

            for (int i = 0; i < studentList.Count; i++) {
                decimal grade = studentList[c].Grad[i];
            if (grade <= 100m && grade >= 89.5m) {
                GPAGrade = 4m;
            }
            else if (grade <= 89.4m && grade >= 79.5m) {
                GPAGrade = 3;
            }
            else if (grade <= 79.4m && grade >= 72.5m) {
                GPAGrade = 2;
            }
            else if (grade <= 72.4m && grade >= 69.5m) {
                GPAGrade = 1;
            }
            else {
                GPAGrade = 0;
            }
            GpaSum = GpaSum + GPAGrade;           
            };

            return Math.Round((GpaSum / studentList.Count), 2);
        }

        //Number GPA for Courses
        public static decimal NumberGPA2(List<Student> studentList, int c) {
            decimal GpaSum = 0;

            for (int i = 0; i < studentList.Count; i++)  {
                decimal grade = studentList[i].Grad[c];
                decimal GPAGrade;

                if (grade <= 100m && grade >= 89.5m)  {
                    GPAGrade = 4m;
                }
                else if (grade <= 89.4m && grade >= 79.5m) {
                    GPAGrade = 3;
                }
                else if (grade <= 79.4m && grade >= 72.5m) {
                    GPAGrade = 2;
                }
                else if (grade <= 72.4m && grade >= 69.5m) {
                    GPAGrade = 1;
                }
                else {
                    GPAGrade = 0;
                }
                GpaSum = GpaSum + GPAGrade;
            };
            return Math.Round((GpaSum / studentList.Count), 2);
        }
    }
}