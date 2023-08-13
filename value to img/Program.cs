using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace value_to_img
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path of the folder");
            string path = Console.ReadLine();
            Console.WriteLine("Please enter the number of images you would like to convert");
            int ImgNumber = int.Parse(Console.ReadLine()); //the files have to be named output + 1 - X to work
            Console.WriteLine("Please enter the output destinacion");
            string outputDir = Console.ReadLine();
            Console.WriteLine("Do you want to receive inforamtion when the program finishes a picture? Y/N");
            string Info = Console.ReadLine();
            Console.WriteLine("Please enter the width of the picture");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the height of the picture");
            int height = int.Parse(Console.ReadLine());
            for (int CurentFile = 1; CurentFile <= ImgNumber; CurentFile++)
            {
                string inputPath = Path.Combine(path, $"output{CurentFile}.txt");
                using (StreamWriter writer = new StreamWriter(outputDir + $"output{CurentFile}.jpg"));
                string text = File.ReadAllText(inputPath);
                string[] splittext = text.Split(' ');
                int currentnumber = 0;
                Bitmap image = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int pixelValue = int.Parse(splittext[currentnumber]);
                        Color color = (pixelValue == 0) ? Color.Black : Color.White;
                        image.SetPixel(x, y, color);
                        currentnumber++;
                    }
                }
                string filePath = Path.Combine(outputDir, $"output{CurentFile}.jpg");
                image.Save(filePath);

                if (Info.ToLower() == "y")
                {
                    Console.WriteLine($"Finished picture: {CurentFile}");
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
