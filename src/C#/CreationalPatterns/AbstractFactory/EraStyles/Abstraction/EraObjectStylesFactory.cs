using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.Abstraction
{
    public abstract class EraObjectStylesFactory
    {
        public abstract EraObject CreateMedievalStyleObject();

        public abstract EraObject CreateRenaissanceStyleObject();

        public abstract EraObject CreateVictorianEraStyleObject();
    }
}
