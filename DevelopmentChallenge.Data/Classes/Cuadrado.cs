using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;
        private readonly ResourceManager _resourceManager;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
            _resourceManager = new ResourceManager(Constants.Constants.UbicacionArhivoRecursos, typeof(Cuadrado).Assembly);
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public override string Traducir(int cantidad, CultureInfo idioma)
        {
            return cantidad == 1 ? _resourceManager.GetString(Constants.Constants.CuadradoSingular, idioma) :
                                    _resourceManager.GetString(Constants.Constants.CuadradoPlural, idioma);
        }

    }
}
