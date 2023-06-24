using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;

namespace Registros.Server.DAL
{
	public class PrioridadContext : DbContext
	{
		public PrioridadContext(DbContextOptions<PrioridadContext> options)
			: base(options) { }

		public DbSet<PrioridadContext> PrioridadContex { get; set; }
		public int PrioridadId { get; internal set; }
	}
}
