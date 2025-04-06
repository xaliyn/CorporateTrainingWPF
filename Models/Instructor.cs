using Corporate_Training_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Corporate_Training_Management.Models;

public class Instructor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Expertise { get; set; }

    // one instructor -> many trainings
    public List<Training> Trainings { get; set; }
}