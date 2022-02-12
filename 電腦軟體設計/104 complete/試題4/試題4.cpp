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
		cout<<"請選擇操作項目：" <<'\n';
		cout<<"<1>輸入模型資料：" <<'\n';
		cout<<"<2>計算平均相似度：" <<'\n';
		cout<<"<3>顯示各資料相似度：" <<'\n';
		cout<<"請選擇：";	
		cin>>c;		
		switch(c){
			case 1:
				cout<<"輸入模型資料，總筆數為：";
				cin>>t;			
				upper.clear();center.clear();lower.clear();upper.resize(t);center.resize(t);lower.resize(t);		
				cout<<'\n'<<"     序列(x軸)：";
				for(int i=0;i<t;i++){
					if(i<10) cout<<" ";
					cout<<i<<" ";
				} 
				cout<<'\n'<<"數值串列(上限)：";
				for(int i=0;i<t;i++){
					cin>>upper[i];
				}
				cout<<"數值串列(中心)：";
				for(int i=0;i<t;i++){
					cin>>center[i];
				}
				cout<<"數值串列(下限)：";
				for(int i=0;i<t;i++){
					cin>>lower[i];
				}
				cout<<'\n';
				break;
			case 2:
				input.clear();alike.clear();input.resize(t);alike.resize(t); 
				cout<<"請輸入「資料串列」檔名：";
				cin>>fn;
				file.open(fn,ios::in);
				if(!file.fail()){
					cout<<"已開啟「資料串列」檔名："<<fn<<'\n';
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
					cout<<"平均相似度為"<<sum/t<<'\n'; 
					file.close();
				}
				else cout<<"「資料串列」無法開啟"<<'\n';	
				
				break;	
			case 3:
				cout<<'\n'<<"序列(x軸)：";
				for(int i=0;i<t;i++){
					if(i<10) cout<<" ";
					cout<<i<<" ";
				} 
				cout<<'\n'<<"   相似值："; 
				for(int i=0;i<t;i++){
					cout<<alike[i]<<" "; 
				}
				cout<<'\n';
				break; 
		}
		cout<<"繼續：請按1，結束：請按0：";
		cin>>n;
	}
}
