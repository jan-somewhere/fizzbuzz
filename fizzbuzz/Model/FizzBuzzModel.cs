using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class FizzBuzzModel {

    private string[] fizzBuzzList;
    private int max;

    private string path;

    private readonly object lk = new object();

    public FizzBuzzModel(IConfiguration config) {
        max = config.GetValue<int>("EndNumber");
        createList();

        path = System.AppDomain.CurrentDomain.BaseDirectory + "fizzbuzz.txt";

        if (!File.Exists(path)) {
            var file = File.Create(path);
            file.Close();
        }
	}

    private void createList() {

        CustomLogger.LogInformation("fizzbuzzmodel: generating list, max: " + max);

        if (max <= 0) {
            CustomLogger.LogWarning("fizzbuzzmodel: max value must be strictly positive, changing value to 20");
            max = 20;
        }

        string[] list = new string[max + 1];

        for (int i = 1; i <= max; i++) {
            if (i % 3 == 0 && i % 5 == 0) {
                list[i] = "fizzbuzz";
            } else if (i % 3 == 0) {
                list[i] = "fizz";
            } else if (i % 5 == 0) {
                list[i] = "buzz";
            } else {
                list[i] = i.ToString();
            }
        }

        fizzBuzzList = list;

        CustomLogger.LogInformation("fizzbuzzmodel: list generated");
    }

    public string[] getList(int start) {
        CustomLogger.LogInformation("fizzbuzzmodel: retrieving list from " + start);

        if (start > max) {
            throw new CustomException("fizzbuzzmodel: start index cannot be bigger than max value");
        } else if (start < 0) {
            throw new CustomException("fizzbuzzmodel: start index must be positive");
        }

        string[] list = new string[max - start + 1];
        Array.Copy(fizzBuzzList, start, list, 0, max - start + 1);
        Task.Run(() => writeListToFile(list));

        CustomLogger.LogInformation("fizzbuzzmodel: retrieved list");

        return list;
    }

    public void writeListToFile(string[] list) {
        CustomLogger.LogInformation("fizzbuzzmodel: writing list to file (async)");

        lock (lk) {
            using (StreamWriter sw = File.AppendText(path)) {
                sw.WriteLineAsync(DateTime.Now.ToString());
                foreach (string s in list) {
                    sw.WriteLineAsync(s);
                }
                sw.Close();
            }
        }

        CustomLogger.LogInformation("fizzbuzzmodel: finished writing list to file");
    }
}
