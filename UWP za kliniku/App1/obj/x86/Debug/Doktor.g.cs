﻿#pragma checksum "C:\Users\belma\Desktop\Zadac4\App1\App1\Doktor.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "400F70200675E533C9F671F0B9B6C4C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1
{
    partial class Doktor : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.pregled = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 13 "..\..\..\Doktor.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.pregled).Checked += this.pregled_Checked;
                    #line default
                }
                break;
            case 2:
                {
                    this.terapija = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 14 "..\..\..\Doktor.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.terapija).Checked += this.terapija_Checked;
                    #line default
                }
                break;
            case 3:
                {
                    this.red = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 15 "..\..\..\Doktor.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.red).Checked += this.red_Checked;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 16 "..\..\..\Doktor.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.Button_Click_1;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 17 "..\..\..\Doktor.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Button_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.ime = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.pacijent = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 19 "..\..\..\Doktor.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.pacijent).SelectionChanged += this.pacijent_SelectionChanged;
                    #line default
                }
                break;
            case 8:
                {
                    this.terapije = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.blok = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10:
                {
                    this.tip = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.tipT = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 12:
                {
                    this.datum = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.datumT = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
