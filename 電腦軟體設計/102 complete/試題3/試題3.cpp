// 試題3.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//

#include <iostream>
#include <fstream>
#include <vector>
#include <queue>
#include <utility>
#include <stack>
using namespace std;
#define pii pair<int,int>
int main()
{
	fstream file;
	file.open("in.txt", ios::in);
	int C[7][7];
	int parent[7];
	int w[7];
	priority_queue<pii,vector<pii>,greater<pii> > pq;
	int a, b;
	for (int i = 0; i < 7; i++)  w[i]=999 ,parent[i] = 0;
	w[0] = 0;
	for (int i = 0; i < 7; i++) for (int j = 0; j < 7; j++) C[i][j] = 0;
	if (!file.fail()) {
		for (int i = 0; i < 9; i++) {
			file >> a >> b;
			file >> C[a-1][b-1];
		}
	}
	pq.emplace(make_pair(0,1));
	while (!pq.empty())
	{
		for (int i = 0; i < 7; i++) {
			if (C[pq.top().second - 1][i] == 0) continue;
			else {
				pq.emplace(make_pair(C[pq.top().second - 1][i] + pq.top().first, i + 1));
				if (w[i] > pq.top().first + C[pq.top().second - 1][i]) {
					parent[i] = pq.top().second;
					w[i] = pq.top().first + C[pq.top().second - 1][i];
				}
			}
		}
		pq.pop();

	}
	cout << "最低成本值總和：" << w[6]<<'\n';
	cout << "路徑次序：";
	a = 7;
	stack<int> buf;
	while (a != 0) {
		buf.push(a);
		a = parent[a-1];
	}
	while (!buf.empty()) {
		cout << buf.top()<<" ";
		buf.pop();
	}
	cout << "\n連線數值：";
	a = 7;
	while (a != 0) {
		if (a > 2) buf.push(w[a - 1] - w[parent[a - 1] - 1]);
		else buf.push(w[a - 1]);
		a = parent[a-1];
	}
	while (!buf.empty()) {
		cout << buf.top()<<" ";
		buf.pop();
	}
}


// 執行程式: Ctrl + F5 或 [偵錯] > [啟動但不偵錯] 功能表
// 偵錯程式: F5 或 [偵錯] > [啟動偵錯] 功能表

// 開始使用的提示: 
//   1. 使用 [方案總管] 視窗，新增/管理檔案
//   2. 使用 [Team Explorer] 視窗，連線到原始檔控制
//   3. 使用 [輸出] 視窗，參閱組建輸出與其他訊息
//   4. 使用 [錯誤清單] 視窗，檢視錯誤
//   5. 前往 [專案] > [新增項目]，建立新的程式碼檔案，或是前往 [專案] > [新增現有項目]，將現有程式碼檔案新增至專案
//   6. 之後要再次開啟此專案時，請前往 [檔案] > [開啟] > [專案]，然後選取 .sln 檔案
