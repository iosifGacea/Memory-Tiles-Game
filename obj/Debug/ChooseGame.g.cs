﻿#pragma checksum "..\..\ChooseGame.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E4AC9E4EF2FBDB20C9648AF4EA92D8D1A59954CCCF2634AACDC0DBFE509A5439"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using TemaMVP;


namespace TemaMVP {
    
    
    /// <summary>
    /// ChooseGame
    /// </summary>
    public partial class ChooseGame : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\ChooseGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button resume;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ChooseGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button statistica;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TemaMVP;component/choosegame.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChooseGame.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 37 "..\..\ChooseGame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\ChooseGame.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.New_Game);
            
            #line default
            #line hidden
            return;
            case 3:
            this.resume = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\ChooseGame.xaml"
            this.resume.Click += new System.Windows.RoutedEventHandler(this.Resume_Game);
            
            #line default
            #line hidden
            return;
            case 4:
            this.statistica = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\ChooseGame.xaml"
            this.statistica.Click += new System.Windows.RoutedEventHandler(this.Statistica);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
