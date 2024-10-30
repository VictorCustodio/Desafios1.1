using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

public class ListaIntervalo
{
    private List<Intervalo> intervalos = new List<Intervalo>();

    public void Add(Intervalo novoIntervalo)
    {
        foreach (var intervalo in intervalos)
        {
            if (intervalo.TemIntersecao(novoIntervalo))
                throw new InvalidOperationException("O intervalo intersecta com um intervalo existente.");
        }
        intervalos.Add(novoIntervalo);
        intervalos = intervalos.OrderBy(i => i.Inicio).ToList();
    }

    public ReadOnlyCollection<Intervalo> Intervalos
    {
        get
        {
            return intervalos.AsReadOnly();
        }
    }
}