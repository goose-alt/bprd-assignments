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
