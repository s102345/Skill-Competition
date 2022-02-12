#include <bits/stdc++.h>
#define leftchild 2*i+1
#define rightchild 2*(i+1)
using namespace std;
void leftmax(vector<int> tree,int tick,int i,int &lmax){
	if(tree[i]==-1) return;
	if(tick>lmax) lmax=tick;
	if(leftchild>=tree.size())return;
	leftmax(tree,tick+1,leftchild,lmax);
	if(rightchild>=tree.size())return;
	leftmax(tree,tick+1,rightchild,lmax);
}
void rightmax(vector<int> tree,int tick,int i,int &rmax){
	if(tree[i]==-1) return;
	if(tick>rmax) rmax=tick;
	if(leftchild>=tree.size())return;
	rightmax(tree,tick+1,leftchild,rmax);
	if(rightchild>=tree.size())return;
	rightmax(tree,tick+1,rightchild,rmax);
}
int main(){
	//ios::sync_with_stdio(false);
	//cin.tie(0);
	int times,k;
	vector<int> tree;
	int lmax=0,rmax=0,result;
	string buf;
	fstream file[3];
	file[0].open("in1.txt",ios::in);
	file[1].open("in2.txt",ios::in);
	file[2].open("out.txt",ios::out);
	file[0]>>times;
	getline(file[0],buf);
	for(int i=0;i<times;i++){
		getline(file[0],buf);
		k=0;
		tree.clear();
		for(int j=0;j<buf.length();j++){
			if(buf[j]==','||buf[j]=='['||buf[j]==']') continue;
			else if(buf[j]=='n'){
				tree.push_back(-1);
				j+=4;
			} 
			else{
				if(buf[j+1]>='0'&&buf[j+1]<='9'){
					k+=buf[j]-'0';
					k*=10;
				}
				else{
					k+=buf[j]-'0';
					tree.push_back(k);
					k=0;
				}
			}
		}
		lmax=0;rmax=0;
		leftmax(tree,0,1,lmax);
		rightmax(tree,0,2,rmax);
		result=lmax+rmax;
		if(tree[1]!=-1) result++;
		if(tree[2]!=-1) result++;
		file[2]<<result<<'\n';
	} 
	file[2]<<'\n';
	file[1]>>times;
	getline(file[1],buf);
	for(int i=0;i<times;i++){
		getline(file[1],buf);
		k=0;
		tree.clear();
		for(int j=0;j<buf.length();j++){
			if(buf[j]==','||buf[j]=='['||buf[j]==']') continue;
			else if(buf[j]=='n'){
				tree.push_back(-1);
				j+=4;
			} 
			else{
				if(buf[j+1]>='0'&&buf[j+1]<='9'){
					k+=buf[j]-'0';
					k*=10;
				}
				else{
					k+=buf[j]-'0';
					tree.push_back(k);
					k=0;
				}
			}
		}
		lmax=0;rmax=0;
		leftmax(tree,0,1,lmax);
		rightmax(tree,0,2,rmax);
		result=lmax+rmax;
		if(tree[1]!=-1) result++;
		if(tree[2]!=-1) result++;
		file[2]<<result<<'\n';
	} 
}

