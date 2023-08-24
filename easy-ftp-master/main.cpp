#include <iostream>
#include "index.h"

using namespace std;

int main()
{
    system("mode con: cols=120 lines=500");
    system("color 1f");

    Index *index = new Index;
    index->appStart();

    return 0;
}
