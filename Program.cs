using System.Runtime.InteropServices;
using CalculadoraDeCalorias.src;

Pessoa p1 = new Pessoa();

double calculoGet;
double calculoTmb;
bool sexoValido = false, nValido = false;
int fatorAtividade = 0;
int respObjetivo = 0;
double quantidadeDeCalorias = 0;


Console.WriteLine("\x1b[1;30;42mCalculadora de gasto calórico\x1b[0m \n");


Console.Write("Digite seu nome: ");
p1.Nome = Console.ReadLine();

do
{
    Console.Write("Digite sua idade: ");
    p1.Idade = Convert.ToInt32(Console.ReadLine());

    if (p1.Idade <= 0)
        Console.WriteLine("Erro: Digite uma idade válida!");


} while (p1.Idade <= 0);


do
{
    Console.Write("Digite sua altura (em cm): ");
    string entradaAltura = Console.ReadLine();

    if (!int.TryParse(entradaAltura, out int altura) || altura <= 0)
        Console.WriteLine("Digite sua altura (em cm):");
    else
        p1.Altura = altura;

} while (p1.Altura <= 0);


do
{
    Console.Write("Digite seu peso: ");
    p1.Peso = Convert.ToDouble(Console.ReadLine());

    if (p1.Peso <= 0)
        Console.WriteLine("Digite um peso válido. Digite novamente");

} while (p1.Peso <= 0);


do
{
    Console.Write("Digite seu sexo (M/F): ");
    p1.Sexo = Console.ReadLine().ToLower();
    Console.WriteLine("\n");


    if (p1.Sexo != "f" && p1.Sexo != "m" && p1.Sexo != "feminino" && p1.Sexo != "masculino")
    {
        sexoValido = false;
        Console.WriteLine("Digite o sexo corretamente. Digite novamente");
    }
    else
    {
        sexoValido = true;
    }

} while (sexoValido == false);

do
{
    Console.WriteLine("\x1b[1;33;46mFator de atividade:\x1b[0m \n");
    Console.WriteLine("\x1b[1;31;40mSedentário (pouca ou nenhuma atividade física) = 1\x1b[0m \n");
    Console.WriteLine("\x1b[1;33;40mLevemente ativo (Atividade física leve) = 2\x1b[0m \n");
    Console.WriteLine("\x1b[1;34;40mModeradamente ativo (Atividade física moderada 3/5x por semana) = 3\x1b[0m \n");
    Console.WriteLine("\x1b[1;32;40mAltamente ativo (Atividade física intensa 6/7x por semana) = 4\x1b[0m \n");
    Console.WriteLine("\x1b[1;35;40mExtremamente ativo (Atleta / treina 2x ou mais por dia) = 5\x1b[0m \n");
    Console.Write("Digite o nº do fator de atividade em que você se encaixa: ");
    fatorAtividade = Convert.ToInt32(Console.ReadLine());


    if (fatorAtividade != 1 && fatorAtividade != 2 && fatorAtividade != 3 && fatorAtividade != 4 && fatorAtividade != 5)
    {
        nValido = false;
        Console.WriteLine("Nº do fator de atividade inválido. Digite um nº válido");
    }
    else
    {
        nValido = true;
    }

} while (nValido == false);

CalculadoraTmb ct1 = new CalculadoraTmb(p1);
calculoTmb = ct1.CalcularTmb();

CalculadoraGet cg1 = new CalculadoraGet(ct1);
calculoGet = cg1.CalcularGet(fatorAtividade);

Console.WriteLine("-------------------------------------------------------------");


if (p1.Sexo == "f" || p1.Sexo == "feminino")
    Console.WriteLine($"\x1b[1;35;40m#### Relatório da {p1.Nome} ####\x1b[0m");
else if (p1.Sexo == "m" || p1.Sexo == "masculino")
    Console.WriteLine($"\x1b[1;36;40m#### Relatório do {p1.Nome} ####\x1b[0m");

Console.WriteLine($"- Sua taxa metabólica basal é: {Math.Round(calculoTmb)} kcal");
Console.WriteLine($"- Seu gasto energético total diário é: {Math.Round(calculoGet)} kcal");


Console.WriteLine("-------------------------------------------------------------");


