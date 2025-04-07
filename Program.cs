//Interface, joka määrittää auton toiminnot, joita kaikkien rajapintaa implementoitavien on toteutettava

public interface ICar
{
    string GetAccessories();
    double GetCost();
}

//Perusauto, joka implementoi ICar- interfacen
public class BasicCar : ICar
{
    public string GetAccessories() => "Perusvarustelu";
    public double GetCost() => 20000;
}

//Abstrakti dekoraattoriluokka
public abstract class CarDecorator : ICar
{
    // Säilyttää viitteen alkuperäiseen autoon.
    protected ICar _car;

    //Konstruktori ottaa ICar-tyyppiä olevan auton
    public CarDecorator(ICar car)
    {
        _car = car;
    }

    // Perusmetodit, jotka ovat ylikirjoitettavissa aliluokilla
    public virtual string GetAccessories() => _car.GetAccessories();
    public virtual double GetCost() => _car.GetCost();
}

// Dekoraattori, joka lisää kevytmetallivanteet
public class AlloyWheelsDecorator : CarDecorator
{
    // Konstruktori kutsuu perityn kantaluokan konstruktoria
    public AlloyWheelsDecorator(ICar car) : base(car) { }

    // Ylikirjoitetaan varustelista ja lisätään kevytmetallivanteet
    public override string GetAccessories() => _car.GetAccessories() + " + 17\" kevytmetallivanteet";

    // Ylikirjoitetaan hinta ja lisätään 1500€ vanteista
    public override double GetCost() => _car.GetCost() + 1500;
}

// Dekoraattori, joka lisää nahkaistuimet
public class LeatherSeatsDecorator : CarDecorator
{
    // Konstruktori kutsuu perityn kantaluokan konstruktoria
    public LeatherSeatsDecorator(ICar car) : base(car) { }

    // Ylikirjoitetaan varustelista ja lisätään kevytmetallivanteet
    public override string GetAccessories() => _car.GetAccessories() + " + nahkaistuimet";

    // Ylikirjoitetaan hinta ja lisätään 3000 nahkaistuimista
    public override double GetCost() => _car.GetCost() + 3000;
}
public class PremiumSoundDecorator : CarDecorator
{
    // Konstruktori kutsuu perityn kantaluokan konstruktoria
    public PremiumSoundDecorator(ICar car) : base(car) { }

    // Ylikirjoitetaan varustelista ja lisätään Premium-Sound -äänentoistojärjestelmä
    public override string GetAccessories() => _car.GetAccessories() + " + Premium-Sound -äänentoistojärjestelmä";

    // Ylikirjoitetaan hinta ja lisätään 2500 äänentoistojärjestelmästä
    public override double GetCost() => _car.GetCost() + 2500;
}


public class Program
{
    public static void Main(string[] args)
    {
        ICar car = new BasicCar();

        int choice = 0;
        bool hasAlloywheels = false;
        bool hasLeatherSeats = false;
        bool hasPremiumSound = false;

        while (choice != 4)
        {
            Console.WriteLine("\n--Valitse autoosi varusteet--");
            Console.WriteLine("\n1: 17\" kevytmetallivanteet");
            Console.WriteLine("2: Nahkaistuimet");
            Console.WriteLine("3: Premium-sound -äänentoistojärjestelmä");
            Console.WriteLine("4: Lopeta");

            Console.Write("Valinta: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (!hasAlloywheels)
                    {
                        // Auto koristellaan kevytmetallivanteilla välittämällä se Decorator-luokalle, joka lisää varusteen ja nostaa kokonaishintaa.
                        car = new AlloyWheelsDecorator(car);
                        hasAlloywheels = true;

                        Console.WriteLine($"\nVarusteet: {car.GetAccessories()}");
                        Console.WriteLine($"Hinta varusteineen: {car.GetCost()} €");

                    }
                    else
                    {
                        Console.WriteLine("\n**Varuste on jo valittu.**");
                        Console.WriteLine($"Varusteet: {car.GetAccessories()}");
                        Console.WriteLine($"Hinta varusteineen: {car.GetCost()} €");
                    }
                    break;

                case 2:
                    if (!hasLeatherSeats)
                    {
                        // Auto koristellaan nahkaistuimilla välittämällä se Decorator-luokalle, joka lisää varusteen ja nostaa kokonaishintaa.
                        car = new LeatherSeatsDecorator(car);
                        hasLeatherSeats = true;
                        Console.WriteLine($"\nVarusteet: {car.GetAccessories()}");
                        Console.WriteLine($"Hinta varusteineen: {car.GetCost()} €");

                    }
                    else
                    {
                        Console.WriteLine("\n**Varuste on jo valittu.**");
                        Console.WriteLine($"Varusteet: {car.GetAccessories()}");
                        Console.WriteLine($"Hinta varusteineen: {car.GetCost()} €");
                    }
                    break;
                case 3:
                    if (!hasPremiumSound)
                    {
                        // Auto koristellaan äänentoistojärjestelmällä välittämällä se Decorator-luokalle, joka lisää varusteen ja nostaa kokonaishintaa.
                        car = new PremiumSoundDecorator(car);
                        hasPremiumSound = true;
                        Console.WriteLine($"\nVarusteet: {car.GetAccessories()}");
                        Console.WriteLine($"Hinta varusteineen: {car.GetCost()} €");
                    }
                    else
                    {
                        Console.WriteLine("\n**Varuste on jo valittu.**");
                        Console.WriteLine($"Varusteet: {car.GetAccessories()}");
                        Console.WriteLine($"Hinta varusteineen: {car.GetCost()} €");
                    }
                    break;
                case 4:
                    break;

                default:
                    Console.WriteLine("\nVirheellinen valinta.");
                    break;

            }
        }
    }
}
