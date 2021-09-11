using System;
using System.Collections.Generic;

namespace basicC
{
    class Program { static void Main(string[] args) { new OptionalTest().Run(); } }
    class OptionalTest {
        public void Run() {
            while (true) {
                Console.WriteLine("\n-----------------------------");
                Console.WriteLine("  Lab Final 6 Optional Test");
                Console.WriteLine("1-A1");
                Console.WriteLine("2-A2");
                Console.WriteLine("3-A3");
                Console.WriteLine("4-A4");
                Console.WriteLine("5-A5");
                Console.WriteLine("6-A6");
                Console.WriteLine("7-Exit");
                Console.WriteLine("-----------------------------");
                Console.Write("menu :> ");
                int menu = int.Parse(Console.ReadLine());
                if (menu == 1) {
                    Console.WriteLine("\n");
                    RunA1();
                    Console.WriteLine("\n");
                } else if (menu == 2) {
                    Console.WriteLine("\n");
                    RunA2();
                    Console.WriteLine("\n");
                } else if (menu == 3) {
                    Console.WriteLine("\n");
                    RunA3();
                    Console.WriteLine("\n");
                } else if (menu == 4) {
                    Console.WriteLine("\n");
                    RunA4();
                    Console.WriteLine("\n");
                } else if (menu == 5) {
                    Console.WriteLine("\n");
                    RunA5();
                    Console.WriteLine("\n");
                } else if (menu == 6) {
                    Console.WriteLine("\n");
                    RunA6();
                    Console.WriteLine("\n");
                } else if (menu == 7) {
                    Console.WriteLine("Exit program.....\n");
                    break;
                } else {
                    Console.WriteLine("\n");
                }
            }
        }

        // --------------- A1 ---------------
        void RunA1() {
            while (true) {
                Console.WriteLine("  Menu");
                Console.WriteLine("1-line");
                Console.WriteLine("2-Rectangle");
                Console.WriteLine("3-Triangle");
                Console.WriteLine("4-exit prg");
                Console.WriteLine("----------");
                Console.Write("menu :> ");
                int menu = int.Parse(Console.ReadLine());
                if (menu == 1) {
                    Console.WriteLine("\n");

                    Console.Write("input length of line :> ");
                    int len = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Line(len);

                    Console.WriteLine("\n");
                } else if (menu == 2) {
                    Console.WriteLine("\n");

                    Console.Write("input length of line :> ");
                    int col = int.Parse(Console.ReadLine());
                    Console.Write("input number of line :> ");
                    int row = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Rectangle(col, row);

                    Console.WriteLine();
                } else if (menu == 3) {
                    Console.WriteLine("\n");

                    Console.Write("input width of line :> ");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Triangle(num);

                    Console.WriteLine("\n");
                } else if (menu == 4) {
                    Console.WriteLine("\n");
                    Console.WriteLine("Exit program.....\n");
                    break;
                } else {
                    Console.WriteLine("\n");
                }
            }
        }

        void Line(int len) {
            if(len > 0) {
                len--;
                Console.Write(len);
                Line(len);
            }
        }

