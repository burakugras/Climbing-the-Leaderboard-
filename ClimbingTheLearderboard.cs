using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        List<int> trying = new List<int>();
        List<int> final = new List<int>();
        int[] res = new int[player.Count];
        if (ranked.Count == 0 || player[0] >= ranked[0])
        { 
            for (int i = 0; i < player.Count; ++i)
            {
                res[i] = 1;
            }
            for (int i = 0; i < res.Length; i++)
            {
                trying.Add(res[i]);
            }

            return trying;
        }
        int[] rankAry = new int[ranked.Count + 1];
        rankAry[1] = ranked[0]; 
        int curPos = 1; 
        int curRank = 2; 
        while (curPos < ranked.Count && ranked[curPos] > player[0])
        {
            if (ranked[curPos] < ranked[curPos - 1])
            {
                rankAry[curRank] = ranked[curPos]; 
                curRank++; 
            }
            curPos++; 
        }

        if (curPos == ranked.Count)
        { 
            rankAry[curRank] = player[0]; 
        }

        for (int i = 0; i < player.Count; ++i)
        {
            if (curRank == 1)
            { 
                res[i] = 1;
                continue;
            }

            
            while (player[i] >= rankAry[curRank - 1])
            {
                if (curRank == 1 || player[i] < rankAry[curRank - 1])
                {
                    break;
                }

                curRank--;
            }
            res[i] = curRank;
        }

        for (int i = 0; i < res.Length; i++)
        {
            final.Add(res[i]);
        }
        return final;

    }

}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();
        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());
        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();
        List<int> result = Result.climbingLeaderboard(ranked, player);
        textWriter.WriteLine(String.Join("\n", result));
        textWriter.Flush();
        textWriter.Close();
    }
}

