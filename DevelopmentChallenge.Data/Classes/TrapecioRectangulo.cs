
using System;
using System.Globalization;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrapecioRectangulo: FormaGeometrica
    {
        private readonly decimal _base1;
        private readonly decimal _base2;
        private readonly decimal _largo;
        private readonly decimal _ancho;
        private readonly decimal _altura;
        private readonly ResourceManager _resourceManager;

        /// <summary>
        /// Contructor para instanciar un Rectángulo
        /// </summary>
        /// <param name="largo"></param>
        /// <param name="ancho"></param>
        public TrapecioRectangulo(decimal largo, decimal ancho)
        {
            _largo = largo;
            _ancho = ancho;
            _resourceManager = new ResourceManager(Constants.Constants.UbicacionArhivoRecursos, typeof(TrapecioRectangulo).Assembly);
        }

        /// <summary>
        /// Constructor para instanciar un Trapecio
        /// </summary>
        /// <param name="base1"></param>
        /// <param name="base2"></param>
        /// <param name="altura"></param>
        public TrapecioRectangulo(decimal base1, decimal base2, decimal altura)
        {
            _base1 = base1;
            _base2 = base2;
            _altura = altura;
            _resourceManager = new ResourceManager(Constants.Constants.UbicacionArhivoRecursos, typeof(TrapecioRectangulo).Assembly);
        }

        /// <summary>
        /// Calcula el Area dependiendo qué subtipo de figura se instanció
        /// </summary>
        /// <returns>decimal conteniendo el valor del area</returns>
        public override decimal CalcularArea()
        {
            if (_altura == 0)
            {
                //Es un rectángulo
                return _largo * _ancho;
            }
            else
            {
                //es un trapecio
                return (decimal)((_base1 + _base2) * _altura) / 2;
            }
        }

        /// <summary>
        /// Calcula el Perímetro dependiendo qué subtipo de figura se instanció
        /// </summary>
        /// <returns>decimal conteniendo el valor del perímetro</returns>
        public override decimal CalcularPerimetro()
        {
            if (_altura == 0)
            {
                //Es un rectángulo
                return (_largo + _ancho) * 2;
            }
            else
            {
                //es un trapecio
                decimal lado1 = (decimal)Math.Sqrt(Math.Pow((double)(_base2 - _base1) / 2, 2) + Math.Pow((double)_altura, 2));
                decimal lado2 = (decimal)Math.Sqrt(Math.Pow((double)_ancho, 2) + Math.Pow((double)_altura, 2));
                return _base1 + _base2 + lado1 + lado2;
            }
        }

        public override string Traducir(int cantidad, CultureInfo idioma)
        {
            return cantidad == 1 ? _resourceManager.GetString(Constants.Constants.TrapecioRectanguloSingular, idioma) :
                                     _resourceManager.GetString(Constants.Constants.TrapecioRectanguloPlural, idioma);
        }
    }
}
