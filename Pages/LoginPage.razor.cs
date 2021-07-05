using FirstBlazor.Interfaces;

namespace FirstBlazor.Pages
{
    public partial class LoginPage
    {
        private void Login()
        {
            NavManager.NavigateTo("/transaction");
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