do
{
    Console.WriteLine("\x1b[1;37;45mQual o seu objetivo?\x1b[0m \n");
    Console.WriteLine("\x1b[1;33;40mEmagrecer - 1\x1b[0m \n");
    Console.WriteLine("\x1b[1;37;40mManutenção (Manter peso) - 2\x1b[0m \n");
    Console.WriteLine("\x1b[1;32;40mGanhar massa (Aumentar peso) - 3\x1b[0m \n");
    Console.Write("Digite o Nº de acordo com seu objetivo: ");
    respObjetivo = Convert.ToInt32(Console.ReadLine());

    if (respObjetivo != 1 && respObjetivo != 2 && respObjetivo != 3)
    {
        nValido = false;
        Console.WriteLine("Nº inválido. Digite novamente: ");

    }
    else
    {
        nValido = true;
    }

} while (nValido == false);


do
{

    if (respObjetivo == 1)
        Console.Write("Digite a quantidade de calorias que deseja diminuir: ");
    else if (respObjetivo == 3)
        Console.Write("Digite a quantidade de calorias que deseja aumentar: ");
    else if (respObjetivo == 2) 
    {
        quantidadeDeCalorias = 0;
        break;
    }

    quantidadeDeCalorias = Convert.ToDouble(Console.ReadLine());

    if (quantidadeDeCalorias <= 0 && respObjetivo != 2)
        Console.WriteLine("Número inválido. Digite novamente");


} while (quantidadeDeCalorias <= 0 && respObjetivo != 2);

CalculadoraCaloriasDaDieta cd1 = new CalculadoraCaloriasDaDieta(cg1);
double caloriasDaDieta = cd1.CalculoCaloriasDaDieta(respObjetivo, fatorAtividade, quantidadeDeCalorias);

Macro m1 = new Macro(cd1);
var macros = m1.CalculoMacrosDaDieta(respObjetivo, caloriasDaDieta, fatorAtividade, quantidadeDeCalorias);

Console.WriteLine("-------------------------------------------------------------");
Console.WriteLine($"\x1b[1;32;40m#### Informações Nutricionais -- {p1.Nome} ####\x1b[0m\n");


if (respObjetivo == 1)
{
    Console.WriteLine($"A quantidade de calorias que você precisa consumir para emagrecer é: \x1b[1;33m{caloriasDaDieta} kcal\x1b[0m");
    Console.WriteLine($"Quantidade de carboidrato: \x1b[1;33m{macros.QuantidadeDeCarboidrato}g\x1b[0m");
    Console.WriteLine($"Quantidade de proteína: \x1b[1;33m{macros.QuantidadeDeProteina}g\x1b[0m");
    Console.WriteLine($"Quantidade de gordura: \x1b[1;33m{macros.QuantidadeDeGordura}g\x1b[0m");
}
else if (respObjetivo == 2)
{
    Console.WriteLine($"A quantidade de calorias que você precisa consumir para manter seu peso é: \x1b[1;33m{caloriasDaDieta} kcal\x1b[0m");
    Console.WriteLine($"Quantidade de carboidrato: \x1b[1;33m{macros.QuantidadeDeCarboidrato}g\x1b[0m");
    Console.WriteLine($"Quantidade de proteína: \x1b[1;33m{macros.QuantidadeDeProteina}g\x1b[0m");
    Console.WriteLine($"Quantidade de gordura: \x1b[1;33m{macros.QuantidadeDeGordura}g\x1b[0m");
}
else if (respObjetivo == 3)
{
    Console.WriteLine($"A quantidade de calorias que você precisa consumir para ganhar massa é: \x1b[1;33m{Math.Round(caloriasDaDieta)} kcal\x1b[0m");
    Console.WriteLine($"Quantidade de carboidrato: \x1b[1;33m{Math.Round(macros.QuantidadeDeCarboidrato)}g\x1b[0m");
    Console.WriteLine($"Quantidade de proteína: \x1b[1;33m{Math.Round(macros.QuantidadeDeProteina)}g\x1b[0m");
    Console.WriteLine($"Quantidade de gordura: \x1b[1;33m{Math.Round(macros.QuantidadeDeGordura)}g\x1b[0m");
}









