
using System.Security.AccessControl;
using System.Security.Cryptography;
using CSharp2HCL.Parameters;

public abstract class Block
{
    public List<Block> Blocks { get; private set; }
    public Parameters Parameters { get; private set; }

    public string _indentModifier = "  "; 

    public int Indent
    {
        get
        {
            return _indentModifier.Length;
        }
        set
        {
            if (value >= 0)
            {
                _indentModifier = new string(' ', value);
            }
            else
            {
                
                throw new ArgumentException("Indent value must be non-negative.");
            }
        }
    }
    
    public Block(List<Block> blocks)
    {
        Blocks = blocks;
        Parameters = new Parameters();
    }
    
    public Block(Parameters parameters)
    {
        Parameters = parameters;
        Blocks = new List<Block>();
    }

    public Block()
    {
        Parameters = new Parameters();
        Blocks = new List<Block>();
    }
    public void AddParameter(string name,  string value)
    {
        StringParameter parameter = new StringParameter(name, value);
        
        string parameterName = parameter.Name;
        
        if (!Parameters.GetParameterNames().Contains(parameterName))
        {
            Parameters._parameters.Add(parameter);
        }
        else
        {
            throw new InvalidOperationException($"Cannot add {parameter.Name}. The property has already been declared ");
        }
    }
    
    public void AddParameter(string name,  int value)
    {
        IntParameter parameter = new IntParameter(name, value);
        
        string parameterName = parameter.Name;
        
        if (!Parameters.GetParameterNames().Contains(parameterName))
        {
            Parameters._parameters.Add(parameter);
        }
        else
        {
            throw new InvalidOperationException($"Cannot add {parameter.Name}. The property has already been declared ");
        }
    }
    
    public void AddParameter(string name,  List<string> value)
    {
        ListOfStringsParameter parameter = new ListOfStringsParameter(name, value);
        
        string parameterName = parameter.Name;
        
        if (!Parameters.GetParameterNames().Contains(parameterName))
        {
            Parameters._parameters.Add(parameter);
        }
        else
        {
            throw new InvalidOperationException($"Cannot add {parameter.Name}. The property has already been declared ");
        }
    }
}

public class GenericBlock : Block
{
    public string Name { get; private set; }

    public GenericBlock(string name)
    {
        Name = name;
    }
}

public class ResourceBlock : Block
{
    public string Provider { get; private set; }
    public string ResourceType { get; private set; }
    public string ResourceName { get; private set; }


    public ResourceBlock(string provider, string resourceType, string resourceName)
    {
        Provider = provider;
        ResourceType = resourceType;
        ResourceName = resourceName;
    }
    
    public ResourceBlock(string provider, string resourceType, string resourceName, List<Block> blocks)
        : base(blocks)
    {
        Provider = provider;
        ResourceType = resourceType;
        ResourceName = resourceName;
    }
    
    public ResourceBlock(string provider, string resourceType, string resourceName, Parameters  blocks)
        : base(blocks)
    {
        Provider = provider;
        ResourceType = resourceType;
        ResourceName = resourceName;
    }

    public void AddGenericBlock(GenericBlock block)
    {
        
        Blocks.Add(block);
    }
}