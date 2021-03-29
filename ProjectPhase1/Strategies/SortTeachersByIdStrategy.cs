using ProjectPhase1.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace ProjectPhase1.Templates
{
    internal class SortTeachersByIdStrategy : ISortTeachersStrategy
    {
        public List<Teacher> Sort(IEnumerable<Teacher> teachers)
        {
            var sorted = new List<Teacher>();

            foreach (var teacher in teachers)
            {
                var inserted = false;
                for (var i = 0; i < sorted.Count(); i++)
                {
                    if (teacher.ID <= sorted[i].ID)
                    {
                        inserted = true;
                        sorted.Insert(i, teacher);
                        break;
                    }
                }

                if (!inserted) sorted.Add(teacher);
            }

            return sorted;
        }
    }
}