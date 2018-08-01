#include <iostream>
#include <stdexcept>
using namespace std;

class Heap {
private:
    int *heap;
    int capacity; //Max capacity for heap
    int size; //Number of elements in the heap
    int sizeOfTheArray; //Number of the elements in the array
    void fixDown (int i); //Fix the heap below the element with index i
    void fixUp (int i); //Fix the heap above the element with index i
    void swap (int i, int j); //To swap two elements

public:
    Heap(int maxCap) {
        capacity = maxCap;
        size = 0;
        heap = new int[maxCap];
    }
    ~Heap() {
        capacity = size = 0;
        delete[] heap;
    }
    int getSize() const { return size; } //Return size of the heap
    int getArraySize() const { return sizeOfTheArray; } //Return the size of the array
    bool Leaf(int i) const { return (i >= size/2) && (i < size); } //Check if element with index i is leaf
    int leftChild (int i) const { return (2*i + 1); } //Return left child of the element with index i
    int rightChild (int i) const { return (2*i + 2); } //Return right child of the element with index i
    int Parent (int i) const { return (i-1) / 2; } //Return parent of the element with index i
    void createHeap (); //Create heap from array
    void insertInHeap (const int el);
    int removeFirst(); //Remove the first element from the heap
    int remove (const int i); //Remove element from position i
    void changeKey (int i, int &x); //To change the key of the element in position i
    void Load (int i ); //Insert element in the array;
    void Print ()const; //Print the heap
};

void Heap::fixDown(int i) {
    while (!Leaf(i)) {
        int max = leftChild(i);
        int temp = rightChild(i);
        if ((temp < size) && (heap[temp] > heap[max])) max = temp;
        if (heap[i] > heap[max]) return;
        swap(i,max);
        i = max;
    }
}

void Heap::fixUp(int i) {
    while (i != 0 && (heap[i] > heap[Parent(i)])) {
        swap(i, Parent(i));
        i = Parent(i);
    }
}

void Heap::swap(int i, int j) {
    int temp = heap[i];
    heap[i] = heap[j];
    heap[j] = temp;
}

void Heap::createHeap() {
    size = sizeOfTheArray;
    for (int i = size/2; i>=0; i--) fixDown(i);
}

void Heap::insertInHeap(int i) {
    if (size > capacity - 1) throw logic_error ("Heap is full!\n");
    heap[size++] = i;
    fixUp(size-1);
}

int Heap::removeFirst() {
    if (size == 0) throw logic_error ("Heap is empty!\n");
    swap (0, --size);
    if (size != 0) fixDown(0);
    return heap[size];
}

int Heap::remove(const int i) {
    if (i < 0 || i >= size) throw logic_error ("Index is not in range!");
    swap(i, --size);
    fixUp(i);
    fixDown(i);
    return heap[size];
}

void Heap::changeKey(int i, int &el) {
    if (heap[i] > el) throw logic_error ("Old value is greater than new!\n");
    heap[i] = el;
    fixUp(i);
}

void Heap::Load(int n) {
    cout << "\nEnter the elements\n";
    size = 0;
    for (int i = 0; i<n; i++) {
        int x;
        cin >> x;
        heap[i] = x;
    }
    sizeOfTheArray = n;
}

void Heap::Print()const {
    for (int i = 0; i<size; i++) cout << heap[i] << " ";
}
int main()
{
    Heap h(20);
    cout << "Enter the number of elements in the array: ";
    int x;
    do {
        cin >> x;
        if (x >= 20) {
            cout << "Number of elements can't be bigger than 20!\n";
            cout << "Enter the number of elements in the array: ";
        }
    } while (x >= 20);
    h.Load(x);
    h.createHeap();
    h.Print();
    cout << "\nFirst element of the heap is: " << h.removeFirst();
    cout << endl;
    h.Print();
    cout<<"\nEnter the index of the number you want to remove: ";
    cin >> x;
    h.remove(x);
    h.Print();
    cout << "\nEnter the number you want to insert int the heap: ";
    cin >> x;
    h.insertInHeap(x);
    h.Print();
    return 0;
}
