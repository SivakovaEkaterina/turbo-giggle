using Newtonsoft.Json;
using System.Xml.Serialization;

namespace редактор_текста
{
    internal class Program
    {
        static void Main(string[] args)
        {
            help text = new help();
            text.Name = "Прямоугольник";
            text.Form = "34 см на 56 см на 12 см";
            text.Opisanie = "средних размеров прямоугольник из обычной задачи по математике";
            text.Cena = "бесплатно";
            while (true)
            {
                List<help> figur = new List<help>();
                figur.Add(text);

                Vigruzka vigruzka = new Vigruzka();

                while (true)
                {
                    int v = 10;
                    while (v != 0)
                    {
                        Console.WriteLine("Введите путь до файла который хотите открыть\n ----------------------------------------------");
                        v = vigruzka.DeCeril(figur, text);
                        if (v == 3)
                        { 
                            figur.Remove(text);
                            figur.Add(text);
                            v = 0;
                        }
                        Console.Clear();
                    }

                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Введите путь для сохранения файла: \n ----------------------------------------------");
                    vigruzka.Ceril(figur);
                    
                    Console.WriteLine("Файл сохранён. Нажмите любую кнопку. \n ----------------------------------------------");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }
    }
}
/* string txtf = "C:\\Users\\edlit\\OneDrive\\Рабочий стол\\help.txt";
            string jsonf = "C:\\Users\\edlit\\OneDrive\\Рабочий стол\\help.json";
            string xmlf = "C:\\Users\\edlit\\OneDrive\\Рабочий стол\\help.xml";

            help text = new help();
            text.Name = "Прямоугольник";
            text.Form = "34 см на 56 см на 12 см";
            text.Opisanie = "средних размеров прямоугольник из обычной задачи по математике";
            text.Cena = "бесплатно";
            int b = 0;
            string fali = "";
            ConsoleKeyInfo s;
            List<help> figur = new List<help>();
            figur.Add(text);
            while (b == 0)
            {
                fali = Console.ReadLine();
                *//*s = Console.ReadKey();*//*
                if (fali == "json")
                {
                    string json = JsonConvert.SerializeObject(figur);
                    File.WriteAllText(jsonf, json);
                    Console.WriteLine(json);
                }
                if (fali == "txt")
                {
                    File.Delete(txtf);
                    File.AppendAllText(txtf, text.Name + "\n");
                    File.AppendAllText(txtf, text.Form + "\n");
                    File.AppendAllText(txtf, text.Opisanie + "\n");
                    File.AppendAllText(txtf, text.Cena + "\n");
                }
                if (fali == "xml")
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<help>));
                    using (FileStream fs = new FileStream(xmlf, FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, figur);
                    }
                }
                string jsons = JsonConvert.SerializeObject(figur);
                if (fali == "read json")
                {
                    List<help> texts = JsonConvert.DeserializeObject<List<help>>(jsons);
                    foreach (var item in texts)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Form);
                        Console.WriteLine(item.Opisanie);
                        Console.WriteLine(item.Cena);
                    }
                }
                if (fali == "read txt")
                {
                    Console.WriteLine(File.ReadAllText(txtf));
                }
                if (fali == "read xml")
                {
                    List<help> HELP;
                    XmlSerializer xml = new XmlSerializer(typeof(List<help>));
                    using (FileStream fs = new FileStream(xmlf, FileMode.Open))
                    {
                        HELP = (List<help>)xml.Deserialize(fs);
                    }
                    foreach (var item in HELP)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Form);
                        Console.WriteLine(item.Opisanie);
                        Console.WriteLine(item.Cena);
                    }
                }
            }*/

    /*Console.WriteLine("Введите путь для сохранения файла: \n ----------------------------------------------");*/
/*else
{
    string fal = "txt";
    string fa = "xml";
    if (fali.Contains(faliT) || fali.Contains(fal) || fali.Contains(fa))
    {
        Console.WriteLine("Open");
        if (fali.Contains(faliT))
        {
            string json = JsonConvert.SerializeObject(figur);
            File.WriteAllText(fali, json);
        }
        faliT = "txt";
        if (fali.Contains(faliT))
        {
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
            using (FileStream fs = new FileStream(fali, FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, figur);
            }
        }
    }
    File.Create(fali);
    foreach (var item in figur)
    {
        File.AppendAllText(fali, item.Name + "\n");
        File.AppendAllText(fali, item.Form + "\n");
        File.AppendAllText(fali, item.Opisanie + "\n");
        File.AppendAllText(fali, item.Cena);
    }
    Console.WriteLine("Файл не был обнаружен и был создан.");
}*/