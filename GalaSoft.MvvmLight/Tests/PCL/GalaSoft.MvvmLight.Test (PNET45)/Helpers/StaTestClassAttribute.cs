using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalaSoft.MvvmLight.Test.Helpers
{
    public class StaTestClassAttribute : TestClassAttribute
    {
        public override TestMethodAttribute GetTestMethodAttribute(TestMethodAttribute testMethodAttribute)
        {
            if (testMethodAttribute is StaTestMethodAttribute)
                return testMethodAttribute;

            return new StaTestMethodAttribute(base.GetTestMethodAttribute(testMethodAttribute));
        }
    }
}