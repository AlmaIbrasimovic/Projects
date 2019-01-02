#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

void maxElement (vector<int> a, int &max) {
    max = a[0];
    for (int i = 0; i < a.size(); i++) {
        if (a[i] > max) max = a[i];
    }
}

//Pomocna funkcija za radix sort
void pomocnaRadix (vector<int> &a, int n) {
    int cifre[10] = {0};
    vector<int> izlaz;
    izlaz.resize(a.size());
    for (int i = 0; i<a.size(); i++) {
        auto exp = (a[i] / n) % 10;
        cifre[exp]++;
    }
    for (int i = 1; i<10; i++) cifre[i] += cifre[i-1];
    for (int i = a.size() - 1; i >= 0; i--) {
        auto exp = (a[i] / n) % 10;
        izlaz[cifre[exp] - 1] = a[i];
        cifre[exp]--;
    }
    a = izlaz;
}

void radixSort (vector<int> &a) {
    int max = 0;
    maxElement(a, max);
    for (int i = 1; max/i > 0; i *= 10) pomocnaRadix(a, i);
}

//Pomocna funkcijja za Heap sort
void pomocnaHeapSort (vector<int> &a, int n, int i) {
    int najveci = i;
    int lijevi = 2*i + 1;
    int desni = 2*i + 2;
    if (lijevi < n && a[lijevi] > a[najveci]) najveci = lijevi;
    if (desni < n && a[desni] > a[najveci]) najveci = desni;
    if (najveci != i) {
        swap(a[i], a[najveci]);
        pomocnaHeapSort(a, n, najveci);
    }
}

void stvoriGomilu (vector<int> &a) {
    for (int i = (a.size() / 2) - 1; i >= 0; i--) {
       pomocnaHeapSort(a, a.size(), i);
    }
}

void gomilaSort(vector<int> &a) {
    stvoriGomilu(a);
    for (int i = a.size() - 1; i>=0; i--) {
        swap(a[0], a[i]);
        pomocnaHeapSort(a, i, 0);
    }
}

int izbaciPrvi(vector<int> &a, int &velicina) {
    if (velicina == 0) throw "Gomila je prazna!";
    velicina--;
    swap(a[0], a[velicina]);
    if (velicina != 0) pomocnaHeapSort(a, velicina, 0);
    return a[velicina];
}

void umetniUGomilu(vector<int> &a, int umetnuti, int &velicina) {
    a.resize(a.size() + 1);
    a[velicina++] = umetnuti;
    int i = velicina - 1;
    while (i != 0 && a[i] > a[(i-1)/2]) {
        swap(a[i], a[(i - 1) / 2]);
        i = (i - 1) / 2; 
    }
}
int main() {
  
    return 0;
}
