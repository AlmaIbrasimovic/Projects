#include <iostream>

using namespace std;

template <typename T>
class OpenAddressing {
protected:
    T *array;
    T emptySpot;
    int size;
    virtual int hashFunction (const T &el, int i) const = 0;
public:
    OpenAddressing (T empty, int siz) {
        array = new T[siz];
        emptySpot = empty;
        size = siz;
        for (int i = 0; i<size; i++) array[i] = empty;
    }
    ~OpenAddressing() {
        delete[] array;
        size = 0;
    }
    bool insert (const T &el);
    int search (const T &key) const;
    void print() const;
};

class LinearProbing : public OpenAddressing<int> {
private:
    int hashFunction(const int &key, int i) const {
        return (key % size + i) % size;
    }
public:
    LinearProbing (int empty = -1, int size = 10) : OpenAddressing<int> (empty, size) {}
};

class DoubleProbing : public OpenAddressing<int> {
private:
    int hashFunction(const int &key, int i)const {
        return (key % 13 + i * (1 + key % 11)) % 13;
    }
public:
    DoubleProbing (int empty = -1, int size = 13) : OpenAddressing(empty, size) {}
};

template<typename T>
bool OpenAddressing<T>::insert(const T &el) {
    int i = 0;
    int j;
    do {
        j = hashFunction(el, i);
        if (array[j] == emptySpot) {
                array[j] = el;
                return true;
        }
        i++;
    } while (i < size);
}

template<typename T>
int OpenAddressing<T>::search (const T &key) const {
    int i = 0;
    int index;
    do {
        index = hashFunction(key, i);
        if (array[index] == key) return index;
        i = i + 1;
    } while (array[index] != emptySpot && i != size);
    return emptySpot;
}

template<typename T>
void OpenAddressing<T>::print() const {
    for (int i = 0; i<size; i++) cout<< array[i] << " ";
}
int main()
{
    const int emptySpot = -1;
    cout << "Creating hash table using LINEAR PROBING....\n";
    LinearProbing lin(emptySpot, 10);
    if (lin.insert(56)) cout << "Element 56 is inserted!\n";
    else cout << "Element 56 is not inserted!\n";
    if (lin.insert(1)) cout << "Element 1 is inserted!\n";
    else cout << "Element 1 is not inserted!\n";
    if (lin.insert(45)) cout << "Element 45 is inserted!\n";
    else cout << "Element 45 is not inserted!\n";
    if (lin.insert(120)) cout << "Element 120 is inserted!\n";
    else cout << "Element 120 is not inserted!\n";
    int p = lin.search(45);
    if (p != emptySpot) cout << "\nElement 45 is found on " << p << ". place.\n";
    else cout << "\nElement 45 is not found in the table!\n";
    cout << "\nContent of the hash table\n";
    lin.print(); cout<<endl;
    cout << "\n\nCreating hash table using DOUBLE PROBING....\n";


    DoubleProbing dou(emptySpot, 10);
    if (dou.insert(56)) cout << "Element 56 is inserted!\n";
    else cout << "Element 56 is not inserted!\n";
    if (dou.insert(1)) cout << "Element 1 is inserted!\n";
    else cout << "Element 1 is not inserted!\n";
    if (dou.insert(45)) cout << "Element 45 is inserted!\n";
    else cout << "Element 45 is not inserted!\n";
    if (dou.insert(120)) cout << "Element 120 is inserted!\n";
    else cout << "Element 120 is not inserted!\n";
    p = dou.search(45);
    if (p != emptySpot) cout << "\nElement 45 is found on " << p << ". place.\n";
    else cout << "\nElement 45 is not found in the table!\n";
    cout << "\nContent of the hash table\n";
    lin.print(); cout<<endl;

    return 0;
}
