using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Shared.Models;

public class Prioridades
{
	[Key] //KEY ES EL ID CODE PARA NUESTRA BASE DE DATOS, (LOS ATRIBUTOS DEBEN INICIAR EN MAYUSCULA)

	public int PrioridadId { get; set; }

	[Required(ErrorMessage = "La descripcion es obligatoria")]
	public string? Descripcion { get; set; }

	[Required(ErrorMessage = "Los dias de compromiso son obligatoria")]
	public int DiasCompromiso { get; set; }

}
