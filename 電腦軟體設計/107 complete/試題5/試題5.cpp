#include <bits/stdc++.h>
using namespace std;
struct Array{
	int max;
	int b;
	int e;
};
bool cmp(Array &a,Array &b){
	return a.max>b.max ||((a.max == b.max)&&(a.b>b.b))||((a.max == b.max)&&(a.b==b.b)&&(a.e<b.e));
}
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	Array buf;
	vector<struct Array> list; 
	vector<int> data;
	int i,j;
	int num,buffer=0;
	while(cin>>num){
		data.resize(num);
		list.resize(num*num);
		for(i=0;i<num;i++){
			cin>>data[i];
		}
		for(i=0;i<num;i++){
			buf.b=i;
			for(j=i;j<num;j++){
				if(buffer+data[j]<0){
					break;
				}
				buffer+=data[j];
				buf.e=j;
				buf.max=buffer;
				list.push_back(buf);
			}
			buffer=0;
		}
		sort(list.begin(),list.end(),cmp);
		cout<<list[0].max<<'\n'<<list[0].b<<" "<<list[0].e<<'\n';
		list.clear();
		data.clear();
	}
}

