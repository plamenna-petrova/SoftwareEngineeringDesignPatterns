using EraStyles.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.Client
{
    public class Era
    {
        private EraObject _eraObject;

        public Era(EraObjectStylesFactory eraObjectStylesFactory, char era)
        {
            switch (era)
            {
                case 'M':
                    _eraObject = eraObjectStylesFactory.CreateMedievalStyleObject();
                    break;
                case 'R':
                    _eraObject = eraObjectStylesFactory.CreateRenaissanceStyleObject();
                    break;
                case 'V':
                    _eraObject = eraObjectStylesFactory.CreateVictorianEraStyleObject();
                    break;
            }
        }

        public void Info()
        {
            _eraObject.ShowDetails();
        }
    }
}
