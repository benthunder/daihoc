#include <iostream>
#include <math.h>
#include <vector>

using namespace std;

struct Complex
{
    float thuc;
    float ao;
};

struct Complex tongSoPhuc(Complex c1, Complex c2)
{
    struct Complex c3;

    c3.thuc = c1.thuc + c2.thuc;
    c3.ao = c1.ao + c2.ao;

    return c3;
}

int main()
{
    struct Complex c1, c2, c3;

    cout << "Nhap phan thuc so phuc 1: ";
    cin >> c1.thuc;

    cout << "Nhap phan ao so phuc 1: ";
    cin >> c1.ao;

    cout << "Nhap phan thuc so phuc 2: ";
    cin >> c2.thuc;

    cout << "Nhap phan ao so phuc 2: ";
    cin >> c2.ao;

    c3 = tongSoPhuc(c1, c2);

    cout << "Gia tri 2 so phuc = : " << c3.thuc << " + " << c3.ao << "i";
}