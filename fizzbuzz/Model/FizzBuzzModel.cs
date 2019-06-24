﻿using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

public class FizzBuzzModel {

    private string[] fizzBuzzList;
    private int max;

    private string path;

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

        using (StreamWriter sw = File.AppendText(path)) {
            sw.WriteLine(DateTime.Now.ToString());
            foreach (string s in list) {
                sw.WriteLine(s);
            }
            sw.Close();
        }
        
        CustomLogger.LogInformation("fizzbuzzmodel: retrieved list");

        return list;
    }
}