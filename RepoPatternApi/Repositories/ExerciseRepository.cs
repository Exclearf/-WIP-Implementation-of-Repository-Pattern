using Microsoft.EntityFrameworkCore;
using RepoPatternApi.Context;
using RepoPatternApi.Models;

namespace RepoPatternApi.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        public ExerciseContext _context;

        public ExerciseRepository(ExerciseContext context)
        {
            _context = context;
        }

        public void Add(Exercise item)
        {
            _context.Add(item);
            saveChanges();
        }

        public void Delete(Exercise item)
        {
            _context.Remove(item);
            saveChanges();
        }

        public void Update(Exercise item)
        {
            _context.Update(item);
            saveChanges();
        }

        public List<Exercise>? GetAll()
        {
            return _context.Exercises.ToList();
        }

        public Exercise? GetById(int Id)
        {
            return _context.Find<Exercise>(Id);
        }

        private void saveChanges()
        {
            _context.SaveChanges();
        }
    }
}
