using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string secretWord = GetRandomWord();
        char[] guessedWord = new char[secretWord.Length];
        for (int i = 0; i < secretWord.Length; i++)
        {
            guessedWord[i] = '_';
        }

        List<char> guessedLetters = new List<char>();
        int attempts = 10;

        Console.WriteLine("Hoş geldiniz! Kelimeyi tahmin etmeye başlayın.");

        while (attempts > 0)
        {
            Console.WriteLine($"Tahmin edilecek kelime: {new string(guessedWord)}");
            Console.WriteLine($"Kullanılan harf: {string.Join(", ", guessedLetters)}");
            Console.WriteLine($"Kalan hakkınız: {attempts}");
            Console.Write("Harf tahmininizi girin: ");
            char guess = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (!char.IsLetter(guess))
            {
                Console.WriteLine("Geçersiz bir harf girdiniz.");
                continue;
            }

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("Bu harfi zaten denediniz.");
                continue;
            }

            guessedLetters.Add(guess);

            if (secretWord.Contains(guess))
            {
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        guessedWord[i] = guess;
                    }
                }
            }
            else
            {
                attempts--;
                Console.WriteLine("Harf kelime içinde bulunmuyor.");
            }

            if (new string(guessedWord) == secretWord)
            {
                Console.WriteLine($"Tebrikler! Kelimeyi buldunuz: {secretWord}");
                break;
            }
        }

        if (attempts == 0)
        {
            Console.WriteLine($"Üzgünüm, kelimeyi bulamadınız. Doğru kelime: {secretWord}");
        }
    }

    static string GetRandomWord()
    {
        string[] words = { "elma", "armut", "kiraz", "muz", "çilek", "portakal", "karpuz", "şeftali" };
        Random random = new Random();
        int index = random.Next(words.Length);
        return words[index];
    }
}
