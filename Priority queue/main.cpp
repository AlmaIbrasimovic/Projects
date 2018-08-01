#include <iostream>
#include "BinaryHeap.h"

using namespace std;

class PriorityQueue : private Heap{
public:
    PriorityQueue (int maxd) : Heap(maxd) {}
    void insertInQueue (int e) { insertInHeap(e); }
    int removeFromQueue() { return removeFirst(); }
    void changePriority(int i, int el) { changeKey(i, el); }
    int getSize() const { return getSize(); }
    void print() const { Print(); }
};

int main()
{
    PriorityQueue pq (20);
    pq.insertInQueue(5);
    pq.insertInQueue(99);
    pq.insertInQueue(11);
    pq.insertInQueue(66);
    pq.insertInQueue(23);
    pq.insertInQueue(42);
    pq.insertInQueue(85);
    pq.insertInQueue(6);
    pq.insertInQueue(8);
    pq.insertInQueue(1);
    pq.print();
    cout << "\nElement with biggest priority is: " << pq.removeFromQueue() << endl;
    pq.insertInQueue(99);
    pq.print();
    pq.changePriority(1,100);
    cout << endl;
    pq.print();
    cout << "\nElement with biggest priority is: " << pq.removeFromQueue() << endl;
    return 0;
}
