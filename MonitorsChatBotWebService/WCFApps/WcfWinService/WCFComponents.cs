using System.ServiceModel;
using System.Runtime.Serialization;
using System;

namespace WcfWinService
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        double SquareofNumber(double no);
        [OperationContract]
        double SquareRootofNumber(double no);
    }

    public class MathComponent : IMathService
    {
        public double SquareofNumber(double no)
        {
            return no*no;
        }

        public double SquareRootofNumber(double no)
        {
            return Math.Sqrt(no);
        }
    }


}