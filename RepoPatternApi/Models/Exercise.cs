using System.ComponentModel.DataAnnotations;

namespace RepoPatternApi.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateStart { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateEnd { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Comments { get; set; }
    }
}
