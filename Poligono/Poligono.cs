using System;
using System.Collections.Generic;
using System.Linq;
public class Vertice
{
    public double xReal;
    public double XReal
    {
        get { return xReal; }
        private set { xReal = value; }
    }
    public double yReal;
    public double YReal
    {
        get { return yReal; }
        private set { yReal = value; }
    }

    
    public Vertice(double x, double y)
    {
        this.XReal = x;
        this.YReal = y;
    }

    public double Distancia(Vertice outroVertice)
    {
        double deltaX = outroVertice.XReal - this.XReal;
        double deltaY = outroVertice.YReal - this.YReal;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    public void Move(double novoX, double novoY)
    {
        this.XReal= novoX;
        this.YReal = novoY;
    }

   public bool VerticeIguais(Vertice novo, Vertice novo2)
    {
        return novo.Equals(novo2) ? true : false;
    }
}
public class Poligono
{
    private List<Vertice> vertices;

    public Poligono(List<Vertice> vertices)
    {
        if (vertices == null || vertices.Count < 3)
            throw new ArgumentException("Um polígono deve ter pelo menos 3 vértices.");

        this.vertices = new List<Vertice>(vertices);
    }

    public bool AddVertice(Vertice v)
    {
        if (vertices.Contains(v))
            return false;

        vertices.Add(v);
        return true;
    }

    public void RemoveVertice(Vertice v)
    {
        if (vertices.Count <= 3)
            throw new InvalidOperationException("Um polígono deve ter pelo menos 3 vértices.");

        vertices.Remove(v);
    }

    public double Perimetro
    {
        get
        {
            double perimetro = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertice atual = vertices[i];
                Vertice proximo = vertices[(i + 1) % vertices.Count];
                perimetro += atual.DistanciaPara(proximo);
            }
            return perimetro;
        }
    }

    public int QuantidadeDeVertices => vertices.Count;
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            List<Vertice> vertices = new List<Vertice>
            {
                new Vertice(0, 0),
                new Vertice(1, 0),
                new Vertice(0, 1)
            };

            Poligono poligono = new Poligono(vertices);
            Console.WriteLine($"Quantidade de Vértices: {poligono.QuantidadeDeVertices}");
            Console.WriteLine($"Perímetro: {poligono.Perimetro}");

            Vertice novoVertice = new Vertice(1, 1);
            if (poligono.AddVertice(novoVertice))
            {
                Console.WriteLine("Vértice adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Vértice já existe no polígono.");
            }

            Console.WriteLine($"Quantidade de Vértices: {poligono.QuantidadeDeVertices}");
            Console.WriteLine($"Perímetro: {poligono.Perimetro}");

            poligono.RemoveVertice(novoVertice);
            Console.WriteLine("Vértice removido com sucesso.");

            Console.WriteLine($"Quantidade de Vértices: {poligono.QuantidadeDeVertices}");
            Console.WriteLine($"Perímetro: {poligono.Perimetro}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
