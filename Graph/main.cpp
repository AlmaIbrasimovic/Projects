#include <iostream>
#include <stdexcept>
#include <queue>

using namespace std;

class Graph {
public:
    virtual ~Graph() {}
    virtual int numberOfVertices() = 0;
    virtual int numberOfEdges() = 0;
    virtual void setEdge (int e1, int e2, int weight) = 0;
    virtual void deleteEdge (int e1, int e2) = 0;
    virtual void deleteAllEdges() = 0;
    virtual int getWeight (int e1, int e2) = 0;
    virtual bool getMark (int v) = 0; //Gets the mark if vertex is visited or not
    virtual void setMark (int v, bool value) = 0; //Set the vertex true if it's visited
    virtual int firstNeighbor (int v) = 0;
    virtual int nextNeighbor (int v1, int v2) = 0;
};

//Graph represented with adjacency matrix
class AGraph : public Graph {
protected:
    int maxVertices;
    int numOfVertices, numOfEdges;
    int **array; //adjacency matrix
    bool *mark; //Pointer to the array of marks
public:
    AGraph (int maxV) {
        maxVertices = maxV;
        numOfEdges = 0;
        numOfVertices = 0;
        mark = new bool[maxV];
        for (int i = 0; i< maxVertices; i++) mark[i] = false;
        array = (int**) new int* [maxVertices];
        for (int i = 0; i<maxVertices; i++) array[i] = new int [maxVertices];
        for (int i = 0; i<maxVertices; i++) {
            for (int j = 0; j<maxVertices; j++) array[i][j] = 0; //Setting weight
        }
    }
    ~AGraph();
    int numberOfVertices() { return numOfVertices; }
    int numberOfEdges() { return numOfEdges; }
    void setEdge(int e1, int e2, int weight);
    void setVertices (int n) {
        if (n > maxVertices) throw logic_error ("Illegal number of vertices!\n");
        numOfVertices = n;
    }
    void deleteEdge(int e1, int e2);
    void deleteAllEdges();
    int getWeight(int e1, int e2) { return array[e1][e2]; }
    bool getMark(int v) { return mark[v]; }
    void setMark(int v, bool value) { mark[v] = value; }
    int firstNeighbor(int v);
    int nextNeighbor(int v1, int v2);
};

AGraph::~AGraph() {
    delete[] mark;
    for (int i = 0; i<maxVertices; i++) delete[] array[i];
    delete[] array;
}

void AGraph::setEdge (int e1, int e2, int weight) {
    if (e1 < 0 || e2 < 0 || e1 >= numOfVertices || e2 >= numOfVertices || weight <= 0) throw logic_error ("Illegal vertex or weight!\n");
    if (array[e1][e2] == 0) numOfEdges++;
    array[e1][e2] = weight;

}

void AGraph::deleteEdge (int e1, int e2) {
    if (e1 < 0 || e2 < 0 || e1 >= numOfEdges || e2 >= numOfEdges) throw logic_error ("Illegal edge!\n");
    if (array[e1][e2] != 0) numOfEdges--;
    array[e1][e2] = 0;
}

void AGraph::deleteAllEdges() {
    if (numOfEdges) throw logic_error ("There are no edges!\n");
    for (int i = 0; i<numOfEdges; i++) {
        for (int j = 0; j<numOfEdges; j++) array[i][j] = 0;
    }
}

int AGraph::firstNeighbor(int v) {
    for (int i = 0; i<numOfVertices; i++) {
        if (array[v][i] != 0) return i;
    }
    return numOfVertices; //If there is no neighbor, return number
}

int AGraph::nextNeighbor(int v1, int v2) {
    for (int i = v2+1; i<numOfVertices; i++) {
        if (array[v1][i] != 0) return i;
    }
    return numOfVertices;
}

class GraphTraversal : public AGraph {
    private:
        void searchBreadth (int s);
        void searchDepth (int s);
    public:
        GraphTraversal (int maxV = 10) : AGraph(10) {}
        void DFS();
        void BFS();
};


//BFS
void GraphTraversal::searchBreadth (int s) {
    mark[s] = true;
    queue<int> q;
    q.push(s);
    setMark(s, true);
    while (!q.empty()) {
        int val = q.front();
        q.pop();
        cout << "-" << val;
        for (int i = firstNeighbor(s); i<numberOfVertices(); i = nextNeighbor(val, i)) {
            if (!getMark(i)) {
                setMark(i, true);
                q.push(i);
            }
        }
    }
}

void  GraphTraversal::BFS() {
    for (int i = 0; i<numOfVertices; i++) setMark(i, false);
    for (int i = 0; i<numberOfVertices(); i++) {
        if (!getMark(i)) searchBreadth(i);
    }
}

//DFS
void GraphTraversal::searchDepth(int s) {
    cout << "-" << s;
    setMark(s, true);
    for (int i = firstNeighbor(s); i < numberOfEdges(); i = nextNeighbor(s, i)) {
        if (!getMark(i)) searchDepth(i);
    }
}

void GraphTraversal::DFS() {
    for (int i = 0; i<numOfVertices; i++) setMark(i, false);
    for (int i = 0; i<numberOfVertices(); i++) {
        if (!getMark(i)) searchDepth(i);
    }
}

int main()
{
    GraphTraversal g(15);
    int numVert = 5;
    g.setVertices(numVert);
    g.setEdge(0,1,1);
    g.setEdge(1,0,1);
    g.setEdge(1,2,1);
    g.setEdge(2,1,1);
    g.setEdge(3,4,1);
    g.setEdge(4,3,1);
    g.setEdge(4,1,1);
    g.setEdge(1,4,1);
    g.DFS();
    g.BFS();
    return 0;
}
