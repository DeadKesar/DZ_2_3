using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ocp
{
    class Case1
    {
        class User
        {
            private bool _isSelected;
            private string _image;

            public User(bool isSelected, string image)
            {
                _isSelected = isSelected;
                _image = image;
            }

            public virtual void DrawUser()
            {
                if (_isSelected)
                    DrawEllipseAroundUser();

                if (_image != null)
                    DrawImageOfUser();
            }

            protected void DrawEllipseAroundUser() { }

            protected void DrawImageOfUser() { }
        }

        class CoolUser : User
        {
            public CoolUser(bool isSelected, string image)
                : base(isSelected, image)
            {
            }

            public override void DrawUser()
            {
                base.DrawUser();
                DrawCoolGuyGlasses();
            }

            private void DrawCoolGuyGlasses() { }
        }
    }
}
