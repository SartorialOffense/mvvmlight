﻿using System;
using GalaSoft.MvvmLight.Helpers;

#if NEWUNITTEST
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace GalaSoft.MvvmLight.Test.Helpers
{
    [TestClass]
    public class WeakFuncGenericNestedTest
    {
        private PublicNestedTestClass<string> _itemPublic;
        private InternalNestedTestClass<string> _itemInternal;
        private PrivateNestedTestClass<string> _itemPrivate;
        private WeakReference _reference;
        private WeakFunc<string, string> _action;

        [TestMethod]
        public void TestPublicClassPublicNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const int index = 99;
                const string parameter = "My parameter";

                _itemPublic = new PublicNestedTestClass<string>(index);

                _action = _itemPublic.GetFunc(WeakActionTestCase.PublicNamedMethod);

                _reference = new WeakReference(_itemPublic);
                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.Public + index + parameter,
                    PublicNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.Public + index + parameter,
                    result);

                _itemPublic = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassPublicStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemPublic = new PublicNestedTestClass<string>();
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetFunc(WeakActionTestCase.PublicStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.PublicStatic + parameter,
                    PublicNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.PublicStatic + parameter,
                    result);

                _itemPublic = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassInternalNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";
                const int index = 99;

                _itemPublic = new PublicNestedTestClass<string>(index);
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetFunc(WeakActionTestCase.InternalNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.Internal + index + parameter,
                    PublicNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.Internal + index + parameter,
                    result);

                _itemPublic = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPublicClassInternalStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemPublic = new PublicNestedTestClass<string>();
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetFunc(WeakActionTestCase.InternalStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.InternalStatic + parameter,
                    PublicNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.InternalStatic + parameter,
                    result);

                _itemPublic = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassPrivateNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";
                const int index = 99;

                _itemPublic = new PublicNestedTestClass<string>(index);
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetFunc(WeakActionTestCase.PrivateNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.Private + index + parameter,
                    PublicNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.Private + index + parameter,
                    result);

                _itemPublic = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPublicClassPrivateStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemPublic = new PublicNestedTestClass<string>();
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetFunc(WeakActionTestCase.PrivateStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.PrivateStatic + parameter,
                    PublicNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + PublicNestedTestClass<string>.PrivateStatic + parameter,
                    result);

                _itemPublic = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPublicClassAnonymousMethod()
        {
            ScopeHelper.CallInOwnScope(() =>
            {

                Reset();

                const int index = 99;
                const string parameter = "My parameter";

                _itemPublic = new PublicNestedTestClass<string>(index);
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetFunc(WeakActionTestCase.AnonymousMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + index + parameter,
                    PublicNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + index + parameter,
                    result);

                _itemPublic = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPublicClassAnonymousStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemPublic = new PublicNestedTestClass<string>();
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetFunc(WeakActionTestCase.AnonymousStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + parameter,
                    PublicNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PublicNestedTestClass<string>.Expected + parameter,
                    result);

                _itemPublic = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassPublicNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const int index = 99;
                const string parameter = "My parameter";

                _itemInternal = new InternalNestedTestClass<string>(index);

                _action = _itemInternal.GetFunc(WeakActionTestCase.PublicNamedMethod);

                _reference = new WeakReference(_itemInternal);
                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.Public + index +
                    parameter,
                    InternalNestedTestClass<string>.Result);
                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.Public + index +
                    parameter,
                    result);

                _itemInternal = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestInternalClassPublicStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemInternal = new InternalNestedTestClass<string>();
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetFunc(WeakActionTestCase.PublicStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.PublicStatic + parameter,
                    InternalNestedTestClass<string>.Result);
                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.PublicStatic + parameter,
                    result);

                _itemInternal = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassInternalNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";
                const int index = 99;

                _itemInternal = new InternalNestedTestClass<string>(index);
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetFunc(WeakActionTestCase.InternalNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.Internal + index +
                    parameter,
                    InternalNestedTestClass<string>.Result);
                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.Internal + index +
                    parameter,
                    result);

                _itemInternal = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestInternalClassInternalStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemInternal = new InternalNestedTestClass<string>();
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetFunc(WeakActionTestCase.InternalStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.InternalStatic +
                    parameter,
                    InternalNestedTestClass<string>.Result);
                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.InternalStatic +
                    parameter,
                    result);

                _itemInternal = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassPrivateNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";
                const int index = 99;

                _itemInternal = new InternalNestedTestClass<string>(index);
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetFunc(WeakActionTestCase.PrivateNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.Private + index +
                    parameter,
                    InternalNestedTestClass<string>.Result);
                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.Private + index +
                    parameter,
                    result);

                _itemInternal = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestInternalClassPrivateStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemInternal = new InternalNestedTestClass<string>();
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetFunc(WeakActionTestCase.PrivateStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.PrivateStatic +
                    parameter,
                    InternalNestedTestClass<string>.Result);
                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + InternalNestedTestClass<string>.PrivateStatic +
                    parameter,
                    result);

                _itemInternal = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestInternalClassAnonymousMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const int index = 99;
                const string parameter = "My parameter";

                _itemInternal = new InternalNestedTestClass<string>(index);
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetFunc(WeakActionTestCase.AnonymousMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + index + parameter,
                    InternalNestedTestClass<string>.Result);
                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + index + parameter,
                    result);

                _itemInternal = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestInternalClassAnonymousStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemInternal = new InternalNestedTestClass<string>();
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetFunc(WeakActionTestCase.AnonymousStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + parameter,
                    InternalNestedTestClass<string>.Result);
                Assert.AreEqual(
                    InternalNestedTestClass<string>.Expected + parameter,
                    result);

                _itemInternal = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPrivateClassPublicNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const int index = 99;
                const string parameter = "My parameter";

                _itemPrivate = new PrivateNestedTestClass<string>(index);

                _action = _itemPrivate.GetFunc(WeakActionTestCase.PublicNamedMethod);

                _reference = new WeakReference(_itemPrivate);
                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.Public + index + parameter,
                    PrivateNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.Public + index + parameter,
                    result);

                _itemPrivate = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPrivateClassPublicStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemPrivate = new PrivateNestedTestClass<string>();
                _reference = new WeakReference(_itemPrivate);

                _action = _itemPrivate.GetFunc(WeakActionTestCase.PublicStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.PublicStatic + parameter,
                    PrivateNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.PublicStatic + parameter,
                    result);

                _itemPrivate = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPrivateClassInternalNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";
                const int index = 99;

                _itemPrivate = new PrivateNestedTestClass<string>(index);
                _reference = new WeakReference(_itemPrivate);

                _action = _itemPrivate.GetFunc(WeakActionTestCase.InternalNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.Internal + index +
                    parameter,
                    PrivateNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.Internal + index +
                    parameter,
                    result);

                _itemPrivate = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPrivateClassInternalStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemPrivate = new PrivateNestedTestClass<string>();
                _reference = new WeakReference(_itemPrivate);

                _action = _itemPrivate.GetFunc(WeakActionTestCase.InternalStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.InternalStatic + parameter,
                    PrivateNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.InternalStatic + parameter,
                    result);

                _itemPrivate = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPrivateClassPrivateNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";
                const int index = 99;

                _itemPrivate = new PrivateNestedTestClass<string>(index);
                _reference = new WeakReference(_itemPrivate);

                _action = _itemPrivate.GetFunc(WeakActionTestCase.PrivateNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.Private + index +
                    parameter,
                    PrivateNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.Private + index +
                    parameter,
                    result);

                _itemPrivate = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPrivateClassPrivateStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemPrivate = new PrivateNestedTestClass<string>();
                _reference = new WeakReference(_itemPrivate);

                _action = _itemPrivate.GetFunc(WeakActionTestCase.PrivateStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.PrivateStatic + parameter,
                    PrivateNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + PrivateNestedTestClass<string>.PrivateStatic + parameter,
                    result);

                _itemPrivate = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestPrivateClassAnonymousMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const int index = 99;
                const string parameter = "My parameter";

                _itemPrivate = new PrivateNestedTestClass<string>(index);
                _reference = new WeakReference(_itemPrivate);

                _action = _itemPrivate.GetFunc(WeakActionTestCase.AnonymousMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + index + parameter,
                    PrivateNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + index + parameter,
                    result);

                _itemPrivate = null;
            });

            GC.Collect();

