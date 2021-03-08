#pragma once

#include <fstream>
#include <vector>
using namespace std;

class BitOStream {
	ofstream theStream;
	char buffer;
	int currentBit;

public:
	/////////////////////////////////////////////////////////////////////////////// Function : constructor
	// Parameters : 	filePath - the path of the file to open for output
	//			headerChunk - a chunk of data to be written at the 
	//					beginning of the file
	//			numberOfBytes - the number of bytes of header information 
	//					to write out
	/////////////////////////////////////////////////////////////////////////////
	BitOStream(const char* filePath, const char* headerChunk = NULL, int numberOfBytes = 0) {
		buffer = 0;
		currentBit = 7;
		theStream.open(filePath);
		if (NULL != headerChunk)
		{
			theStream.write(headerChunk, numberOfBytes);
		}
	}
	/////////////////////////////////////////////////////////////////////////////
	// Function : destructor
	/////////////////////////////////////////////////////////////////////////////
	~BitOStream() {
		close();
	}
	/////////////////////////////////////////////////////////////////////////////
	// Function : insertion operator
	// Parameters : bits - a vector containing some number of 1's and 0's to 
	//						stream out to the file
	// Return : BitOStream& - the stream (allows for daisy-chaining insertions)
	////////////////////////////////////////////////////////////////////////////
	BitOStream& operator<<(vector<int>& bits) {
		for (unsigned int i = 0; i < bits.size(); i++){
			if (bits[i] == 1){
				buffer |= 1 << currentBit;
			}
			--currentBit;
			if (currentBit < 0){
				theStream.write(&buffer, 1);
				buffer = 0;
				currentBit = 7;
			}
		}
		return *this;
	}
	/////////////////////////////////////////////////////////////////////////////
	// Function : close
	// Notes : closes the file stream - if remaining bits exist, they are written
	//			to the file with trailing 0's. if no remaining bits exist, 
	//			simply close the file
	/////////////////////////////////////////////////////////////////////////////
	void close() {
		if (currentBit < 7){
			theStream.write(&buffer, 1);
		}
		theStream.close();
	}

};
class BitIStream {
	ifstream theStream;
	char buffer;
	int currentBit;

public:
	/////////////////////////////////////////////////////////////////////////////
	// Function : constructor
	// Parameters : 	filePath - the path of the file to open for input
	//			headerChunk - a chunk of data to be read from the 
	//					beginning of the file
	//			numberOfBytes - the number of bytes of header information 
	//					to read in
	/////////////////////////////////////////////////////////////////////////////
	BitIStream(const char* filePath, char* headerChunk = NULL, int numberOfBytes = 0) {
		theStream.open(filePath);
		if (NULL != headerChunk){
			theStream.read(headerChunk, numberOfBytes);
		}
		currentBit = 7;
		theStream.read(&buffer, 1);
	}
	/////////////////////////////////////////////////////////////////////////////
	// Function : destructor
	/////////////////////////////////////////////////////////////////////////////
	~BitIStream() {
		close();
	}
	/////////////////////////////////////////////////////////////////////////////
	// Function : extraction operator
	// Parameters : bit - store the next bit here
	// Return : BitIStream& - the stream (allows for daisy-chaining extractions)
	/////////////////////////////////////////////////////////////////////////////
	BitIStream& operator>>(int& bit) {
		if (currentBit < 0){
			currentBit = 7;
			theStream.read(&buffer, 1);
		}
		if (buffer & (1 << currentBit)){
			bit = 1;
		}
		else {
			bit = 0;
		}
		--currentBit;

		return *this;
	}
	/////////////////////////////////////////////////////////////////////////////
	// Function : eof
	// Return : true if we are at the end of the file, false otherwise
	// Notes : should only return true when we have given the user every byte
	//		from the file and every bit from the buffer
	/////////////////////////////////////////////////////////////////////////////
	bool eof() {
		return (theStream.eof());
	}
	/////////////////////////////////////////////////////////////////////////////
	// Function : close
	// Notes : close the file
	/////////////////////////////////////////////////////////////////////////////
	void close() {
		theStream.close();
	}

};