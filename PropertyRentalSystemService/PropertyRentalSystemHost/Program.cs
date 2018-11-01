using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace PropertyRentalSystemHost
{    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost prsHost = null;
            try
            {
                //Base Address for PropertyRentalSystem
                Uri httpBaseAddress = new Uri("http://localhost:4321/PropertyRentalSystem");

                //Instantiate ServiceHost
                prsHost = new ServiceHost(typeof(PropertyRentalService.PropertyRentalService), httpBaseAddress);

                //Add Endpoint to Host
                prsHost = new ServiceHost(typeof(PropertyRentalService.PropertyRentalService), httpBaseAddress);

                prsHost.AddServiceEndpoint(typeof(PropertyRentalService.IPropertyRentalService),
                                                        new WSHttpBinding(), "");

                //Metadata Exchange
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                prsHost.Description.Behaviors.Add(serviceBehavior);

                //Open
                prsHost.Open();
                Console.WriteLine("Service is live now at: {0}", httpBaseAddress);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                prsHost = null;
                Console.WriteLine("There is an issue with PropertyRentalSystemService" + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
