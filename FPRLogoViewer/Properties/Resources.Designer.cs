﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FPRLogoViewer.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FPRLogoViewer.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Export Logo as PNG....
        /// </summary>
        internal static string ExportPngDialogTitle {
            get {
                return ResourceManager.GetString("ExportPngDialogTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Export Logo as Raw Logo Data....
        /// </summary>
        internal static string ExportRawDialogTitle {
            get {
                return ResourceManager.GetString("ExportRawDialogTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to open GIF file.
        /// </summary>
        internal static string GifError_CantOpen {
            get {
                return ResourceManager.GetString("GifError_CantOpen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not remap color.
        /// </summary>
        internal static string GifError_CantRemapColor {
            get {
                return ResourceManager.GetString("GifError_CantRemapColor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No errors..
        /// </summary>
        internal static string GifError_None {
            get {
                return ResourceManager.GetString("GifError_None", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Too many colors in image (should be 64 or less).
        /// </summary>
        internal static string GifError_TooManyColors {
            get {
                return ResourceManager.GetString("GifError_TooManyColors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wrong image size (should be 128x128 pixels).
        /// </summary>
        internal static string GifError_WrongImageSize {
            get {
                return ResourceManager.GetString("GifError_WrongImageSize", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wrong pixel format (should be 8BPP indexed).
        /// </summary>
        internal static string GifError_WrongPixelFormat {
            get {
                return ResourceManager.GetString("GifError_WrongPixelFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Import Logo from GIF....
        /// </summary>
        internal static string ImportGifDialogTitle {
            get {
                return ResourceManager.GetString("ImportGifDialogTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Import Logo from Raw Logo Data....
        /// </summary>
        internal static string ImportRawDialogTitle {
            get {
                return ResourceManager.GetString("ImportRawDialogTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No file loaded..
        /// </summary>
        internal static string NoFileLoaded {
            get {
                return ResourceManager.GetString("NoFileLoaded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .ps2 and .max files are not supported..
        /// </summary>
        internal static string NoSupportPs2Max {
            get {
                return ResourceManager.GetString("NoSupportPs2Max", resourceCulture);
            }
        }
    }
}
