﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VM.DisasterRecovery.Persistence.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Persistence : global::System.Configuration.ApplicationSettingsBase {
        
        private static Persistence defaultInstance = ((Persistence)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Persistence())));
        
        public static Persistence Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DisasterRecoveryConnection")]
        public string ConnectionStringName {
            get {
                return ((string)(this["ConnectionStringName"]));
            }
        }
    }
}
