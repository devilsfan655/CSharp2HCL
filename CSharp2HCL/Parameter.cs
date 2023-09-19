public abstract class Parameter
{
    public string Name { get; private set; }

    public Parameter(string name)
    {
        this.Name = name;
    }

    public abstract string GetParameterToHclString();
}

public class IntParameter : Parameter
{
    public int Value { get; private set; }

    public IntParameter(string name, int value) : base(name)
    {
        this.Value = value;
    }

    public override string GetParameterToHclString()
    {
        return $"{this.Name} = {this.Value}";
    }
}

public class StringParameter : Parameter
{
    public string Value { get; private set; }

    public StringParameter(string name, String value) : base(name)
    {
        Value = value;
    }
    
    public override string GetParameterToHclString()
    {
        return $"{this.Name} = \"{this.Value}\"";
    }
}

public class ListOfStringsParameter : Parameter
{
    public List<string> Value { get; private set; }

    public ListOfStringsParameter(string name, List<string> value) : base(name)
    {
        Value = value;
    }
    
    public override string GetParameterToHclString()
    {
        string listOfStrings = "";

        int interationCount = 0;

        foreach (string item in Value)
        {
            listOfStrings = listOfStrings + $"\"{item}\"";

            if (interationCount < Value.Count - 1)
            {
                listOfStrings += ", ";
            }

            interationCount++;
        }
        
        return $"{this.Name} = [{listOfStrings}]";
    }
}

public class JsonParameter : Parameter
{
    public dynamic Value { get; set; }
    
    public JsonParameter(string name, dynamic value) : base(name)
    {
        Value = value;
    }

    public override string GetParameterToHclString()
    {
        return "Feature not implemented yet.";
    }
}



