#include <bits/stdc++.h>
using namespace std;
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	fstream file[3];
	file[0].open("in1.txt",ios::in);
	file[1].open("in2.txt",ios::in);
	file[2].open("out.txt",ios::out);
	int x,y;
	int times;
	double ans;
	char buf;
	file[0]>>times;
	for(int i=0;i<times;i++){
		file[0]>>x;file[0]>>buf;file[0]>>y;
		ans=log10(x)*y;
		file[2]<<floor(ans)+1<<'\n';
	}
	file[2]<<'\n';
	file[1]>>times;
	for(int i=0;i<times;i++){
		file[1]>>x;file[1]>>buf;file[1]>>y;
		ans=log10(x)*y;
		file[2]<<floor(ans)+1<<'\n';
	}
}

