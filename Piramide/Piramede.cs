using System;

class Program
{
    static void Main(string[] args)
    {
        int tamanhoPiramede = int.Parse(Console.ReadLine());
        Console.WriteLine(tamanhoPiramede);
       
        try
        {
            Piramede teste = new Piramede(tamanhoPiramede);
            teste.Desenha();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
public class Piramede
{
    private int numberPiramide;
    public int NumberPiramide
    {
        get { return numberPiramide; }
        set
        {
            if (value >= 1)
            {
                numberPiramide = value;
            }
        }
    }

    public Piramede(int numberPiramedeNew)
    {
        if (numberPiramedeNew < 1)
        {
            throw new System.ArgumentException("Parâmetro não pode ser menor que 1");
        }
        else
        {
            this.NumberPiramide = numberPiramedeNew;
        }
    }

    public void Desenha()
    {
        int counter = 0;
        int spaces = this.NumberPiramide;
        while (counter < this.NumberPiramide)
        {
            for (int i = 0; i < this.NumberPiramide; i++)
            {
                for (int k = 0; k < spaces -1 ; k++)
                {
                    Console.Write(" ");
                }
                for (int x = 0; x <= counter; x++)
                {
                    Console.Write(x + 1);
                }
                for (int y = counter; y >= 1; y--)
                {
                    Console.Write(y);
                }
                Console.WriteLine();
                counter++;
                spaces--;
            }
            
        }
    }
}