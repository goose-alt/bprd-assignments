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

