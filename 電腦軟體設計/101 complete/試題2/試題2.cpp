// 試題2.cpp : 此檔案包含 'main' 函式。程式會於該處開始執行及結束執行。
//

#include <iostream>
#include <iomanip>
using namespace std;
int main()
{
	double A[3][3];
	double a, b;
	double p12, p13, p23;
	double B[3][3];
	double total;
	while (1) {
		cout << "輸入比值：\n";
		cout << "請輸入「專業能力」對「通識素養」的指標比值(輸入兩個數值)：";
		cin >> a >> b;
		p12 = a / b;
		cout << "請輸入「專業能力」對「合群性」的指標比值(輸入兩個數值)：";
		cin >> a >> b;
		p13 = a / b;
		cout << "請輸入「通識素養」對「合群性」的指標比值(輸入兩個數值)：";
		cin >> a >> b;
		p23 = a / b;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (i == j) A[i][j] = 1;
				else {
					if (i == 0 && j == 1) A[i][j] = p12;
					if (i == 0 && j == 2) A[i][j] = p13;
					if (i == 1 && j == 2) A[i][j] = p23;
					if (i == 1 && j == 0) A[i][j] = 1 / p12;
					if (i == 2 && j == 0) A[i][j] = 1 / p13;
					if (i == 2 && j == 1) A[i][j] = 1 / p23;
				}
			}
		}
		cout << "顯示比值矩陣：\n";
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				cout << fixed << setprecision(3) << A[i][j] << " ";
			}
			cout << '\n';
		}
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				total = 0;
				for (int k = 0; k < 3; k++) {
					total += A[k][j];
				}
				B[i][j] = A[i][j] / total;
			}
		}
		double w[3] = { 0,0,0 };
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				w[i] += B[i][j];
			}
			w[i] /= 3;
		}
		cout << "顯示指標的權重：";
		for (int i = 0; i < 3; i++) {
			cout << "w" << i + 1 << ":" << w[i] << "    ";
		}
		double LM = 0;
		for (int i = 0; i < 3; i++) {
			total = 0;
			for (int j = 0; j < 3; j++) {
				total += A[j][i];
			}
			LM += w[i] * total;
		}
		cout << "\n顯示最大特徵值LundaMax=" << LM;
		double CR;
		CR = (LM - 3) / (2 * 0.58);
		cout << "\n顯示一致性比率CR=" << CR;
		if (CR < 0.1) cout << "。CR小於0.1，符合一致性。";
		else cout << "。不符合一致性";
		cout << "\n繼續否？<y or n>";
		char c;
		cin >> c;
		if (c == 'n') break;
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
