using Newtonsoft.Json;
using System.Xml.Serialization;

namespace редактор_текста
{
    internal class Vigruzka
    {
        public void Ceril(List<help> figur)
        {
           
            string fali = Console.ReadLine();
            string faliT;
            faliT = "json";
                if (fali.Contains(faliT))
                {
                    string json = JsonConvert.SerializeObject(figur);
                    File.WriteAllText(fali, json);
                }
                faliT = "txt";
                if (fali.Contains(faliT))
                {
                    File.Delete(fali);
                    foreach (var item in figur)
                    {
                        File.AppendAllText(fali, item.Name + "\n");
                        File.AppendAllText(fali, item.Form + "\n");
                        File.AppendAllText(fali, item.Opisanie + "\n");
                        File.AppendAllText(fali, item.Cena);
                    }
                }
                faliT = "xml";
                if (fali.Contains(faliT))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<help>));
                    using (FileStream fs = new FileStream(fali, FileMode.Create))
                    {
                        xml.Serialize(fs, figur);
                    }
                }
                Console.Clear();
            

            
        }
        public int DeCeril(List<help> figur, help text)
        {
            List<help> texts = new List<help>();
            string fali = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Данные файла: \n----------------------------------------");
            string faliT;
            int h = 5;
            if (File.Exists(fali))
            {
                faliT = "json";
                if (fali.Contains(faliT))
                {
                    string json = File.ReadAllText(fali);
                    texts = JsonConvert.DeserializeObject<List<help>>(json);
                    foreach (var item in texts)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Form);
                        Console.WriteLine(item.Opisanie);
                        Console.WriteLine(item.Cena);
                    }
                }
                faliT = "txt";
                if (fali.Contains(faliT))
                {

                    string[] lines = File.ReadAllLines(fali);
                    for (int i = 0; i < lines.Length; i+=4)
                    {
                        help hp = new help();
                        hp.Name = lines[i];
                        hp.Form = lines[i + 1];
                        hp.Opisanie = lines[i + 2];
                        hp.Cena = lines[i + 3];

                        texts.Add(hp);
                    }
                    foreach (var item in texts)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Form);
                        Console.WriteLine(item.Opisanie);
                        Console.WriteLine(item.Cena);
                    }

                }
                faliT = "xml";
                if (fali.Contains(faliT))
                {
                    
                    XmlSerializer xml = new XmlSerializer(typeof(List<help>));
                    using (FileStream fs = new FileStream(fali, FileMode.Open))
                    {
                        texts = (List<help>)xml.Deserialize(fs);
                    }
                    foreach (var item in texts)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Form);
                        Console.WriteLine(item.Opisanie);
                        Console.WriteLine(item.Cena);
                    }
                }
                Console.WriteLine("----------------------------------------\n Желаете изменить файл? \n  Да\n  Нет");
                int p = 8;
                int pr = 3;
                h = Strelka(p, pr);
                if (h == 9)
                {
                    foreach (var item in texts)
                    {
                        Console.WriteLine("  " + item.Name);
                        text.Name = item.Name;
                        Console.WriteLine("  " + item.Form);
                        text.Form = item.Form;
                        Console.WriteLine("  " + item.Opisanie);
                        text.Opisanie = item.Opisanie;
                        Console.WriteLine("  " + item.Cena);
                        text.Cena = item.Cena;
                    }
                    h = 3;
                }
                if (h == 8)
                {
                    Menalka(texts, text);
                    h = 3;
                }
                
            }
            else
            {
                Console.WriteLine("Такого файла не существует");
            }

            return h;

        }
        public int Strelka(int p, int pr)
        {
            int b = 9;
            while (b != 0)
            {
                ConsoleKeyInfo k = Console.ReadKey();

                if (k.Key == ConsoleKey.Enter)
                {
                    b = 0;
                }
                if (k.Key == ConsoleKey.Escape)
                {
                    p = 0;
                    b = 0;
                }
                if (k.Key == ConsoleKey.DownArrow)
                {
                    p = p + 1;
                    b = p - 1;
                }
                if (k.Key == ConsoleKey.UpArrow)
                {
                    p = p - 1;
                    b = p + 1;
                }
                if (pr == 3)
                {
                    if (p == 10)
                    {
                        p = 9;b = 8;
                    }
                    if (p == 7)
                    {
                        p = 8;b = 9;
                    }
                }
                if (pr == 2)
                {
                    if (p == 1)
                    { p = 2; b = 3; }
                    if (p == 6)
                    { p = 5; b = 4; }

                }
                Console.SetCursorPosition(0, p);
                Console.WriteLine("->");
                Console.SetCursorPosition(0, b);
                Console.WriteLine("  ");
            }
            return p;
        }
        public void Menalka(List<help> texts, help text)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Выберите строчку и измените её. \n ---------------------------------");
            foreach (var item in texts)
            {
                Console.WriteLine("  " + item.Name);
                text.Name = item.Name;
                Console.WriteLine("  " + item.Form);
                text.Form = item.Form;
                Console.WriteLine("  " + item.Opisanie);
                text.Opisanie = item.Opisanie;
                Console.WriteLine("  " + item.Cena);
                text.Cena = item.Cena;
            }
            int p = 2;
            int pr = 2;
            int d = Strelka(p, pr);
            Console.SetCursorPosition(0, d);
            Console.Write("                                                                     ");
            if (d == 2)
            {
                Console.SetCursorPosition(2, d);
                text.Name = Console.ReadLine();
            }
            if (d == 3)
            {
                Console.SetCursorPosition(2, d);
                text.Form = Console.ReadLine();
            }
            if (d == 4)
            {
                Console.SetCursorPosition(2, d);
                text.Opisanie = Console.ReadLine();
            }
            if (d == 5)
            {
                Console.SetCursorPosition(2, d);
                text.Cena = Console.ReadLine();
            }

        }
    }
}
