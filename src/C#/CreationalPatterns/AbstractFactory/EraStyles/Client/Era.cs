using EraStyles.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace EraStyles.Client
{
    public class Era
    {
        private EraObject _eraObject;

        public Era(EraObjectStylesFactory stylesFactory, char era)
        {
            switch (era)
            {
                case 'M':
                    _eraObject = stylesFactory.CreateMedievalStyleObject();
                    break;
                case 'R':
                    _eraObject = stylesFactory.CreateRenaissanceStyleObject();
                    break;
                case 'V':
                    _eraObject = stylesFactory.CreateVictorianEraStyleObject();
                    break;
            }
        }

        public void Info()
        {
            _eraObject.ShowDetails();
        }
    }
}
