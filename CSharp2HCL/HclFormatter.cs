using CSharp2HCL.Parameters;

namespace CSharp2HCL;
public class HclFormatter
{
    public static string GetNormalizedString(string str, int spaceCount)
    {
        string[] keyValueStr = str.Split("=");
        string key = keyValueStr[0];
        string value = keyValueStr[1];
        int lengthOfKey = key.Length;
        string spaces = "";

        for (int i = 0; i < spaceCount - lengthOfKey + 1; i++)
        {
            spaces += " ";
        }

        string normalizedString = key + spaces + "=" + value;

        return normalizedString;
    }

    public static int GetMaxLength(string[] strArray)
    {
        int maxLength = 0;

        foreach (string str in strArray)
        {
            if (str.Length > maxLength)
                maxLength = str.Length;
        }

        return maxLength;
    }
    
    public static int GetMaxLength(List<Parameter> paramArray)
    {
        int maxLength = 0;

        foreach (Parameter parameter in paramArray)
        {
            if (parameter.Name.Length > maxLength)
                maxLength = parameter.Name.Length;
        }

        return maxLength;
    }
}