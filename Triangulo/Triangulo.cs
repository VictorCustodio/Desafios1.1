using System;

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
        return novo.VerticeIguais(novo2) ? true : false;
    }
}

public enum TipoTriangulo
{
    Equilatero,
    Isosceles,
    Escaleno
}

public class Triangulo
{
    public Vertice Vertice1 { get; private set; }
    public Vertice Vertice2 { get; private set; }
    public Vertice Vertice3 { get; private set; }

    public Triangulo(Vertice v1, Vertice v2, Vertice v3)
    {
        if (!FormaTriangulo(v1, v2, v3))
            throw new ArgumentException("Os vértices não formam um triângulo.");

        Vertice1 = v1;
        Vertice2 = v2;
        Vertice3 = v3;
    }

    private bool FormaTriangulo(Vertice v1, Vertice v2, Vertice v3)
    {
        double a = v1.Distancia(v2);
        double b = v2.Distancia(v3);
        double c = v3.Distancia(v1);

        return a + b > c && a + c > b && b + c > a;
    }

    public bool VerticeIguais(Triangulo outro)
    {
        return (Vertice1.VerticeIguais(outro.Vertice1) && Vertice2.VerticeIguais(outro.Vertice2) && Vertice3.VerticeIguais(outro.Vertice3)) ||
               (Vertice1.VerticeIguais(outro.Vertice1) && Vertice2.VerticeIguais(outro.Vertice3) && Vertice3.VerticeIguais(outro.Vertice2)) ||
               (Vertice1.VerticeIguais(outro.Vertice2) && Vertice2.VerticeIguais(outro.Vertice1) && Vertice3.VerticeIguais(outro.Vertice3)) ||
               (Vertice1.VerticeIguais(outro.Vertice2) && Vertice2.VerticeIguais(outro.Vertice3) && Vertice3.VerticeIguais(outro.Vertice1)) ||
               (Vertice1.VerticeIguais(outro.Vertice3) && Vertice2.VerticeIguais(outro.Vertice1) && Vertice3.VerticeIguais(outro.Vertice2)) ||
               (Vertice1.VerticeIguais(outro.Vertice3) && Vertice2.VerticeIguais(outro.Vertice2) && Vertice3.VerticeIguais(outro.Vertice1));
    }

    public double Perimetro
    {
        get
        {
            double a = Vertice1.Distancia(Vertice2);
            double b = Vertice2.Distancia(Vertice3);
            double c = Vertice3.Distancia(Vertice1);
            return a + b + c;
        }
    }

    public TipoTriangulo Tipo
    {
        get
        {
            double a = Vertice1.Distancia(Vertice2);
            double b = Vertice2.Distancia(Vertice3);
            double c = Vertice3.Distancia(Vertice1);

            if (a == b && b == c)
                return TipoTriangulo.Equilatero;
            else if (a == b || b == c || a == c)
                return TipoTriangulo.Isosceles;
            else
                return TipoTriangulo.Escaleno;
        }
    }

    public double Area
    {
        get
        {
            double a = Vertice1.Distancia(Vertice2);
            double b = Vertice2.Distancia(Vertice3);
            double c = Vertice3.Distancia(Vertice1);
            double s = Perimetro / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}