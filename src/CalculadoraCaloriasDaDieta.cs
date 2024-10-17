using System.Collections.Concurrent;

namespace CalculadoraDeCalorias.src
{
    public class CalculadoraCaloriasDaDieta
    {

        private CalculadoraGet _calculadoraGet;

        public CalculadoraCaloriasDaDieta(CalculadoraGet calculadoraGet)
        {
            _calculadoraGet = calculadoraGet;
        }

        //Fazer de um jeito para que seja possível a pessoa escolher a quantidade de calorias que deseja reduzir!
        public double CalculoCaloriasDaDieta(int respObjetivo, int fatorAtividade, double quantidadeDeCalorias)
        {
            double caloriasDaDieta = 0;
            double get = _calculadoraGet.CalcularGet(fatorAtividade);

            if (respObjetivo == 1)
                caloriasDaDieta = get - quantidadeDeCalorias;
            else if (respObjetivo == 2)
                caloriasDaDieta = get;
            else if (respObjetivo == 3)
                caloriasDaDieta = get + quantidadeDeCalorias;

            return caloriasDaDieta;
        }
    }
}