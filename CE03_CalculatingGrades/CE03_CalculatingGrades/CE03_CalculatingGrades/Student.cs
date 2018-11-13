using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMckinney_CE03
{
    class Student
    {
        private string _firstName;
        private string _lastName;
        List<decimal> _grade1;

        public string FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public List<decimal> Grad {
            get { return _grade1; }
            set { _grade1 = value; }
        }

        public Student(string firstName, string lastName, List<decimal> g) {
            _firstName = firstName;
            _lastName = lastName;
            _grade1 = g;
        }
    }
}
