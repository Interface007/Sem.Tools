using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sem.Tools.TestHelper.Tests
{
    /// <summary>
    /// Tests the exception class <see cref="ExpectedExceptionMessageAttribute"/>
    /// </summary>
    public static class ClassExpectedExceptionMessageAttribute
    {
        /// <summary>
        /// Tests the constructor of <see cref="ExpectedExceptionMessageAttribute"/>.
        /// </summary>
        [TestClass]
        public class Verify
        {
            /// <summary>
            /// Wrong exception type should throw correct exception message.
            /// </summary>
            [TestMethod]
            public void CorrectExceptionIsAccepted()
            {
                var target = new ExpectedExceptionMessageAttributeWrapper(typeof(ArgumentException), "matching string");
                target.VerifyAccessor(new ArgumentException("matching string"));
            }
        
            /// <summary>
            /// Wrong exception type should throw correct exception message.
            /// </summary>
            [TestMethod]
            [ExcludeFromCodeCoverage]
            [ExpectedExceptionMessage(typeof(Exception), "Wrong exception of type .*; expected exception type should derive from: .*; exception message: .*")]
            public void ThrowsCorrectMessageWithWrongType()
            {
                var target = new ExpectedExceptionMessageAttributeWrapper(typeof(ArgumentException), "matching string");
                target.VerifyAccessor(new AccessViolationException());
            }
        
            /// <summary>
            /// Wrong exception type should throw correct exception message.
            /// </summary>
            [TestMethod]
            [ExcludeFromCodeCoverage]
            [ExpectedExceptionMessage(typeof(Exception), "Wrong exception message. Expected RegEx pattern: '.*'; actual message '.*'; full exception messages: .*")]
            public void ThrowsCorrectMessageWithWrongMessage()
            {
                var target = new ExpectedExceptionMessageAttributeWrapper(typeof(ArgumentException), "matching string");
                target.VerifyAccessor(new ArgumentException("something went wrong"));
            }

            /// <summary>
            /// Includes inner exceptions.
            /// </summary>
            [TestMethod]
            [ExcludeFromCodeCoverage]
            [ExpectedExceptionMessage(typeof(Exception), ".*from inner exception.*")]
            public void IncludesInnerExceptions()
            {
                var target = new ExpectedExceptionMessageAttributeWrapper(typeof(ArgumentException), "matching string");
                target.VerifyAccessor(new ArgumentException("something went wrong", new Exception("from inner exception")));
            }
        }

        /// <summary>
        /// Tests the constructor of <see cref="ExpectedExceptionMessageAttribute"/>.
        /// </summary>
        [TestClass]
        public class Ctor
        {
            /// <summary>
            /// Ctor should throw an exception when the exception type is null.
            /// </summary>
            [TestMethod]
            [ExcludeFromCodeCoverage]
            [ExpectedExceptionMessage(typeof(ArgumentNullException), ".")]
            public void CtorThrowsExpectedExceptionWhenTypeIsNull()
            {
                // ReSharper disable once ObjectCreationAsStatement
                new ExpectedExceptionMessageAttribute(null, string.Empty);
            }

            /// <summary>
            /// Ctor should throw an exception when the type does not inherit from <see cref="Exception"/>.
            /// </summary>
            [TestMethod]
            [ExcludeFromCodeCoverage]
            [ExpectedExceptionMessage(typeof(ArgumentException), "Expected exception type must derive from exception")]
            public void CtorThrowsExpectedExceptionWhenExceptionTypeNotInheritsException()
            {
                // ReSharper disable once ObjectCreationAsStatement
                new ExpectedExceptionMessageAttribute(typeof(string), null);
            }
        }

        public class ExpectedExceptionMessageAttributeWrapper
         : ExpectedExceptionMessageAttribute
        {
            public ExpectedExceptionMessageAttributeWrapper(Type exceptionType, string messageRegexPattern)
                : base(exceptionType, messageRegexPattern)
            {
            }

            public void VerifyAccessor(Exception exception)
            {
                base.Verify(exception);
            }
        }
    }
}
