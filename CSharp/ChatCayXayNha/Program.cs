﻿/*

[Sắp Xếp - Tìm Kiếm] - Chặt cây xây nhà
Bob là một thợ mộc tài hoa. Hiện tại anh đang có kế hoạch xây dựng một căn nhà toàn bộ bằng gỗ.
Biệt thự được xây bởi các khúc gỗ khác nhau và tổng độ dài của các thanh gỗ là L.

Để lấy các khúc gỗ đó, anh ấy cần vào rừng và chặt cây.
Khu rừng gần chỗ anh có N cây với độ cao khác nhau.
Bob sẽ dùng một cái máy cưa đặc biệt, nó có thể cắt một lượt qua tất cả các cây.

Đầu tiên, anh ấy sẽ chọn một độ cao cố định là H, sau đó dùng máy cưa đặc biệt
để cắt một đường theo độ cao H này trên các cây có độ cao lớn H.

Ví dụ : các cây có độ cao lần lượt là: 10,16,17,15. Chọn H bằng 15.
Do đó, cây thứ 2,3 sẽ được cắt và tổng độ dài các khúc gỗ thu được là 1+2=3.
Cho độ cao của các cây trong rừng và giá trị L. (Tổng độ dài của các khúc gỗ cần).

Hãy giúp Bob tìm giá trị lớn nhất của H thỏa mãn rằng Bob chỉ cần
dùng máy cắt đúng một lượtđể thu được số các khúc gỗ cần thiết.

Chú ý : Tổng độ dài các khúc gỗ có thỏa mãn có thể lớn hơn L (hay nói cách khác L ≤ tổng độ dài).

Đầu vào
Dòng đầu tiên chứa một số nguyên mô tả số lượng cây N (1≤N≤10^6)
và L là tổng độ dài của các khúc gỗ cần dùng (1≤L≤2∗10^9

Dòng tiếp theo chứa N số tự nhiên h[i] là độ cao tương ứng của các cây (h[i]<10^9).
Tổng độ cao của các cây lớn hơn hoặc bằng L.

Giới hạn
N/A

Đầu ra
Một số nguyên duy nhất: giá trị độ cao lớn nhất mà tại đó Bob cắt đúng một đường đề thu được các khúc gỗ thỏa mãn.

Ví dụ :
Input 01
3 6
1 2 3
Output 01
0

*/

using System;

int.TryParse(Console.ReadLine(), out int N);
long.TryParse(Console.ReadLine(), out long L);

string[] arr = Console.ReadLine().Split(' ');
long[] trees = Array.ConvertAll(arr, str => long.Parse(str));