﻿using System;
using System.Data.Entity;
using System.Windows.Forms;
using VisualPerception.Model;
using VisualPerception.Student;
using VisualPerception.Teacher;

namespace VisualPerception
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var context = new VisualPerceptionContext())
            {
                if (!context.Database.Exists())
                {
                    context.User.Add(new User { Name = "admin", GroupNumber = 0, Password = "admin" });

                    context.ExperimentSetting.Add(new ExperimentSetting { Name = "Предъявлений", Value = "5" });
                    context.ExperimentSetting.Add(new ExperimentSetting { Name = "Слов", Value = "16" });
                    context.ExperimentSetting.Add(new ExperimentSetting { Name = "Время", Value = "2,0" });
                    context.ExperimentSetting.Add(new ExperimentSetting { Name = "Теоретические", Value = "          Избирательность  восприятия  -  это  одно  из  его  важнейших  свойств.  Оно заключается  в  том,  что  человек воспринимает среди объектов, находящихся в поле  зрения,  не все  объекты,  а  только некоторые (или воспринимает не все, а лишь определенные признаки одного объекта).  \n          Избирательность   восприятия   определяется   как   объективными,    так    и субъективными  факторами.  К  объективным   факторам   относятся   различные отличительные признаки объектов (размер,  форма  цвет,   группировка и т.д.), к субъективным     факторам     относятся     личностные     особенности     субъекта восприятия   (потребности,   мотивы,   цели   и   задачи   деятельности,   ожидания, расположения, предпочтения и т.д.)." });

                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пила" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Рыба" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Кофе" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мебель" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Закат" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Кровь" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Море" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Конь" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шило" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Зола" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Сахар" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Топор" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Краска" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Дело" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Филин" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Цифра" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мыло" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ветер" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Баркас" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Фикус" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Масло" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Улица" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мышка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Река" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ствол" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мясо" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Картон" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Рынок" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Сани" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Буря" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Свекла" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Судья" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Живот" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Марка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Рулет" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Нора" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Лицо" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Голос" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Рама" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Атом" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Бедро" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Вопль" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Жаба" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Зона" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Икра" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Карта" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Луза" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мера" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ярмо" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Юнга" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Хобот" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Стол" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Банда" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Корпус" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Линза" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мята" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Урок" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Щука" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Арбуз" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Сокол" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Гиря" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Яма" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мерка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Нога" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Говор" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Гриб" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Орден" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пытка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пятно" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шакал" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Вата" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Губка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Сито" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пена" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ирис" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Щека" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Сера" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Утро" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Битва" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Висок" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ручка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Буран" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шанс" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Круг" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ветка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Вкус" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Жертва" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Накал" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Банка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пиво" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Горе" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Конус" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Юрта" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Норка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пятка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Сонет" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Флаг" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Локон" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Липа" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Фильтр" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Луна" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шепот" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мина" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Замок" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Парус" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Щетка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Тело" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Лето" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Орган" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Бензин" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Волк" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Грибок" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Зерно" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Кожа" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мода" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Вокзал" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Зебра" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Жест" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Запах" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Меч" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Страх" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шорох" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Счет" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Заяц" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Лыжи" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Лодка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Крыло" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Аист" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Душа" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Рельс" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Картуз" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шляпа" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Штопор" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Брюки" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Гайка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Гильза" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Группа" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Волос" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Лира" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мечта" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Жена" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Право" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пенал" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Крыша" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Жабо" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ангел" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Алмаз" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мороз" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Холод" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Заря" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Скирда" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Весна" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Терка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Заказ" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пчела" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Молот" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Парта" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Майка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Месяц" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Язык" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Юла" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Муха" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Кошка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Печать" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шнур" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Небо" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Арка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Вина" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ворот" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Бада" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Гараж" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Доска" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Десна" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Драка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Жила" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Закон" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Боров" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Печаль" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Антей" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Диван" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ковер" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Лепет" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Локоть" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Палец" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Батон" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Капот" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мираж" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Гроза" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Волна" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Штора" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шторм" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Грот" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пачка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Осень" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Водка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Стена" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Стекло" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Трепет" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Жиклер" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Серп" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Грабли" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Рыбак" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мангал" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Микроб" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Нарыв" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шторка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Щенок" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Ангар" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Артист" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Сцена" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Книга" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Парад" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Фитиль" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Халат" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Юмор" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Мячик" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шарик" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Стакан" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Вода" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Воля" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Гимн" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Дебри" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Дуга" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Дерби" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Опыт" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Зрачок" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пуля" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Тина" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шпага" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шпала" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Часы" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Кино" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Горб" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Орел" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Вино" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Шкаф" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Кружок" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Образ" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пекарь" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пикап" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Аркан" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Вираж" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Белок" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Металл" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Зелье" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Икона" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Жетон" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Рейс" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Пилка" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Дротик" });
                    context.ExperimentData.Add(new ExperimentData { Stimul = "Диск" });

                    context.SaveChanges();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
