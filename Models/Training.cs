using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate_Training_Management.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }

        // Foreign key
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        // Many-to-many relationship
        public List<TrainingParticipant> TrainingParticipants { get; set; }
    }
}
