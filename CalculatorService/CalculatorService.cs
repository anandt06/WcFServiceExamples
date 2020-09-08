using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    //   Note   //

  //  it is better to include changes in coonfiguration rather than in code because changes in configuration doesnt
  //  require application to be built and redeploy
    [ServiceBehavior(IncludeExceptionDetailInFaults =true)]
    public class CalculatorService : ICalculatorService
    {
        public int Divide(int Numerator, int Denominator)
        {
            return Numerator / Denominator;
        }
    }
}
