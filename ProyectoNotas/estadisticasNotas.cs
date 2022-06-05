using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotas
{
    /// <summary>
    /// Clase que calcula las estadíaticas de un conjunto de notas
    /// </summary>
    public class estadisticasNotas  // esta clase nos calcula las estadísticas de un conjunto de notas 
    {
        private int suspensos;  // Suspensos
        private int aprobados;  // Aprobados
        private int notables;  // Notables
        private int sobresalientes;  // Sobresalientes

        private double media; // Nota media
        /// <summary>
        /// Se innicializan las variables a 0
        /// </summary>
        // Constructor vacío
        public estadisticasNotas()
        {
            suspensos = 0;
            aprobados = 0;
            notables = 0;
            sobresalientes = 0;  // inicializamos las variables
            media = 0.0;
        }
        /// <summary>
        /// Constuctor a partir de una lista al crear un objeto
        /// </summary>
        /// <param name="listaNotas">Lista con las notas de los alumnos</param>

        // Constructor a partir de un array, calcula las estadísticas al crear el objeto
        public estadisticasNotas(List<int> listaNotas)
        {
            Estadisticas(listaNotas);
        }

        /// <summary>
        /// Funcion para introducir notas
        /// </summary>
        /// <param name="listaNotas">Lista de notas introducidas</param>
        private void Estadisticas(List<int> listaNotas)
        {
            media = 0.0;

            for (int i = 0; i < listaNotas.Count; i++)
            {
                if (listaNotas[i] < 5) suspensos++;              // Por debajo de 5 suspenso
                else if (listaNotas[i] > 5 && listaNotas[i] < 7) aprobados++;// Nota para aprobar: 5
                else if (listaNotas[i] > 7 && listaNotas[i] < 9) notables++;// Nota para notable: 7
                else if (listaNotas[i] > 9) sobresalientes++;         // Nota para sobresaliente: 9

                media = media + listaNotas[i];
            }

            media = media / listaNotas.Count;
        }

        /// <summary>
        /// Para un conjunto de listaNotas, calculamos las estadísticas
        /// </summary>
        /// <param name="listaNotas">Lista con las notas de los alumnos</param>
        /// <returns>Devuelve la media y el numero de  notas</returns>

        // Para un conjunto de listnot, calculamos las estadísticas
        // calcula la media y el número de suspensos/aprobados/notables/sobresalientes
        //
        // El método devuelve -1 si ha habido algún problema, la media en caso contrario	
        public double calcularEstadistica(List<int> listaNotas)
        {
            media = 0.0;

            // TODO: hay que modificar el tratamiento de errores para generar excepciones
            //
            if (listaNotas.Count <= 0)  // Si la lista no contiene elementos, devolvemos un error
                throw new Exception("Lista vacía");

            for (int i = 0; i < 10; i++)
                if (listaNotas[i] < 0 || listaNotas[i] > 10)      // comprobamos que las notables están entre 0 y 10 (mínimo y máximo), si no, error
                    throw new ArgumentOutOfRangeException("Nota ", i, " Nota fuera de rango válido");

            Estadisticas(listaNotas);

            media = media / listaNotas.Count;

            return media;
        }
    }
}

