﻿#pragma checksum "..\..\..\..\view\AddPost.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91D96FE9477E74ACAFF832F3808B9C0C725EFDB0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GMap.NET.WindowsPresentation;
using PaluGada.view;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PaluGada.view {
    
    
    /// <summary>
    /// AddPost
    /// </summary>
    public partial class AddPost : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\view\AddPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox box_ItemName;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\view\AddPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox box_Description;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\view\AddPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadButton;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\view\AddPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ButtonContent;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\view\AddPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox box_Location;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\view\AddPost.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GMap.NET.WindowsPresentation.GMapControl mapControl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PaluGada;component/view/addpost.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\view\AddPost.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.box_ItemName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.box_Description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.UploadButton = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\..\view\AddPost.xaml"
            this.UploadButton.Click += new System.Windows.RoutedEventHandler(this.UploadButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonContent = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 5:
            this.box_Location = ((System.Windows.Controls.TextBox)(target));
            
            #line 89 "..\..\..\..\view\AddPost.xaml"
            this.box_Location.KeyDown += new System.Windows.Input.KeyEventHandler(this.box_Location_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.mapControl = ((GMap.NET.WindowsPresentation.GMapControl)(target));
            
            #line 108 "..\..\..\..\view\AddPost.xaml"
            this.mapControl.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.mapControl_PreviewMouseWheel);
            
            #line default
            #line hidden
            
            #line 108 "..\..\..\..\view\AddPost.xaml"
            this.mapControl.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.mapControl_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 113 "..\..\..\..\view\AddPost.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PostButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

