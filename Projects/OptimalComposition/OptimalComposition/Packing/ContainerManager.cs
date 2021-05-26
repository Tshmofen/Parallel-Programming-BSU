using System.Collections.Generic;
using System.Linq;

namespace OptimalComposition.Packing
{
    public static class ContainerManager
    {
        public static List<Container> PerformNextFit(IEnumerable<int> numbers, int containerSize)
        {
            var containers = new List<Container> { new(containerSize) };
            
            foreach (var number in numbers)
            {
                if (!containers.Last().Add(number))
                {
                    var newContainer = new Container(containerSize);
                    newContainer.Add(number);
                    containers.Add(newContainer);
                }
            }

            return containers;
        }
    }
}