using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate_Training_Management.Models
{
    public class TrainingParticipant
    {
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }

    }
}
