using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SondaProject.Models;
using System.Linq;

namespace SondaProject.Controllers
{
	[Route("api/[controller]")]
	public class SondaController : Controller
	{
		private readonly SondaContext _context;

		public SondaController(SondaContext context)
		{
			_context = context;

			if (_context.Sondas.Count() == 0)
			{
                _context.Sondas.Add(new Sonda { Name = "Sonda1", CoordX = 1, CoordY = 2 , Direction = 'N' });
				_context.SaveChanges();
			}
		}


		[HttpGet]
		public IEnumerable<Sonda> GetAll()
		{
			return _context.Sondas.ToList();
		}

		[HttpGet("{id}", Name = "GetSonda")]
		public IActionResult GetById(long id)
		{
			var item = _context.Sondas.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}


		[HttpPost]
		public IActionResult Create([FromBody] Sonda sonda)
		{
			if (sonda == null)
			{
				return BadRequest();
			}

			_context.Sondas.Add(sonda);
			_context.SaveChanges();

			return CreatedAtRoute("GetSonda", new { id = sonda.Id }, sonda);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] Sonda sonda)
		{
			if (sonda == null || sonda.Id != id)
			{
				return BadRequest();
			}

			var mysonda = _context.Sondas.FirstOrDefault(t => t.Id == id);

			if (mysonda == null)
			{
				return NotFound();
			}

			mysonda.CoordX = sonda.CoordX;
            mysonda.CoordY = sonda.CoordY;
            mysonda.Direction = sonda.Direction;
			mysonda.Name = sonda.Name;

			_context.Sondas.Update(mysonda);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			var mysonda = _context.Sondas.FirstOrDefault(t => t.Id == id);
			if (mysonda == null)
			{
				return NotFound();
			}

			_context.Sondas.Remove(mysonda);
			_context.SaveChanges();
			return new NoContentResult();
		}

	}
}