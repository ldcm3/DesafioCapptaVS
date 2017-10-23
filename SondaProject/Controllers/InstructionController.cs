using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SondaProject.Models;
using System.Linq;
using System;
using System.Data;


namespace SondaProject.Controllers
{
    [Route("api/[controller]")]
    public class InstructionController : Controller
    {
        private readonly SondaContext _context;

		// Construtor
		public InstructionController(SondaContext context)
		{
			_context = context;

			if (_context.Instructions.Count() == 0)
			{
                _context.Instructions.Add(new Instruction { SondaName = "Sonda1", Moves = "RRRR", PlanaltoName = "Marte" });
				_context.SaveChanges();
			}
		}

		// GET api/instruction
		[HttpGet]
		public IEnumerable<Instruction> GetAll()
		{
			return _context.Instructions.ToList();
		}

		// GET api/instruction/id
		[HttpGet("{id}", Name = "GetInstruction")]
		public IActionResult GetById(long id)
		{
			var item = _context.Instructions.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		// POST api/instruction
		[HttpPost]
		public IActionResult Create([FromBody] Instruction instruction)
		{
			if (instruction == null)
			{
				return BadRequest();
			}

			_context.Instructions.Add(instruction);
			_context.SaveChanges();

            // Query malha e sonda definidas por intruction
            var malha = _context.Planaltos.Single(b => b.Name == instruction.PlanaltoName);

			if (malha == null)
			{
				return NotFound();
			}
                      
            var sonda = _context.Sondas.Single(b => b.Name == instruction.SondaName );

			if (sonda == null)
			{
				return NotFound();
			}

			// Cria objetos 
            Malha m = new Malha(malha.lenX, malha.lenY);
			SondaDevice s = new SondaDevice(sonda.CoordX,sonda.CoordY,sonda.Direction);

            // Executa instrucoes na sonda s e na malha m
            foreach (char ch in instruction.Moves)
            {
                s.SendInstruction(ch, m);
            }

            // Atualiza novas coordenadas da sonda
            Tuple<int, int> coords = s.GetCurPosition();

            sonda.CoordX = coords.Item1;
            sonda.CoordY = coords.Item2;
            sonda.Direction = s.GetCurDirection();

			_context.Sondas.Update(sonda);
			_context.SaveChanges();

			return CreatedAtRoute("GetInstruction", new { id = instruction.Id }, instruction);
		}

    }
}