using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp2.ocp
{
    class Case1
    {
        // Контракт крутого парня
        public interface ICoolGuy
        {
            void DrawCoolGuyGlasses();
        }

        // Абстракция в виде класса - пользователя
        public abstract class User
        {
            protected bool _isSelected;
            protected string _image;

            // Конструктор
            public User(bool isSelected, string image)
            {
                _isSelected = isSelected;
                _image = image;
            }

            // Метод для рисования пользователя
            public virtual void DrawUser()
            {
                if (_isSelected)
                    DrawEllipseAroundUser();
                if (_image != null)
                    DrawImageOfUser();
            }

            // Добавил хоть что-то в эти методы без кода
            // Метод для рисования контура вокруг пользователя
            protected virtual void DrawEllipseAroundUser()
            {
                Console.WriteLine("Drawing ellipse around user");
            }

            // Метод для рисования изображения пользователя 
            protected virtual void DrawImageOfUser()
            {
                Console.WriteLine("Drawing user image");
            }
        }

        // Класс обычного пользователя
        public class RegularUser : User
        {
            public RegularUser(bool isSelected, string image) : base(isSelected, image) { }
        }

        // Класс "крутого" пользователя
        public class CoolUser : User, ICoolGuy
        {
            public CoolUser(bool isSelected, string image) : base(isSelected, image) { }

            // Метод для рисования очков
            public void DrawCoolGuyGlasses()
            {
                Console.WriteLine("Drawing cool guy glasses");
            }

            // Метод для рисования "крутого" пользователя
            public override void DrawUser()
            {
                base.DrawUser();
                DrawCoolGuyGlasses();
            }
        }
    }
}
