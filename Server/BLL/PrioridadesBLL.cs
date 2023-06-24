using Microsoft.EntityFrameworkCore;
using Registros.Server.DAL;
using Registros.Shared.Models;
using System.Linq.Expressions;

namespace Registros.Server.BLL
{
	public class PrioridadesBLL
	{
		private readonly PrioridadContext _contexto;

		public PrioridadesBLL(PrioridadContext contexto)
		{			
			_contexto = contexto;
		}

		public bool Existe(int PrioridadId)
		{
			return _contexto.PrioridadContex.Any(s => s.PrioridadId == PrioridadId);
		}

		private bool Insertar(PrioridadContext prioridad)
		{
			_contexto.PrioridadContex.Add(prioridad);
			int cantidad = _contexto.SaveChanges();
			return cantidad > 0;
		}

		private bool Modificar(PrioridadContext prioridad)
		{
			_contexto.Update(prioridad);
			int cantidad = _contexto.SaveChanges();
			return cantidad > 0;
		}

		public bool Guardar(PrioridadContext prioridad)
		{
			if (!Existe(prioridad.PrioridadId))
				return Insertar(prioridad);
			else
				return Modificar(prioridad);
		}

		public bool Eliminar(PrioridadContext prioridad)
		{
			_contexto.PrioridadContex.Remove(prioridad);
			int cantidad = _contexto.SaveChanges();
			return cantidad > 0;
		}

		public PrioridadContext? Buscar(int PrioridadId)
		{
			return _contexto.PrioridadContex
				.AsNoTracking()
				.FirstOrDefault(s => s.PrioridadId == PrioridadId);
		}

		public List<PrioridadContext> GetList(Expression<Func<PrioridadContext, bool>> Criterio)
		{
			return _contexto.PrioridadContex
				.Where(Criterio)
				.AsNoTracking()
				.ToList();
		}
	}
}
