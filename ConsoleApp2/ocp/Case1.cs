using System;

namespace ConsoleApp2.ocp
{
    class Case1
    {
        interface IUserDrawer
        {
            void Draw(User user);
        }

        interface ICoolGuy
        {
        }

        class User
        {
            public bool IsSelected { get; }
            public string Image { get; }

            public User(bool isSelected, string image)
            {
                IsSelected = isSelected;
                Image = image;
            }
        }

        class DefaultUserDrawer : IUserDrawer
        {
            public virtual void Draw(User user)
            {
                if (user.IsSelected)
                    DrawEllipseAroundUser();

                if (user.Image != null)
                    DrawImageOfUser();
            }

            protected void DrawEllipseAroundUser()
            {
                Console.WriteLine("Drawing ellipse around user.");
            }

            protected void DrawImageOfUser()
            {
                Console.WriteLine("Drawing user image.");
            }
        }

        class CoolGuyUserDrawer : DefaultUserDrawer
        {
            public override void Draw(User user)
            {
                base.Draw(user);

                if (user is ICoolGuy)
                    DrawCoolGuyGlasses();
            }

            private void DrawCoolGuyGlasses()
            {
                Console.WriteLine("Drawing cool guy glasses.");
            }
        }

        class CoolUser : User, ICoolGuy
        {
            public CoolUser(bool isSelected, string image)
                : base(isSelected, image)
            {
            }
        }
    }
}
