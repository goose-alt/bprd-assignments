//iii
void main(){
    int arr[7];  
    arr[0] = 1;
    arr[1] = 2;
    arr[2] = 1;
    arr[3] = 1;
    arr[4] = 1;
    arr[5] = 2;
    arr[6] = 0;

    int freq[4];

    histogram(7, arr, 3, freq);

    print(freq[0]);
    print(freq[1]);
    print(freq[2]);
    print(freq[3]);
}

void histogram(int n, int ns[], int max, int freq[]){
    int i;
    i = 0;
    while(i < n){
        int num;
        num = ns[i];
        freq[num] = freq[num] + 1;
        i = i + 1;
    }
}