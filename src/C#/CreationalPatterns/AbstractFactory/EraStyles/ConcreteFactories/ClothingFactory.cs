using EraStyles.Abstraction;
using EraStyles.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.ConcreteFactories
{
    public class ClothingFactory : EraObjectStylesFactory
    {
        public override EraObject CreateMedievalStyleObject()
        {
            return new MedievalClothing();
        }

        public override EraObject CreateRenaissanceStyleObject()
        {
            return new RenaissanceClothing();
        }

        public override EraObject CreateVictorianEraStyleObject()
        {
            return new VictorianClothing();
        }
    }
}