        void Rectangle(int col, int row) {
            for (int i = 1; i <= row; i++) {
                for(int j = 1; j < col; j++) {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        void Triangle(int num) {
            for (int i = num ; i >= 1 ; i--) {
                for (int j = 1 ; j < i ; j++) {
                    Console.Write("*");
                }
                Console.Write(i);
                Console.WriteLine();
            }
        }

        // --------------- A2 ---------------
        void RunA2() {
            var data = InputDoubleArray();

            Console.Write("input data to search :> ");
            double searched = Double.Parse(Console.ReadLine());

            Console.WriteLine("\nindex");
            for (int i = 0, line = 0; i < data.Length; i++) {
                if (line == 0) {
                    Console.Write($"{i}\t");
                }

                if (i == data.Length-1 && line == 0) {
                    line = 1;
                    i = 0;
                    Console.WriteLine();
                }

                if (line == 1) {
                    Console.Write("{0:0.0###}\t", data[i]);
                }
                
            }
            Console.WriteLine();
            Console.WriteLine("\ndata\tsum");
            Console.Write("{0}\t{1}", searched, SumSearched(data, searched));
        }

        double SumSearched(double[] data, double searched)
        {
            double sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (searched == data[i])
                {
                    sum += data[i];
                }
            }
            return sum;
        }

        // --------------- A3 ---------------
        void RunA3() {
            var data = InputIntArray();
            int Max = data[0], Min = data[0];
            for (int i = 0; i < data.Length; i++) {
                if (Min > data[i]) {
                    Min = data[i];
                } else if (Max < data[i]) {
                    Max = data[i];
                }
            }

            Console.WriteLine("\nMax is {0}", Max);
            Console.WriteLine("Min is {0}", Min);
            Console.WriteLine("Diff is {0}", Math.Abs(Max - Min));
        }

        // --------------- A4 ---------------
        void RunA4() {
            int input;
            List<int> logs = new List<int>();
            while(true) {
                Console.Write("input data[{0}] :> ", logs.Count+1);
                input = int.Parse(Console.ReadLine());
                if (input >= 0 && input < 10) {
                    if (input == 0) {
                        break;
                    } else {
                        logs.Add(input);
                    }
                } else {
                    Console.WriteLine("please input [0-9]");
                }
            }
            Console.WriteLine("\ndata from villager :");
            foreach(var item in logs)
            {
                Console.Write("{0}\t",item.ToString());
            }

            Console.WriteLine("\nscore of each applycant :");
            int[] applycant_score = new int[10];
            for (int i = 0; i < logs.Count; i++) {
                applycant_score[logs[i]] += 1;
            }
            foreach(var item in applycant_score)
            {
                Console.Write("{0}\t",item.ToString());
            }
            int head_is = 0;
            int head_score = applycant_score[0];
            int ast_is = 0;
            int ast_score = applycant_score[0]; 
            for (int i = 0; i < applycant_score.Length; i++) {
                if (head_score < applycant_score[i]) {
                    head_is = i;
                    head_score = applycant_score[i];
                }
            }

            for (int i = 0; i < applycant_score.Length; i++) {
                if (ast_score < applycant_score[i] && applycant_score[i] < head_score) {
                    ast_is = i;
                    ast_score = applycant_score[i];
                }
            }

            Console.WriteLine("\nHead is number {0}\tvote_score is {1}", head_is, head_score);
            Console.WriteLine("Assistant is number {0}\tvote_score is {1}", ast_is, ast_score);
        }


        // --------------- A5 ---------------
        void RunA5() {
            Console.Write("how many number :> ");
            int len = int.Parse(Console.ReadLine());
            int[] data1 = new int[len];
            int[] data2 = new int[len];
            for (int i = 0; i < len; i++) {
                Console.Write("input data1[{0}] :> ", i+1);
                data1[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\n------------------------------");
            for (int i = 0; i < len; i++) {
                Console.Write("input data2[{0}] :> ", i+1);
                data2[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\n------------------------------");

            double[] result = new double[len]; 
            for (int i = 0; i < len; i++) {
                result[i] = Math.Pow(data1[i] - data2[i], 2);
                Console.WriteLine("data1[{0}] - data2[{1}] = {2}", data1[i], data2[i], result[i]);
            }

            Console.WriteLine("------------------------------\n");

            double sum = 0;
            for (int i = 0; i < len; i++) {
                sum += result[i];
            }
            Console.WriteLine("Sum of Diff-Square is {0}", sum);
        }

        // --------------- A6 ---------------
        void RunA6() {
            Console.Write("How many student :> ");
            int len = int.Parse(Console.ReadLine());
            int cP = 0;
            int cS = 0;
            int cU = 0;

            int cT = 0;
            int cA = 0;
            int cB = 0;
            int cC = 0;
            int cF = 0;
            for (int i = 0; i < len; i++) {
                Console.Write("Type of exam\t: ");
                string type = Console.ReadLine();
                Console.Write("Exam of score\t: ");
                double score = double.Parse(Console.ReadLine());
                string result = setResult(score, type);
                Console.Write("Exam of result\t: {0}\n", result);

                if (string.Equals(type, "p", StringComparison.OrdinalIgnoreCase)) {
                    if (result.Equals("S")) {
                        cP += 1;
                        cS += 1;
                    } else if (result.Equals("U")) {
                        cP += 1;
                        cU += 1;
                    }
                }

                if (string.Equals(type, "t", StringComparison.OrdinalIgnoreCase)) {
                    if (result.Equals("A")) {
                        cT += 1;
                        cA += 1;
                    } else if (result.Equals("B")) {
                        cT += 1;
                        cB += 1;
                    } else if (result.Equals("C")) {
                        cT += 1;
                        cC += 1;
                    } else if (result.Equals("F")) {
                        cT += 1;
                        cF += 1;
                    }
                }
            }
            Console.WriteLine("\nProposal {0} students", cP);
            Console.WriteLine("\tS = {0}, U = {1}", cS, cU);
            Console.WriteLine("Project {0} students", cT);
            Console.WriteLine("\tA = {0}, B = {1}, C = {2}, F = {3}", cA, cB, cC, cF);
        }

        string setResult(double score, string type) {
            string result = "NA";
            if (string.Equals(type, "p", StringComparison.OrdinalIgnoreCase)) {
                if (score < 60) {
                    result = "U";
                } else {
                    result = "S";
                }
            } else if (string.Equals(type, "t", StringComparison.OrdinalIgnoreCase)) {
                if (score < 50) {
                    result = "F";
                } else if (score >= 50 && score < 60) {
                    result = "C";
                } else if (score >= 60 && score < 80) {
                    result = "B";
                } else {
                    result = "A";
                }
            }
            return result;
        }

        // ------------- Tools --------------
        double[] InputDoubleArray() {
            Console.Write("how many number :> ");
            int len = int.Parse(Console.ReadLine());
            double[] data = new double[len];
            for (int i = 0; i < data.Length; i++) {
                Console.Write("input data[{0}] :> ", i+1);
                data[i] = Double.Parse(Console.ReadLine());
            }
            return data;
        }

        int[] InputIntArray() {
            Console.Write("how many number :> ");
            int len = int.Parse(Console.ReadLine());
            int[] data = new int[len];
            for (int i = 0; i < data.Length; i++) {
                Console.Write("input data[{0}] :> ", i+1);
                data[i] = int.Parse(Console.ReadLine());
            }
            return data;
        }
    }
}
