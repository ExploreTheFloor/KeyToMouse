﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KeyboardToMouse {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.6.0.0")]
    internal sealed partial class Global : global::System.Configuration.ApplicationSettingsBase {
        
        private static Global defaultInstance = ((Global)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Global())));
        
        public static Global Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int XOffset {
            get {
                return ((int)(this["XOffset"]));
            }
            set {
                this["XOffset"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-20")]
        public int YOffset {
            get {
                return ((int)(this["YOffset"]));
            }
            set {
                this["YOffset"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("125")]
        public int ClickDistance {
            get {
                return ((int)(this["ClickDistance"]));
            }
            set {
                this["ClickDistance"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int ClickDelay {
            get {
                return ((int)(this["ClickDelay"]));
            }
            set {
                this["ClickDelay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool RandomizeClickDelay {
            get {
                return ((bool)(this["RandomizeClickDelay"]));
            }
            set {
                this["RandomizeClickDelay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int RandomClickDelay {
            get {
                return ((int)(this["RandomClickDelay"]));
            }
            set {
                this["RandomClickDelay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseRadialTurning {
            get {
                return ((bool)(this["UseRadialTurning"]));
            }
            set {
                this["UseRadialTurning"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ClickMaxDistance {
            get {
                return ((bool)(this["ClickMaxDistance"]));
            }
            set {
                this["ClickMaxDistance"] = value;
            }
        }
    }
}
