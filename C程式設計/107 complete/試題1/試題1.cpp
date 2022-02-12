#include <bits/stdc++.h>
using namespace std;
int main(){
	fstream file[3];
	pair<int,int> num;
	vector<pair<int,int> > count;
	file[0].open("in1.txt",ios::in);
	file[1].open("in2.txt",ios::in);
	int n1,n2;
	string text;
	stringstream ss;
	int space,Ss,Sper;
	string buf;
	if(!file[0]) cout<<"檔案1無法開啟\n";
	else if(!file[1]) cout<<"檔案2無法開啟\n";
	else{
		file[0]>>n1;	
		getline(file[0],text);	
		for(int i=0;i<n1;i++){
			Ss=0;space=0;
			ss.clear();
			ss.str(" ");
			getline(file[0],text);
			ss<<text;
			while(1){
				ss>>buf;
				if(ss.fail()) break;
				Sper=0;
				space++;
				for(int i=0;i<buf.length();i++){
					if(buf[i]=='S'||buf[i]=='s') Sper=1; 
					if(buf[i]==','||buf[i]==';'||buf[i]=='!'||buf[i]=='.'){
						if(i+1!=buf.length()){
							if(buf[i+1]>'a'&&buf[i+1]<'z') space++;
						}
					}
				} 
				Ss+=Sper;
			}
			num.first=space;
			num.second=Ss;
			count.push_back(num);
		}
		file[1]>>n2;	
		getline(file[1],text);	
		for(int i=0;i<n2;i++){
			Ss=0;space=0;
			ss.clear();
			ss.str(" ");	
			getline(file[1],text);
			ss<<text;
			while(1){
				ss>>buf;
				if(ss.fail()) break;
				Sper=0;
				space++;
				for(int i=0;i<buf.length();i++){
					if(buf[i]=='S'||buf[i]=='s') Sper=1; 
					if(buf[i]==','||buf[i]==';'||buf[i]=='!'||buf[i]=='.'){
						if(i+1!=buf.length()){
							if(buf[i+1]>'a'&&buf[i+1]<'z') space++;
						}
					}
				} 
				Ss+=Sper;
			}
			num.first=space;
			num.second=Ss;
			count.push_back(num);
		}
		file[2].open("out.txt",ios::out);
		for(int i=0;i<n1;i++){
			file[2]<<count[i].first<<","<<count[i].second<<'\n';
		}
		file[2]<<'\n';
		for(int i=0;i<n2;i++){
			file[2]<<count[i+n1].first<<","<<count[i+n1].second<<'\n';
		}
	}
	//ios::sync_with_stdio(false);
	//cin.tie(0);
}

