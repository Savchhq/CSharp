

public class Thermometr
{
    public int temperature { get; set; }
    
    public delegate void Notify(Thermometr thermometr, string msg);
    public event Notify MsgOnTempr;
    public void Display()
    {
        System.Console.WriteLine("Temperature: "+ temperature);
        if(temperature > 30)
        {
            MsgOnTempr?.Invoke(this, "Temperature is high!");
        }
        else if(temperature < 15)
        {
            MsgOnTempr?.Invoke(this, "Temperature is small");
        }
    }
}

    class Program
{
    static void Check(Thermometr thermometr, string msg)
    {
            System.Console.WriteLine(msg);

    } 
      static void Main(string[] args)
        {
            Thermometr thermometr = new Thermometr();
            thermometr.MsgOnTempr += Check;
            thermometr.temperature = 31;
            thermometr.Display();
            thermometr.temperature = 25;
            thermometr.Display();
            thermometr.temperature = 11;
            thermometr.Display();


        }
}
