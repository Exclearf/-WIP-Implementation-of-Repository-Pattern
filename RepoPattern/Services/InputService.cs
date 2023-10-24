using RepoPattern.Models;
using RepoPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Services
{
    public class InputService : IInputService
    {
        private IRequestRepository _requestRepository;

        public InputService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public void Delete(Exercise? exercise = null, int id = -1)
        {
            throw new NotImplementedException();
        }

        public void Add(Exercise? exercise)
        {

            _requestRepository.Add(exercise);

        }

        public void Get(Exercise? exercise = null, int id = -1)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}
