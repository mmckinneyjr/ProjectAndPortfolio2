using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMckinney_CE03
{
    class Course
    {
       protected string _courseName;

        public string CourseName {
            get { return _courseName; }
            set { _courseName = value; }
        }

        public Course(string courseName) {
            _courseName = courseName;
        }
    }
}
