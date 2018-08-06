#include <iostream>
#include <stdexcept>
#include "Graph.h"

using namespace std;

class MSTPrim : public AGraph {
private:
    static const int INF = 1000000;
    int *D;
    int *P;
    int minVertex() {
        int u = -1;
        for (int i = 0; i<numOfVertices; i++) {
            if (getMark(i) == false) {
                u = i;
                break;
            }
            for (int j = u + 1; j<numOfVertices; j++) {
                if ((getMark(j) == false) && (D[j] < D[u])) u = j;
            }
        }
        return u;
    }
public:
    MSTPrim(int numVertices = 10) : AGraph(numVertices), D(new int[numVertices]), P(new int[numVertices]) {}
    ~MSTPrim() {
        delete[] D;
        delete[] P;
    }
    void Prim (int s);
    void printEdge (int v1, int v2) {
        cout << "Add edge " << v1 << " " << v2 << endl;
    }
};

void MSTPrim::Prim(int s) {
    for (int i = 0; i<numOfVertices; i++) {
        D[i] = INF;
        P[i] = -1;
        setMark(i, false);
    }
    D[s] = 0;
    for (int i = 0; i<numOfVertices; i++) {
        int u = minVertex();
        setMark(u, true);
        if (u != s) printEdge(P[u], u);
        if (D[u] == INF) return;
        for (int i = firstNeighbor(u); i<numOfVertices; i = nextNeighbor(u, i)) {
            if (D[i] > getWeight(u, i)) {
                D[i] = getWeight(u, i);
                P[i] = u;
            }
        }
    }
}

int main()
{
    MSTPrim g(10);
    g.setVertices(9);
    g.setEdge(0,1,5);   g.setEdge(0,3,9);
    g.setEdge(1,3,13);  g.setEdge(1,2,10);  g.setEdge(1,6,12);
    g.setEdge(2,3,8);   g.setEdge(2,4,7);   g.setEdge(2,6,7);
    g.setEdge(3,4,2);
    g.setEdge(4,5,3);
    g.setEdge(5,6,6);   g.setEdge(5,8,14);  g.setEdge(5,7,16);
    g.setEdge(6,7,4);
    g.setEdge(7,8,11);

    /*g.setEdge(0,1,2);
    g.setEdge(0,3,6);
    g.setEdge(1,3,8);
    g.setEdge(3,4,9);
    g.setEdge(1,2,3);
    g.setEdge(1,4,5);
    g.setEdge(2,4,7);*/
    g.Prim(0);
    return 0;
}
