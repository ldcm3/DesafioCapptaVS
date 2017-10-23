using System;
using Microsoft.EntityFrameworkCore;

namespace SondaProject.Models
{
	public class InstructionContext : DbContext
	{
        public InstructionContext(DbContextOptions<InstructionContext> options)
			: base(options)
		{
		}

		public DbSet<Instruction>  { get; set; }
	}
}
