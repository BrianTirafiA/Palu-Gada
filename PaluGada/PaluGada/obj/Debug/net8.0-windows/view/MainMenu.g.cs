﻿#pragma checksum "..\..\..\..\view\MainMenu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "161D433E3955CBDBB056AF53E475CCA2FEFEE7DB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// MainMenu
    /// </summary>
    public partial class MainMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\view\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HomeButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\view\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainMenuFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/PaluGada;component/view/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\view\MainMenu.xaml"
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
            this.HomeButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\view\MainMenu.xaml"
            this.HomeButton.Click += new System.Windows.RoutedEventHandler(this.HomeButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 42 "..\..\..\..\view\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddPostButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 43 "..\..\..\..\view\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MyItemButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 44 "..\..\..\..\view\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.WishlistButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 45 "..\..\..\..\view\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChatButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 46 "..\..\..\..\view\MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AccountButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MainMenuFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

