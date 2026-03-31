namespace ConsoleApp2.ocp
{
    class Case1
    {
        class User
        {
            // изменяю члены чтобы можно было управлять через другие классы
            public bool IsSelected {get; }
            public string Image {get; }

            public bool IsCool { get; }

            public User(bool isSelected, string image, bool isCool)
            {
                IsSelected = isSelected;
                Image = image;
                IsCool = isCool;
            }
            public void DrawUser(IEnumerable<IUserFeatureDrawer> featureDrawers)
            {
                // отрисовка присущая всем user 
                DrawBaseUser();

                // проходимся по последоват. способов отрисовки 
                // Если этот способ может отрисовать что-то для user, то рисуем
                foreach (var drawer in featureDrawers)
                {
                    if (drawer.CanDraw(this))
                        drawer.Draw(this);
                }
            }
            private void DrawBaseUser() { }
        }
        interface IUserFeatureDrawer
        {
            bool CanDraw(User user);
            void Draw(User user);
        }
        // До этого для каждой новой отрисовки приходилось бы изменять уже рабочую версию, добавляя новые if и реализации.
        // Сейчас мы можем не изменять имеющийся код, а расширять его. 
        class SelectedUserDrawer : IUserFeatureDrawer
        {
            public bool CanDraw(User user) => user.IsSelected;

            public void Draw(User user)
            {
                DrawEllipseAroundUser();
            }

            private void DrawEllipseAroundUser() { }
        }

        class ImageUserDrawer : IUserFeatureDrawer
        {
            public bool CanDraw(User user) => user.Image != null;

            public void Draw(User user)
            {
                DrawImageOfUser();
            }

            private void DrawImageOfUser() { }
        }

        class CoolGuyDrawer : IUserFeatureDrawer
        {
            public bool CanDraw(User user) => user.IsCool;

            public void Draw(User user)
            {
                DrawCoolGuyGlasses();
            }

            private void DrawCoolGuyGlasses() { }
        }
    }
}
