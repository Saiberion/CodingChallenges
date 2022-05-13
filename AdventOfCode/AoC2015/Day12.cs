using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;

namespace AoC2015
{
    public class Day12 : Day
    {
        int SumUpObject(Dictionary<string, object> obj, bool skipRed)
        {
            int sum = 0;

            if (skipRed && obj.ContainsValue("red"))
            {
                return 0;
            }

            foreach (KeyValuePair<string, object> kvp in obj)
            {
                if (kvp.Value is Dictionary<string, object>)
                {
                    sum += SumUpObject(kvp.Value as Dictionary<string, object>, skipRed);
                }
                else if (kvp.Value is object[])
                {
                    sum += SumUpArray(kvp.Value as object[], skipRed);
                }
                else if (kvp.Value is int i)
                {
                    sum += i;
                }
            }

            return sum;
        }

        int SumUpArray(object[] arr, bool skipRed)
        {
            int sum = 0;

            foreach(object o in arr)
            {
                if (o is Dictionary<string, object>)
                {
                    sum += SumUpObject(o as Dictionary<string, object>, skipRed);
                }
                else if (o is object[])
                {
                    sum += SumUpArray(o as object[], skipRed);
                }
                else if (o is int i)
                {
                    sum += i;
                }
            }

            return sum;
        }

        override public void Solve()
        {
            int sum = 0;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            object jsonInput = serializer.DeserializeObject(Input[0]);

            if (jsonInput is Dictionary<string, object>)
            {
                sum += SumUpObject(jsonInput as Dictionary<string, object>, false);
            }
            else if (jsonInput is object[])
            {
                sum += SumUpArray(jsonInput as object[], false);
            }
            Part1Solution = sum.ToString();

            sum = 0;
            if (jsonInput is Dictionary<string, object>)
            {
                sum += SumUpObject(jsonInput as Dictionary<string, object>, true);
            }
            else if (jsonInput is object[])
            {
                sum += SumUpArray(jsonInput as object[], true);
            }
            Part2Solution = sum.ToString();
        }
    }
}
