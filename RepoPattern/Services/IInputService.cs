using RepoPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Services
{
    public interface IInputService
    {
        public void GetAll();
        public void Get(Exercise? exercise = null, int id = -1);
        public void Add(Exercise? exercise);
        public void Update(Exercise exercise);
        public void Delete(Exercise? exercise = null, int id = -1);
    }
}
