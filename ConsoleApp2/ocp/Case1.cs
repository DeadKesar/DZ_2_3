using System;
using System.Collections.Generic;

namespace ConsoleApp2.ocp
{
    //Выделяем поведение отрисовки в отдельные классы
    /// Представляет одну операцию отрисовки, применяемую к пользователю.
    internal interface IUserDrawer
    {
        void Draw(User user);
    }
    // Рисует эллипс вокруг пользователя, если он выбран.
    internal class EllipseDrawer : IUserDrawer
    {
        public void Draw(User user)
        {
            if (user.IsSelected)
                DrawEllipse();
        }
        private void DrawEllipse() { }
    }
    // Рисует изображение пользователя, если оно задано.
    internal class ImageDrawer : IUserDrawer
    {
        public void Draw(User user)
        {
            if (!string.IsNullOrEmpty(user.Image))
                DrawImage(user.Image);
        }
        private void DrawImage(string image) { }
    }
    // Рисует «крутые» очки, если пользователь реализует интерфейс ICoolGuy.
    internal class CoolGuyGlassesDrawer : IUserDrawer
    {
        public void Draw(User user)
        {
            if (user is ICoolGuy)
                DrawGlasses();
        }
        private void DrawGlasses() { /* логика отрисовки очков */ }
    }
    // Маркернтй интерфейс для «крутых» пользователей
    public interface ICoolGuy
    {
        void CallCoolGuy();
    }
    // Рефакторинг класса User 
    public class User
    {
        private readonly List<IUserDrawer> _drawers = new List<IUserDrawer>();
        // Свойства вместо полей — для инкапсуляции и удобства чтения
        public bool IsSelected { get; }
        public string Image { get; }

        public User(bool isSelected, string image)
        {
            IsSelected = isSelected;
            Image = image;
        }
        // Добавляет операцию отрисовки к данному пользователю.
        // Позволяет расширять функциональность без изменения класса User.
        public void AddDrawer(IUserDrawer drawer)
        {
            if (drawer == null)
                throw new ArgumentNullException(nameof(drawer));
            _drawers.Add(drawer);
        }

        // Отрисовывает пользователя, применяя все зарегистрированные операции.
        public void DrawUser()
        {
            foreach (var drawer in _drawers)
            {
                drawer.Draw(this);
            }
        }
    }
}
Что нарушено
В исходном коде метод DrawUser() содержал всю логику отрисовки внутри класса User.
При добавлении нового типа отрисовки пришлось бы изменять этот метод — нарушение Open/Closed Principle (класс закрыт для модификации, открыт для расширения).
Что сделали
Вынесли каждую операцию отрисовки (эллипс, изображение, очки) в отдельные классы, реализующие общий интерфейс IUserDrawer.
В классе User убрали конкретные условия и вместо этого добавили список таких «рисовальщиков».
Добавили метод AddDrawer(), чтобы можно было гибко подключать нужные операции.
Зачем и почему
Теперь User больше не меняется при появлении новых видов отрисовки — он просто вызывает все добавленные IUserDrawer.
Новую отрисовку добавляют без изменения существующего кода (создаётся новый класс-рисовальщик и регистрируется через AddDrawer()).
Код стал чище: каждый класс отвечает за одну операцию (принцип единственной ответственности), зависимости явные, инкапсуляция сохранена.
