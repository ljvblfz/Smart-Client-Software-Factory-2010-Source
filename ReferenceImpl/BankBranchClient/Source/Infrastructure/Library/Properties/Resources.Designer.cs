﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30128.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GlobalBank.Infrastructure.Library.Properties {
    using System;
    
    
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GlobalBank.Infrastructure.Library.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to AddServices() method called for Module {0}..
        /// </summary>
        internal static string AddServicesCalled {
            get {
                return ResourceManager.GetString("AddServicesCalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Section &apos;{0}&apos; depends on section &apos;{1}&apos; which was not found..
        /// </summary>
        internal static string DependencyNotFound {
            get {
                return ResourceManager.GetString("DependencyNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A duplicated module with name {0} has been found by the loader..
        /// </summary>
        internal static string DuplicatedModule {
            get {
                return ResourceManager.GetString("DuplicatedModule", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to load module from assembly {0}. Error was:
        ///{1}.
        /// </summary>
        internal static string FailedToLoadModule {
            get {
                return ResourceManager.GetString("FailedToLoadModule", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The solution profile references an unknown schema..
        /// </summary>
        internal static string InvalidSolutionProfileSchema {
            get {
                return ResourceManager.GetString("InvalidSolutionProfileSchema", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Module {0} added to the container..
        /// </summary>
        internal static string LogModuleAdded {
            get {
                return ResourceManager.GetString("LogModuleAdded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Loaded assembly file {0} for Module..
        /// </summary>
        internal static string LogModuleAssemblyLoaded {
            get {
                return ResourceManager.GetString("LogModuleAssemblyLoaded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Assembly file {0} was not found..
        /// </summary>
        internal static string ModuleNotFound {
            get {
                return ResourceManager.GetString("ModuleNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Load() method called for Module {0}..
        /// </summary>
        internal static string ModuleStartCalled {
            get {
                return ResourceManager.GetString("ModuleStartCalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No user was selected for the authentication service..
        /// </summary>
        internal static string NoUserProvidedForAuthentication {
            get {
                return ResourceManager.GetString("NoUserProvidedForAuthentication", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The ModuleLoaderService cannot initialize the module because some of their dependencies are not present. Make sure to deploy all the assemblies needed to execute the module..
        /// </summary>
        internal static string ReferencedAssemblyNotFound {
            get {
                return ResourceManager.GetString("ReferencedAssemblyNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service {1} added for Module {0}..
        /// </summary>
        internal static string ServiceAdded {
            get {
                return ResourceManager.GetString("ServiceAdded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service {1} will be added on demand for Module {0}..
        /// </summary>
        internal static string ServiceAddedOnDemand {
            get {
                return ResourceManager.GetString("ServiceAddedOnDemand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Top level control cannot have RightToLeft property set to &quot;Inherit&quot;.
        /// </summary>
        internal static string TopLevelControlRightToLeftInherit {
            get {
                return ResourceManager.GetString("TopLevelControlRightToLeftInherit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no a user matching the information you have provided..
        /// </summary>
        internal static string UserNotFoundMessage {
            get {
                return ResourceManager.GetString("UserNotFoundMessage", resourceCulture);
            }
        }
    }
}
