//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autofac.AsyncExtras.DynamicProxy {
    using System;
    using System.Reflection;


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RegistrationExtensionsResources {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RegistrationExtensionsResources() {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Autofac.Extras.DynamicProxy.RegistrationExtensionsResources", typeof(RegistrationExtensionsResources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to The transparent proxy does not support the additional interface(s): {0}..
        /// </summary>
        internal static string InterfaceNotSupportedByTransparentProxy {
            get {
                return ResourceManager.GetString("InterfaceNotSupportedByTransparentProxy", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to The component {0} cannot use interface interception as it provides services that are not publicly visible interfaces. Check your registration of the component to ensure you&apos;re not enabling interception and registering it as an internal/private interface type..
        /// </summary>
        internal static string InterfaceProxyingOnlySupportsInterfaceServices {
            get {
                return ResourceManager.GetString("InterfaceProxyingOnlySupportsInterfaceServices", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to The transparent proxy of type &apos;{0}&apos; must be an interface..
        /// </summary>
        internal static string TransparentProxyIsNotInterface {
            get {
                return ResourceManager.GetString("TransparentProxyIsNotInterface", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to The instance of type &apos;{0}&apos; is not a transparent proxy..
        /// </summary>
        internal static string TypeIsNotTransparentProxy {
            get {
                return ResourceManager.GetString("TypeIsNotTransparentProxy", resourceCulture);
            }
        }
    }
}
