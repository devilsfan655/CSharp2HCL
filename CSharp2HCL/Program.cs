// See https://aka.ms/new-console-template for more information


using CSharp2HCL;

class Program
{
    static void Main(string[] args)
    {
        ResourceBlock exampleResourceGroup = new ResourceBlock("azurerm", "resource_group", "example");
            exampleResourceGroup.AddParameter("name", "example_resource_group");
            exampleResourceGroup.AddParameter("location", "West Europe");
            HclConsoleWriter.WriteBlock(exampleResourceGroup);

        ResourceBlock exampleNetworkSecurityGroup = new ResourceBlock("azurerm", "network_security_group", "example");
            exampleNetworkSecurityGroup.AddParameter("name", "example_resource_group");
            exampleNetworkSecurityGroup.AddParameter("location", "West Europe");
            exampleNetworkSecurityGroup.AddParameter("resource_group_name", "example");
            HclConsoleWriter.WriteBlock(exampleNetworkSecurityGroup);

        ResourceBlock exampleVirtualNetwork = new ResourceBlock("azurerm", "virtual_network", "example");
            exampleVirtualNetwork.AddParameter("name", "example_resource_group");
            exampleVirtualNetwork.AddParameter("location", "West Europe");
            exampleVirtualNetwork.AddParameter("resource_group_name", "example");
            exampleVirtualNetwork.AddParameter("address_space", new List<string>() {"10.0.0.0/10"});
            exampleVirtualNetwork.AddParameter("dns_servers", new List<string>() {"10.0.0.4", "10.0.0.5"});

            GenericBlock subnet = new GenericBlock("subnet");
                subnet.AddParameter("name", "default");
                subnet.AddParameter("address_prefix", "10.0.2.0/24");
                subnet.AddParameter("security_group", "example_security_group");
                
            exampleVirtualNetwork.AddGenericBlock(subnet);
            HclConsoleWriter.WriteBlock(exampleVirtualNetwork);
            

            HclConsoleWriter.WriteBlock(exampleVirtualNetwork);
    }
}