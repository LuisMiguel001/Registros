using Microsoft.EntityFrameworkCore;
using Registros.Server.DAL;
using Registros.Shared.Models;
using System.Linq.Expressions;

namespace Registros.Server.BLL;

public class PrioridadesBLL
{
	private readonly PrioridadContext _contexto;

	public PrioridadesBLL(PrioridadContext contexto)
	{
		_contexto = contexto;
	}

	public bool Existe(int PrioridadId)
	{
		return _contexto.Prioridades.Any(s => s.PrioridadId == PrioridadId);
	}

	private bool Insertar(Prioridades prioridad)
	{
		_contexto.Prioridades.Add(prioridad);
		int cantidad = _contexto.SaveChanges();
		return cantidad > 0;
	}

	private bool Modificar(Prioridades prioridad)
	{
		_contexto.Update(prioridad);
		int cantidad = _contexto.SaveChanges();
		return cantidad > 0;
	}

	public bool Guardar(Prioridades prioridad)
	{
		if (!Existe(prioridad.PrioridadId))
			return Insertar(prioridad);
		else
			return Modificar(prioridad);
	}

	public bool Eliminar(Prioridades prioridad)
	{
		_contexto.Prioridades.Remove(prioridad);
		int cantidad = _contexto.SaveChanges();
		return cantidad > 0;
	}

	public Prioridades? Buscar(int PrioridadId)
	{
		return _contexto.Prioridades
			.AsNoTracking()
			.FirstOrDefault(s => s.PrioridadId == PrioridadId);
	}

	public List<Prioridades> GetList(Expression<Func<Prioridades, bool>> Criterio)
	{
		return _contexto.Prioridades
			.Where(Criterio)
			.AsNoTracking()
			.ToList();
	}
}

