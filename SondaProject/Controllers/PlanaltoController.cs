using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SondaProject.Models;
using System.Linq;

namespace SondaProject.Controllers
{
	[Route("api/[controller]")]
	public class PlanaltoController : Controller
	{
		private readonly SondaContext _context;

		public PlanaltoController(SondaContext context)
		{
			_context = context;

			if (_context.Planaltos.Count() == 0)
			{
                _context.Planaltos.Add(new Planalto { Name = "Marte", lenX = 5, lenY = 5});
				_context.SaveChanges();
			}
		}


		[HttpGet]
		public IEnumerable<Planalto> GetAll()
		{
			return _context.Planaltos.ToList();
		}

		[HttpGet("{id}", Name = "GetPlanalto")]
		public IActionResult GetById(long id)
		{
			var item = _context.Planaltos.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}


		[HttpPost]
		public IActionResult Create([FromBody] Planalto planalto)
		{
			if (planalto == null)
			{
				return BadRequest();
			}

			_context.Planaltos.Add(planalto);
			_context.SaveChanges();

            return CreatedAtRoute("GetPlanalto", new { id = planalto.Id }, planalto);
		}

		[HttpPut("{id}")]
		public IActionResult Update(long id, [FromBody] Planalto planalto)
		{
			if (planalto == null || planalto.Id != id)
			{
				return BadRequest();
			}

			var myplanalto = _context.Planaltos.FirstOrDefault(t => t.Id == id);

			if (myplanalto == null)
			{
				return NotFound();
			}

            myplanalto.lenX = planalto.lenX;
            myplanalto.lenY = planalto.lenY;
			myplanalto.Name = planalto.Name;

            _context.Planaltos.Update(myplanalto);
			_context.SaveChanges();
			return new NoContentResult();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
            var myplanalto = _context.Planaltos.FirstOrDefault(t => t.Id == id);
			if (myplanalto == null)
			{
				return NotFound();
			}

			_context.Planaltos.Remove(myplanalto);
			_context.SaveChanges();
			return new NoContentResult();
		}

	}
}