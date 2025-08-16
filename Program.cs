using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Activity_35
{
    internal class Program
    {
        class Student
        {
            public string Name;
            public string Zone;

            public Student(string name, string zone)
            {
                Name = name;
                Zone = zone;
            }
        }

        class Bus
        {
            public int Id;
            public string Zone;
            public int Capacity;
            public List<Student> Assigned;

            public Bus(int id, string zone, int capacity)
            {
                Id = id;
                Zone = zone;
                Capacity = capacity;
                Assigned = new List<Student>();
            }

            public bool TryAdd(Student s)
            {
                if (Assigned.Count < Capacity)
                {
                    Assigned.Add(s);
                    return true;
                }
                return false;
            }
        }
        static void Main()
        {
            List<Student> students = new List<Student>
        {
            new Student("Aly", "North"),
            new Student("Bea", "North"),
            new Student("Lie", "South"),
            new Student("David", "North"),
            new Student("Evan", "South"),
            new Student("Frankie", "East")
        };

            List<Bus> buses = new List<Bus>
        {
            new Bus(1, "North", 2),
            new Bus(2, "South", 1),
            new Bus(3, "East", 2)
        };

            List<Student> unassigned = new List<Student>();
            foreach (var s in students)
            {
                bool placed = false;

                foreach (var b in buses)
                {
                    if (b.Zone == s.Zone && b.TryAdd(s))
                    {
                        placed = true;
                        break;
                    }
                }

                if (!placed)
                {
                    foreach (var b in buses)
                    {
                        if (b.TryAdd(s))
                        {
                            placed = true;
                            break;
                        }
                    }
                }

                if (!placed)
                    unassigned.Add(s);
            }

            foreach (var b in buses)
            {
                Console.WriteLine($"\nBus {b.Id} (Zone {b.Zone}, Capacity {b.Capacity}):");
                foreach (var s in b.Assigned)
                    Console.WriteLine($" - {s.Name} ({s.Zone})");
            }

            if (unassigned.Count > 0)
            {
                Console.WriteLine("\nUnassigned students:");
                foreach (var s in unassigned)
                    Console.WriteLine($" - {s.Name} ({s.Zone})");
            }
        }
    }
}