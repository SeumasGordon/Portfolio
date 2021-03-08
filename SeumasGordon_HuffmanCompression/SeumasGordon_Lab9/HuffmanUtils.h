#pragma once
#include <vector>
#include "HuffmanDef.h"
#include "BitStream.h"
using namespace std;

struct cmp{
    bool operator() (const HuffNode* a, const HuffNode* b) {
        return (a->freq > b->freq);
    }
};
/////////////////////////////////////////////////////////////////////////////
// Function : generateFrequencyTable
// Parameters : filePath - the path to the file to open
// Return : unsigned int* - a dynamically allocated frequency table 
// Notes : Dynamically allocates an array of 257 unsigned ints representing
//		the count of each character in the file (the index in the array
//		is the char's value). [256] is the total count
/////////////////////////////////////////////////////////////////////////////
unsigned int* generateFrequencyTable(const char* filePath) {
    ifstream file;
    file.open(filePath);
    unsigned int* table;
    table = new unsigned int[257];
    for (int i = 0; i < 257; i++)    
        table[i] = 0;
    char c;
    while (!file.eof())
    {
        c = file.get();
        if (file.eof())       
            break;        
        table[(unsigned char)c]++;
        //table[256]++;
    }
    return table;
}
/////////////////////////////////////////////////////////////////////////////
// Function : generateLeafList
// Parameters : freqTable - the frequency table to be used to generate leaf 
//			nodes
// Return : vector<HuffNode*> - a vector containing the leaf nodes
/////////////////////////////////////////////////////////////////////////////
vector<HuffNode*> generateLeafList(unsigned int* freqTable) {
    vector<HuffNode*> Vec;
    for (int i = 0; i < 256; i++)
        if (freqTable[i] > 0){
            HuffNode* node = new HuffNode;
            node->freq = freqTable[i];
            node->value = i;
            node->left = nullptr;
            node->right = nullptr;
            Vec.push_back(node);
        }   
    return Vec;
}
/////////////////////////////////////////////////////////////////////////////
// Function : generateHuffmanTree
// Parameters : leafList - the leaf nodes that will appear in our huffman 
//			tree
// Return : HuffNode* - the root of the generated tree (it will be the top
//		of the queue)
/////////////////////////////////////////////////////////////////////////////
HuffNode* generateHuffmanTree(vector<HuffNode*>& leafList) {
    priority_queue <HuffNode*, vector<HuffNode*>, cmp> Vec;
    for (int i = 0; i < leafList.size(); i++)
        Vec.push(leafList[i]);    
    while (Vec.size() > 1){
        HuffNode* tmp = Vec.top();
        HuffNode* parent = new HuffNode;
        HuffNode* rightNode;
        parent->left = Vec.top();
        tmp = Vec.top();
        tmp->parent = parent;
        Vec.pop();
        parent->right = Vec.top();
        rightNode = Vec.top();
        Vec.pop();
        rightNode->parent = parent;
        parent->parent = nullptr;
        parent->value = -1;
        parent->freq = tmp->freq + rightNode->freq;
        Vec.push(parent);
    }
    return Vec.top();
}
/////////////////////////////////////////////////////////////////////////////
// Function : generateEncodingTable
// Parameters : leafList - a vector containing all the leaves in the tree
// Return : vector<int>* - a dynamically-allocated array of 256 vectors
// Notes : each index in the encoding table corresponds to an index in the 
//			frequency table
/////////////////////////////////////////////////////////////////////////////
vector<int>* generateEncodingTable(vector<HuffNode*>& leafList) {
    vector<int>* Vec = new vector<int>[256];
    HuffNode* node;
    for (int i = 0; i < leafList.size(); i++){
        int num = leafList[i]->value;
        node = leafList[i];
        while (node->parent != nullptr){
            if (node->parent->right == node) 
                Vec[num].push_back(1);           
            else 
                Vec[num].push_back(0);           
            node = node->parent;
        }
        reverse(Vec[num].begin(), Vec[num].end());
    }
    return Vec;
}
/////////////////////////////////////////////////////////////////////////////
// Function : writeHuffmanFile
// Parameters : 	inputFilePath - the path of the file to open for input
//			outputFilePath - the path of the file to open for output
//			freqTable - the frequency table
//			encodingTable - the encoding table
// Notes : open the input file using ifstream, read characters one at a time,
//		write the encoding path for that character to BitOStream
/////////////////////////////////////////////////////////////////////////////
void writeHuffmanFile(const char* inputFilePath, const char* outputFilePath,
    unsigned int* freqTable, vector<int>* encodingTable) {
    ifstream file;
    file.open(inputFilePath);
    BitOStream name(outputFilePath, (const char*)freqTable, 1028);
    char c;
    while (!file.eof()){
        c = file.get();
        if (file.eof())
            break;
        name << encodingTable[c];
    }
    file.close();
    name.close();
}
    /////////////////////////////////////////////////////////////////////////////
    // Function : cleanup
    // Notes : delete each array, and write recursive helper function to delete
    //		the tree in post-order
    /////////////////////////////////////////////////////////////////////////////
void helper(HuffNode* huffTree) {
    if (huffTree != nullptr){
        if (huffTree->left)
            helper(huffTree->left);
        if (huffTree->right)
            helper(huffTree->right);
        delete huffTree;
    }
}
void cleanup(unsigned int* freqTable, HuffNode* huffTree, vector<int>* encodingTable) {
    helper(huffTree);
    delete[] freqTable;
    delete[] encodingTable;
}
    /////////////////////////////////////////////////////////////////////////////
    // Function : decodeHuffmanFile
    // Parameters :	inputFilePath - the file to open and decode
    //			outputFilePath - the decoded mesasge, written to a file
    // Notes: Must re-generate the leaflist, tree, and encoding table using
    //		the other functions. The frequency table is pulled from the file
    //		via the header chunk.
    /////////////////////////////////////////////////////////////////////////////
void decodeHuffmanFile(const char* inputFilePath, const char* outputFilePath) {
    unsigned int table[257];
    ofstream file;
    file.open(outputFilePath);
    BitIStream name(inputFilePath, (char*)table, 1028);

    vector<HuffNode*> leaf = generateLeafList(table);
    HuffNode* tree = generateHuffmanTree(leaf);
    vector<int>* encodetable = generateEncodingTable(leaf);

    while (!name.eof()){
        HuffNode* node;
        node = tree;
        while (node->value == -1){
            int direction;
            name >> direction;
            if (direction == 0)
                node = node->left;           
            else 
                node = node->right;           
        }
        file << (char)node->value;
    }
    cleanup(nullptr, tree, encodetable);
}
