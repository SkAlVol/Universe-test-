using System;
using UnityScriptTester; // Простір імен для основного класу

namespace UnityScriptTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var камера = new ПереміщенняКамери();
            камера.Ініціалізувати();

            Console.WriteLine("=== Перевірка змінних ПереміщенняКамери ===");
            Console.WriteLine($"Ціль: {(камера.Ціль != null ? "Встановлено" : "Не встановлено")}");
            Console.WriteLine($"Швидкість руху: {камера.ШвидкістьРуху}");
            Console.WriteLine($"Швидкість огляду: {камера.ШвидкістьОгляду}");
            Console.WriteLine($"Мінімальний Y: {камера.МінY}");
            Console.WriteLine($"Максимальний Y: {камера.МаксY}");
            Console.WriteLine($"Швидкість гравця: {камера.ШвидкістьГравця}");
            Console.WriteLine($"Сила стрибка: {камера.СилаСтрибка}");
            Console.WriteLine($"Максимальна кількість стрибків: {камера.МаксСтрибків}");
            Console.WriteLine($"Поточна кількість стрибків: {камера.ПоточніСтрибки}");
            Console.WriteLine($"На землі: {камера.НаЗемлі}");

            Console.WriteLine("\nДодаткові перевірки:");
            if (камера.ПоточніСтрибки > камера.МаксСтрибків)
            {
                Console.WriteLine("Помилка: Поточна кількість стрибків перевищує максимум.");
            }
            if (камера.ШвидкістьРуху <= 0)
            {
                Console.WriteLine("Помилка: Швидкість руху повинна бути додатною.");
            }

            Console.WriteLine("\nПеревірка завершена.");
        }
    }
}
