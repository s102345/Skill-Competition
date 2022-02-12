#include <bits/stdc++.h>
using namespace std;
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	string pswd;
	cout<<"請輸入密碼:";
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
	cout<<"密碼長度:"<<pswd.size()<<'\n'; 
	cout<<"大寫英文字母長度:"<<big<<'\n';
	cout<<"小寫英文字母長度:"<<small<<'\n';
	cout<<"數字長度:"<<num<<'\n';
	cout<<"符號長度:"<<sym<<'\n';
	if(pswd_ok) cout<<"符合密碼規則"<<'\n';
	else  cout<<"不符密碼規則"<<'\n';
}

