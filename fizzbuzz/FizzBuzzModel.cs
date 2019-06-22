using System;
using Microsoft.Extensions.Configuration;

public class FizzBuzzModel {

    private string[] fizzBuzzList;
    private int max;

    public FizzBuzzModel(IConfiguration config) {
        max = config.GetValue<int>("EndNumber");
        createList();
	}

    private void createList() {
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
    }

    public string[] getList(int start) {
        string[] list = new string[max - start + 1];
        Array.Copy(fizzBuzzList, start, list, 0, max - start + 1);
        return list;
    }
}
