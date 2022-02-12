#include <bits/stdc++.h>
using namespace std;
void rotate(vector<int> &a,int s,int b){
	for(int i=b;i>0;i--)
		swap(a[s+i-1],a[s+i]);
}//s為起始位置 b為間隔  
void permutation(vector<vector<int> > &p,vector<int> a,int s){
	if(s==a.size()) return;
	vector<int> buf;
	for(int i=0;i+s<a.size();i++){
		buf=a;
		rotate(buf,s,i);
		permutation(p,buf,s+1);
		if(s==a.size()-2) p.push_back(buf);
	}
}
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	fstream file[3];
	int x,target,times;
	int timer=0;
	vector<int> a;
	vector<vector<int> > p;
	string buf;
	file[0].open("in1.txt",ios::in);
	file[1].open("in2.txt",ios::in);
	file[2].open("out.txt",ios::out);
	if(!file[0]) file[2]<<"檔案1無法讀取";
	else if(!file[1]) file[2]<<"檔案2無法讀取";
	else{
		file[0]>>times;
		getline(file[0],buf);
		for(int i=0;i<times;i++){
			timer=0;
			target=0;
			a.clear();
			p.clear();
			getline(file[0],buf);
			x=(buf[0]-'0');
			for(int j=0;j<x;j++){
				a.push_back(buf[2*(j+1)]-'0');
			} 
			for(int j=2*(x+1);j<buf.length();j++){
				target+=(buf[j]-'0');
				if(j+1!=buf.length()) target*=10; 
			}
			permutation(p,a,0);
			for(int j=0;j<x;j++){
				file[2]<<p[target-1][j];
			}
			file[2]<<'\n';
		}
		file[2]<<'\n';
		file[1]>>times;
		getline(file[1],buf);
		for(int i=0;i<times;i++){
			timer=0;
			target=0;
			a.clear();
			p.clear();
			getline(file[1],buf);
			x=(buf[0]-'0');
			for(int j=0;j<x;j++){
				a.push_back(buf[2*(j+1)]-'0');
			} 
			for(int j=2*(x+1);j<buf.length();j++){
				target+=(buf[j]-'0');
				if(j+1!=buf.length()) target*=10; 
			}
			permutation(p,a,0);
			for(int j=0;j<x;j++){
				file[2]<<p[target-1][j];
			}
			file[2]<<'\n';
		}
	} 
}

