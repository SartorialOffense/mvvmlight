using System;

namespace GalaSoft.MvvmLight.Test.Helpers
{
    /// <summary>
    /// In .NET Core, just nulling out a reference and doing a GC collection does not
    /// collect that object.  To force this, the object should be created and nulled out
    /// in a different scope.  So just use this handy helper!
    /// </summary>
    public static class ScopeHelper
    {
        public static void CallInOwnScope(Action a)
        {
            a.Invoke();
        }
    }
}