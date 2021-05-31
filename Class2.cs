using System;

public class Class1
{
	public Class1()
	{
        static void Main(string[] args)
        {
            var path = @"I:\Study\CsPrograms\myfile.txt";

            string text = "old falcon";
            File.WriteAllText(path, text);

            Console.WriteLine("text written");
        }
    }
}
