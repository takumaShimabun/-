﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace インボイス番号検索ツール.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.7.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\sms002\\99システム室_文書\\3_プログラム\\C#\\配布\\インボイス番号検索ツール")]
        public string AutoUpdaterServerFolderPath {
            get {
                return ((string)(this["AutoUpdaterServerFolderPath"]));
            }
            set {
                this["AutoUpdaterServerFolderPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("インボイス番号検索ツール.exe")]
        public string AutoUpdaterProjectFileName {
            get {
                return ((string)(this["AutoUpdaterProjectFileName"]));
            }
            set {
                this["AutoUpdaterProjectFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("インボイス番号検索ツール.old")]
        public string AutoUpdaterOldProjectFileName {
            get {
                return ((string)(this["AutoUpdaterOldProjectFileName"]));
            }
            set {
                this["AutoUpdaterOldProjectFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ThemeColor {
            get {
                return ((string)(this["ThemeColor"]));
            }
            set {
                this["ThemeColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string StrCustomColors {
            get {
                return ((string)(this["StrCustomColors"]));
            }
            set {
                this["StrCustomColors"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\dev001\\C$\\data\\適格請求書発行事業者公開データ取込\\*")]
        public string UnZipperDefaultPath {
            get {
                return ((string)(this["UnZipperDefaultPath"]));
            }
            set {
                this["UnZipperDefaultPath"] = value;
            }
        }
    }
}
