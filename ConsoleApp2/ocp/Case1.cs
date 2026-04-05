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
        }

        // общий интерфейс для отрисовки элементов юзера
        interface IUserFeatureDrawer
        {
            bool CanDraw(User user);
            void Draw(User user);
        }

        class User
        {
            // изменяю члены, чтгобы можно были использовать через другие классы
            public bool IsSelected { get; }
            public string Image { get; }

            public User(bool isSelected, string image)
            {
                IsSelected = isSelected;
                Image = image;
            }

            // сейчас юзер не содержит всю логику отрисовки, он только себя передает обработчикам
            public void DrawUser(IEnumerable<IUserFeatureDrawer> featureDrawers)
            {
                // здесь проходим по способам отрисовки, если способ может что-то отрисовать для юзер, то просто рисуем
                foreach (var drawer in featureDrawers)
                {
                    if (drawer.CanDraw(this))
                    {
                        drawer.Draw(this);
                    }
                }
            }
        }

        // отдельный класс, для использования айкулгай
        class CoolGuyUser : User, ICoolGuy
        {
            public CoolGuyUser(bool isSelected, string image)
                : base(isSelected, image)
            {
            }
        }
        // сейчас не нужно постоянно менять код, добавляя иф и новые реализации. Также мы не можем изменять имеющийся код, просто расширяешь его и все работает как часики
        // отрисовка для выбранного пользователя
        class SelectedUserDrawer : IUserFeatureDrawer
        {
            public bool CanDraw(User user)
            {
                return user.IsSelected;
            }

            public void Draw(User user)
            {
                DrawEllipseAroundUser();
            }

            private void DrawEllipseAroundUser()
            {
            }
        }

        // отрисовка для картинки
        class ImageUserDrawer : IUserFeatureDrawer
        {
            public bool CanDraw(User user)
            {
                return !string.IsNullOrWhiteSpace(user.Image);
            }

            public void Draw(User user)
            {
                DrawImageOfUser();
            }

            private void DrawImageOfUser()
            {
            }
        }

        // отрисовка для НАИКРУТЕЙШЕГО ПАРЕНЬКА
        class CoolGuyDrawer : IUserFeatureDrawer
        {
            public bool CanDraw(User user)
            {
                return user is ICoolGuy;
            }

            public void Draw(User user)
            {
                DrawCoolGuyGlasses();
            }

            private void DrawCoolGuyGlasses()
            {
            }
        }
    }
}