using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class accionTexto
    {
        public string tipoAccion { get; set; }
        public string contenido { get; set; }
        public int[] fechaHora { get; set; }

        public accionTexto(string tipoAccion, string contenido, int[] fechaHora)
        {
            this.tipoAccion = tipoAccion;
            this.contenido = contenido;
            this.fechaHora = fechaHora;
        }
    }

    public class Tarea
    {
        public enum PrioridadTarea
        {
            Baja,
            Media,
            Alta
        }

        public string Id { get; }
        public string Titulo { get; }
        public PrioridadTarea Prioridad { get; }
        public int EstimacionMinutos { get; }

        public Tarea(string id, string titulo, PrioridadTarea prioridad, int estimacionMinutos)
        {
            Id = id;
            Titulo = titulo;
            Prioridad = prioridad;
            EstimacionMinutos = estimacionMinutos;
        }

    }
}
