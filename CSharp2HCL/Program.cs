// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        var intParameter = new IntParameter("InstaceNumber", 5);
        var stringParameter = new StringParameter("management_group_id", "root/okay/what/is/this");
        var listOfStringsParameter = new ListOfStringsParameter("endpoints", new List<string>()
        {
            "hey",
            "how",
            "are",
            "you"
        });

        List<Parameter> test = new List<Parameter>() { intParameter, stringParameter, listOfStringsParameter };

        foreach (Parameter parameter in test)
        {
            Console.WriteLine(parameter.GetParameterToHclString());
        }
        
    }
}