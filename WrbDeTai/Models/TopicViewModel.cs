using System.ComponentModel.DataAnnotations;
using WrbDeTai.Data;

namespace WrbDeTai.Models
{
    public class TopicMD
    {
        public int Id { get; set; }
        public string? StudientId {get; set;}
        public int TopicId { get; set;}
        public int TeacherId { get; set;}
    }
    public class Topic
    {
        public int Id { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public string StudentId { get; set; }
        public int TeacherId { get; set; }
        public int Status { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class TopicViewModel
    {
        public int ID { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public string StudentID { get; set; }
        public int TeacherID { get; set; }
        public string Status { get; set; }
        public int Year { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class TopicSelectionViewModel
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public int? SelectedTopicId { get; set; }
        public string SelectedTopicName { get; set; } 
        public int? SelectedTeacherId { get; set; }
        public string SelectedTeacherName { get; set; } 
        public List<Topic> AvailableTopics { get; set; }
        public List<TeacherViewModel> AvailableTeachers { get; set; }
    }

}
