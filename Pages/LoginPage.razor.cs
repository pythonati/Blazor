using FirstBlazor.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using FirstBlazor.OtherClasses.Enum;

namespace FirstBlazor.Pages
{
    public partial class LoginPage
    {
        private void Login()
        {
            if (authUser.Id > 0)
            {
                navManager.NavigateTo("/transaction");
                return;
            }

            if (!string.IsNullOrEmpty(_model.Login) && !string.IsNullOrEmpty(_model.Password))
            {
                SetUserId(LoginCheck());
            }
        }
        private ILoginDBModel LoginCheck()
        {
            var haspedPassword = ComputeHash(_model.Password, new SHA256CryptoServiceProvider());

            var _params = new Dictionary<string, string>()
            {
                {"Login", _model.Login },
                { "Password", haspedPassword },
                { "LoginType", _selectedLogin.ToString() }
            };

            return rep_login.UserId(_params);
        }
        private void SetUserId(ILoginDBModel _login)
        {
            switch (_login.Result)
            {
                case LoginResults.Registered or LoginResults.Found:
                    authUser.Id = _login.UserId;
                    RefreshUserUrls(_login);
                    Login();
                    break;
                case LoginResults.NotFound:
                    _showPopup = true;
                    _errorMessage = "Пользователь не найден, проверьте Имя и пароль";
                    break;
                case LoginResults.NotRegistered:
                    _showPopup = true;
                    _errorMessage = "Пользователь с таким именем уже существует в системе";
                    break;
                default:
                    break;
            }
        }
        private void RefreshUserUrls(ILoginDBModel _login)
        {
            var _params = new Dictionary<string, string>()
            {
                {"userId", _login.UserId.ToString() }
            };

            authUser.Refresh(rep_userUrls.Items(_params));
        }
        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
        public class SaveButton : IText, IStyle
        {
            private int _selected;
            public SaveButton setSelected(int val)
            {
                _selected = val;

                return this;
            }
            public string GetStyle
            {
                get
                {
                    if (_selected == 1)
                    {
                        return "btn btn-warning btn-block fcolor-ati-white";
                    }

                    return "btn btn-success btn-block fcolor-ati-white";
                }
            }

            public string GetText
            {
                get
                {
                    if (_selected == 1)
                    {
                        return "Register";
                    }

                    return "Sign In";
                }
            }
        }

        public class RegistrationButton : IText, IStyle
        {
            private int _id;
            private int _selected;

            public RegistrationButton(int id)
            {
                _id = id;
            }
            public RegistrationButton setSelected(int val)
            {
                _selected = val;

                return this;
            }
            public string GetStyle
            {
                get
                {
                    if (_selected == _id)
                    {
                        return "btn btn-block btn-ati-login-disable bcolor-ati-green fcolor-ati-white";
                    }

                    return "btn btn-block btn-ati-login-action bcolor-ati-darkgreen fcolor-ati-white";
                }
            }

            public string GetText => "Registration";
        }
        public class SignInButton : IText, IStyle
        {
            private int _id;
            private int _selected;

            public SignInButton(int id)
            {
                _id = id;
            }
            public SignInButton setSelected(int val)
            {
                _selected = val;

                return this;
            }
            public string GetStyle
            {
                get
                {
                    if (_selected == _id)
                    {
                        return "btn btn-block btn-ati-login-disable bcolor-ati-green fcolor-ati-white";
                    }

                    return "btn btn-block btn-ati-login-action bcolor-ati-darkgreen fcolor-ati-white";
                }
            }

            public string GetText => "Sign In";
        }
    }
}
