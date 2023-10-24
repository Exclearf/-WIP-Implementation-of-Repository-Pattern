using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepoPatternApi.Context;
using RepoPatternApi.Models;
using RepoPatternApi.Services;

namespace RepoPatternApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ExerciseContext _context;
        private IExerciseService _exerciseService;

        public ExercisesController(ExerciseContext context, IExerciseService exerciseService)
        {
            _context = context;
            _exerciseService = exerciseService; 
        }

        // GET: api/Exercises
        [HttpGet]
        public ActionResult<IEnumerable<Exercise?>> Exercises()
        {
          if (_context.Exercises == null)
          {
              return NotFound();
          }
            return _exerciseService.GetExercise();
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Exercise?>> GetExercise(int id)
        {
          if (_exerciseService.GetExercise() == null)
          {
              return NotFound();
          }
            var exercise = _exerciseService.GetExercise(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return exercise;
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutExercise(Exercise exercise)
        {
            try
            {
                _exerciseService.UpdateExercise(exercise);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        // POST: api/Exercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Exercise> PostExercise(Exercise exercise)
        {
            try
            {
                _exerciseService.AddExercise(exercise);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public IActionResult DeleteExercise(int id)
        {
            try
            {
                _exerciseService.DeleteExercise();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }
    }
}
