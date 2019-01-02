#include <iostream>
#include <stdexcept>

using namespace std;

template <typename Tip>
class Stek {
    private:
        struct Cvor {
            Tip element;
            Cvor *sljedeci;
            Cvor (const Tip &el, Cvor *slje) : element(el), sljedeci(slje) {}
        };
        Cvor *vrh_steka;
        int velicina_steka;
    public:
        Stek () : vrh_steka(nullptr), velicina_steka(0) {}  //
        ~Stek() { brisi(); } //
        Stek (const Stek &st) ;
        Stek (Stek &&st); //
        Stek &operator= (const Stek &st);
        Stek &operator= (Stek &&st);

        void brisi() {
            while (velicina_steka != 0) skini();
        }
        void stavi (const Tip &el); //
        Tip skini(); //
        Tip &vrh() {
            if (velicina_steka == 0) throw ("Stek je prazan!\n");
            return vrh_steka->element;
        }
        int brojElemenata() const { return velicina_steka; }
};
template<typename Tip>
Stek<Tip>::Stek (const Stek &st) {
    velicina_steka = st.velicina_steka;
    Cvor *novi_vrh = st.vrh_steka;
    Cvor *temp;
    vrh_steka = nullptr;
    while (novi_vrh != nullptr) {
        Cvor *novi = new Cvor (novi_vrh->element, nullptr);
        if (vrh_steka == nullptr) vrh_steka = novi;
        else temp->sljedeci = novi;
        novi_vrh = novi_vrh->sljedeci;
        temp = novi;
    }
}
template<typename Tip>
Stek<Tip>::Stek (Stek &&st): vrh_steka(st.vrh_steka), velicina_steka(st.velicina_steka) {
    st.vrh_steka = nullptr;
    st.velicina_steka = 0;
}
template<typename Tip>
Stek<Tip> &Stek<Tip>::operator= (const Stek &st) {
    if (&st == this) return *this;
    brisi();
    velicina_steka = st.velicina_steka;
    Cvor *novi_vrh = st.vrh_steka;
    Cvor *temp;
    vrh_steka = nullptr;
    while (novi_vrh != nullptr) {
        Cvor *novi = new Cvor (novi_vrh->element, nullptr);
        if (vrh_steka == nullptr) vrh_steka = novi;
        else temp->sljedeci = novi;
        novi_vrh = novi_vrh->sljedeci;
        temp = novi;
    }
    return *this;
}
template<typename Tip>
Stek<Tip> &Stek<Tip>::operator= (Stek &&st) {
    if (&st == this) return *this;
    brisi();
    vrh_steka = st.vrh_steka;
    velicina_steka = st.velicina_steka;
    st.vrh_steka = nullptr;
    st.velicina_steka = 0;
    return *this;
}
template <typename Tip>
void Stek<Tip>::stavi (const Tip &el) {
    Cvor *temp = new Cvor (el, nullptr);
    if (velicina_steka == 0) {
        vrh_steka = temp;
    }
    else {
        Cvor *privremeni = vrh_steka;
        vrh_steka = temp;
        vrh_steka->sljedeci = privremeni;
    }
    temp = nullptr;
    delete temp;
    velicina_steka++;
}
template <typename Tip>
Tip Stek<Tip>::skini () {
    if (velicina_steka == 0) throw domain_error ("Stek je prazan!\n");
    Tip za_vratiti = vrh_steka->element;
    Cvor *novi_vrh = vrh_steka->sljedeci;
    delete vrh_steka;
    vrh_steka = novi_vrh;
    velicina_steka--;
    return za_vratiti;
}
template<typename Tip>
class Red {
    private:
        struct Cvor {
            Tip element;
            Cvor *sljedeci;
            Cvor (const Tip &el, Cvor *slj) : element(el), sljedeci(slj) {}
        };
        Cvor *pocetak;
        Cvor *kraj;
        int velicinaReda;
    public:
    Red() : pocetak(nullptr), kraj(nullptr), velicinaReda(0) {} //
    ~Red() { brisi(); } //
    Red (const Red &r); //
    Red (Red &&r); //
    Red &operator= (const Red &r); //
    Red &operator= (Red &&r); //
    void brisi(); //
    void stavi (const Tip &e); //
    Tip skini();//
    Tip &celo() const;//
    Tip &celo();//
    int brojElemenata() const { return velicinaReda; }//
};
template<typename Tip>
Red<Tip>::Red(const Red &r) {
    velicinaReda = 0;
    pocetak = kraj = nullptr;
    Cvor *noviPocetak = r.pocetak;
    while (noviPocetak != nullptr) {
        stavi(noviPocetak->element);
        noviPocetak = noviPocetak->sljedeci;
    }
}
template<typename Tip>
Red<Tip>::Red (Red &&r) {
    pocetak = r.pocetak;
    kraj = r.kraj;
    velicinaReda = r.velicinaReda;
    r.pocetak = r.kraj = nullptr;
    r.velicinaReda = 0;
}
template<typename Tip>
Red<Tip> &Red<Tip>::operator= (const Red &r) {
    if (this == &r) return *this;
    brisi();
    Cvor *noviPocetak = r.pocetak;
    while (noviPocetak != nullptr) {
        stavi(noviPocetak->element);
        noviPocetak = noviPocetak->sljedeci;
    }
    return *this;
}
template<typename Tip>
Red<Tip> &Red<Tip>::operator= (Red &&r) {
    if (this == &r) return *this;
    brisi();
    pocetak = r.pocetak;
    kraj = r.kraj;
    velicinaReda = r.velicinaReda;
    r.pocetak = r.kraj = nullptr;
    r.velicinaReda = 0;
    return *this;
}
template<typename Tip>
void Red<Tip>::brisi() {
    while (pocetak != nullptr) skini();
}
template<typename Tip>
Tip Red<Tip>::skini() {
    if (velicinaReda == 0) throw ("Red je prazan!\n");
    Tip x = pocetak->element;
    Cvor *p = pocetak;
    if (velicinaReda == 0) pocetak = kraj = nullptr;
    else pocetak = pocetak->sljedeci;
    delete p;
    velicinaReda--;
    return x;
}
template<typename Tip>
void Red<Tip>::stavi(const Tip &e) {
    Cvor *temp = new Cvor (e, nullptr);
    if (pocetak == nullptr) pocetak = kraj = temp;
    else {
        kraj->sljedeci = temp;
        kraj = kraj->sljedeci;
    }
    velicinaReda++;
}
template<typename Tip>
Tip &Red<Tip>::celo() const {
    if (velicinaReda == 0) throw ("Red je prazan!\n");
    return pocetak->element;
}
template<typename Tip>
Tip &Red<Tip>::celo() {
    if (velicinaReda == 0) throw ("Red je prazan!\n");
    return pocetak->element;
}

void  funkcija (Stek<Red<int>> &s, Red<int> &r, Red<int> &r2) {
    r = s.skini();
    for (int i = 0; i<s.brojElemenata(); i++) {
            r2 = s.skini();
            s.stavi(r2);
    }
    s.stavi(r);
}
int main() {
    Stek<Red<int>> tr;
    Red<int> a, b, c;
    a.stavi(1); a.stavi(2); a.stavi(6); a.stavi(55); a.stavi(51);
    b.stavi(1264); b.stavi(62); b.stavi(69); b.stavi(545); b.stavi(4251);
    c.stavi(12); c.stavi(28); c.stavi(3); c.stavi(5); c.stavi(89);
   // cout<<a.brojElemenata() << " " << b.brojElemenata() << " " << c.brojElemenata();
    tr.stavi(a);
    tr.stavi(b);
    tr.stavi(c);
   //funkcija(tr,a,b);
    int ovd = tr.brojElemenata();
    for (int i = 0; i<ovd; i++) {
            int vel = tr.vrh().brojElemenata();
            for (int j = 0; j<vel; j++) {
                cout << tr.vrh().skini() << " ";
            }
            tr.skini();
    cout<<endl;
    }
    return 0;
}
