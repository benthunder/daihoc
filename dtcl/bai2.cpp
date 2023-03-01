#include <iostream>
#include <math.h>
#include <vector>

using namespace std;
int giaiThua(int n)
{

    int gt = 1;
    for (int i = 1; i <= n; i++)
    {
        gt *= i;
    }

    return gt;
}

int main()
{
    int n, k, result;
    cout << "Nhap n: ";
    cin >> n;

    cout << "Nhap k: ";
    cin >> k;

    result = giaiThua(n) / (giaiThua(k) * giaiThua(n - k));

    cout << "Ket qua : " << result;
}
