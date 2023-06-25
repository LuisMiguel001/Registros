using Microsoft.EntityFrameworkCore;
using Registros.Shared;
using Registros.Shared.Models;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;

namespace Registros.Server.DAL;

public class PrioridadContext : DbContext
{
	public PrioridadContext(DbContextOptions<PrioridadContext> options)
		: base(options) { }
	
	public DbSet<Prioridades> Prioridades { get; set; }
}

