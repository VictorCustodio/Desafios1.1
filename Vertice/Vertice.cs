using System;

public class Program
{
    static void Main(string[] args)
    {
        double verticeX = double.Parse(Console.ReadLine());
        double verticeY = double.Parse(Console.ReadLine());

        Vertice vertice1 = new Vertice(verticeX, verticeY);

        double verticeX2 = double.Parse(Console.ReadLine());
        double verticeY2 = double.Parse(Console.ReadLine());

        Vertice vertice2 = new Vertice(verticeX2, verticeY2);

        double distancia = vertice1.Distancia(vertice2);

        Console.WriteLine($"distancia entre dois vertices: {distancia}");

        Console.WriteLine("coordenadas para mover o vertice:");

        double novoX = double.Parse(Console.ReadLine());
        double novoY = double.Parse(Console.ReadLine());

        vertice1.Move(novoX, novoY);

        Console.WriteLine($"foi movido para: ({vertice1.XReal}, {vertice1.YReal})");

        bool saoIguais = vertice1.Equals(vertice2);

        Console.WriteLine($"São Iguais {saoIguais}");
    }
}
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