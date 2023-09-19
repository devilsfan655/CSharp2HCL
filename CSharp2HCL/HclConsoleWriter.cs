using System.Runtime.CompilerServices;
using CSharp2HCL.Parameters;

namespace CSharp2HCL;

public class HclConsoleWriter
{
    public static void WriteBlock(ResourceBlock block)
    {
        Console.WriteLine();
        Console.WriteLine($"resource {block.Provider}_{block.ResourceType} \"{block.ResourceName}\" {{");
        
        WriteParameters(block);
        
        foreach (GenericBlock childBlock in block.Blocks)
        {
            childBlock.Indent += 2;
            WriteBlock(childBlock);
        }

        Console.WriteLine($"}}");
    }
    
    public static void WriteBlock(GenericBlock block)
    {
        Console.WriteLine($"{block._indentModifier.Substring(4)}{block.Name} {{");
        WriteParameters(block);
        Console.WriteLine($"{block._indentModifier.Substring(4)}}}");

        foreach (GenericBlock childBlock in block.Blocks)
        {
            childBlock.Indent += 2;
            Console.WriteLine($"Indent = 4");
            WriteBlock(childBlock);
        }

        
    }

    public static void WriteParameters(Block block)
    {
        int maxParameterNameLength = HclFormatter.GetMaxLength(block.Parameters._parameters);
        
        foreach (Parameter parameter in block.Parameters._parameters)
        {
            string formattedParameter = HclFormatter.GetNormalizedString(parameter.GetParameterToHclString(),maxParameterNameLength);
            Console.WriteLine(block._indentModifier + formattedParameter);
        }
    }
}