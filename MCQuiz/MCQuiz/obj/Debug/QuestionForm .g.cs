﻿#pragma checksum "..\..\QuestionForm .xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4638F53ECC8C11E76954F9975EAF5CB1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MCQuiz;
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


namespace MCQuiz {
    
    
    /// <summary>
    /// QuestionForm
    /// </summary>
    public partial class QuestionForm : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\QuestionForm .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbo_answer_1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\QuestionForm .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbo_answer_2;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\QuestionForm .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbo_answer_3;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\QuestionForm .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbo_answer_4;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\QuestionForm .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\QuestionForm .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_forward;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\QuestionForm .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_question;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\QuestionForm .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image img_gif;
        
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
            System.Uri resourceLocater = new System.Uri("/MCQuiz;component/questionform%20.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\QuestionForm .xaml"
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
            this.rbo_answer_1 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 2:
            this.rbo_answer_2 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.rbo_answer_3 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.rbo_answer_4 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\QuestionForm .xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.btn_back_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_forward = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\QuestionForm .xaml"
            this.btn_forward.Click += new System.Windows.RoutedEventHandler(this.btn_forward_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbx_question = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.img_gif = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

