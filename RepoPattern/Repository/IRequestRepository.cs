using RepoPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Repository
{
    public interface IRequestRepository
    {
        public void Get(Exercise exercise);
        public void GetAll(int id);
        public Task Add(Exercise exercise);
        public void Delete(int id);
    }
}
