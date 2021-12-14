using System;
using System.Collections.Generic;
using System.IO;

namespace CowInterpreter {

    class Program {
        static int Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Пожалуйста, в качестве аргумента командной строки укажите путь к файлу исходного кода.");
            }
            else {
                if (File.Exists(args[0])) {
                    StreamReader sr = File.OpenText(args[0]);
                    List<string> allElements = new List<string>();
                    while (true) {
                        string str = sr.ReadLine();
                        if (str == null)
                            break;
                        string[] el = str.Split(" ");
                        for (int i = 0; i < el.Length; i++)
                            allElements.Add(el[i]);
                    }
                    String[] coms_list = {"moo", "mOo", "moO", "mOO", "Moo", "MOo", "MoO", "MOO", "OOO", "MMM", "OOM", "oom"};
                    int[] cells = new int[5000];
                    for (int i = 0; i < 5000; i++) {
                        cells[i] = 0;
                    }
                    int index = 0;
                    int register = -1;
                    int lvl = 0, lvlstart = 0;
                    for (int i = 0; i < allElements.Count; i++) {
                        string action = allElements[i].ToString();
                    Mark:
                        switch (action) {
                            case "MoO":
                                cells[index]++; break;
                            case "MOo":
                                cells[index]--; break;
                            case "moO":
                                index++; break;
                            case "mOo":
                                index--; break;
                            case "OOM":
                                Console.WriteLine(cells[index]); break;
                            case "Moo":
                                if (cells[index] != 0) Console.Write((char)cells[index]);
                                else cells[index] = Console.Read();
                                break;
                            case "OOO":
                                cells[index] = 0; break;
                            case "MMM":
                                if (register == -1)
                                    register = cells[index];
                                else {
                                    cells[index] = register; register = -1;
                                }
                                break;
                            case "moo":
                                lvl = 1;
                                if (cells[index] != 0) {
                                    while (lvl > 0) {
                                        i--;
                                        if (allElements[i].ToString() == "MOO") lvl--;
                                        else if (allElements[i].ToString() == "moo") lvl++;
                                    }
                                }
                                break;
                            case "MOO":
                                lvl = 1;
                                if (cells[index] == 0) {
                                    while (lvl > 0) {
                                        i++;
                                        if (allElements[i].ToString() == "MOO") lvl++;
                                        else if (allElements[i].ToString() == "moo") lvl--;
                                    }
                                }
                                break;
                            case "mOO":
                                if (cells[index] == 3 || cells[index] > 11)
                                    return 1;
                                else {
                                    action = coms_list[cells[index]];
                                    goto Mark;
                                }
                            default:
                                break;
                        }
                    }
                }
                else {
                    Console.WriteLine("Файл не найден. Пожалуйста, укажите только наименование файла без спецсимволов (тире и слеши не нужны), либо проверьте правильность написания имени файла.");
                }
            }
            Console.ReadKey();
            return 0;
        }
    }
}