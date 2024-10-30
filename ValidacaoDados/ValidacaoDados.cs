using System;
using System.Globalization;

public class Cliente
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public float RendaMensal { get; set; }
    public char EstadoCivil { get; set; }
    public int Dependentes { get; set; }

    public static bool ValidarNome(string nome)
    {
        return nome.Length >= 5;
    }

    public static bool ValidarCPF(string cpf)
    {
        if (cpf.Length != 11 || long.TryParse(cpf, out _) == false)
            return false;

        for (int i = 1; i < 11; i++)
            if (cpf[i] != cpf[0])
                break;
            else if (i == 10)
                return false;

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        string digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }

    public static bool ValidarDataNascimento(string data, out DateTime dataNascimento)
    {
        if (DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascimento))
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (dataNascimento > DateTime.Now.AddYears(-idade)) idade--;
            return idade >= 18;
        }
        return false;
    }

    public static bool ValidarRendaMensal(string renda, out float rendaMensal)
    {
        return float.TryParse(renda, NumberStyles.Float, CultureInfo.InvariantCulture, out rendaMensal) && rendaMensal >= 0;
    }

    public static bool ValidarEstadoCivil(string estadoCivil, out char estado)
    {
        estado = char.ToUpper(estadoCivil[0]);
        return estado == 'C' || estado == 'S' || estado == 'V' || estado == 'D';
    }

    public static bool ValidarDependentes(string dependentes, out int numDependentes)
    {
        return int.TryParse(dependentes, out numDependentes) && numDependentes >= 0 && numDependentes <= 10;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Cliente cliente = new Cliente();

        while (true)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            if (Cliente.ValidarNome(nome))
            {
                cliente.Nome = nome;
                break;
            }
            Console.WriteLine("Nome inválido. Deve ter pelo menos 5 caracteres.");
        }

        while (true)
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            if (Cliente.ValidarCPF(cpf))
            {
                cliente.CPF = cpf;
                break;
            }
            Console.WriteLine("CPF inválido.");
        }

        while (true)
        {
            Console.Write("Data de Nascimento (DD/MM/AAAA): ");
            string dataNascimento = Console.ReadLine();
            if (Cliente.ValidarDataNascimento(dataNascimento, out DateTime data))
            {
                cliente.DataNascimento = data;
                break;
            }
            Console.WriteLine("Data de nascimento inválida ou cliente menor de 18 anos.");
        }

        while (true)
        {
            Console.Write("Renda Mensal: ");
            string renda = Console.ReadLine();
            if (Cliente.ValidarRendaMensal(renda, out float rendaMensal))
            {
                cliente.RendaMensal = rendaMensal;
                break;
            }
            Console.WriteLine("Renda mensal inválida.");
        }

        while (true)
        {
            Console.Write("Estado Civil (C, S, V, D): ");
            string estadoCivil = Console.ReadLine();
            if (Cliente.ValidarEstadoCivil(estadoCivil, out char estado))
            {
                cliente.EstadoCivil = estado;
                break;
            }
            Console.WriteLine("Estado civil inválido.");
        }

        while (true)
        {
            Console.Write("Dependentes: ");
            string dependentes = Console.ReadLine();
            if (Cliente.ValidarDependentes(dependentes, out int numDependentes))
            {
                cliente.Dependentes = numDependentes;
                break;
            }
            Console.WriteLine("Número de dependentes inválido.");
        }

        Console.WriteLine("\nDados do Cliente:");
        Console.WriteLine($"Nome: {cliente.Nome}");
        Console.WriteLine($"CPF: {cliente.CPF}");
        Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento:dd/MM/yyyy}");
        Console.WriteLine($"Renda Mensal: {cliente.RendaMensal:F2}");
        Console.WriteLine($"Estado Civil: {cliente.EstadoCivil}");
        Console.WriteLine($"Dependentes: {cliente.Dependentes}");
    }
}