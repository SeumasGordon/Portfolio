#pragma once

template<typename Type> class DLLIter;

template<typename Type> class DLList {
	friend class DLLIter<Type>;
private:
	struct Node
	{
		Type data;
		Node* next, * prev;
		Node(const Type& _data, Node* _next = nullptr, Node* _prev = nullptr) : data(_data), next(_next), prev(_prev) {};
	};
	Node* head = nullptr;
	Node* tail = nullptr;
	unsigned int Size = 0;
	void helper(Node* tmp) {
		if (tmp != nullptr)
		{
			helper(tmp->next);
			addHead(tmp->data);
		}
	}

public:
	DLList() {}
	~DLList();
	DLList<Type>& operator=(const DLList<Type>& that);
	DLList(const DLList<Type>& that);
	void addHead(const Type& v);
	void addTail(const Type& v);
	void clear();
	void insert(DLLIter<Type>& index, const Type& v);
	void remove(DLLIter<Type>& index);
};
template<typename Type> class DLLIter {
	friend class DLList<Type>;
private:
	DLList<Type>* ptrList;
	typename DLList<Type>::Node* curr;

public:
	DLLIter(DLList<Type>& listToIterate);
	void beginHead();
	void beginTail();
	bool end() const;
	DLLIter<Type>& operator++();
	DLLIter<Type>& operator--();
	Type& current() const;
};

template<typename Type>
inline DLList<Type>::~DLList()
{
	clear();
}

template<typename Type>
inline DLList<Type>& DLList<Type>::operator=(const DLList<Type>& that)
{
	// TODO: insert return statement here
	if (this != &that)
	{
		clear();
		helper(that.head);
	}
	return *this;
}

template<typename Type>
inline DLList<Type>::DLList(const DLList<Type>& that)
{
	operator=(that);
}

template<typename Type>
inline void DLList<Type>::addHead(const Type& v)
{
	Node* tmp = new Node(v);
	if (head == nullptr) {
		tail = tmp;
		head = tmp;
	}
	else {
		tmp->next = head;
		head->prev = tmp;
	}
	head = tmp;
	Size++;
}

template<typename Type>
inline void DLList<Type>::addTail(const Type& v)
{
	Node* tmp = new Node(v);
	if (tail == nullptr) {
		tail = tmp;
		head = tmp;
	}
	else {
		tmp->prev = tail;
		tail->next = tmp;
	}
	tail = tmp;
	Size++;
}

template<typename Type>
inline void DLList<Type>::clear()
{
	Size = 0;
	tail = nullptr;
	while (head != nullptr) {
		Node* tmp = head->next;
		delete head;
		head = tmp;
	}
}

template<typename Type>
inline void DLList<Type>::insert(DLLIter<Type>& index, const Type& v)
{
	if (index.curr == nullptr)
	{
		return;
	}
	Size++;
	if (index.curr->prev == nullptr)
	{
		addHead(v);
		index.curr = head;

		return;
	}

	Node* tmp = new Node(v, index.curr, index.curr->prev);
	index.curr->prev->next = tmp;
	index.curr = tmp;

}

template<typename Type>
inline void DLList<Type>::remove(DLLIter<Type>& index)
{
	if (index.curr == nullptr)
	{
		return;
	}
	Size--;
	if (index.curr->prev == nullptr && index.curr->next == nullptr) {
		head = nullptr;
		tail = nullptr;
		delete index.curr;
		index.curr = nullptr;
		return;
	}
	else if (index.curr->prev == nullptr)
	{
		Node* tmp = index.curr->next;
		head = index.curr->next;
		delete index.curr;
		index.curr = tmp;
		head->prev = nullptr;
		return;
	}
	else if (index.curr->next == nullptr) {
		Node* tmp = index.curr->prev;
		tail = index.curr->prev;
		delete index.curr;
		index.curr = nullptr;
		tail->next = nullptr;
		return;
	}
	else {
		Node* tmp = index.curr->prev;
		index.curr->prev->next = index.curr->next;
		index.curr->next->prev = index.curr->prev;
		delete index.curr;
		index.curr = tmp;
		return;
	}
}
//
// DLLIter functions
//

template<typename Type>
inline DLLIter<Type>::DLLIter(DLList<Type>& listToIterate)
{
	ptrList = &listToIterate;
	//begin
}

template<typename Type>
inline void DLLIter<Type>::beginHead()
{
	curr = ptrList->head;
}

template<typename Type>
inline void DLLIter<Type>::beginTail()
{
	curr = ptrList->tail
;
}

template<typename Type>
inline bool DLLIter<Type>::end() const
{
	if (curr == nullptr) {
		return true;
	}
	return false;
}

template<typename Type>
inline DLLIter<Type>& DLLIter<Type>::operator++()
{
	// TODO: insert return statement here
	if (curr != nullptr)
	{
		curr = curr->next;
	}
	return *this;
}

template<typename Type>
inline DLLIter<Type>& DLLIter<Type>::operator--()
{
	// TODO: insert return statement here
	if (curr != nullptr)
	{
		curr = curr->prev;
	}
	return *this;
}

template<typename Type>
inline Type& DLLIter<Type>::current() const
{
	// TODO: insert return statement here
	return curr->data;
}
