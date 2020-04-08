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
    public class WeakActionTest
    {
        private PublicTestClass _itemPublic;
        private InternalTestClass _itemInternal;
        private CommonTestClass _common;
        private WeakReference _reference;
        private WeakAction _action;
        private string _local;

        [TestMethod]
        public void TestPublicClassPublicNamedMethod()
        {

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                const int index = 99;

                _itemPublic = new PublicTestClass(index);

                _action = _itemPublic.GetAction(WeakActionTestCase.PublicNamedMethod);

                _reference = new WeakReference(_itemPublic);
                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    PublicTestClass.Expected + PublicTestClass.Public + index,
                    PublicTestClass.Result);

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

                _itemPublic = new PublicTestClass();
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetAction(WeakActionTestCase.PublicStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    PublicTestClass.Expected + PublicTestClass.PublicStatic,
                    PublicTestClass.Result);

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

                const int index = 99;

                _itemPublic = new PublicTestClass(index);
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetAction(WeakActionTestCase.InternalNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    PublicTestClass.Expected + PublicTestClass.Internal + index,
                    PublicTestClass.Result);

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

                _itemPublic = new PublicTestClass();
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetAction(WeakActionTestCase.InternalStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    PublicTestClass.Expected + PublicTestClass.InternalStatic,
                    PublicTestClass.Result);

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

                const int index = 99;

                _itemPublic = new PublicTestClass(index);
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetAction(WeakActionTestCase.PrivateNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    PublicTestClass.Expected + PublicTestClass.Private + index,
                    PublicTestClass.Result);

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

                _itemPublic = new PublicTestClass();
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetAction(WeakActionTestCase.PrivateStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    PublicTestClass.Expected + PublicTestClass.PrivateStatic,
                    PublicTestClass.Result);

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

                _itemPublic = new PublicTestClass(index);
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetAction(WeakActionTestCase.AnonymousMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    PublicTestClass.Expected + index,
                    PublicTestClass.Result);

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
            Reset();


            ScopeHelper.CallInOwnScope(() =>
            {
                _itemPublic = new PublicTestClass();
                _reference = new WeakReference(_itemPublic);

                _action = _itemPublic.GetAction(WeakActionTestCase.AnonymousStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    PublicTestClass.Expected,
                    PublicTestClass.Result);

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

                _itemInternal = new InternalTestClass(index);

                _action = _itemInternal.GetAction(WeakActionTestCase.PublicNamedMethod);

                _reference = new WeakReference(_itemInternal);
                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    InternalTestClass.Expected + InternalTestClass.Public + index,
                    InternalTestClass.Result);

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

                _itemInternal = new InternalTestClass();
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetAction(WeakActionTestCase.PublicStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    InternalTestClass.Expected + InternalTestClass.PublicStatic,
                    InternalTestClass.Result);

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

                const int index = 99;

                _itemInternal = new InternalTestClass(index);
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetAction(WeakActionTestCase.InternalNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    InternalTestClass.Expected + InternalTestClass.Internal + index,
                    InternalTestClass.Result);

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

                _itemInternal = new InternalTestClass();
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetAction(WeakActionTestCase.InternalStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    InternalTestClass.Expected + InternalTestClass.InternalStatic,
                    InternalTestClass.Result);

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

                const int index = 99;

                _itemInternal = new InternalTestClass(index);
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetAction(WeakActionTestCase.PrivateNamedMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    InternalTestClass.Expected + InternalTestClass.Private + index,
                    InternalTestClass.Result);

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

                _itemInternal = new InternalTestClass();
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetAction(WeakActionTestCase.PrivateStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    InternalTestClass.Expected + InternalTestClass.PrivateStatic,
                    InternalTestClass.Result);

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

                _itemInternal = new InternalTestClass(index);
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetAction(WeakActionTestCase.AnonymousMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    InternalTestClass.Expected + index,
                    InternalTestClass.Result);

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

                _itemInternal = new InternalTestClass();
                _reference = new WeakReference(_itemInternal);

                _action = _itemInternal.GetAction(WeakActionTestCase.AnonymousStaticMethod);

                Assert.IsTrue(_reference.IsAlive);
                Assert.IsTrue(_action.IsAlive);

                _action.Execute();

                Assert.AreEqual(
                    InternalTestClass.Expected,
                    InternalTestClass.Result);

                _itemInternal = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
        }

        [TestMethod]
        public void TestNonStaticMethodWithNullTarget()
        {
            Reset();
            var action = new WeakAction(null, DoStuff);
            Assert.IsFalse(action.IsAlive);
        }

        [TestMethod]
        public void TestStaticMethodWithNullTarget()
        {
            Reset();
            var action = new WeakAction(null, DoStuffStatic);
            Assert.IsTrue(action.IsAlive);
        }

        [TestMethod]
        public void TestStaticMethodWithNonNullTarget()
        {

            WeakAction action = null;

            ScopeHelper.CallInOwnScope(() =>
            {
                Reset();

                _common = new CommonTestClass();
                _reference = new WeakReference(_common);
                Assert.IsTrue(_reference.IsAlive);

                action = new WeakAction(_common, DoStuffStatic);
                Assert.IsTrue(action.IsAlive);

                _common = null;
            });

            GC.Collect();

            Assert.IsFalse(_reference.IsAlive);
            Assert.IsFalse(action.IsAlive);
        }

        public static void DoStuffStatic()
        {

        }

        public void DoStuff()
        {
            _local = DateTime.Now.ToString();
        }

        private void Reset()
        {
            _itemPublic = null;
            _itemInternal = null;
            _reference = null;
        }
    }
}
