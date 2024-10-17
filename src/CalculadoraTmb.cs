namespace CalculadoraDeCalorias.src
{
    public class CalculadoraTmb
    {
        private Pessoa _pessoa;

        public CalculadoraTmb(Pessoa pessoa)
        {
            _pessoa = pessoa;
        }

        public double CalcularTmb() { 
            double tmb = 0;

            if (_pessoa.Sexo == "m")
                tmb = 88.36 + ((13.4 * _pessoa.Peso) + (4.8 * _pessoa.Altura) - (5.7 * _pessoa.Idade));
            else if (_pessoa.Sexo == "f")
                tmb = 447.6 + ((9.2 * _pessoa.Peso) + (3.1 * _pessoa.Altura) - (4.3 * _pessoa.Idade));

            return tmb;
        }
    }
}