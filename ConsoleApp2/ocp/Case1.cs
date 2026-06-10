using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.ocp
{
    class Case1
    {
        public interface IUser
        {
            void Draw();
        }

        public abstract class User : IUser
        {
            protected bool _isSelected;
            protected string _image;

            public User(bool isSelected, string image)
            {
                _isSelected = isSelected;
                _image = image;
            }

            public virtual void Draw()
            {
                if (_isSelected)
                    DrawEllipseAroundUser();
                if (_image != null)
                    DrawImageOfUser();
            }

            protected void DrawEllipseAroundUser() { }
            protected void DrawImageOfUser() { }
        }

        public interface ICoolGuy
        {
            void CallCoolGuy();
        }

        public class CoolGuyUser : User, ICoolGuy
        {
            public CoolGuyUser(bool isSelected, string image) : base(isSelected, image) { }

            public void CallCoolGuy() { }

            public override void Draw()
            {
                base.Draw();
                DrawCoolGuyGlasses();
            }

            private void DrawCoolGuyGlasses() { }
        }

        public class RegularUser : User
        {
            public RegularUser(bool isSelected, string image) : base(isSelected, image) { }
        }
    }
}
