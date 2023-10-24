using RepoPatternApi.Models;

namespace RepoPatternApi.Services
{
    public interface IExerciseService
    {
        public void AddExercise(Exercise item);
        public void DeleteExercise(Exercise? item = null, int id = 0);
        public void UpdateExercise(Exercise item);
        public List<Exercise?> GetExercise(int Id = -1);
    }
}
