#include <bits/stdc++.h>
using namespace std;
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	string pswd;
	cout<<"�п�J�K�X:";
	cin>>pswd;
	bool pswd_ok=true;
	int lack=0;
	int big=0,small=0,num=0,sym=0;
	char symbol[14]={'!','@','#','$','%','^','&','*','(',')','-','+','_','='};
	if(pswd.size()<8 || pswd.size()>128)	pswd_ok=false;
	for(int i=0;i<pswd.size();i++){
		if(pswd[i]>='A' && pswd[i]<='Z'){
			big++;
		}
		if(pswd[i]>='a' && pswd[i]<='z'){
			small++;
		}
		if(pswd[i]>='0' && pswd[i]<='9'){
			num++;
		}
		for(int j=0;j<14;j++){
			if(pswd[i]==symbol[j]) sym++;
		}
	}
	if(!big) lack++;
	if(!small) lack++;
	if(!num) lack++;
	if(!sym) lack++;
	if(lack>=2) pswd_ok=false;
	cout<<"�K�X����:"<<pswd.size()<<'\n'; 
	cout<<"�j�g�^��r������:"<<big<<'\n';
	cout<<"�p�g�^��r������:"<<small<<'\n';
	cout<<"�Ʀr����:"<<num<<'\n';
	cout<<"�Ÿ�����:"<<sym<<'\n';
	if(pswd_ok) cout<<"�ŦX�K�X�W�h"<<'\n';
	else  cout<<"���űK�X�W�h"<<'\n';
}

