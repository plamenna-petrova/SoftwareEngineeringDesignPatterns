using EraStyles.Abstraction;
using EraStyles.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.ConcreteFactories
{
    public class ShipFactory : EraObjectStylesFactory
    {
        public override EraObject CreateMedievalStyleObject()
        {
            return new MedievalShip();
        }

        public override EraObject CreateRenaissanceStyleObject()
        {
            return new RenaissanceShip();
        }

        public override EraObject CreateVictorianEraStyleObject()
        {
            return new VictorianShip();
        }
    }
}
