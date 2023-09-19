using System.Reflection;
namespace CSharp2HCL.Parameters;
public class Parameters
{
    private readonly List<Parameter> _parameters;
    
    public Parameters()
    {
        _parameters = new List<Parameter>();
    }

    public Parameters(List<Parameter> parameters)
    {
        _parameters = parameters;
    }
    
    public void AddParameter(Parameter parameter)
    {
        string parameterName = parameter.Name;
        
        if (!GetParameterNames().Contains(parameterName))
        {
            _parameters.Add(parameter);
        }
        else
        {
            throw new InvalidOperationException($"Cannot add {parameter.Name}. The property has already been declared ");
        }
    }
    
    public void AddParameter(string name,  string value)
    {
        StringParameter parameter = new StringParameter(name, value);
        
        string parameterName = parameter.Name;
        
        if (!GetParameterNames().Contains(parameterName))
        {
            _parameters.Add(parameter);
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
        
        if (!GetParameterNames().Contains(parameterName))
        {
            _parameters.Add(parameter);
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
        
        if (!GetParameterNames().Contains(parameterName))
        {
            _parameters.Add(parameter);
        }
        else
        {
            throw new InvalidOperationException($"Cannot add {parameter.Name}. The property has already been declared ");
        }
    }
    public List<string> GetParameterNames()
    {
        List<string> parameterNames = new List<string>();

        foreach (Parameter parameter in _parameters)
            parameterNames.Add(parameter.Name);

        return parameterNames;
    }

    public void GetNormalizedParameters(bool toConsole)
    {
        int maxParameterNameLength = HclFormatter.GetMaxLength(_parameters);
        
        foreach (Parameter parameter in _parameters)
        {
            string hclFormattedParameter =
                HclFormatter.GetNormalizedString(parameter.GetParameterToHclString(), maxParameterNameLength);
            
            Console.WriteLine(hclFormattedParameter);
        }
    }

    public List<string> GetNormalizedParameters()
    {
        List<string> parameters = new List<string>();

        int maxParameterNameLength = HclFormatter.GetMaxLength(_parameters);

        foreach (Parameter parameter in _parameters)
        {
            string hclFormattedParameter = 
                HclFormatter.GetNormalizedString(parameter.GetParameterToHclString(), maxParameterNameLength) + "\n";
            
            parameters.Add(hclFormattedParameter);
        }

        return parameters;

    }
}
