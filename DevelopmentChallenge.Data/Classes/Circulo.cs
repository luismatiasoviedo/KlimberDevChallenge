using System;
using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private readonly decimal _radio;
        private readonly ResourceManager _resourceManager;

        public Circulo(decimal radio)
        {
            _radio = radio;
            _resourceManager = new ResourceManager(Constants.Constants.UbicacionArhivoRecursos, typeof(Circulo).Assembly);
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (decimal)Math.Pow((double) _radio,2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _radio * 2;
        }

        public override string Traducir(int cantidad, CultureInfo idioma)
        {
            return cantidad == 1 ? _resourceManager.GetString(Constants.Constants.CirculoSingular, idioma) :
                                    _resourceManager.GetString(Constants.Constants.CirculoPlural, idioma);
        }

    }
}
