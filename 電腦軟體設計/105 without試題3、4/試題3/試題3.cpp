#include <bits/stdc++.h>
using namespace std;
struct point{
	int x,y;
	point(int a,int b){
		x=a;
		y=b;
	}
};
void print(int x,int y){
	cout<<"("<<x<<","<<y<<")"<<'\n';
}
void drawLine(struct point p1,struct point p2){
	if(p2.x-p1.x<p2.y-p1.y) {
		swap(p1.x,p2.x);
		swap(p1.y,p2.y);
	}
	int dx=p2.x-p1.x;
	int dy=p2.y-p1.y;
	double error =0;
	double m=(double)dy/dx;
	int y=p1.y;
	for(int x=p1.x;x<=p2.x;x++){
		print(x,y);
		error+=m;
		if(abs(error)>=0.5){
			if(m>0)y+=1;
			else y-=1;
			error-=1; 
		}	
	}	
}
void drawTri(struct point p1,struct point p2,struct point p3){
	drawLine(p1,p2);
	drawLine(p2,p3);
	drawLine(p1,p3);
}
int menu(){
	cout<<"�п�ܾާ@���ءG"<<'\n';
	cout<<"	<1>��J���I�y��<x1,y1>,<x2,y2>ø�@�u�G"<<'\n';
	cout<<"	<2>��J�T�ӳ��I�y��<x1,y1>,<x2,y2>,<x3,y3>ø�T���ΡG"<<'\n';
	cout<<"	<3>�W�D�T���Τ���½��G"<<'\n';
	cout<<"�п�ܡG";	
	int n;
	cin>>n;
	return n;
}
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	int n;
	int x1,x2,x3,y1,y2,y3;
	while(1){
		switch(menu()){
			case 1:
				cout<<"<x1,y1>,<x2,y2>";
				cin>>x1>>y1>>x2>>y2;
				drawLine(point(x1,y1),point(x2,y2));
				break;
			case 2:
				cout<<"<x1,y1>,<x2,y2>,<x3,y3>";				
				cin>>x1>>y1>>x2>>y2>>x3>>y3;
				drawTri(point(x1,y1),point(x2,y2),point(x3,y3));
				break;
			case 3:
				double mx=(x1+x2)/2;
				double a=x3-mx; 
				if(x3>mx) x3-=2*abs(a);
				else  x3+=2*abs(a);
				drawTri(point(x1,y1),point(x2,y2),point(x3,y3));
				break;		
		}
		cout<<"�~��G�Ы�1�C�����G�Ы�0�C";
		cin>>n;
		if(n==0) break;
	}
}


