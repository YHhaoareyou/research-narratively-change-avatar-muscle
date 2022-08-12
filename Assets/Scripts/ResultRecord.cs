using System;
using System.Collections.Generic;
using System.IO;

public class QuestionnaireResultRecord
{
    private static List<string> records = new List<string>();

    public static void AddAnswer(int answer)
    {
        records.Add(answer.ToString());
    }

    public static void WriteRecordToFile(string fileName)
    {
        using (StreamWriter sw = File.AppendText("./Output/" + fileName + ".txt"))
        {
            string output = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "," + string.Join(",", records);
            sw.WriteLine(output);
        }
        records.Clear();
    }
}
