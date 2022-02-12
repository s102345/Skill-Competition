#include <bits/stdc++.h>
using namespace std;
bool happynum(int x){
	vector<int> num;
	vector<int> before;
	int sum;
	while(1){			
		num.clear();
		before.push_back(x);
		while(x>9){
			num.push_back(x%10);
			x/=10;
		}
		num.push_back(x);
		sum=0;
		for(int i=0;i<num.size();i++){
			sum+=num[i]*num[i];
		}
		x=sum;
		for(int i=0;i<before.size();i++){
			if(x==before[i]) return false;
		}
		if(x==1) return true;
	}	
}
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	fstream file[3];
	file[0].open("in1.txt",ios::in);
	file[1].open("in2.txt",ios::in);
	int n1,n2;
	int buf;
	vector<bool> result;
	if(file[0].fail()) cout<<"無法讀取檔案1";
	else if(file[1].fail()) cout<<"無法讀取檔案2";
	else{
		file[0]>>n1;
		for(int i=0;i<n1;i++){
			file[0]>>buf;
			result.push_back(happynum(buf));
		}
		file[1]>>n2;
		for(int i=0;i<n2;i++){
			file[1]>>buf;
			result.push_back(happynum(buf));
		}
		file[2].open("out.txt",ios::out);
		for(int i=0;i<n1;i++){
			if(result[i]) file[2]<<"T\n";
			else file[2]<<"F\n";
		}
		file[2]<<'\n';
		for(int i=0;i<n2;i++){
			if(result[i+n1]) file[2]<<"T\n";
			else file[2]<<"F\n";
		}
	}
}

