#include <bits/stdc++.h>
using namespace std;
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	int num;
	cout<<"�п�J��{processes�ƶq(MAX 5)�G";
	cin>>num;
	while(num>5){
		cout<<"�п�J��{processes�ƶq(MAX 5)�G";
		cin>>num;
	}
	cout<<'\n'<<"�п�J�C�Ӧ�{������ɶ�burst_time..."<<'\n';
	int process[num];
	for(int i=0;i<num;i++){
		cout<<"P"<<i+1<<":";
		cin>>process[i];
	}
	cout<<'\n'<<"�п�J�ɶ��t�Btime_quantum�G";
	int time;
	cin>>time;
	cout<<'\n'<<"�U��{processes���涶�Ǭ�..."<<'\n';
	int max=0;
	int timer=0;
	int processing=1;
	bool flag=true;
	int wait[5]={0};
	while(flag){
		switch(processing){
			case 1:
				if(timer<10) cout<<0<<timer<<":P1  ";
				else cout<<timer<<":P1  ";
				break;
			case 2:
				if(timer<10) cout<<0<<timer<<":P2  ";
				else cout<<timer<<":P2  ";
				break;
			case 3:
				if(timer<10) cout<<0<<timer<<":P3  ";
				else cout<<timer<<":P3  ";
				break;
			case 4:
				if(timer<10) cout<<0<<timer<<":P4  ";
				else cout<<timer<<":P4  ";
				break;
			case 5:
				if(timer<10) cout<<0<<timer<<":P5  ";
				else cout<<timer<<":P5  ";
				break;
		}
		if(process[processing-1]<time){
			for(int i=0;i<num;i++){
				if(i+1==processing) continue;
				if(process[i]==0) continue;
				wait[i]+=process[processing-1];
			}	
			timer+=process[processing-1];
			process[processing-1]=0;	
		}
		else{
			timer+=time;
			process[processing-1]-=time;
			for(int i=0;i<num;i++){
				if(i+1==processing) continue;
				if(process[i]==0) continue;
				wait[i]+=time;
			}	
		}
		for(int i=0;i<num;i++){
			max+=process[i];
		}
		if(max==0){
			flag=false;	
		}
		else{
			max=0;
		}
		if(processing==num){
			processing=1;
		}
		else processing++;
		while(process[processing-1]==0){
			if(processing==num){
			processing=1;
			}
			else processing++;
			if(!flag) break;
		}
		
	}
	cout<<timer<<'\n'<<'\n';
	for(int i=0;i<num;i++){
		switch(i+1){
			case 1:
				cout<<"P1���ݮɶ��G"; 
				break;
			case 2:
				cout<<"P2���ݮɶ��G"; 
				break;
			case 3:
				cout<<"P3���ݮɶ��G"; 
				break;
			case 4:
				cout<<"P4���ݮɶ��G"; 
				break;
			case 5:
				cout<<"P5���ݮɶ��G"; 
				break;
		}
		cout<<wait[i]<<"  ";
	}
	system("pause");
}

