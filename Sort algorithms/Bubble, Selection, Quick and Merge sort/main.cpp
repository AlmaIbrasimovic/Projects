#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <time.h>

using namespace std;

template<typename Tip>
void bubble_sort (Tip *niz, int vel) {
    Tip temp;
    for (int i = 0; i<vel; i++) {
        for (int j = i + 1; j < vel; j++) {
            if (niz[j] < niz[i]) {
                temp = niz[i];
                niz[i] = niz[j];
                niz[j] = temp;
            }
        }
    }
}

template<typename Tip>
void selection_sort (Tip *niz, int vel) {
    for (int i = 0; i<vel-1; i++) {
        Tip temp = niz[i];
        int index = i;
        for (int j = i+1; j<vel; j++) {
            if (niz[j] < temp) {
                temp = niz[j];
                index = j;
            }
        }
        niz[index] = niz[i];
        niz[i] = temp;
    }
}
//Pomocna funkcija za quick_sort koja vraca poziciju pivota
template<typename Tip>
int Particije_quick_sorta (Tip *niz, const int prvi, const int zadnji) {
    Tip pivot = niz[prvi];
    int p = prvi + 1;
    while (p <= zadnji) {
        if (niz[p] <= pivot) p++;
        else break;
    }
    for (int i = p + 1; i<=zadnji; i++) {
        if (niz[i] < pivot) {
            Tip temp = niz[p];
            niz[p] = niz[i];
            niz[i] = temp;
            p++;
        }
    }
    Tip temp = niz[prvi];
    niz[prvi] = niz[p - 1];
    niz[p - 1] = temp;
    return p-1;
}
template<typename Tip>
void quick_sort (Tip *niz, int vel, int prvi = 0, int zadnji = 0, int put = 0) {
    if (put == 0) zadnji = vel - 1;
    if (prvi < zadnji) {
        int j = Particije_quick_sorta(niz, prvi, zadnji);
        quick_sort(niz, vel, prvi, j - 1, 1);
        quick_sort(niz, vel, j + 1, zadnji, 1);
    }
}
//Pomocna fja za merge_sorta koja kreira particije i na kraju ih spaja u jedan niz
template<typename Tip>
void pomocnaMergeSort (Tip *niz, int lijevi, int desni, int srednji) {
    int vel2 = desni - srednji;
    int vel1 = srednji - lijevi + 1;
    Tip *lijeva = new Tip [vel1];
    Tip *desna = new Tip [vel2];
    for (int i = 0; i<vel1; i++) lijeva[i] = niz[lijevi + i];
    for (int i = 0; i<vel2; i++) desna[i] = niz[srednji + 1 + i];
    
    int i = 0, j = 0, k = lijevi;
    while (i < vel1 && j < vel2) {
        if (lijeva[i] <= desna[j]) {
            niz[k] = lijeva[i];
            i++;
        }
        else {
            niz[k] = desna[j];
            j++;
        }
        k++;
    }
    while (i < vel1) {
        niz[k] = lijeva[i];
        i++; k++;
    }
    while (j < vel2) {
        niz[k] = desna[j];
        j++; k++;
    }
    delete[] lijeva;
    delete[] desna;
}
template<typename Tip>
void merge_sort (Tip *niz, int vel, int lijevi = 0, int desni = 0, int put = 0) {
   if (put == 0) desni = vel - 1;
   if (lijevi < desni) {
       int srednji = lijevi + (desni - lijevi) / 2;
       merge_sort (niz, vel, lijevi, srednji, 1);
       merge_sort (niz, vel, srednji + 1, desni, 1);
       pomocnaMergeSort(niz, lijevi, desni, srednji);
   }
}

//Fja za ucitavanje brojeva iz datoteke u niz
void ucitaj(string filename, int*& niz, int &vel) {
    ifstream datoteka(filename);
    if (!datoteka) throw "Datoteka nije ispravna ili ne postoji!\n";
    else {
        int broj;
        vel = 0;
        niz = new int[3000000];
        while (datoteka >> broj) 
            niz[vel++] = broj;
    }
    datoteka.close();
}
//Fja za generisanje i upisivanje random brojeva u datoteku
void generisi(string filename, int vel) {
    ofstream  izlazniTok (filename);
    if (!izlazniTok) throw "Nije OK!\n";
    for (int i = 0; i<vel; i++) {
        auto temp = rand() % 100;
        izlazniTok << temp << " ";
    }
    izlazniTok.close();
}

void Meni() {
    int *niz;
    cout << "Unesite broj elemenata niza: ";
    int vel;
    cin >> vel;
    generisi("dat.txt", vel);
    ucitaj("dat.txt", niz, vel);
    int izbor;
    cout << "Izaberite koji algoritam sortiranja zelite koristiti:\n";
    cout << "1. Bubble Sort\n2. Quick Sort\n3. Selection Sort\n4. Merge Sort\n5. Izlaz\n";
    cin >> izbor;
    clock_t vrijeme1, vrijeme2;
    switch(izbor) {
        case(1) : vrijeme1 = clock(); 
                  bubble_sort(niz, vel); 
                  vrijeme2 = clock();
                  break;
        case(2) : vrijeme1 = clock();
                  quick_sort(niz,vel); 
                  vrijeme2 = clock();
                  break;
        case(3) : vrijeme1 = clock();
                  selection_sort(niz,vel);
                  vrijeme2 = clock();
                  break;
        case(4) : vrijeme1 = clock();
                  merge_sort(niz,vel);
                  vrijeme2 = clock();
                  break;
        case(5) : cout <<"Dovidenja!\n"; break;
        default : cout << "Pogresan odabir!\n";
    }
    bool sortiran = true;
    for(int i(0); i<vel-1; i++) 
        if(niz[i] > niz[i+1]) {
            sortiran = false;
            break;
        }
    if (sortiran) cout << "Niz je sortiran!\n";
    ofstream izlazniTok ("sortiranNiz");
    if (!izlazniTok) throw "Kreiranje datoteke nije uspjelo";
    else {
         for (int i = 0; i < vel; i++) izlazniTok << niz[i] << " ";
    cout << "Sortirani niz je upisan u datoteku 'sortiranNiz'\n";
    }
    int ukupnoVrijeme = (vrijeme2 - vrijeme1) / (CLOCKS_PER_SEC / 1000);
    cout << "Vrijeme izvrsenja: " << ukupnoVrijeme << " ms." << endl;
}
int main() {
    Meni();
    return 0;
}
