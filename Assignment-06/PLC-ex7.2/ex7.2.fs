//i
void main(){
    int arr[4]; 
    arr[0] = 7;
    arr[1] = 13;
    arr[2] = 9;
    arr[3] = 8;

    int *sump;
    int result;
    result = arrsum(4, arr, sump);
    print(result);
}

void arrsum(int n, int arr[], int *sump){
    int i;
    i = 0;
    int sum;
    sum = 0;
    while(i<n){
        sum = sum + arr[i];
        i = i + 1;
    }
    sump = sum;
}

//ii
void main(){
    int arr[20]; 

    result = squares(15, arr);

    int *sump;
    sum = arrsum(15, result, sump);

    print(sum);
}

void squares(int n, int arr[]){
    int i;
    i = 0;
    while(i < n){
        arr[i] = i*i;
        i = i + 1;
    }   
}

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
    print(freq[4]);
    print(freq[5]);
    print(freq[6]);
}

void histogram(int n, int ns[], int max, int freq[]){
    int i;
    i = 0;
    while(i < n){
        int num;
        num = arr[i];
        freq[num] = freq[num] + 1;
        i = i + 1;
    }
}