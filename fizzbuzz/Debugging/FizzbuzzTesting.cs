﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class FizzbuzzTesting {

    private static IConfiguration _config = null;
    private static int max = 0;

    public static void Init(IConfiguration config) {
        _config = config;
        max = config.GetValue<int>("EndNumber"); 
    }

    public static void IntegrationTest() {
        CustomLogger.LogInformation("Testing: Beggining integration test");
        TestFromOne();
        TestFromNegative();
        TestFromOver();
        TestAsync();
        CustomLogger.LogInformation("Testing: Integration test finished, see log for results");
    }

    public static void TestFromOne() {
        CustomLogger.LogDebug("Testing: TestFromOne()");
        FizzBuzzModel fbm = new FizzBuzzModel(_config);

        try {
            fbm.getList(1);
            CustomLogger.LogDebug("Testing: TestFromOne() successful");
        } catch (CustomException e) {
            CustomLogger.LogError("Testing: TestFromOne() unsuccessful: " + e.Message);
        }
    }

    public static void TestFromNegative() {
        CustomLogger.LogDebug("Testing: TestFromNegative()");
        FizzBuzzModel fbm = new FizzBuzzModel(_config);

        try {
            fbm.getList(-1);
            CustomLogger.LogDebug("Testing: TestFromNegative() unsuccessful, no exceptions found");
        } catch (CustomException e) {
            CustomLogger.LogError("Testing: TestFromNegative() successful: " + e.Message);
        }
    }

    public static void TestFromOver() {
        CustomLogger.LogDebug("Testing: TestFromOver()");
        FizzBuzzModel fbm = new FizzBuzzModel(_config);

        try {
            fbm.getList(max + 1);
            CustomLogger.LogDebug("Testing: TestFromOver() unsuccessful, no exceptions found");
        } catch (CustomException e) {
            CustomLogger.LogError("Testing: TestFromOver() successful: " + e.Message);
        }
    }
    public static void TestAsync() {
        CustomLogger.LogDebug("Testing: TestAsync()");
        FizzBuzzModel fbm = new FizzBuzzModel(_config);

        Task[] tasks = new Task[max - 1];

        try {
            for (int i = 1; i < max; i++) {
                tasks[i-1] = Task.Run(() => fbm.getList(i));
            }

            foreach (Task t in tasks) {
                t.Wait();
            }

            CustomLogger.LogDebug("Testing: TestAsync successful");
        } catch (Exception e) {
            CustomLogger.LogError("Testing: TestAsync() unsuccessful: " + e.Message);
        }
    }
}

