#include <iostream>
#include <math.h>
#include <vector>

using namespace std;

void sapXepMang(vector<int> &dayso)
{
    int n = dayso.size(), temp;
    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (dayso.at(i) > dayso.at(j))
            {
                temp = dayso.at(i);
                dayso.at(i) = dayso.at(j);
                dayso.at(j) = temp;
            }
        }
    }
}

int main()
{
    vector<int> dayso;
    int myint;
    float result;
    cout << "Nhap -1 de ket thuc:"
         << "\n";

    do
    {
        cin >> myint;
        if (myint != -1)
        {
            dayso.push_back(myint);
        }
    } while (myint != -1);
    sapXepMang(dayso);

    int sizeOfDaySo = dayso.size();
    if (sizeOfDaySo % 2 == 0)
    {
        int v1 = (sizeOfDaySo / 2);
        int v2 = v1 + 1;

        result = (float)(dayso.at(v1 - 1)) + (float)(dayso.at(v2 - 1));
        result = result / 2;
    }
    else
    {
        int v3 = (sizeOfDaySo + 1) / 2;

        result = dayso.at(v3 - 1);
    }

    cout << "so dong vi la " << result << "\n";

    return 0;
}
