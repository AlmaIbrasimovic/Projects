#include <iostream>

using namespace std;

template<typename Tip>
class Iterator;

template<typename Tip> 
class Lista {
    public:
        Lista() {}; //konst. bez para
        virtual int brojElemenata() const = 0;
        virtual Tip &trenutni() const = 0;
        virtual bool prethodni() = 0;
        virtual bool sljedeci() = 0;
        virtual void pocetak() = 0;
        virtual void kraj() = 0;
        virtual void obrisi() = 0;
        virtual void dodajIspred (const Tip &el) = 0;
        virtual void dodajIza (const Tip &el) = 0;
        virtual Tip &operator[] (int n) = 0;
        virtual Tip operator[] (int n) const = 0; //konst varijanta
        virtual ~Lista() = default;
        friend class Iterator<Tip>;
};
template<typename Tip>
class DvostrukaLista : public Lista<Tip> {
    private:
        struct Cvor {
            Tip element;
            Cvor *prethodni;
            Cvor *sljedeci;
            Cvor (const Tip &el, Cvor *pre, Cvor *slj) : element(el), prethodni(pre), sljedeci(slj) {}
            Cvor (Cvor *pre = 0, Cvor *slj = 0) : prethodni(pre), sljedeci(slj) {}
        };
        Cvor *pocetakListe;
        Cvor *krajListe;
        Cvor *tekuciElement;
        int  dDuzina, lDuzina;
    public:
        DvostrukaLista () : dDuzina(0), lDuzina(0) {
            tekuciElement = pocetakListe = new Cvor (0, 0);
            krajListe = new Cvor (pocetakListe, 0);
            pocetakListe->sljedeci = krajListe;
        }
        DvostrukaLista(const DvostrukaLista &l); //
        DvostrukaLista(DvostrukaLista &&L); //
        DvostrukaLista &operator= (const DvostrukaLista &L); 
        DvostrukaLista &operator= (DvostrukaLista &&L);
        ~DvostrukaLista() { 
            while (pocetakListe != 0) {
                tekuciElement = pocetakListe;
                pocetakListe = pocetakListe->sljedeci;
                delete tekuciElement;
            }
            krajListe = 0; tekuciElement = 0;
        }
        int brojElemenata() const { return dDuzina + lDuzina; }
        Tip &trenutni() const override {
            if (lDuzina + dDuzina == 0) throw ("Lista je prazna!\n");
            return tekuciElement->sljedeci->element;
        }
        Tip &trenutni() {
            if (lDuzina + dDuzina == 0) throw ("Lista je prazna!\n");
            return tekuciElement->sljedeci->element;
        }
        bool prethodni() override;//
        bool sljedeci() override;//
        void pocetak() override;//
        void kraj() override;//
        void obrisi() override;//
        void dodajIspred (const Tip &el) override; //
        void dodajIza (const Tip &el) override;//
        Tip operator[] (int i) const override; //
        Tip &operator[] (int i) override; //
        friend class Iterator<Tip>;
};
template<typename Tip>
DvostrukaLista<Tip>::DvostrukaLista (DvostrukaLista &&L) {
    pocetakListe = L.pocetakListe;
    krajListe = L.krajListe;
    tekuciElement = L.tekuciElement;
    dDuzina = L.dDuzina;
    lDuzina = L.lDuzina;
    L.pocetakListe = L.krajListe = L.tekuciElement = nullptr;
    L.dDuzina = L.lDuzina = 0;
}
template<typename Tip>
DvostrukaLista<Tip>::DvostrukaLista (const DvostrukaLista &l) {
    lDuzina = l.lDuzina;
    dDuzina = l.dDuzina;
    tekuciElement = pocetakListe = krajListe = new Cvor (nullptr, nullptr);
    if (l.brojElemenata() != 0) {
        Cvor *staro = l.pocetakListe;
        Cvor *novo = pocetakListe;
        while (staro != l.krajListe->prethodni) {
            novo->sljedeci = new Cvor (staro->sljedeci->element, novo, nullptr);
            if (l.tekuciElement == staro) tekuciElement = novo;
            staro = staro->sljedeci;
            novo = novo->sljedeci;
        }
        krajListe = new Cvor (novo, nullptr);
        novo->sljedeci = krajListe;
    }
}
template<typename Tip>
DvostrukaLista<Tip> &DvostrukaLista<Tip>::operator= (const DvostrukaLista &l) {
    if (this == &l) return *this;
    while (pocetakListe != nullptr) {
        tekuciElement = pocetakListe;
        pocetakListe = pocetakListe->sljedeci;
        delete tekuciElement;
    }
    krajListe = nullptr; tekuciElement = nullptr;
    tekuciElement = pocetakListe = new Cvor (nullptr, nullptr);
    if (l.brojElemenata() != 0) {
        Cvor *staro = l.pocetakListe;
        Cvor *novo = pocetakListe;
        while (staro != l.krajListe->prethodni) {
            novo->sljedeci = new Cvor (staro->sljedeci->element, novo, nullptr);
            if (l.tekuciElement == staro) tekuciElement = novo;
            staro = staro->sljedeci;
            novo = novo->sljedeci;
        }
        krajListe = new Cvor (novo, nullptr);
        novo->sljedeci = krajListe;
    }
    dDuzina = l.dDuzina; lDuzina = l.lDuzina;
    return *this;
}
template<typename Tip>
DvostrukaLista<Tip> &DvostrukaLista<Tip>::operator= (DvostrukaLista &&l) {
    if (this == &l) return *this;
     while (pocetakListe != nullptr) {
        tekuciElement = pocetakListe;
        pocetakListe = pocetakListe->sljedeci;
        delete tekuciElement;
    }
    lDuzina = l.lDuzina; dDuzina = l.dDuzina;
    pocetakListe = l.pocetakListe; krajListe = l.krajListe; tekuciElement = l.tekuciElement;
    l.dDuzina = l.lDuzina = 0;
    l.pocetakListe = l.krajListe = l.tekuciElement = nullptr;
    return *this;
}
/*Metoda koja pozionira tekući element na prethodni element u listi*/
template<typename Tip>
bool DvostrukaLista<Tip>::prethodni() {
    if (lDuzina + dDuzina == 0) throw ("Lista je prazna!\n");
    if (tekuciElement == pocetakListe) return false;
    tekuciElement = tekuciElement->prethodni;
    lDuzina--;
    dDuzina++;
    return true;
}
/*Metoda koja pozionira tekući element na sljedeći element u listi*/
template<typename Tip>
bool DvostrukaLista<Tip>::sljedeci() {
    if (lDuzina + dDuzina == 0) throw ("Lista je prazna!\n");
    if (krajListe->prethodni == tekuciElement) return false;
    if (dDuzina == 1) return false;
    tekuciElement = tekuciElement->sljedeci;
    lDuzina++;
    dDuzina--;
    return true;
}
/*Metoda koja pozionira tekući element na početak*/
template<typename Tip>
void DvostrukaLista<Tip>::pocetak() {
    if (dDuzina + lDuzina == 0) throw ("Lista je prazna!\n");
    tekuciElement = pocetakListe;
    dDuzina += lDuzina;
    lDuzina = 0;
}
/*Metoda koja pozionira tekući element na kraj*/
template<typename Tip>
void DvostrukaLista<Tip>::kraj() {
    if (dDuzina + lDuzina == 0) throw ("Lista je prazna!\n");
    tekuciElement = krajListe->prethodni->prethodni;
    lDuzina += dDuzina;
    dDuzina = 0;
}
template<typename Tip>
void DvostrukaLista<Tip>::obrisi() {
   if (lDuzina + dDuzina == 0) throw ("Lista je prazna!\n");
    if (tekuciElement->sljedeci == krajListe) {
        krajListe->prethodni = tekuciElement->prethodni;
        tekuciElement = tekuciElement->prethodni;
        tekuciElement->sljedeci = krajListe;
        dDuzina--;
    }
    else {
        Cvor *KRAJ = krajListe->prethodni;
        Cvor *temp = tekuciElement->sljedeci;
        tekuciElement->sljedeci = temp->sljedeci;
        temp->sljedeci->prethodni = tekuciElement;
        if (temp == KRAJ) tekuciElement = tekuciElement->prethodni;
        delete temp;
        dDuzina--;
 
    }
}
/*Metoda koja dodaje element ispred tekućeg elementa*/
template<typename Tip>
void DvostrukaLista<Tip>::dodajIspred (const Tip &el) {
    Cvor *novi = new Cvor (el, nullptr, nullptr);
    if (dDuzina + lDuzina == 0) {
        novi->prethodni = pocetakListe;
        pocetakListe->sljedeci = novi;
        krajListe->prethodni = novi;
        novi->sljedeci = krajListe;
        dDuzina++;
    }
    else {
        novi->sljedeci = tekuciElement->sljedeci;
        novi->prethodni = tekuciElement;
        tekuciElement->sljedeci->prethodni = novi;
        tekuciElement->sljedeci = novi;
        tekuciElement = novi;
        lDuzina++;
    }
}
/*Metoda koja dodaje element iza tekućeg elementa*/
template<typename Tip>
void DvostrukaLista<Tip>::dodajIza (const Tip &el) {
    Cvor *novi = new Cvor (el, 0, 0);
    if (dDuzina + lDuzina == 0) {
        novi->prethodni = pocetakListe;
        pocetakListe->sljedeci = novi;
        krajListe->prethodni = novi;
        novi->sljedeci = krajListe;
        tekuciElement = pocetakListe;
       
    }
    else {
        novi->prethodni = tekuciElement->sljedeci;
        tekuciElement->sljedeci->sljedeci->prethodni = novi;
        novi->sljedeci = tekuciElement->sljedeci->sljedeci;
        tekuciElement->sljedeci->sljedeci = novi;
    }
    dDuzina++;

}
/*Const verzija preklopljeniog operatora dodjele*/
template<typename Tip>
Tip DvostrukaLista<Tip>::operator[] (int i) const {
    if (i < 0 || i > (dDuzina + lDuzina) - 1) throw ("Index je ilegalan!\n");
    if (i == 0) return pocetakListe->sljedeci->element;
    Cvor *pom = pocetakListe->sljedeci;
    for (int j = 0; j < i; j++) pom = pom->sljedeci;
    return pom->element;
}
template<typename Tip>
Tip &DvostrukaLista<Tip>::operator[] (int i) {
    if (i < 0 || i > (dDuzina + lDuzina) - 1) throw ("Index je ilegalan!\n");
    if (i == 0) return pocetakListe->sljedeci->element;
    Cvor *pom = pocetakListe->sljedeci;
    for (int j = 0; j < i; j++) pom = pom->sljedeci;
    return pom->element;
}
template<typename Tip>
class Iterator {
    private:
        const DvostrukaLista<Tip> *dLista;
        typename DvostrukaLista<Tip>::Cvor *trenutniElement;
    public:
        Iterator (const Lista<Tip> &lista) {
            dLista = (DvostrukaLista<Tip> *) &lista;
            //trenutniElement = dLista->tekuciElement;
        }
        Tip &trenutni() {
            if (dLista->lDuzina + dLista->dDuzina == 0) throw ("Lista je prazna!\n");
            return trenutniElement->element;
        };
        bool sljedeci();
        bool prethodni();
        Tip pocetak();
        Tip kraj();
};
template<typename Tip>
bool Iterator<Tip>::sljedeci() {
    if (dLista->lDuzina + dLista->dDuzina == 0) throw ("Lista je prazna!\n");
    if (dLista->krajListe->prethodni == trenutniElement) return false;
    trenutniElement = trenutniElement->sljedeci;
    return true;
}
template<typename Tip>
bool Iterator<Tip>::prethodni() {
    if (dLista->lDuzina + dLista->dDuzina == 0) throw ("Lista je prazna!\n");
    if (dLista->pocetakListe == trenutniElement) return false;
    trenutniElement = trenutniElement->prethodni;
    return true;
}
template<typename Tip>
Tip Iterator<Tip>::pocetak() {
    if (dLista->lDuzina + dLista->dDuzina == 0) throw ("Lista je prazna!\n");
    trenutniElement = dLista->pocetakListe->sljedeci;
    return trenutniElement->element;
}
template<typename Tip>
Tip Iterator<Tip>::kraj() {
    if (dLista->lDuzina + dLista->dDuzina == 0) throw ("Lista je prazna!\n");
    trenutniElement = dLista->krajListe->prethodni;
    return trenutniElement->element;
}
template<typename Tip>
Tip dajMaksimum (const Lista<Tip> &n) {
    Iterator<Tip> it(n);
    Tip max = it.pocetak();
    while (it.sljedeci()) {
        if (it.trenutni() > max) max = it.trenutni();
    }
    return max;
}
int main() {
    DvostrukaLista<int> l;
    if(testirajBrojElemenata(l))  cout << "OK\n";
    else cout << "Nije OK\n";
    if(testirajTrenutni(l))  cout << "OK\n";
    else cout << "Nije OK\n";
    if(testirajPrethodni(l))  cout << "OK\n";
    else cout << "Nije OK\n";
    if(testirajSljedeci(l))  cout << "OK\n";
    else cout << "Nije OK\n";
    if(testirajPocetak(l))  cout << "OK\n";
    else cout << "Nije OK\n";
    if(testirajKraj(l))  cout << "OK\n";
    else cout << "Nije OK\n";
    if(testirajObrisi(l))  cout << "OK\n";
    else cout << "Nije OK\n"; 
    if(testirajDodajIspred(l))  cout << "OK\n";
    else cout << "Nije OK\n";
    if(testirajDodajIza(l))  cout << "OK\n";
    else cout << "Nije OK\n"; 
    return 0;
}
