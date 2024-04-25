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
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int LessonNumber {  get; set; }

        public Guid SubjectId {  get; set; }
        public Guid TeacherId { get; set; }
        public Guid AudienceId { get; set; }
        public Guid GroupId { get; set; }

        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public Audience Audience { get; set; }
        public Group Group { get; set; }

        private Schedule() { }

        public Schedule(Guid id, DateTime date, int lessonNumber, Subject subject, Teacher teacher, Audience audience, Group group)
        {
            Id = id;

            Date = date;
            LessonNumber = lessonNumber;

            Subject = subject;
            SubjectId = subject.Id;

            Teacher = teacher;
            TeacherId = teacher.Id;

            Audience = audience;
            AudienceId = audience.Id;

            Group = group;
            GroupId = group.Id;
        }

        public Schedule(DateTime data, int lessonNumber, Guid subjectId, Guid teacherId, Guid audienceId, Guid groupId)
        {
            Id = Guid.NewGuid();
            Date = data;
            LessonNumber = lessonNumber;
            SubjectId = subjectId;
            TeacherId = teacherId;
            AudienceId = audienceId;
            GroupId = groupId;
        }
    }
}
