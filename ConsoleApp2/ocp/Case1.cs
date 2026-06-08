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
            public void DrawUser()
            {
                if (_isSelected)
                    DrawEllipseAroundUser();
                if (_image != null)
                    DrawImageOfUser();
                if (this is ICoolGuy) // редкий случай
                    DrawCoolGuyGlasses();
                // И т. д.
            }
            void DrawEllipseAroundUser() { }
            void DrawImageOfUser() { }
            void DrawCoolGuyGlasses() { }
        }
    }



    // Нарушение принципа OCP было в том, что при добавлении любого нового элемента нам приходилось бы вручную изменять готовый код класса User и дописывать новые условния if
    // Вся логика отрисовки каждого элемента в отдельности представлена обособленными классами. При необходимости добавить новый, достаточно создать новый класс. 
    // Отсюда, класс User стал открыт для дополнений, но закрыт для изменений.
    class Case1better
    {
        // интерфейс из оригинального условия
        public interface ICoolGuy { }

        // общий новый интерфейс для отрисовки 
        public interface IUserDrawer
        {
            void Draw(User user);
        }

        // отдельный класс, рисующий овал вокруг пользователя
        public class SelectionDrawer : IUserDrawer
        {
            public void Draw(User user)
            {
                // логика рисования овала
            }
        }

        // отдельный класс, рисующий картинку пользователя
        public class ImageDrawer : IUserDrawer
        {
            public void Draw(User user)
            {
                // логика рисования картинки
            }
        }

        // отдельный класс, рисующий очки крутого парня
        public class CoolGuyGlassesDrawer : IUserDrawer
        {
            public void Draw(User user)
            {
                if (user is ICoolGuy)
                {
                    Console.WriteLine("Drawing cool guy glasses.");
                }
            }
        }

        // Класс пользователя теперь закрыт для изменений. Он хранит только данные о себе и список элементов, которые нужно нарисовать
        public class User
        {
            public bool IsSelected { get; }
            public string Image { get; }

            private readonly List<IUserDrawer> _drawers;

            public User(bool isSelected, string image, List<IUserDrawer> drawers)
            {
                IsSelected = isSelected;
                Image = image;
                _drawers = drawers;
            }

            // Метод отрисовки теперь никогда не изменится, сколько бы новых элементов не пришлось добавить
            public void DrawUser()
            {
                foreach (var drawer in _drawers)
                {
                    drawer.Draw(this);
                }
            }
        }
    }
}




    