#include <bits/stdc++.h>
using namespace std;

int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	int choose;
	cout<<"請選擇欲輸入之檔案 (1) data1 (2) data2 (3) data3"<<'\n';
	cin>>choose;
	fstream file1("C:\\Users\\User\\Desktop\\data1.txt");
	fstream file2("C:\\Users\\User\\Desktop\\data2.txt");
	fstream file3("C:\\Users\\User\\Desktop\\data3.txt");
	string buf;
	double high[35],low[35],last[35],ADX[35],Pre[35],PDM[35],APDM[35],MDM[35],AMDM[35],TR[35],ATR[35],PDI[35],MDI[35],DX[35];
	for(int i=0;i<35;i++){
		high[i]=0;low[i]=0;last[i]=0;ADX[i]=0;Pre[i]=0;PDM[i]=0;APDM[i]=0;MDM[i]=0;AMDM[i]=0;TR[i]=0;ATR[i]=0;
		PDI[i]=0;MDI[i]=0;DX[i]=0;
	}
	double TR1,TR2,TR3;
	if(choose==1){
		if(!file1){
			cout<<"Input fail"<<'\n';
		}
		else{
			file1>>buf;
			for(int i=0;i<35;i++){
				file1>>high[i];
			}
			file1>>buf;
			for(int i=0;i<35;i++){
				file1>>last[i];
			}
			file1>>buf;
			for(int i=0;i<35;i++){
				file1>>low[i];
			}			
		}
	}
	if(choose==2){
		if(!file2){
			cout<<"Input fail"<<'\n';
		}
		else{
			file2>>buf;
			for(int i=0;i<35;i++){
				file2>>high[i];
			}
			file2>>buf;
			for(int i=0;i<35;i++){
				file2>>last[i];
			}
			file2>>buf;	
			for(int i=0;i<35;i++){
				file2>>low[i];
			}		
		}
	}
	if(choose==3){
		if(!file3){
			cout<<"Input fail"<<'\n';
		}
		else{
			file3>>buf;
			for(int i=0;i<35;i++){
				file3>>high[i];
			}
			file3>>buf;	
			for(int i=0;i<35;i++){
				file3>>last[i];
			}	
			file3>>buf;
			for(int i=0;i<35;i++){
				file3>>low[i];
			}		
		}
	}
	for(int i=1;i<35;i++){
		 PDM[i]=high[i]-high[i-1];
		 MDM[i]=low[i-1]-low[i];
		 TR1=abs(high[i]-low[i]);
		 TR2=abs(high[i]-last[i-1]);
		 TR3=abs(low[i]-last[i-1]);
		 TR[i]=max(TR1,(TR2,TR3)); 
		 if(PDM[i]<0)	PDM[i]=0;	 
		 if(MDM[i]<0)	MDM[i]=0;
		 if(PDM[i]>MDM[i]) MDM[i]=0;
		 else if(PDM[i]<MDM[i]) PDM[i]=0; 
		 else {
		 	MDM[i]=0; 
			PDM[i]=0;
		 }
		 //cout<<TR[i] <<"　";
	}
//	cout<<'\n'; 
	for(int i=9;i<35;i++){
		for(int j=0;j<10;j++){
			APDM[i]+=PDM[i-j];
			AMDM[i]+=MDM[i-j];
			ATR[i]+=TR[i-j];
		}
		APDM[i]/=10.0;
		AMDM[i]/=10.0;
		ATR[i]/=10.0;
		PDI[i]=APDM[i]/ATR[i];
		MDI[i]=AMDM[i]/ATR[i];
		DX[i]=100*abs(PDI[i]-MDI[i])/(PDI[i]+MDI[i]);
	}
	for(int i=18;i<35;i++){
		for(int j=0;j<10;j++){
			ADX[i]+=DX[i-j];
		}
		ADX[i]/=10.0;
		if(ADX[i]>=ADX[i-1])	Pre[i]=1;
		else Pre[i]=0;
			
	}
	cout<<"ADX: ";
	for(int i=20;i<35;i++){
		cout<<fixed<<setprecision(2)<<ADX[i]<<' ';
	}
	cout<<'\n'<<"預測: ";
	for(int i=20;i<35;i++){
		cout<<fixed<<setprecision(0)<<Pre[i]<<"     ";
	}
	cout<<'\n';
	
}


