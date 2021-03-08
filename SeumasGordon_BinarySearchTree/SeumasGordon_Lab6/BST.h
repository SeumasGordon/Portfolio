#pragma once
template<typename Type>
class BST {
private:
	struct Node {
		Type data;
		Node* left = nullptr;
		Node* right = nullptr;
		Node(const Type& v, Node* left = nullptr, Node* right = nullptr) : data(v), left(left), right(right) {};
	};
	Node* root = nullptr;
	void insertrecursice(const Type& v, Node* Current);
	bool findrecursice(const Type& v, Node* Current) const;
	void clearrecursice(Node* v);
	void printrecursice(Node* Cu) const;
	void copyrecersice(Node* v);

	void Case0(Node* v, Node* Par);
	void Case1(Node* v, Node* Par);
	//void Case2(Node* v);
public:
	BST() {}
	~BST();
	BST& operator=(const BST& that);
	BST(const BST& that);
	void insert(const Type& v);
	bool findAndRemove(const Type& v);
	bool find(const Type& v) const;
	void clear();
	void printInOrder() const;
};

template<typename Type>
inline BST<Type>::~BST()
{
	clear();
}

template<typename Type>
inline BST<Type>& BST<Type>::operator=(const BST& that)
{
	if (this != &that)
	{
		clear();
		copyrecersice(that.root);
	}
	return *this;
}

template<typename Type>
inline void BST<Type>::copyrecersice(Node* v)
{
	if (v != nullptr) {
		copyrecersice(v->left);
		insert(v->data);
		copyrecersice(v->right);
	}
}

template<typename T>
inline BST<T>::BST(const BST& that)
{
	operator=(that);
}

template<typename Type>
inline void BST<Type>::insert(const Type& v)
{
	if (!root)
	{
		root = new Node(v);
	}
	else {
		insertrecursice(v, root);
	}
}

template<typename Type>
inline void BST<Type>::insertrecursice(const Type& v, Node* Current)
{
	if (v >= Current->data)
	{
		if (Current->right)
		{
			insertrecursice(v, Current->right);
		}
		else {
			Current->right = new Node(v);
		}
	}
	else {
		if (Current->left)
		{
			insertrecursice(v, Current->left);
		}
		else {
			Current->left = new Node(v);
		}
	}
	return;
}

template<typename Type>
inline bool BST<Type>::findrecursice(const Type& v, Node* Current) const
{
	if (Current->data == v)
	{
		return true;
	}
	else if (v < Current->data && Current->left) {
		findrecursice(v, Current->left);
	}
	else if (v >= Current->data && Current->right) {
		findrecursice(v, Current->right);
	}
	else {
		return false;
	}
}

template<typename Type>
inline bool BST<Type>::findAndRemove(const Type& v)
{
	if (root)
	{
		Node* Curr = root;
		Node* Par = nullptr;
		while (true)
		{
			if (Curr->data == v)
			{
				break;
			}
			Par = Curr;
			if (v < Curr->data && Curr->left)
			{
				Curr = Curr->left;
				continue;
			}
			else if (v >= Curr->data && Curr->right)
			{
				Curr = Curr->right;
				continue;
			}
			else
				return false;
		}
		if (Curr->left && Curr->right) {//Case 2
			Node* TempCurr = Curr->right;
			Node* TempPar = Curr;
			while (TempCurr->left)
			{
				TempPar = TempCurr;
				TempCurr = TempCurr->left;
			}
			if (!Par)
			{
				swap(Curr, TempCurr);
				Type temp = TempCurr->data;
				TempCurr->data = Curr->data;
				Curr->data = temp;
			}
			else if (Par->left == Curr)
			{
				swap(Curr, TempCurr);
				Type temp = TempCurr->data;
				TempCurr->data = Curr->data;
				Curr->data = temp;
				Par->left = TempCurr;
			}
			else if (Par->right == Curr)
			{
				swap(TempCurr, Curr);
				Type temp = TempCurr->data;
				TempCurr->data = Curr->data;
				Curr->data = temp;
				Par->right = TempCurr;
			}
			Par = TempPar;
		}
		if (Curr->left || Curr->right) {//Case 1
			Case1(Curr, Par);
			return true;
		}
		else {//Case 0
			Case0(Curr, Par);
			return true;
		}
	}
	return false;
}

template<typename Type>
inline void BST<Type>::Case0(Node* Curr, Node* Par)
{
	if (!Par)
	{
		root = nullptr;
	}
	else if (Par->left == Curr)
	{
		Par->left = nullptr;
	}
	else if (Par->right == Curr)
	{
		Par->right = nullptr;
	}
	delete Curr;
}

template<typename Type>
inline void BST<Type>::Case1(Node* Curr, Node* Par)
{
	if (!Par)
	{
		if (Curr->right)
		{
			root = Curr->right;
		}
		else if (Curr->left)
		{
			root = Curr->left;
		}
	}
	else if (Par->left == Curr)
	{
		if (Curr->right)
		{
			Par->left = Curr->right;
		}
		else if (Curr->left) {
			Par->left = Curr->left;
		}
	}
	else if (Par->right == Curr) {
		if (Curr->right)
		{
			Par->right = Curr->right;
		}
		else if (Curr->left)
		{
			Par->right = Curr->left;
		}
	}
	delete Curr;
}

//template<typename Type>
//inline void BST<Type>::Case2(Node* Curr)
//{
//	Node* mini = Curr->left;
//	Node* TempPar = Curr;
//	while (mini->left != nullptr)
//	{
//		Par = mini;
//		mini = mini->left;
//	}
//	if (!Par)
//	{
//		swap(mini, Par);
//		Type temp = mini->data;
//		mini->data = Curr->data;
//		Curr->data = temp;
//	}
//	else if (Par->left == Curr)
//	{
//		swap(mini, Par);
//		Type temp = mini->data;
//		mini->data = Curr->data;
//		Curr->data = temp;
//		Par->left = mini;
//	}
//	else if (Par->right == Curr)
//	{
//		swap(mini, Par);
//		Type temp = mini->data;
//		mini->data = Curr->data;
//		Curr->data = temp;
//		Par->right = mini;
//	}
//}

template<typename Type>
inline bool BST<Type>::find(const Type& v) const
{
	if (root)
	{
		return findrecursice(v, root);
	}
	return false;
}

template<typename Type>
inline void BST<Type>::clear()
{
	if (root)
	{
		clearrecursice(root);
	}
	root = nullptr;
}

template<typename Type>
inline void BST<Type>::clearrecursice(Node* Current)
{
	if (Current->left){
		clearrecursice(Current->left);
	}
	if (Current->right) {
		clearrecursice(Current->right);
	}
	delete[] Current;
}

template<typename Type>
inline void BST<Type>::printInOrder() const
{
	if (root)
	{
		printrecursice(root);
		std::cout << std::endl;
	}
}

template<typename Type>
inline void BST<Type>::printrecursice(Node* Current) const
{
	if (Current->left)
	{
		printrecursice(Current->left);
	}
	std::cout << Current->data << ' ';
	if (Current->right)
	{
		printrecursice(Current->right);
	}
}


