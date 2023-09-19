// See https://aka.ms/new-console-template for more information

using CSharp2HCL.Parameters;
class Program
{
    static void Main(string[] args)
    {

        Parameters parameters = new Parameters();
        
        parameters.AddParameter("name", "F1231A3315CA23");
        parameters.AddParameter("display_name", "test-policy-global");
        parameters.AddParameter("number_of_instances", 5);
        parameters.AddParameter("available_ips", new List<string>(){"192.168.0.1", "192.168.1.1", "172.27.0.1"});

        ResourceBlock azureVirtualMachine = new ResourceBlock("azurerm", "virtual_machine", "vm1", parameters);
        

    }
}

