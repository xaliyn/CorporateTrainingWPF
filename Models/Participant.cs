using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate_Training_Management.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }

        public List<TrainingParticipant> TrainingParticipants { get; set; }
    }
}
