#include <bits/stdc++.h>
using namespace std;
#define MAX 200
void bconvert(int b[],int x){
	int k=MAX-1;
	while(x>9){
		b[k]=x%10;
		x/=10;
		k--;
	}
	b[k]=x;
}
int fac(int x){
	int table[25]={2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97}; //25
	int y=0;
	if(x==1) return 0; 
	for(int i=0;i<25;i++){
		if(x==0) break; 
		while(x%table[i]==0){
			y++;
			x/=table[i];
		}
	}
	return y;
}
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	int n;
	int a[MAX],b[MAX],c[MAX*2];
	int x,flag,count;
	while(cin>>n){
		for(int i=0;i<MAX;i++){
			a[i]=0; 
			b[i]=0;
		} 
		a[MAX-1]=1;
		count=0;
		for(int i=1;i<=n;i++){
			count+=fac(i);
			bconvert(b,i);
			for(int j=0;j<MAX*2;j++) c[j]=0;
			for(int j=MAX-1;j>0;j--){
				for(int k=MAX-1;k>0;k--){
					c[j+k+1]+=a[k]*b[j];
					if(c[j+k+1]>9){
						c[j+k]+=c[j+k+1]/10;
						c[j+k+1]%=10;
					}
				}
			}
			for(int j=MAX;j<2*MAX;j++){
				a[j-MAX]=c[j];
			} 
		}
		for(int i=0;i<MAX*2;i++){
			if(c[i]!=0){
				flag=i;
				break;
			}	
		}
		for(int i=flag;i<MAX*2;i++){
			cout<<c[i];
		}
		int sum=0;
		for(int i=0;i<MAX*2;i++){
			sum+=c[i];
		}
		cout<<'\n'<<sum<<'\n'<<count;
	}
}

