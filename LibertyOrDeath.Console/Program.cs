using System;
using System.Linq;
using LibertyOrDeath.Data.Repositories;
using LibertyOrDeath.Domain.Entities;
using LibertyOrDeath.Domain.ValueTypes.British;

namespace LibertyOrDeath.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var locations = new LocationRepository().GetMediumScenarioLocations();
            var british = new Domain.Entities.British(1, "British", 5, new BritishForces(7, 10, 3, 6, 6));
            var garrison = new Garrison(new Map(locations), british);

            foreach (var movement in garrison.CommandMovements)
            {
                System.Console.WriteLine(movement.Description);
            }
            System.Console.ReadKey();
        }
    }
}
