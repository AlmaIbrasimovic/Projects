#include <iostream>
#include <stdexcept>

using namespace std;

template <typename T>
class Node {
public:
    T key;
    Node *left, *right;
    Node() {
        key = {};
        left(nullptr);
        right(nullptr);
    }
    Node (T k, Node *l = nullptr, Node *r = nullptr) {
        key = k;
        left = l;
        right = r;
    }
};

template <typename T>
class BinarySearchTree {
private:
    Node<T> *root;
    void Insert (Node<T> *&r, const T &element);
    void Inorder (Node<T> *t);
    void Postorder (Node<T> *t);
    void Preorder (Node<T> *t);
    Node<T> *minElement (Node<T> *root);
    Node<T> *maxElement (Node<T> *root);
    Node<T> *Search (Node<T> *root, const T &key);
    Node<T> *iterativeSearch (Node<T> *root, const T &key);
    int Height (Node<T> *root);
    void deleteWholeTree (Node<T> *r);
    bool deleteNode (Node<T> *&p, const T &x);

public:
    BinarySearchTree() { root = nullptr; }
    ~BinarySearchTree() { deleteWholeTree(); }
   // BinarySearchTree (const BinarySearchTree<T> &bT);

    //Search functions
    Node<T> *Search (const T &key) { return Search(root, key); }
    Node<T> *iterativeSearch (const T &key) { return iterativeSearch(root, key); }
    Node<T> *minElement () { return minElement(root); }
    Node<T> *maxElement () { return maxElement(root); }

    //Traverse functions
    void Inorder () { Inorder(root); }
    void Postorder () { Postorder(root); }
    void Preorder () { Preorder(root); }

    //Insertion function
    void Insert (const T &el) { Insert(root, el);}

    //Utility functions
    int Height() { return Height(root); }
    void deleteWholeTree() { deleteWholeTree(root); root = nullptr; }
    bool deleteNode(const T &x) { deleteNode(root, x); }
};

template<typename T>
Node<T> *BinarySearchTree<T>::Search (Node<T> *r, const T &key) {
    if (r == nullptr || r->key == key) return r;
    else if (key < r->key) Search(r->left, key);
    else Search(r->right, key);
}

template<typename T>
Node<T> *BinarySearchTree<T>::iterativeSearch(Node<T> *r, const T &key) {
    while (r != nullptr && r->key != key) {
        if (key < r->key) r = r->left;
        else  r = r->right;
    }
    return r;
}

template<typename T>
Node<T> *BinarySearchTree<T>::minElement(Node<T> *r) {
    if (r == nullptr) throw logic_error("Tree is empty!\n");
    else if (r->left == nullptr) return r;
    else return minElement(r->left);
}

template<typename T>
Node<T> *BinarySearchTree<T>::maxElement(Node<T> *r) {
    if (r== nullptr) throw logic_error("Tree is empty!\n");
    else if (r->right == nullptr) return r;
    else return maxElement(r->right);
}

template<typename T>
void BinarySearchTree<T>::Inorder (Node<T> *t) {
    if (t == nullptr) return;
    Inorder(t->left);
    cout << t->key << " ";
    Inorder(t->right);
}

template<typename T>
void BinarySearchTree<T>::Preorder (Node<T> *r) {
    if (r != nullptr) {
        cout << r->key << " ";
        Preorder(r->left);
        Preorder(r->right);
    }
}

template<typename T>
void BinarySearchTree<T>::Postorder (Node<T> *t) {
    if (t != nullptr) {
        Postorder(t->left);
        Postorder(t->right);
        cout << t->key << " ";
    }
}

template<typename T>
void BinarySearchTree<T>::Insert (Node<T> *&Root, const T &element) {
    if (Root == nullptr) {
            Root = new Node<T>(element, nullptr, nullptr);
            return;
    }
    else if (element > Root->key) Insert(Root->right, element);
    else Insert(Root->left, element);
}

template<typename T>
int BinarySearchTree<T>::Height (Node<T> *root) {
    int hLeft = 0, hRight = 0;
    if (root == nullptr) return -1;
    hLeft = Height(root->left);
    hRight = Height(root->right);
    if (hLeft > hRight) return hLeft + 1;
    return hRight + 1;
}

template<typename T>
void BinarySearchTree<T>::deleteWholeTree (Node<T> *p) {
    if (p) {
        deleteWholeTree(p->left);
        deleteWholeTree(p->right);
        delete p;
    }
}

template<typename T>
bool BinarySearchTree<T>::deleteNode (Node<T> *&r, const T &x) {
    Node<T> *tempRoot = r, *q = nullptr;
    Node<T> *temp = nullptr, *pp = nullptr, *rp = nullptr;
    while (tempRoot != nullptr && x != tempRoot->key) {
        q = tempRoot;
        if (x < tempRoot->key) tempRoot = tempRoot->left;
        else tempRoot = tempRoot->right;
    }
    //We didn't find the element
    if (tempRoot == nullptr) return false;

    //If there is only one child, left or right
    if (tempRoot->left == nullptr) rp = tempRoot->right;
    else if (tempRoot->right == nullptr) rp = tempRoot->left;

    //If there are both children
    else {
        pp = tempRoot;
        rp =tempRoot->left;
        temp= rp->right;
        while (temp != nullptr) {
            pp = rp->left;
            rp = temp;
            temp = rp->right;
        }
        if (pp != tempRoot) {
            pp->right = rp->left;
            rp->left = tempRoot->left;
        }
        rp->right = tempRoot->right;
    }
     if (q == nullptr)root =rp;
     else if (tempRoot == q->left) q->left = rp;
     else q->right = rp;
     delete tempRoot;
     return true;
}

int main()
{
    try {
        BinarySearchTree<int> t;
        t.Insert(25);
        t.Insert(12);
        t.Insert(7);
        t.Insert(18);
        t.Insert(3);
        t.Insert(10);
        t.Insert(34);
        t.Insert(29);
        t.Insert(39);
        t.Insert(27);
        t.Insert(32);

        cout << "Inorder: "; t.Inorder();
        cout << "\nPostorder: "; t.Postorder();
        cout << "\nPreorder: "; t.Preorder();
        cout<< endl;
        cout << "\nMinimal element is: " << (t.minElement())->key;
        cout << "\nMaximal element is: " << (t.maxElement())->key;
        cout << endl << endl;

        if (t.Search(56)) cout << "Element 56 is in binary tree!";
        else cout << "Element 56 is not in binary tree!\n";
        if (t.Search(27)) cout << "Element 27 is in binary tree!\n";
        else cout << "Element 27 is not in binary tree!\n";
        cout << "\nHeight of the tree is: " << t.Height() <<endl;
        if (t.deleteNode(32)) cout << "\nNode 32 has been deleted!\n";
        else cout << "\nNode 32 is not deleted!\n";

     }
     catch (logic_error error) {
        cout << error.what()<< endl;
    }
    return 0;
}
