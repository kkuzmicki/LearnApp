﻿using CommunityToolkit.Mvvm.Input;
using LearnAppClientWPF.Models;
using LearnAppClientWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearnAppClientWPF.ViewModels
{
    class LoginViewModel : ViewModelBase
    {

        public string? EmailText { get; set; } = "admin1@email.com";
        public string? PasswordText { get; set; } = "strongPassword1";

        public ICommand LoginCommand => new RelayCommand(SignIn);


        private async void SignIn()
        {
            if (String.IsNullOrEmpty(EmailText) || !Validator.IsEmailAddressValid(EmailText))
            {
                Trace.WriteLine("wrong email");
                return;
            }

            if (String.IsNullOrEmpty(PasswordText) || !Validator.IsPasswordValid(PasswordText))
            {
                Trace.WriteLine("wrong password");
                return;
            }

            try
            {
                UserModel userModel = await HttpHelper.GetUserWithEmailAddressAndPassword(EmailText, Cryptography.HashPassword_SHA256(PasswordText));
                App.Current.Properties["UsersID"] = userModel.id;
                Trace.WriteLine(App.Current.Properties["UsersID"] ?? "No 'UsersID'");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Ex: " + ex.Message);
            }
        }

    }
}