#if SILVERLIGHT
            Assert.IsTrue(_reference.IsAlive); // Anonymous, private and internal methods cannot be GCed
            _action = null;
            GC.Collect();
            Assert.IsFalse(_reference.IsAlive);
#else
            Assert.IsFalse(_reference.IsAlive);
#endif
        }

        [TestMethod]
        public void TestPrivateClassAnonymousStaticMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const string parameter = "My parameter";

                _itemPrivate = new PrivateNestedTestClass<string>();
                _reference = new WeakReference(_itemPrivate);

                _action = _itemPrivate.GetFunc(WeakActionTestCase.AnonymousStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                var result = _action.Execute(parameter);

                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + parameter,
                    PrivateNestedTestClass<string>.Result);
                Assert.AreEqual(
                    PrivateNestedTestClass<string>.Expected + parameter,
                    result);

                _itemPrivate = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        private void Reset()
        {
            _itemPublic = null;
            _itemInternal = null;
            _itemPrivate = null;
            _reference = null;
        }

        public class PublicNestedTestClass<T>
        {
            private int _index; // Just here to force instance methods

            public const string Expected = "Hello";
            public const string Public = "Public";
            public const string Internal = "Internal";
            public const string Private = "Private";
            public const string PublicStatic = "PublicStatic";
            public const string InternalStatic = "InternalStatic";
            public const string PrivateStatic = "PrivateStatic";

            public static string Result { get; private set; }

            public PublicNestedTestClass()
            {

            }

            public PublicNestedTestClass(int index)
            {
                _index = index;
            }

            private void DoStuffPrivately(T parameter)
            {
                Result = Expected + Private + _index + parameter;
            }

            internal void DoStuffInternally(T parameter)
            {
                Result = Expected + Internal + _index + parameter;
            }

            public void DoStuffPublically(T parameter)
            {
                Result = Expected + Public + _index + parameter;
            }

            private static void DoStuffPrivatelyAndStatically(T parameter)
            {
                Result = Expected + PrivateStatic + parameter;
            }

            public static void DoStuffPublicallyAndStatically(T parameter)
            {
                Result = Expected + PublicStatic + parameter;
            }

            internal static void DoStuffInternallyAndStatically(T parameter)
            {
                Result = Expected + InternalStatic + parameter;
            }

            private string DoStuffPrivatelyWithResult(T parameter)
            {
                Result = Expected + Private + _index + parameter;
                return Result;
            }

            internal string DoStuffInternallyWithResult(T parameter)
            {
                Result = Expected + Internal + _index + parameter;
                return Result;
            }

            public string DoStuffPublicallyWithResult(T parameter)
            {
                Result = Expected + Public + _index + parameter;
                return Result;
            }

            private static string DoStuffPrivatelyAndStaticallyWithResult(T parameter)
            {
                Result = Expected + PrivateStatic + parameter;
                return Result;
            }

            public static string DoStuffPublicallyAndStaticallyWithResult(T parameter)
            {
                Result = Expected + PublicStatic + parameter;
                return Result;
            }

            internal static string DoStuffInternallyAndStaticallyWithResult(T parameter)
            {
                Result = Expected + InternalStatic + parameter;
                return Result;
            }

            public WeakFunc<T, string> GetFunc(WeakActionTestCase testCase)
            {
                WeakFunc<T, string> action = null;

                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPublicallyWithResult);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffInternallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPrivatelyWithResult);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPublicallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffInternallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPrivatelyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            p =>
                            {
                                Result = Expected + p;
                                return Result;
                            });
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            p =>
                            {
                                Result = Expected + _index + p;
                                return Result;
                            });
                        break;
                }

                return action;
            }
        }

        internal class InternalNestedTestClass<T>
        {
            private int _index; // Just here to force instance methods

            public const string Expected = "Hello";
            public const string Public = "Public";
            public const string Internal = "Internal";
            public const string InternalStatic = "InternalStatic";
            public const string Private = "Private";
            public const string PublicStatic = "PublicStatic";
            public const string PrivateStatic = "PrivateStatic";

            public static string Result { get; private set; }

            public InternalNestedTestClass()
            {

            }

            public InternalNestedTestClass(int index)
            {
                _index = index;
            }

            private string DoStuffPrivatelyWithResult(T parameter)
            {
                Result = Expected + Private + _index + parameter;
                return Result;
            }

            internal string DoStuffInternallyWithResult(T parameter)
            {
                Result = Expected + Internal + _index + parameter;
                return Result;
            }

            public string DoStuffPublicallyWithResult(T parameter)
            {
                Result = Expected + Public + _index + parameter;
                return Result;
            }

            private static string DoStuffPrivatelyAndStaticallyWithResult(T parameter)
            {
                Result = Expected + PrivateStatic + parameter;
                return Result;
            }

            private static string DoStuffInternallyAndStaticallyWithResult(T parameter)
            {
                Result = Expected + InternalStatic + parameter;
                return Result;
            }

            public static string DoStuffPublicallyAndStaticallyWithResult(T parameter)
            {
                Result = Expected + PublicStatic + parameter;
                return Result;
            }

            public WeakFunc<T, string> GetFunc(WeakActionTestCase testCase)
            {
                WeakFunc<T, string> action = null;

                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPublicallyWithResult);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffInternallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPrivatelyWithResult);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPublicallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPrivatelyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffInternallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            p =>
                            {
                                Result = Expected + p;
                                return Result;
                            });
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            p =>
                            {
                                Result = Expected + _index + p;
                                return Result;
                            });
                        break;
                }

                return action;
            }
        }

        private class PrivateNestedTestClass<T>
        {
            private int _index; // Just here to force instance methods

            public const string Expected = "Hello";
            public const string Public = "Public";
            public const string Internal = "Internal";
            public const string InternalStatic = "InternalStatic";
            public const string Private = "Private";
            public const string PublicStatic = "PublicStatic";
            public const string PrivateStatic = "PrivateStatic";

            public static string Result { get; private set; }

            public PrivateNestedTestClass()
            {

            }

            public PrivateNestedTestClass(int index)
            {
                _index = index;
            }

            private string DoStuffPrivatelyWithResult(T parameter)
            {
                Result = Expected + Private + _index + parameter;
                return Result;
            }

            internal string DoStuffInternallyWithResult(T parameter)
            {
                Result = Expected + Internal + _index + parameter;
                return Result;
            }

            public string DoStuffPublicallyWithResult(T parameter)
            {
                Result = Expected + Public + _index + parameter;
                return Result;
            }

            private static string DoStuffPrivatelyAndStaticallyWithResult(T parameter)
            {
                Result = Expected + PrivateStatic + parameter;
                return Result;
            }

            private static string DoStuffInternallyAndStaticallyWithResult(T parameter)
            {
                Result = Expected + InternalStatic + parameter;
                return Result;
            }

            public static string DoStuffPublicallyAndStaticallyWithResult(T parameter)
            {
                Result = Expected + PublicStatic + parameter;
                return Result;
            }

            public WeakFunc<T, string> GetFunc(WeakActionTestCase testCase)
            {
                WeakFunc<T, string> action = null;

                switch (testCase)
                {
                    case WeakActionTestCase.PublicNamedMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPublicallyWithResult);
                        break;
                    case WeakActionTestCase.InternalNamedMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffInternallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateNamedMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPrivatelyWithResult);
                        break;
                    case WeakActionTestCase.PublicStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPublicallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.PrivateStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffPrivatelyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.InternalStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            DoStuffInternallyAndStaticallyWithResult);
                        break;
                    case WeakActionTestCase.AnonymousStaticMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            p =>
                            {
                                Result = Expected + p;
                                return Result;
                            });
                        break;
                    case WeakActionTestCase.AnonymousMethod:
                        action = new WeakFunc<T, string>(
                            this,
                            p =>
                            {
                                Result = Expected + _index + p;
                                return Result;
                            });
                        break;
                }

                return action;
            }
        }
    }
}