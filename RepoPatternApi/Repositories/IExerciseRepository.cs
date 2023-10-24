using RepoPatternApi.Models;

namespace RepoPatternApi.Repositories
{
    public interface IExerciseRepository
    {
        public void Add(Exercise item);
        public void Delete(Exercise item);
        public void Update(Exercise item);
        public List<Exercise>? GetAll();
        public Exercise? GetById(int Id);
    }
}
