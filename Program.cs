using System;
using UnityScriptTester; // ������ ���� ��� ��������� �����

namespace UnityScriptTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var ������ = new ����������������();
            ������.������������();

            Console.WriteLine("=== �������� ������ ���������������� ===");
            Console.WriteLine($"ֳ��: {(������.ֳ�� != null ? "�����������" : "�� �����������")}");
            Console.WriteLine($"�������� ����: {������.������������}");
            Console.WriteLine($"�������� ������: {������.��������������}");
            Console.WriteLine($"̳�������� Y: {������.̳�Y}");
            Console.WriteLine($"������������ Y: {������.����Y}");
            Console.WriteLine($"�������� ������: {������.��������������}");
            Console.WriteLine($"���� �������: {������.�����������}");
            Console.WriteLine($"����������� ������� �������: {������.�����������}");
            Console.WriteLine($"������� ������� �������: {������.�������������}");
            Console.WriteLine($"�� ����: {������.������}");

            Console.WriteLine("\n�������� ��������:");
            if (������.������������� > ������.�����������)
            {
                Console.WriteLine("�������: ������� ������� ������� �������� ��������.");
            }
            if (������.������������ <= 0)
            {
                Console.WriteLine("�������: �������� ���� ������� ���� ��������.");
            }

            Console.WriteLine("\n�������� ���������.");
        }
    }
}
