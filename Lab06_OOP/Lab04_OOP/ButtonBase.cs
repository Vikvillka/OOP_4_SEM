using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_OOP
{
    /*public abstract class ButtonBase : ContentControl
{
        // определение событие
        public static readonly RoutedEvent ClickEvent;

        static ButtonBase()
        {
            // регистрация маршрутизированного события
            ButtonBase.ClickEvent = EventManager.RegisterRoutedEvent("Click",
                RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ButtonBase));
            //................................
        }
        // обертка над событием
        public event RoutedEventHandler Click
        {
            add
            {
                // добавление обработчика
                base.AddHandler(ButtonBase.ClickEvent, value);
            }
            remove
            {
                // удаление обработчика
                base.RemoveHandler(ButtonBase.ClickEvent, value);
            }
        }
        // остальное содержимое класса
    }*/
}
