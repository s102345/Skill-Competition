#include <bits/stdc++.h>
using namespace std;
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	int times;
	int x,y;
	bool flag=true;
	string buf;
	vector<int> list;
	vector<int> origin;
	fstream file[3];
	file[0].open("in1.txt",ios::in);
	file[1].open("in2.txt",ios::in);
	file[2].open("out.txt",ios::out);
	file[0]>>times;
	getline(file[0],buf);
	for(int i=0;i<times;i++){
		getline(file[0],buf);
		x=0;
		list.clear();
		for(int j=0;j<buf.length();j++){
			if(buf[j]==','||buf[j]=='['||buf[j]==']') continue;
			else if(buf[j+1]<='9'&&buf[j+1]>='0'){
				x+=(buf[j]-'0');
				x*=10;
			}
			else{
				x+=(buf[j]-'0');
				list.push_back(x);
				x=0;			
			}
		}
		origin=list;
		sort(origin.begin(),origin.end());
		file[2]<<'[';
		for(int j=0;j<origin.size();j++){
			if(origin[j]==list[j]){
				file[2]<<'['<<origin[j]<<']';
				origin[j]=-1;
			}
			else{
				if(origin[j]==-1){
					continue;
				}
				else{
					file[2]<<'[';
					x=origin[j];
					y=j;
					file[2]<<origin[j];
					while(x!=list[y]){
						origin[y]=-1;
						y=list[y]-1;
						file[2]<<','<<origin[y];
					}
					origin[y]=-1;
					file[2]<<']';
				}
			}
			for(int l=0;l<origin.size();l++){
				if(origin[l]==-1) flag=false;
				else{
					flag=true;
					break;
				}
			}
			if(!flag) break;
			if(j!=origin.size()-1) file[2]<<',';
		}
		file[2]<<']'<<'\n';
	}
	file[2]<<'\n';
	file[1]>>times;
	getline(file[1],buf);
	for(int i=0;i<times;i++){
		getline(file[1],buf);
		x=0;
		list.clear();
		for(int j=0;j<buf.length();j++){
			if(buf[j]==','||buf[j]=='['||buf[j]==']') continue;
			else if(buf[j+1]<='9'&&buf[j+1]>='0'){
				x+=(buf[j]-'0');
				x*=10;
			}
			else{
				x+=(buf[j]-'0');
				list.push_back(x);
				x=0;			
			}
		}
		origin=list;
		sort(origin.begin(),origin.end());
		file[2]<<'[';
		for(int j=0;j<origin.size();j++){
			if(origin[j]==list[j]){
				file[2]<<'['<<origin[j]<<']';
				origin[j]=-1;
			}
			else{
				if(origin[j]==-1){
					continue;
				}
				else{
					file[2]<<'[';
					x=origin[j];
					y=j;
					file[2]<<origin[j];
					while(x!=list[y]){
						origin[y]=-1;
						y=list[y]-1;
						file[2]<<','<<origin[y];
					}
					origin[y]=-1;
					file[2]<<']';
				}
			}
			for(int l=0;l<origin.size();l++){
				if(origin[l]==-1) flag=false;
				else{
					flag=true;
					break;
				}
			}
			if(!flag) break;
			if(j!=origin.size()-1) file[2]<<',';
		}
		file[2]<<']'<<'\n';
	}
}

