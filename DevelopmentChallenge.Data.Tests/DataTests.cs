using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ReporteFormas.Imprimir(new List<FormaGeometrica>(), new CultureInfo("es")));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ReporteFormas.Imprimir(new List<FormaGeometrica>(), new CultureInfo("en")));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new Cuadrado(5)};

            var resumen = ReporteFormas.Imprimir(cuadrados, new CultureInfo("es"));

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 Formas Perímetro 20 Área 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = ReporteFormas.Imprimir(cuadrados, new CultureInfo("en"));

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 Shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = ReporteFormas.Imprimir(formas, new CultureInfo("en"));

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52.03 | Perimeter 36.13 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 Shapes Perimeter 115.73 Area 130.67",
                resumen);

        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = ReporteFormas.Imprimir( formas, new CultureInfo("es"));

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 52.03 | Perímetro 36.13 <br/>3 Triángulos | Área 49.64 | Perímetro 51.6 <br/>TOTAL:<br/>7 Formas Perímetro 115.73 Área 130.67",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            var rectangulos = new List<FormaGeometrica> { new TrapecioRectangulo(5,2) };

            var resumen = ReporteFormas.Imprimir(rectangulos, new CultureInfo("es"));

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio/Rectángulo | Área 10 | Perímetro 14 <br/>TOTAL:<br/>1 Formas Perímetro 14 Área 10", resumen);
        }

        [TestCase]
        public void TestResumenListaConDosTrapeciosUnRectanguloEnItaliano()
        {
            var trapecios = new List<FormaGeometrica> 
            { 
                new TrapecioRectangulo(3, 5, 8), 
                new TrapecioRectangulo(4, 2, 10),
                new TrapecioRectangulo(4,6)
            };

            var resumen = ReporteFormas.Imprimir(trapecios, new CultureInfo("it"));

            Assert.AreEqual("<h1>Rapporto di Formi</h1>3 Trapezi/Rettangoli | Area 86 | Perimetro 70.11 <br/>TOTAL:<br/>3 Forme Perimetro 70.11 Area 86", resumen);
        }

        [TestCase]
        public void TestResumenListaConDosFigurasDeCadaTipoEnItaliano()
        {
            var formasvarias = new List<FormaGeometrica>
            {
                new Circulo(7),
                new Circulo(3.88m),
                new Cuadrado(5.5m),
                new Cuadrado(4),
                new TrianguloEquilatero(7),
                new TrianguloEquilatero(3.75m),
                new TrapecioRectangulo(3, 5, 8),
                new TrapecioRectangulo(4,6)
            };

            var resumen = ReporteFormas.Imprimir(formasvarias, new CultureInfo("it"));

            Assert.AreEqual("<h1>Rapporto di Formi</h1>2 Cerchi | Area 201.23 | Perimetro 68.36 <br/>2 Quadrati | Area 46.25 | Perimetro 38 <br/>2 Triangoli | Area 27.31 | Perimetro 32.25 <br/>2 Trapezi/Rettangoli | Area 56 | Perimetro 44.06 <br/>TOTAL:<br/>8 Forme Perimetro 182.67 Area 330.79", resumen);
        }
    }
}
