using ProjectPhase1.Builders;
using ProjectPhase1.Repositories;
using ProjectPhase1.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPhase1.Templates
{
    public class ConcreteTeacherManagementApp : AbstractTeacherAppTemplate
    {
        protected override void loadTeachers()
        {
            var teachersRepository = new PipeDelimitedFileTeachersRepository("teachers.txt");
            var teachersAsList = teachersRepository.Load();
            _teachers = teachersAsList.ToDictionary(t => t.ID);
            Console.WriteLine($"Loaded {_teachers.Count} teachers");
        }

        protected override void saveTeachers()
        {
            var teachersRepository = new PipeDelimitedFileTeachersRepository("teachers.txt");
            teachersRepository.Save(_teachers.Values);
        }

        protected override int getOption()
        {
            return int.Parse(Console.ReadLine());
        }

        protected override void addTeacher()
        {
            var teacherBuilder = new ConcreteTeacherBuilder();
            var teacher = teacherBuilder.Build();
            _teachers[teacher.ID] = teacher;
        }

        protected override void deleteTeacher()
        {
            Console.WriteLine("Enter ID of techer to delete");
            var id = int.Parse(Console.ReadLine());

            if (!_teachers.ContainsKey(id))
            {
                Console.WriteLine($"Teacher with id {id} not found");
            }
            else
            {
                _teachers.Remove(id);
                Console.WriteLine("Removed teacher");
            }
        }

        protected override void findTeacher()
        {
            Console.WriteLine("Enter ID of teacher to find");
            var id = int.Parse(Console.ReadLine());
           
          
            if (!_teachers.ContainsKey(id))
            {
                Console.WriteLine($"Teacher with id {id} not found");
            }
            else
            {
                Console.WriteLine(_teachers[id]);
            }
         
        }

        protected override void listTeachers(IEnumerable<Teacher> teachers)
        {
            foreach(var teacher in teachers)
            {
                Console.WriteLine(teacher);
            }
        }

        protected override void sortTeachers()
        {
            Console.WriteLine("You chose to sort teachers");
            Console.WriteLine("How would you like to sort them?");
            Console.WriteLine("1) ID");
            Console.WriteLine("2) Last Name");
            Console.WriteLine("3) First Name");

            var option = int.Parse(Console.ReadLine());
            ISortTeachersStrategy sortStrategy = null;
            switch (option)
            {
                case 1: sortStrategy = new SortTeachersByIdStrategy(); break;
                case 2: sortStrategy = new SortTeachersByLastNameStrategy(); break;
                case 3: sortStrategy = new SortTeachersByFirstNameStrategy(); break;
            }

            var sorted = sortStrategy.Sort(_teachers.Values);
            listTeachers(sorted);
        }

        protected override void updateTeacher()
        {
            Console.WriteLine("Enter ID of teacher to update");
            var id = int.Parse(Console.ReadLine());
            if (!_teachers.ContainsKey(id))
            {
                Console.WriteLine($"Did not find teacher with id: {id}");
                return;
            }

            var teacher = _teachers[id];
            Console.WriteLine("You selected...");
            Console.WriteLine(teacher);

            Console.WriteLine("Enter new First Name of the teacher");
            var newFirstName = Console.ReadLine();
            if (newFirstName == "")
            {
                Console.WriteLine("First Name will not be changed.");
            }
            else 
            {
                teacher.FirstName = newFirstName;
            }
            

            Console.WriteLine("Enter new Last Name of the teacher");
            var newLastName = Console.ReadLine();
            if (newLastName == "")
            {
                Console.WriteLine("Last Name will not be changed.");
            }
            else
            {
                teacher.LastName = newLastName;
            }
            
            _teachers[id] = teacher;

        }
    }
}
