namespace CalculadoraDeCalorias.src
{
    public class CalculadoraGet
    {
        public double Get { get; set; }
        private CalculadoraTmb _calculadoraTmb;

        public CalculadoraGet(CalculadoraTmb calculadoraTmb)
        {
            _calculadoraTmb = calculadoraTmb;
        }

        public double CalcularGet(int fatorAtividade)
        {
            double get = 0;

            if (fatorAtividade == 1)
                get = _calculadoraTmb.CalcularTmb() * 1.2;
            else if (fatorAtividade == 2)
                get = _calculadoraTmb.CalcularTmb() * 1.375;
            else if (fatorAtividade == 3)
                get = _calculadoraTmb.CalcularTmb() * 1.55;
            else if (fatorAtividade == 4)
                get = _calculadoraTmb.CalcularTmb() * 1.725;
            else if (fatorAtividade == 5)
                get = _calculadoraTmb.CalcularTmb() * 1.9;

            return get;

        }
    }
}