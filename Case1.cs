using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ocp
{
    class Case1
    {
        interface ICoolGuy
        {
            void CallCoolGuy();
        }

        class User
        {
            private bool _isSelected;
            private string _image;

            public User(bool isSelected, string image)
            {
                _isSelected = isSelected;
                _image = image;
            }

            public virtual void DrawUser()//стал virtual 
            {
                if (_isSelected)
                    DrawEllipseAroundUser();

                if (_image != null)
                    DrawImageOfUser();
            }

            private void DrawEllipseAroundUser() { }
            private void DrawImageOfUser() { }
            protected void DrawCoolGuyGlasses() { }//protected для наследников + clean code
        }

        // новый класс для расширения через наследование и переопределение
        class CoolGuyUser : User
        {
            public CoolGuyUser(bool isSelected, string image)
                : base(isSelected, image)
            {
            }

            public override void DrawUser()
            {
                base.DrawUser();
                DrawCoolGuyGlasses();      //специфичное поведение
            }
        }
    }
}