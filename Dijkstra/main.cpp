#include <iostream>
#include "Graph.h"

using namespace std;

class Dijkstra : public AGraph {
private:
    static const int INF = 1000000;
    int *D; //niz sa najkracim rastojanjima
    int *P; //niz sa cvorovima prethodnicima
    int minCvor() {
        int v = -1;
        for (int i = 0; i<numOfVertices; i++) {
            if (getMark(i) == false) {
                v = i;
                break;
            }
            for (int j = v + 1; j<numOfVertices; j++) {
                if ((getMark(j) == false) && (D[j] < D[v])) v = j;
            }
        }
        return v;
    }
    void prikaziPut (int v1, int v2) {
        if (v1 == v2) cout << v1 << "..";
        else if (P[v1] == -1) cout << "Nema puta od " << v2 << "do " << v1 << endl;
        else {
            prikaziPut(P[v1], v2);
            cout << v1 << "..";
        }
    }
public:
    Dijkstra (int maxBrojCvorova=10) : AGraph(maxBrojCvorova), D(new int[maxBrojCvorova]), P(new int[maxBrojCvorova]) {}
    ~Dijkstra() {
        delete[] D;
        delete[] P;
    }
    void DijkstraAlgoritam (int s);
    void prikaziSve (int s) {
        for (int i = 0; i<numOfVertices; i++) {
            if (i == s) cout << s << ".." << s;
            else prikaziPut(i,s);
            cout << "->" << D[i] << endl;
        }
    }
};

void Dijkstra::DijkstraAlgoritam(int s) {
    for (int i = 0; i<numOfVertices; i++) {
        D[i] = INF;
        P[i] = -1;
        setMark(i, false);
    }
    D[s] = 0;
    for (int i = 0; i<numOfVertices; i++) {
        int u = minCvor();
        setMark(u, true);
        if (D[u] == INF) return;
        for (int j = firstNeighbor(u); j<numOfVertices; j = nextNeighbor(u, j)) {
            if (D[j] > (D[u] + getWeight(u,j))) {
                D[j] = D[u] + getWeight(u,j);
                P[j] = u;
            }
        }
    }
}

int main()
{
    Dijkstra d(15);
    d.setVertices(7);
    d.setEdge(0,1,3); d.setEdge(0,3,2); d.setEdge(0,6,6);
    d.setEdge(1,4,1); d.setEdge(1,2,6);
    d.setEdge(2,5,1);
    d.setEdge(3,1,2); d.setEdge(3,4,3);
    d.setEdge(4,5,4);
    d.setEdge(6,5,2);
    d.prikaziSve(0);

    return 0;
}
