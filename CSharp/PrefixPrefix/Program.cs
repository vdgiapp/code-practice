/*

[Mảng Cộng Dồn - Mảng Hiệu] - Prefix prefix

Cho mảng A[] có N phần tử và M thao tác, mỗi thao tác
yêu cầu bạn tăng các phần tử ở vị trí L tới R của mảng lên D đơn vị (1<=L<=R<=N).
Các thao tác này được đánh số từ 1 đến M, ngoài ra Tèo lại muốn thực hiện K truy vấn,
mỗi truy vấn Tèo lại thực hiện các thao tác từ x tới y theo số thứ tự thao tác (1<=x<=y<=M).
Bạn hãy giúp Tèo in ra mảng A[] sau K truy vấn

Đầu vào
• Dòng 1 là N, M, K

• Dòng 2 là N số trong mảng A[]

• M dòng tiếp theo mỗi dòng gồm 3 số L, R, D

• K dòng tiếp theo mỗi dòng gồm 2 số x, y

Giới hạn
• 1<=N,M,K<=10^5

• 0<=A[i]<=10^5

• 1<=L,R<=N, 0<=D<=10^5

• 1<=x,y<=M

Đầu ra
In ra mảng sau khi thực hiện xong các truy vấn

Ví dụ :
Input 01
6 5 2
1 7 5 2 8 7
2 6 5
1 5 1
1 6 1
2 6 4
2 5 4
2 5
2 4
Output 01
5 23 21 18 24 17
Giải thích :
Truy vấn 1 : 2 5 tức là sẽ thực hiện các thao tác từ thứ 2 tới 5 mỗi thao tác 1 lần

Thực hiện thao tác 2 : 1 5 1 mảng A[] = [2 8 6 3 9 7]

Thực hiện thao tác 3 : 1 6 1 mảng A[] = [3 9 7 4 10 8]

Thực hiện thao tác 4 : 2 6 4 mảng A[] = [3 13 11 8 14 12]

Thực hiện thao tác 5 : 2 5 4 mảng A[] = [3 17 15 12 18 12]

Truy vấn 2 : 2 4 tức là sẽ thực hiện các thao tác từ thứ 2 tới 4 mỗi thao tác 1 lần

Thực hiện thao tác 2 : 1 5 1 mảng A[] = [4 18 16 13 19 12]

Thực hiện thao tác 3 : 1 6 1 mảng A[] = [5 19 17 14 20 13]

Thực hiện thao tác 4 : 2 6 4 mảng A[] = [5 23 21 18 24 17]

*/

using System;

// Input dong 1  1<=N,M,K<=10^5
string[] input1 = Console.ReadLine().Split(' ');
ushort N = ushort.Parse(input1[0]);
ushort M = ushort.Parse(input1[1]);
ushort K = ushort.Parse(input1[2]);

// Input dong 2
string[] input2 = Console.ReadLine().Split(' ');
ushort[] A = Array.ConvertAll(input2, ushort.Parse);

// Input M dong tiep theo - Nhap thao tac
int[,] operations = new int[M+1, 3]; // mang 2 chieu voi M+1 cot, 3 hang
for (int i = 1; i <= M; i++)
{
    string[] line = Console.ReadLine().Split(' ');
    operations[i, 0] = int.Parse(line[0]); // L
    operations[i, 1] = int.Parse(line[1]); // R
    operations[i, 2] = int.Parse(line[2]); // D
}

// Input K dong tiep theo - Nhap truy van
int[,] queries = new int[K+1, 2];
for (int i = 1; i <= K; i++)
{
    string[] line = Console.ReadLine().Split(' ');
    queries[i, 0] = int.Parse(line[0]); // x
    queries[i, 1] = int.Parse(line[1]); // y
}

// Xu ly truy van
ushort[] operation_count = new ushort[M + 2];
for (int i = 1; i <= K; i++)
{
    int x = queries[i, 0];
    int y = queries[i, 1];
    operation_count[x]++;
    if (y + 1 <= M) operation_count[y + 1]--;
}
for (int i = 1; i <= M; i++) operation_count[i] += operation_count[i - 1];

// Ap dung cac thao tac
ushort[] diff = new ushort[N + 2];
for (int i = 1; i <= M; i++)
{
    int L = operations[i, 0];
    int R = operations[i, 1];
    int D = operations[i, 2];
    long times = operation_count[i];

    diff[L] += (ushort)(D * times);
    if (R + 1 <= N) diff[R + 1] -= (ushort)(D * times);
}

// Cong don mang hieu
for (int i = 1; i <= N; i++)
{
    diff[i] += diff[i - 1];
    A[i - 1] += diff[i];
}

Console.WriteLine(string.Join(" ", A));

// for (int i = 1; i <= K; i++)
// {
//     int x = queries[i, 0];
//     int y = queries[i, 1];

//     for (int u = x; u <= y; u++)
//     {
//         int L = operations[u, 0];
//         int R = operations[u, 1];
//         int D = operations[u, 2];

//         for (int j = L; j <= R; j++)
//         {
//             A[j] += (ushort)D;
//         }
//     }
// }