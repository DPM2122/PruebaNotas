using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ProyectoNotas;

namespace PruebaNotas2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaValoresCorrectos()
        {
            EstadisticasNotas estadisticas = new EstadisticasNotas();
            List<int> listaNotas = new List<int>();

            listaNotas.Add(0);
            listaNotas.Add(5);
            listaNotas.Add(9);
            listaNotas.Add(3);
            listaNotas.Add(7);
            listaNotas.Add(4);
            listaNotas.Add(8);

            double mediaEsperada = 5.143;
            int suspensosEsperados = 3;
            int aprobadosEsperados = 1;
            int notablesEsperados = 2;
            int sobresalientesEsperados = 1;
           
            
            estadisticas.calcularEstadistica(listaNotas);

            int numeroSuspendidosMetodo = estadisticas.NumeroSuspensos;
            int numeroAprobadosMetodo = estadisticas.NumeroAprobados;
            int numeroNotablesMetodo = estadisticas.NumeroNotables;
            int numeroSobresalientesMetodo = estadisticas.NumeroSobresalientes;
            double mediaMetodo = estadisticas.Media;

            Assert.AreEqual(suspensosEsperados, numeroSuspendidosMetodo, 0.01, "El numero de suspensos no coincide");
            Assert.AreEqual(aprobadosEsperados, numeroAprobadosMetodo, 0.01, "El numero de Aprobados no coincide");
            Assert.AreEqual(notablesEsperados, numeroNotablesMetodo, 0.01, "El numero de Notables no coincide");
            Assert.AreEqual(sobresalientesEsperados, numeroSobresalientesMetodo, 0.001, "El numero de Sobresalientes no coincide");
            Assert.AreEqual(mediaEsperada, mediaMetodo, 0.01, "La media no coincide");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PruebaListaVacia_ExcepcionEsperada()
        {
            List<int> listaNotas = new List<int>();
            EstadisticasNotas  estadisticas = new EstadisticasNotas();
            estadisticas.calcularEstadistica(listaNotas);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PruebaNotasIncorrectas_ExcepcionEsperada()
        {
            List<int> listaNotas = new List<int>();
            listaNotas.Add(0);
            listaNotas.Add(5);
            listaNotas.Add(-9);
            listaNotas.Add(3);
            listaNotas.Add(7);
            listaNotas.Add(4);
            listaNotas.Add(8);

            EstadisticasNotas estadisticas = new EstadisticasNotas();
            estadisticas.calcularEstadistica(listaNotas);
        }
    }
}
