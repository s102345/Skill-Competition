#include <bits/stdc++.h>
using namespace std;
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	fstream file;
	file.open("in.txt",ios::in);
	if(file.fail()) cout<<"檔案無法開啟";
	else{
		string buf;
		double money[15];
		int day[15]={1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
		double pre[16];
		double b[15];
		double a,x,y,buf1,buf2;
		for(int i=0;i<15;i++){
			b[i]=0;
			pre[i]=0;
		}
		getline(file,buf); getline(file,buf); getline(file,buf); //三行垃圾資訊 
		for(int i=0;i<15;i++){
			file>>money[i];
		}
		for(int i=0;i<6;i++){
			x=0;y=0;
			for(int j=0;j<10;j++){
				x+=day[i+j];
				y+=money[i+j];
			}
			x/=10;y/=10;
			buf1=0;buf2=0;
			for(int j=0;j<10;j++){
				buf1+=(day[i+j]-x)*(money[i+j]-y);
				buf2+=(day[i+j]-x)*(day[i+j]-x);
			};
			b[i+9]=buf1/buf2;
			a=y-b[i+9]*x;
			pre[i+10]=a+b[i+9]*(i+11);
			/*cout<<"Pre:"<<pre[i+10]<<'\n';	
			cout<<"a:"<<a<<'\n';
			cout<<"b:"<<b[i+9]<<'\n';
			cout<<"x:"<<x<<'\n';
			cout<<"y:"<<y<<'\n';*/				
		}
		cout<<"直線斜率b:"<<'\n';
		for(int i=0;i<15;i++){
			if(b[i]==0){
				cout<<"0.0 ";
			}
			else{
				cout<<round(b[i]*10)/10<<" ";
			}			
		}
		cout<<'\n'<<"價格預測:"<<'\n';
		for(int i=0;i<15;i++){
			if(b[i]==0){
				cout<<"0.0 ";
			}
			else{
				cout<<round(pre[i]*10)/10<<" ";
			}	
		}
	} 
}

