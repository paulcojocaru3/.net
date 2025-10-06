ex3.t();



public record student(string Name);

public class ex3
{
    
    public static void t()
    {
        List<student> listaDeNume = new List<student>();
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "end")
                {
                break;
                }
            else
            {
                listaDeNume.Add(new student(input));
            }

        }

        foreach (var s in listaDeNume)
        {
            Console.WriteLine(s.Name);
        }
    }
}