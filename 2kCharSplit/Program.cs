using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _2kCharSplit
{
   /*  public static class EnumUtil {
        public static IEnumerable<T> GetValues<T>() {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    } */
    public class textProcess {
        public string getText(string @file=""){
            Console.Write("Please enter the name of the text file to process, or type 'manual': ");
            string user_input = Console.ReadLine();;
            if(user_input != "manual"){
                try{
                    var outPutFile = File.CreateText("output.txt");
                    @file = user_input;
                    @file += ".txt";
                    File.OpenRead(@file);
                    string in_text = File.ReadAllText(@file);
                    in_text.ToArray();
                    for (int i = 0; i <= 2000; i++)
                    {
                        outPutFile.Write(in_text[i]);
                    }
                    outPutFile.Close();
                    
                }
                catch(Exception e){
                    if(e.Source != null){
                        Console.WriteLine("Error: " + e);
                        Console.WriteLine("Generating error log errlog.txt");
                        File.AppendAllTextAsync("errlog.txt", (e.Source + "\n" + e.Message + "\n"));                        
                    }
                    else{
                        Console.WriteLine("Welp, it's fucked?");
                    }
                }
            }
            else{
                // enter text manually
                try{
                    manual_text:
                    Console.WriteLine("Manual Mode: Please enter the text you would like to send to the file for processing: ");
                    string manual_text = Console.ReadLine();
                    if(manual_text != "" && manual_text != null){
                        var outPutFile = File.CreateText("output.txt");
                        outPutFile.Write(manual_text);
                        outPutFile.Close();
                    }
                    else{
                        Console.WriteLine("Error: Please enter some text");
                        goto manual_text;
                    }
                }
                catch(Exception e){
                    if(e.Source != null){
                        Console.WriteLine("Error: " + e);
                        Console.WriteLine("Generating error log errlog.txt");
                        File.AppendAllTextAsync("errlog.txt", (e.Source + "\n" + e.Message + "\n"));                        
                    }
                }
            }


            return @file;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            textProcess txtPro = new textProcess();
            txtPro.getText();
        }
    }
}
