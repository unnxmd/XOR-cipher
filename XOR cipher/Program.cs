using System;

namespace XOR_cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            byte initial_byte = 5;
            Console.Write("Перетащите файл или введите путь до него: ");
            string path = Console.ReadLine();
            path.Replace("\"", "");
            byte[] file_bytes = Encrypt_Decrypt(System.IO.File.ReadAllBytes(path), initial_byte);
            System.IO.File.WriteAllBytes(path, file_bytes);
            Console.WriteLine("Готово!");
            Console.ReadLine();
        }

        static byte CreateGammaByte(byte previous_byte)
        {
            //1+x^1+x^7+x^8
            byte bit = (byte)((previous_byte >> 0) ^ (previous_byte >> 1) ^ (previous_byte >> 7));
            return ((byte)((previous_byte >> 1) | (bit << 7)));
        }

        static byte[] Encrypt_Decrypt(byte[] permutate, byte init)
        {
            byte current = CreateGammaByte(init);
            for (int i = 0; i < permutate.Length; i++)
            {
                permutate[i] = (byte)(permutate[i] ^ current);
                current = CreateGammaByte(current);
            }
            return permutate;
        }
    }
}
