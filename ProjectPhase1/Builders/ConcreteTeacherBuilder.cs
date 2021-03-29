using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhase1.Builders
{
    public class ConcreteTeacherBuilder : AbstractTeacherBuilder
    {
        protected override void BuildID(Teacher teacher)
        {
            Console.WriteLine("Enter an ID for the teacher");
            var idAsText = Console.ReadLine();
            teacher.ID = int.Parse(idAsText);
        }

        protected override void BuildFirstName(Teacher teacher)
        {
            Console.WriteLine("Enter First Name of the teacher");
            var firstName = Console.ReadLine();
            teacher.FirstName = firstName;
        }

        protected override void BuildLastName(Teacher teacher)
        {
            Console.WriteLine("Enter Last Name of the teacher");
            var lastName = Console.ReadLine();
            teacher.LastName = lastName;
        }

    }
}
