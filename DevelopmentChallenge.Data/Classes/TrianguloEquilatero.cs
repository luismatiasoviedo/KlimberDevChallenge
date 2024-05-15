using System;
using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        private readonly decimal _lado;
        private readonly ResourceManager _resourceManager;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
            _resourceManager = new ResourceManager(Constants.Constants.UbicacionArhivoRecursos, typeof(TrianguloEquilatero).Assembly);
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public override string Traducir(int cantidad, CultureInfo idioma)
        {
            return cantidad == 1 ? _resourceManager.GetString(Constants.Constants.TrianguloSingular, idioma) :
                                    _resourceManager.GetString(Constants.Constants.TrianguloPlural, idioma);
        }

    }
}
