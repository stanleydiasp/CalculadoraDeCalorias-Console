namespace CalculadoraDeCalorias.src
{
    public class Macro
    {
        private CalculadoraCaloriasDaDieta _calculadoraCaloriasDaDieta;

        public Macro(CalculadoraCaloriasDaDieta calculadoraCaloriasDaDieta)
        {
            _calculadoraCaloriasDaDieta = calculadoraCaloriasDaDieta;

        }

        public MacroResult CalculoMacrosDaDieta(int respObjetivo, double caloriasDaDieta, int fatorAtividade, double quantidadeDeCalorias)
        {
            double calorias = _calculadoraCaloriasDaDieta.CalculoCaloriasDaDieta(respObjetivo, fatorAtividade, quantidadeDeCalorias);
            double quantidadeDeCarboidrato = 0;
            double quantidadeDeProteina = 0;
            double quantidadeDeGordura = 0;

            if (respObjetivo == 1)
            {
                quantidadeDeCarboidrato = (calorias * 0.5) / 4;
                quantidadeDeProteina = (calorias * 0.3) / 4;
                quantidadeDeGordura = (calorias * 0.2) / 9;

            }
            else if (respObjetivo == 2)
            {
                quantidadeDeCarboidrato = (calorias * 0.5) / 4;
                quantidadeDeProteina = (calorias * 0.3) / 4;
                quantidadeDeGordura = (calorias * 0.2) / 9;
            }
            else if (respObjetivo == 3)
            {
                quantidadeDeCarboidrato = (calorias * 0.6) / 4;
                quantidadeDeProteina = (calorias * 0.2) / 4;
                quantidadeDeGordura = (calorias * 0.2) / 9;
            }

            var result = new MacroResult()
            {
                QuantidadeDeCarboidrato = quantidadeDeCarboidrato,
                QuantidadeDeProteina = quantidadeDeProteina,
                QuantidadeDeGordura = quantidadeDeGordura
            };
            return result;
        }
    }

    public class MacroResult
    {
        public double QuantidadeDeCarboidrato { get; set; }
        public double QuantidadeDeProteina { get; set; }
        public double QuantidadeDeGordura { get; set; }
    }
}