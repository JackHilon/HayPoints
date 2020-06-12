using System;
using System.Collections.Generic;
using System.Linq;

namespace HayPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hay Points problem: 
            // https://open.kattis.com/problems/haypoints

            // calculate text value based on HayPoints (words) values

            // --> solved but I get: Time Limit Exceeded !!!! in kattis.com


            var str = Console.ReadLine();
            var strArr = str.Split(' ',2);
            var NumOfHayPoints = int.Parse(strArr[0]);
            var NumOfJobDescriptions = int.Parse(strArr[1]);


            List<object[]> HayPoints = EnterAllHayPoints(NumOfHayPoints);

            List<List<string>> Descriptions = EnterAllDescriptions(NumOfJobDescriptions);

            PrintList(DescriptionsValuesList(Descriptions, HayPoints));

        } // === end Main ===

        private static List<int> DescriptionsValuesList(List<List<string>> Descriptions, List<object[]> HayPoints)
        {
            List<int> Answers = new List<int>();
            int res;
            for (int q = 0; q < Descriptions.Count; q++)
            {
                //var Des = Descriptions[0]; // List<object[]> HayPoints
                res = 0;
                for (int i = 0; i < HayPoints.Count; i++)
                {
                    res = res + HayPointValueSum(Descriptions[q], (string)HayPoints[i][0], (int)HayPoints[i][1]);
                }
                Answers.Add(res);
            }
            return Answers;
        }

        private static List<List<string>> EnterAllDescriptions(int desCount)
        {
            List<List<string>> descriptions = new List<List<string>>();
            for (int i = 0; i < desCount; i++)
            {
                descriptions.Add(EnterJobDescription());
            }
            return descriptions;
        }


        private static List<object[]> EnterAllHayPoints(int pointsCount)
        {
            List<object[]> points = new List<object[]>();
            for (int i = 0; i < pointsCount; i++)
            {
                points.Add(EnterHayPoint());
            }
            return points;
        }

        private static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        private static int HayPointValueSum(List<string> list, string hay, int hayValue)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == hay)
                    sum = sum + hayValue;
            }
            return sum;
        }

        private static List<string> EnterJobDescription()
        {
            List<string> des = new List<string>();
            List<string> desLine = new List<string>();
            string[] strArr;

            while (true)
            {
                var str = Console.ReadLine();
                if (str == ".")
                    return des;
                else
                {
                    strArr = str.Split(' ');
                    desLine = strArr.ToList();
                    des.AddRange(desLine);
                }
            }
        }
        private static object[] EnterHayPoint()
        {
            var str = " ";
            
            string[] strArr = { " ", " " };
            object[] result = new object[2] { " ", 0 };
            str = Console.ReadLine();
            try
            {
                strArr = str.Split(' ', 2);
                result[0] = strArr[0];
                result[1] = int.Parse(strArr[1]);
                int a = (int) result[1];
                if (a < 0 || a > 1000000)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
                return EnterHayPoint();
            }
            return result;
        }
    }
}
