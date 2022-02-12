#include <bits/stdc++.h>
using namespace std;
/*
	[0,0] [1,0] [2,0]
	[0,1] [1,1] [2,1]
	[0,2] [1,2] [2,2]
*/
int checkrow(char XO[3][3]){
	if(XO[0][0]==XO[1][0]&&XO[1][0]==XO[2][0]&&XO[0][0]==XO[2][0]&&XO[0][0]!='0') return XO[0][0]-'0';
	if(XO[0][1]==XO[1][1]&&XO[1][1]==XO[2][1]&&XO[0][1]==XO[2][1]&&XO[0][1]!='0') return XO[0][1]-'0';
	if(XO[0][2]==XO[1][2]&&XO[1][2]==XO[2][2]&&XO[0][2]==XO[2][2]&&XO[0][2]!='0') return XO[0][2]-'0';
	return 0;
}
int checkcol(char XO[3][3]){
	if(XO[0][0]==XO[0][1]&&XO[0][1]==XO[0][2]&&XO[0][2]==XO[0][0]&&XO[0][0]!='0') return XO[0][0]-'0';
	if(XO[1][0]==XO[1][1]&&XO[1][1]==XO[1][2]&&XO[1][2]==XO[1][0]&&XO[1][0]!='0') return XO[1][0]-'0';
	if(XO[2][0]==XO[2][1]&&XO[2][1]==XO[2][2]&&XO[2][0]==XO[2][2]&&XO[2][0]!='0') return XO[2][0]-'0';
	return 0;
}
int checkobl(char XO[3][3]){
	if(XO[0][0]==XO[1][1]&&XO[1][1]==XO[2][2]&&XO[2][2]==XO[0][0]&&XO[0][0]!='0') return XO[0][0]-'0';
	if(XO[2][0]==XO[1][1]&&XO[1][1]==XO[0][2]&&XO[0][2]==XO[2][0]&&XO[2][0]!='0') return XO[2][0]-'0';
	return 0;
}
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	fstream file[3];
	file[0].open("in1.txt",ios::in);
	file[1].open("in2.txt",ios::in);
	int n1,n2;
	char XO[3][3];
	vector<int> winner;
	if(file[0].fail()) cout<<"檔案1輸入失敗";
	else if(file[1].fail()) cout<<"檔案2輸入失敗";
	else{
		file[0]>>n1;
		for(int i=0;i<n1;i++){
			for(int y=0;y<3;y++){
				for(int x=0;x<3;x++){
					file[0]>>XO[x][y];

				}
			}
			if(checkrow(XO)!=0) winner.push_back(checkrow(XO));
			else if(checkcol(XO)!=0) winner.push_back(checkcol(XO));
			else if(checkobl(XO)!=0) winner.push_back(checkobl(XO));
			else winner.push_back(3);	
		}
			
		file[1]>>n2;
		for(int i=0;i<n2;i++){
			for(int y=0;y<3;y++){
				for(int x=0;x<3;x++){
					file[1]>>XO[x][y];
				}
			}
			if(checkrow(XO)!=0) winner.push_back(checkrow(XO));
			else if(checkcol(XO)!=0) winner.push_back(checkcol(XO));
			else if(checkobl(XO)!=0) winner.push_back(checkobl(XO));
			else winner.push_back(3);	
		}
		file[2].open("out.txt",ios::out);
		for(int i=0;i<n1;i++){
			file[2]<<winner[i]<<'\n';
		}
		file[2]<<'\n';
		for(int i=0;i<n2;i++){
			file[2]<<winner[i+n1]<<'\n';
		}
	}
	
}


