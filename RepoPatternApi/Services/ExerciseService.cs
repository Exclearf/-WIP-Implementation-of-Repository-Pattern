using RepoPatternApi.Models;
using RepoPatternApi.Repositories;

namespace RepoPatternApi.Services
{
    public class ExerciseService : IExerciseService
    {
        IExerciseRepository _repository;

        public ExerciseService(IExerciseRepository repository)
        {
            _repository = repository;
        }

        public void AddExercise(Exercise item)
        {
            _repository.Add(item);
        }

        public void DeleteExercise(Exercise? item = null, int id = 0)
        {
            if(item == null)
            {
                item = GetExercise(id).First();
            }

            _repository.Delete(item);
        }
        public void UpdateExercise(Exercise item)
        {
            _repository.Update(item);
        }

        public List<Exercise?> GetExercise(int Id = -1)
        {
            if(Id < 0)
            {
                return _repository.GetAll();
            }
            var exercise = _repository.GetById(Id);

            return new List<Exercise?>() { exercise };

        }
    }
}
