#include <bits/stdc++.h>
using namespace std;
double alikeCal(int upper,int center,int lower,int data){
	if(data>=upper) return 0; 						
	if(data<=lower) return 0;
	if(data==center) return 1;
	if(data<center) return 1-(double)(center-data)/(center-lower);
	if(data>center) return 1-(double)(data-center)/(upper-center);
}
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	int n=1;
	vector<int> upper,center,lower,input;
	vector<double> alike;
	fstream file;
	int c,t;
	double sum;
	char fn[5];
	while(n){						
		cout<<"�п�ܾާ@���ءG" <<'\n';
		cout<<"<1>��J�ҫ���ơG" <<'\n';
		cout<<"<2>�p�⥭���ۦ��סG" <<'\n';
		cout<<"<3>��ܦU��Ƭۦ��סG" <<'\n';
		cout<<"�п�ܡG";	
		cin>>c;		
		switch(c){
			case 1:
				cout<<"��J�ҫ���ơA�`���Ƭ��G";
				cin>>t;			
				upper.clear();center.clear();lower.clear();upper.resize(t);center.resize(t);lower.resize(t);		
				cout<<'\n'<<"     �ǦC(x�b)�G";
				for(int i=0;i<t;i++){
					if(i<10) cout<<" ";
					cout<<i<<" ";
				} 
				cout<<'\n'<<"�ƭȦ�C(�W��)�G";
				for(int i=0;i<t;i++){
					cin>>upper[i];
				}
				cout<<"�ƭȦ�C(����)�G";
				for(int i=0;i<t;i++){
					cin>>center[i];
				}
				cout<<"�ƭȦ�C(�U��)�G";
				for(int i=0;i<t;i++){
					cin>>lower[i];
				}
				cout<<'\n';
				break;
			case 2:
				input.clear();alike.clear();input.resize(t);alike.resize(t); 
				cout<<"�п�J�u��Ʀ�C�v�ɦW�G";
				cin>>fn;
				file.open(fn,ios::in);
				if(!file.fail()){
					cout<<"�w�}�ҡu��Ʀ�C�v�ɦW�G"<<fn<<'\n';
					for(int i=0;i<t;i++){
						file>>input[i];						
					}				
					for(int i=0;i<t;i++){
						alike[i]=alikeCal(upper[i],center[i],lower[i],input[i]);
					}
					sum=0;
					for(int i=0;i<t;i++){
						sum+=alike[i];
					}
					cout<<"�����ۦ��׬�"<<sum/t<<'\n'; 
					file.close();
				}
				else cout<<"�u��Ʀ�C�v�L�k�}��"<<'\n';	
				
				break;	
			case 3:
				cout<<'\n'<<"�ǦC(x�b)�G";
				for(int i=0;i<t;i++){
					if(i<10) cout<<" ";
					cout<<i<<" ";
				} 
				cout<<'\n'<<"   �ۦ��ȡG"; 
				for(int i=0;i<t;i++){
					cout<<alike[i]<<" "; 
				}
				cout<<'\n';
				break; 
		}
		cout<<"�~��G�Ы�1�A�����G�Ы�0�G";
		cin>>n;
	}
}
