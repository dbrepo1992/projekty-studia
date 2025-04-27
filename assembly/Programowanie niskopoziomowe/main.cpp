#ifdef _DEBUG
#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>
#endif
#include <iostream>
#include <ctime>
#include "utils.h"
#include "lab04.h"
using namespace std;

short asm04_01_short(short* a, uint n) {
    short y = 0;
    __asm {
        mov ebx, a;// ebx <- base address of vector a
        xor ax, ax;// ax <- sum = 0
        mov ecx, n;// ecx <- n (size of the loop)
    _loop:
        add ax, word ptr[ebx + 2 * ecx - 2];// ax <- sum += a[i]
        dec ecx;// ecx <- i--
        jnz _loop;// while (i != 0)
        mov y, ax;// save result in memory
    }
    return y;
}

int asm04_04_int(int* a, uint n) {
    int y = 0;
    __asm {
        mov ebx, a;// ebx <- base address of vector a
        mov ecx, n;// ecx <- size of vector a
        mov eax, dword ptr[ebx];// eax <- max = a[0];
    _loop:
        cmp eax, dword ptr[ebx + 4 * ecx - 4];// compare max to a[i]
        jge _skip;// if (max >= a[i]) go to _skip
        mov eax, dword ptr[ebx + 4 * ecx - 4];// eax <- max = a[i]
    _skip:
        dec ecx;// i--
        jnz _loop;// while (i != 0)
        mov y, eax;// store result in memory
    }
    return y;
}

short asm04_12_short(short* a, uint n) {
    short y = 0;
    __asm {
        xor di, di;// di <- sum = 0
        mov esi, a;// esi <- base address of vector a
        mov ecx, n;// ecx <- size of vector a
        mov bx, 8;// bx <- 8
    _loop:
        mov ax, word ptr[esi + 2 * ecx - 2];// ax <- a[i]
        cwd;// dx:ax <- sign extent of ax
        idiv bx;// ax <- a[i] / 8; dx <- a[i] % 8
        cmp dx, 0;// compare dx to 0
        jne _skip;// skip if dx != 0 (a[i] is not divisible by 0)
        inc di;// di <- sum++
    _skip:
        dec ecx;// ecx <- i--
        jnz _loop;// while (i != 0)
        mov y, di;// store result in memory
    }
    return y;
}

int main() {
#ifdef _DEBUG
    _CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
#endif
    srand((uint)time(0));

    {
        uint n = 10;
        short* a = newFillPtr<short>(n);
        printPtr(a, n);
        short yAsm = asm04_01_short(a, n);
        short yCpp = cpp04_01<short>(a, n);
        resultComparator(yCpp, yAsm);
        freePtr(a);
    }
    {
        uint n = 10;
        int* a = newFillPtr<int>(n);
        printPtr(a, n);
        int yAsm = asm04_04_int(a, n);
        int yCpp = cpp04_04<int>(a, n);
        resultComparator(yCpp, yAsm);
        freePtr(a);
    }

    {
        uint n = 10;
        short* a = newFillPtr<short>(n);
        printPtr(a, n);
        short yAsm = asm04_12_short(a, n);
        short yCpp = cpp04_12<short>(a, n);
        resultComparator(yCpp, yAsm);
        freePtr(a);
    }

    system("pause");
    return 0;
}