
using CSharp2HCL.Parameters;
public class ResourceBlock
{
    private string _name;
    private readonly string _resourceType;
    private readonly List<Parameter> _parameters;
    private readonly List<ResourceBlock> _resourceBlocks;
}