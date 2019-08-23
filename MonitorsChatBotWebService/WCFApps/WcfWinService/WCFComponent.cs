using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfWinService
{
    public interface IMathService
    {
        [OperationContract]
        double SquareOfNumber(double no);
        [OperationContract]
        double SquareRootOfNumber(double no);
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFComponent" in both code and config file together.
    public class MathComponent : IMathService
    {

        public double SquareOfNumber(double no)
        {
            return no * no;
        }



        public double SquareRootOfNumber(double no)
        {
            return Math.Sqrt(no);
        }
    }
}

