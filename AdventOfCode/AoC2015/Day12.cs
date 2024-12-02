using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AdventOfCode.AoC2015
{
    public class Day12 : AoCDay
    {
        int SumUpObject(JsonElement obj, bool skipRed)
        {
            int sum = 0;

            foreach (JsonProperty jp in obj.EnumerateObject())
            {
                if (jp.Value.ValueKind == JsonValueKind.Object)
                {
                    sum += SumUpObject(jp.Value, skipRed);
                }
                else if (jp.Value.ValueKind == JsonValueKind.Array)
                {
                    sum += SumUpArray(jp.Value, skipRed);
                }
                else if (jp.Value.ValueKind == JsonValueKind.Number)
                {
                    sum += jp.Value.GetInt32();
                }
                else if (skipRed && (jp.Value.ValueKind == JsonValueKind.String))
                {
                    if (jp.Value.GetString().Equals("red"))
                    {
                        return 0;
                    }
                }
            }

            return sum;
        }

        int SumUpArray(JsonElement arr, bool skipRed)
        {
            int sum = 0;

            for (int i = 0; i < arr.GetArrayLength(); i++)
            {
                if (arr[i].ValueKind == JsonValueKind.Object)
                {
                    sum += SumUpObject(arr[i], skipRed);
                }
                else if (arr[i].ValueKind == JsonValueKind.Array)
                {
                    sum += SumUpArray(arr[i], skipRed);
                }
                else if (arr[i].ValueKind == JsonValueKind.Number)
                {
                    sum += arr[i].GetInt32();
                }
            }

            return sum;
        }

        override public void Solve()
        {
            int sum = 0;
            JsonElement jsonInput = JsonSerializer.Deserialize<dynamic>(Input[0]);

            if (jsonInput.ValueKind == JsonValueKind.Object)
            {
                sum += SumUpObject(jsonInput, false);
            }
            else if (jsonInput.ValueKind == JsonValueKind.Array)
            {
                sum += SumUpArray(jsonInput, false);
            }
            Part1Solution = sum.ToString();

            sum = 0;
            if (jsonInput.ValueKind == JsonValueKind.Object)
            {
                sum += SumUpObject(jsonInput, true);
            }
            else if (jsonInput.ValueKind == JsonValueKind.Array)
            {
                sum += SumUpArray(jsonInput, true);
            }
            Part2Solution = sum.ToString();
        }
    }
}
