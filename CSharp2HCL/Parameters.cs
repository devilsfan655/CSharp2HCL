using System.Reflection;
namespace CSharp2HCL.Parameters;
public class Parameters
{
    public readonly List<Parameter> _parameters;
    
    public Parameters()
    {
        _parameters = new List<Parameter>();
    }

    public Parameters(List<Parameter> parameters)
    {
        _parameters = parameters;
    }
    public List<string> GetParameterNames()
    {
        List<string> parameterNames = new List<string>();

        foreach (Parameter parameter in _parameters)
            parameterNames.Add(parameter.Name);

        return parameterNames;
    }
    
}
