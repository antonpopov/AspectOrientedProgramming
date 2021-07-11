using System;
using System.Diagnostics.CodeAnalysis;
using Autofac.Core;
using Castle.DynamicProxy;

namespace Autofac.AsyncExtras.DynamicProxy
{

    /// <summary>
    /// Indicates that a type should be intercepted.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes")]
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class InterceptAsyncAttribute : Attribute
    {
        /// <summary>
        /// Gets the interceptor service.
        /// </summary>
        public Service InterceptorService { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptAsyncAttribute"/> class.
        /// </summary>
        /// <param name="interceptorService">The interceptor service.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="interceptorService" /> is <see langword="null" />.
        /// </exception>
        public InterceptAsyncAttribute(Service interceptorService)
        {
            if (interceptorService == null)
                throw new ArgumentNullException(nameof(interceptorService));

            InterceptorService = interceptorService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptAsyncAttribute"/> class.
        /// </summary>
        /// <param name="interceptorServiceName">Name of the interceptor service.</param>
        public InterceptAsyncAttribute(string interceptorServiceName)
            : this(new KeyedService(interceptorServiceName, typeof(IAsyncInterceptor)))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptAsyncAttribute"/> class.
        /// </summary>
        /// <param name="interceptorServiceType">The typed interceptor service.</param>
        public InterceptAsyncAttribute(Type interceptorServiceType)
            : this(new TypedService(interceptorServiceType))
        {
        }
    }
}
