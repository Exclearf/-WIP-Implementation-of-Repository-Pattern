using RepoPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Controllers
{
    public interface IInputController
    {
        public void Start(IInputService inputService, bool isCaseSensitive = false, ConsoleColor color = ConsoleColor.Green);
        public void EndSession();
        public void ShowMenu();
        public void AddExercise();
        public void EditExercise();
        public void RemoveExercise();
        public void DisplayAll();
    }
}
