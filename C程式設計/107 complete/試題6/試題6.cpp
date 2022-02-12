#include <bits/stdc++.h>
using namespace std;
int Mod(int x,int y){
	if(x>0) return x%y;
	while(x<0){
		x+=y;
	}
	return x;
}
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	fstream file[3];
	file[0].open("in1.txt",ios::in);
	file[1].open("in2.txt",ios::in);
	file[2].open("out.txt",ios::out);
	int times,ticks;
	int am,aM,bm,bM,mm,mM;
	file[0]>>times;
	for(int i=0;i<times;i++){
		ticks=0;
		file[0]>>am>>aM>>bm>>bM>>mm>>mM;
		for(int a=am;a<=aM;a++){
			for(int b=bm;b<=bM;b++){
				for(int m=mm;m<=mM;m++){
					if(Mod(a-b,m)==Mod(a+b,m)) ticks++;				
				}
			}
		}
		file[2]<<ticks<<'\n';
	}
	file[2]<<'\n';
	file[1]>>times;
	for(int i=0;i<times;i++){
		ticks=0;
		file[1]>>am>>aM>>bm>>bM>>mm>>mM;
		for(int a=am;a<=aM;a++){
			for(int b=bm;b<=bM;b++){
				for(int m=mm;m<=mM;m++){
					if(Mod(a-b,m)==Mod(a+b,m)) ticks++;
				}
			}
		}
		file[2]<<ticks<<'\n';
	}
}

