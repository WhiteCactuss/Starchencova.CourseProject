using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolk.Entites
{
    public class Schedule
    {
        public Guid ScheduleId { get; set; }
        public DateTime Day { get; set; }
        public int NumberLesson {  get; set; }

        public Guid SubjectId {  get; set; }
        public Guid TeacherId { get; set; }
        public Guid AudienceId { get; set; }

        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Audience Audience { get; set; }

        public Schedule() { }
        
        public Schedule(Guid scheduleid, DateTime day, int numberLesson, Guid subjectId,Guid teacherId, Guid audienceId)
        {
            ScheduleId = Guid.NewGuid();
            Day = day;
            NumberLesson = numberLesson;
            SubjectId = subjectId;
            TeacherId = teacherId;
            AudienceId = audienceId;
        }
    }
}
