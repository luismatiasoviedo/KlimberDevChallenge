using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class ReporteFormas
    {
        /// <summary>
        /// Genera un reporte en formato html de las figuras geometricas dadas, mostrando perimetros y areas por cada tipo de figura, además un total general
        /// </summary>
        /// <param name="formas">Listado de FormaGenerica de la que se requiere el reporte</param>
        /// <param name="idioma">idioma en el que se necesita mostrar el reporte, en formato CultureInfo. Por ejemplo: new CultureInfo("it") para Italiano</param>
        /// <returns></returns>
        public static string Imprimir(List<FormaGeometrica> formas, CultureInfo idioma)
        {
            StringBuilder sb = new StringBuilder();
            ResourceManager resourceManager = new ResourceManager(Constants.Constants.UbicacionArhivoRecursos, typeof(FormaGeometrica).Assembly);

            if (!formas.Any())
            {
                //Retorna mensaje de reporte vacío
                sb.Append(resourceManager.GetString(Constants.Constants.ListaVacia, idioma));
            }
            else
            {
                //Cabecera del Reporte
                sb.Append(resourceManager.GetString(Constants.Constants.ReporteFormas, idioma));

                //Diccionario para agrupar todas las formas ingresadas por tipo
                var formasAgrupadas = new Dictionary<Type, List<FormaGeometrica>>();

                foreach (var forma in formas)
                {
                    var tipo = forma.GetType();
                    if (!formasAgrupadas.ContainsKey(tipo))
                    {
                        formasAgrupadas[tipo] = new List<FormaGeometrica>();
                    }
                    formasAgrupadas[tipo].Add(forma);
                }

                //Con los tipos agrupados podemos recorrerlos y usar linq para obtener los totales de cada tipo de figura
                foreach (var tipoForma in formasAgrupadas)
                {
                    //Cantidad de objetos de la misma forma
                    var cantidad = tipoForma.Value.Count;
                    //Clase correspondiente
                    var forma = tipoForma.Value[0];
                    //Sumatoria de las Areas
                    var areaTotal = tipoForma.Value.Sum(f => f.CalcularArea());
                    //Sumatoria de los Perimetros
                    var perimetroTotal = tipoForma.Value.Sum(f => f.CalcularPerimetro());
                    //Imprime totales por tipo de forma
                    sb.Append($"{cantidad} {forma.Traducir(cantidad, idioma)} | ");
                    sb.Append($"{resourceManager.GetString(Constants.Constants.Area, idioma)} {areaTotal:#.##} | {resourceManager.GetString(Constants.Constants.Perimetro, idioma)} {perimetroTotal:#.##} <br/>");
                }

                //Cálculo de Totales generales
                var totalFormas = formas.Count;
                var totalArea = formas.Sum(f => f.CalcularArea());
                var totalPerimetro = formas.Sum(f => f.CalcularPerimetro());

                //Imprime y formatea totales
                sb.Append(resourceManager.GetString(Constants.Constants.Total, idioma));
                sb.Append($"{totalFormas} {resourceManager.GetString(Constants.Constants.Formas, idioma)} ");
                sb.Append($"{resourceManager.GetString(Constants.Constants.Perimetro, idioma)} {totalPerimetro:#.##} ");
                sb.Append($"{resourceManager.GetString(Constants.Constants.Area, idioma)} {totalArea:#.##}");
            }

            return sb.ToString();
        }
    }
}
