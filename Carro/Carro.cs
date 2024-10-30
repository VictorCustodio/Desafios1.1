using System;
using System.Collections.Generic;

public class Motor
{
    public double Cilindrada { get; }
    public Carro CarroInstalado { get; private set; }

    public Motor(double cilindrada)
    {
        if (cilindrada <= 0)
            throw new ArgumentException("Cilindrada deve ser maior que zero.");

        Cilindrada = cilindrada;
    }

    public void InstalarEmCarro(Carro carro)
    {
        if (CarroInstalado != null)
            throw new InvalidOperationException("Este motor já está instalado em um carro.");

        CarroInstalado = carro;
    }

    public void RemoverDeCarro()
    {
        CarroInstalado = null;
    }
}

public class Carro
{
    public string Placa { get; }
    public string Modelo { get; }
    private Motor _motor;

    public Motor Motor
    {
        get => _motor;
        set
        {
            if (value == null)
                throw new ArgumentException("O carro deve ter um motor.");

            if (value.CarroInstalado != null && value.CarroInstalado != this)
                throw new InvalidOperationException("Este motor já está instalado em outro carro.");

            _motor?.RemoverDeCarro();
            _motor = value;
            _motor.InstalarEmCarro(this);
        }
    }

    public Carro(string placa, string modelo, Motor motor)
    {
        if (string.IsNullOrWhiteSpace(placa))
            throw new ArgumentException("Placa é obrigatória.");
        if (string.IsNullOrWhiteSpace(modelo))
            throw new ArgumentException("Modelo é obrigatório.");
        if (motor == null)
            throw new ArgumentException("Motor é obrigatório.");

        Placa = placa;
        Modelo = modelo;
        Motor = motor;
    }

    public double CalcularVelocidadeMaxima()
    {
        if (Motor.Cilindrada <= 1.0)
            return 140;
        if (Motor.Cilindrada <= 1.6)
            return 160;
        if (Motor.Cilindrada <= 2.0)
            return 180;
        return 220;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Motor motor1 = new Motor(1.6);
            Carro carro1 = new Carro("ABC1234", "Modelo A", motor1);

            Console.WriteLine($"Carro 1: Placa = {carro1.Placa}, Modelo = {carro1.Modelo}, Motor = {carro1.Motor.Cilindrada}, Velocidade Máxima = {carro1.CalcularVelocidadeMaxima()} km/h");

            Motor motor2 = new Motor(2.0);
            carro1.Motor = motor2;

            Console.WriteLine($"Carro 1 após troca de motor: Placa = {carro1.Placa}, Modelo = {carro1.Modelo}, Motor = {carro1.Motor.Cilindrada}, Velocidade Máxima = {carro1.CalcularVelocidadeMaxima()} km/h");

            Carro carro2 = new Carro("XYZ5678", "Modelo B", motor1);
            Console.WriteLine($"Carro 2: Placa = {carro2.Placa}, Modelo = {carro2.Modelo}, Motor = {carro2.Motor.Cilindrada}, Velocidade Máxima = {carro2.CalcularVelocidadeMaxima()} km/h");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}