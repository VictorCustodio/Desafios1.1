using System;

public class Intervalo
{
    public DateTime Inicio { get; }
    public DateTime Fim { get; }

    public Intervalo(DateTime inicio, DateTime fim)
    {
        if (inicio >= fim)
            throw new ArgumentException("A data/hora inicial deve ser anterior à data/hora final.");

        Inicio = inicio;
        Fim = fim;
    }

    public bool TemIntersecao(Intervalo outro)
    {
        return Inicio < outro.Fim && Fim > outro.Inicio;
    }

    public override bool Equals(object obj)
    {
        if (obj is Intervalo outro)
        {
            return Inicio == outro.Inicio && Fim == outro.Fim;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Inicio, Fim);
    }

    public TimeSpan Duracao
    {
        get
        {
            return Fim - Inicio;
        }
    }
}