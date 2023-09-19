
using CSharp2HCL.Parameters;

public abstract class Block
{
    public List<Block> Blocks { get; private set; }
    public Parameters Parameters { get; private set; }
    
    public Block(List<Block> blocks)
    {
        Blocks = blocks;
        Parameters = new Parameters();
    }
    
    public Block(Parameters parameters )
    {
        Parameters = parameters;
        Blocks = new List<Block>();
    }

    public Block()
    {
        Parameters = new Parameters();
        Blocks = new List<Block>();
    }

    public abstract List<string> GetBlock();
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

    public override List<string> GetBlock()
    {
        List<string> block = new List<string>() { $"resource {Provider}_{ResourceType} {ResourceName} {{ \n" };

        List<string> resourceParameters = this.Parameters.GetNormalizedParameters();

        foreach (string parameter in resourceParameters)
        {
            block.Add(parameter);
        }

        block.Add("} \n");

        return block;
    }
    
}