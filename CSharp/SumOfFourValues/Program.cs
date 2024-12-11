/*

[Hai Con Trỏ] - Sum of four values

Cho mảng A[] gồm N phần tử và số nguyên K, hãy kiểm tra xem trong mảng
có 4 phần tử A[i], A[j], A[k], A[l] với i, j, k, l khác nhau
và A[i] + A[j] + A[k] + A[l] = K hay không ?

Đầu vào
• Dòng đầu tiên là N và K

• Dòng thứ 2 là N số trong mảng A[]

Giới hạn
• 1<=N<=1000

• 1<=A[i],K<=10^9

Đầu ra
In ra YES nếu tồn tại, ngược lại in ra NO

Ví dụ :
Input 01
6 28
3 6 7 9 1 6
Output 01
YES

*/

using System;

// Input dong 1
string[] input1 = Console.ReadLine().Split(' ');
short N = short.Parse(input1[0]);
uint K = uint.Parse(input1[1]);

// Input dong 2
string[] input2 = Console.ReadLine().Split(' ');
uint[] A = Array.ConvertAll(input2, uint.Parse);

// Luu cap chi so
Dictionary<uint, List<(int, int)>> sumPairs = new();

// Them vao dict
for (int i = 0; i < N; i++)
{
    for (int j = i + 1; j < N; j++)
    {
        uint sum = A[i] + A[j];
        if (!sumPairs.ContainsKey(sum)) sumPairs[sum] = new();
        sumPairs[sum].Add((i, j));
    }
}

// Kiem tra ton tai
for (int k = 0; k < N; k++)
{
    for (int l = k + 1; l < N; l++)
    {
        uint target = K - (A[k] + A[l]);
        if (sumPairs.ContainsKey(target))
        {
            foreach (var pair in sumPairs[target])
            {
                int i = pair.Item1;
                int j = pair.Item2;

                if (i != k && i != l && j != k && j != l)
                {
                    Console.WriteLine("YES");
                    return;
                }
            }
        }
    }
}
Console.WriteLine("NO");