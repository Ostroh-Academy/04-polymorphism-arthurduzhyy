using System.Text;

namespace Lab4_patterns;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        Console.Write("Виберіть, з яким рівнням хочете працювати (1 або 2): ");
        int type = int.Parse(Console.ReadLine());

        Fraction? f = null;
        if(type == 1)
            f = new Fraction(2, 2);
        else if (type == 2)
            f = new Fraction3D([2, 4, 6], 2);
        else
        {
            Console.WriteLine("Так не можна! Лише 1 або 2!!!");
            return;
        }

        Console.WriteLine(f.ValueAt());
        Console.WriteLine(f.ToString());
    }
}

public class Fraction
{
    public double Denominator { get; set; }
    public double X { get; set; }

    public Fraction(double denominator, double x)
    {
        Denominator = denominator;
        X = x;
    }

    public virtual double ValueAt() => 1.0 / (Denominator * X);

    public override string ToString() => $"Numerator: {1.0}, a: {Denominator}, x: {X}";
}

public class Fraction3D : Fraction
{
    public List<double> Denominators { get; set; }

    public Fraction3D(List<double> denominators, double x) : base(denominators[0], x)
    {
        Denominators = denominators;
    }

    public override double ValueAt()
    {
        return 1.0 / (Denominators[0] * X + (1.0 / (Denominators[1] * X + (1.0 / (Denominators[2] * X)))));
        //return 1.0 / (Denominators[0] * X + (1.0 / (Denominators[1] * X + 1.0 / (Denominators[2] * X))));
    }

    public override string ToString() =>
        $"Numerator: {1.0}, a1: {Denominators[0]}, a2: {Denominators[1]}, a3: {Denominators[2]}";
}