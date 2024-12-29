using System;

namespace UnityScriptTester
{
    public class ПереміщенняКамери
    {
        public string Ціль { get; set; }
        public float ШвидкістьРуху { get; set; } = 10.0f;
        public float ШвидкістьОгляду { get; set; } = 2.0f;
        public float МінY { get; set; } = -10f;
        public float МаксY { get; set; } = 10f;
        public float ШвидкістьГравця { get; set; } = 5.0f;
        public float СилаСтрибка { get; set; } = 5.0f;
        public int МаксСтрибків { get; set; } = 2;
        public int ПоточніСтрибки { get; set; }
        public bool НаЗемлі { get; set; } = false;

        public void Ініціалізувати()
        {
            ПоточніСтрибки = МаксСтрибків;
        }
    }
}
