using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace GalaSoft.MvvmLight.Test.Helpers
{
    public class StaTestMethodAttribute : TestMethodAttribute
    {
        private readonly TestMethodAttribute _testMethodAttribute;

        public StaTestMethodAttribute()
        {
        }

        public StaTestMethodAttribute(TestMethodAttribute testMethodAttribute)
        {
            _testMethodAttribute = testMethodAttribute;
        }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                return Invoke(testMethod);

            TestResult[] result = null;
            var thread = new Thread(() => result = Invoke(testMethod));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return result;
        }

        private TestResult[] Invoke(ITestMethod testMethod)
        {
            if (_testMethodAttribute != null)
                return _testMethodAttribute.Execute(testMethod);

            return new[] { testMethod.Invoke(null) };
        }
    }
}