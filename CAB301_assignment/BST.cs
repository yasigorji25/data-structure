using System;
using CAB301_assignment;

public class Node {
    private Movie item; // movie object. 
    private Node lchild; // reference to its left child 
    private Node rchild; // reference to its right child

    public Node(Movie item) {
        this.item = item;
        lchild = null;
        rchild = null;
    }

    public Movie Item {
        get { return item; }
        set { item = value; }
    }

    public Node LChild {
        get { return lchild; }
        set { lchild = value; }
    }

    public Node RChild {
        get { return rchild; }
        set { rchild = value; }
    }
}

public class BST {

    private Movie[] unsort = new Movie[100];
    int i = 0;

    public Movie[] Unsort {
        get { return unsort; }
        set { unsort = value; }

    }

    private Node root;

    public BST() {
        root = null;
    }


    // pre: focusNode != null
    // post: item is inserted to the binary search tree rooted at focusNode
    private void Insert(Movie item, Node focusNode) {
        if (string.Compare(item.Title, focusNode.Item.Title, StringComparison.Ordinal) < 0) {
            if (focusNode.LChild == null)
                focusNode.LChild = new Node(item);
            else
                Insert(item, focusNode.LChild);
        } else {
            if (focusNode.RChild == null)
                focusNode.RChild = new Node(item);
            else
                Insert(item, focusNode.RChild);
        }
    }

    // The node to be deleted is a leaf, has only one child or has both left and right children
    public void Delete(string item) {
        Node focusNode = root;
        Node parent = null;
        while ((focusNode != null) && (string.Compare(item, focusNode.Item.Title, StringComparison.Ordinal) != 0)) {
            parent = focusNode;
            if (string.Compare(item, focusNode.Item.Title, StringComparison.Ordinal) < 0)
                focusNode = focusNode.LChild;
            else
                focusNode = focusNode.RChild;
        }

        if (focusNode != null) {
            // item has two children
            if ((focusNode.LChild != null) && (focusNode.RChild != null)) {
                // find the right-most node in left subtree of focusNode
                if (focusNode.LChild.RChild == null) {
                    focusNode.Item = focusNode.LChild.Item;
                    focusNode.LChild = focusNode.LChild.LChild;
                } else {
                    Node p = focusNode.LChild;
                    Node pp = focusNode; // parent of p
                    while (p.RChild != null) {
                        pp = p;
                        p = p.RChild;
                    }
                    // copy the item at p to focusNode
                    focusNode.Item = p.Item;
                    pp.RChild = p.LChild;
                }
            } else // only one child
              {
                Node c;
                if (focusNode.LChild != null)
                    c = focusNode.LChild;
                else
                    c = focusNode.RChild;

                // remove focusNode
                if (focusNode == root)
                    root = c;
                else {
                    if (focusNode == parent.LChild)
                        parent.LChild = c;
                    else
                        parent.RChild = c;
                }
            }

        }
    }


    public bool Search(string item) {
        return Search(item, root);
    }

    private bool Search(string item, Node m) {
        if (m != null) {
            if (string.Compare(item, m.Item.Title, StringComparison.Ordinal) == 0)

                return true;
            else
                if (string.Compare(item, m.Item.Title, StringComparison.Ordinal) < 0)
                return Search(item, m.LChild);
            else
                return Search(item, m.RChild);
        } else
            return false;
    }

    public void Insert(Movie item) {
        if (root == null)
            root = new Node(item);
        else
            Insert(item, root);
    }

    public bool IsEmpty() {
        return root == null;
    }

    public void PreOrderTraverse() {
        Console.Write("PreOrder: ");
        PreOrderTraverse(root);
        Console.WriteLine();
    }

    private void PreOrderTraverse(Node r) {
        if (r != null) {
            Console.Write(r.Item);
            PreOrderTraverse(r.LChild);
            PreOrderTraverse(r.RChild);
        }
    }

    public void InOrderTraverse() {
        //Console.Write("InOrder: ");
        InOrderTraverse(root);
        Console.WriteLine();
    }

    private void InOrderTraverse(Node r) {
        if (r != null) {
            InOrderTraverse(r.LChild);
            Console.WriteLine();
            Console.Write(r.Item);
            Console.WriteLine();
            InOrderTraverse(r.RChild);
            Console.WriteLine();
        }
    }



    public void PostOrderTraverse() {
        unsort = new Movie[100];
        i = -1;
        PostOrderTraverse(root);
    }

    private void PostOrderTraverse(Node r) {

        if (r != null) {
            i++;
            if (r.Item != null) {

                unsort[i] = r.Item;

            } else Console.WriteLine("null {0}", i);

            PostOrderTraverse(r.LChild);
            PostOrderTraverse(r.RChild);
        }
    }


    public Movie reurnMovieByTitle(string item) {
        return reurnMovieByTitle(item, root);
    }

    private Movie reurnMovieByTitle(string item, Node r) {
        if (r != null) {
            if (string.Compare(item, r.Item.Title, StringComparison.Ordinal) == 0)

                return r.Item;
            else
                if (string.Compare(item, r.Item.Title, StringComparison.Ordinal) < 0)
                return reurnMovieByTitle(item, r.LChild);
            else
                return reurnMovieByTitle(item, r.RChild);
        }

        return null;
    }



    public void Clear() {
        root = null;
    }
}

