﻿using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace DemoApp.WPF.CustomControls;
/// <summary>
/// Interaktionslogik für BindablePasswordBox.xaml
/// </summary>
public partial class BindablePasswordBox : UserControl
{
    public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox));

    public SecureString Password 
    { 
        get => (SecureString)GetValue(PasswordProperty); 
        set => SetValue(PasswordProperty, value); 
    }

    public BindablePasswordBox()
    {
        InitializeComponent();
        txtPassword.PasswordChanged += OnPasswordChanged;
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        Password = txtPassword.SecurePassword;
    }
}
