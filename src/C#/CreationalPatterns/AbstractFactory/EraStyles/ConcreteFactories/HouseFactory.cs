using EraStyles.Abstraction;
using EraStyles.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.ConcreteFactories
{
    public class HouseFactory : EraObjectStylesFactory
    {
        public override EraObject CreateMedievalStyleObject()
        {
            return new MedievalHouse();
        }

        public override EraObject CreateRenaissanceStyleObject()
        {
            return new RenaissanceHouse();
        }

        public override EraObject CreateVictorianEraStyleObject()
        {
            return new VictorianHouse();
        }
    }
}
