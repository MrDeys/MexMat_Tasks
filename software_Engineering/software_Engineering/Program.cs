using System;

class Program
{
    static int[,] distances = {
        { 0, 10, 15, 20 },
        { 10, 0, 35, 25 },
        { 15, 35, 0, 30 },
        { 20, 25, 30, 0 }
    };

    static int[] path;
    static bool[] visited;
    static int n;
    static int minDistance;

    static void Main(string[] args)
    {
        n = distances.GetLength(0);
        path = new int[n];
        visited = new bool[n];
        minDistance = int.MaxValue;

        path[0] = 0;
        visited[0] = true;
        TravelingSalesman(1, 0, 0);

        Console.WriteLine("Минимальное расстояние: " + minDistance);
    }

    static void TravelingSalesman(int count, int currentCity, int currentDistance)
    {
        if (count == n)
        {
            int distance = currentDistance + distances[currentCity, 0];
            if (distance < minDistance)
            {
                minDistance = distance;
            }
            return;
        }

        for (int i = 1; i < n; i++)
        {
            if (!visited[i])
            {
                path[count] = i;
                visited[i] = true;
                int distance = currentDistance + distances[currentCity, i];
                if (distance < minDistance)
                {
                    TravelingSalesman(count + 1, i, distance);
                }
                visited[i] = false;
            }
        }
    }
}