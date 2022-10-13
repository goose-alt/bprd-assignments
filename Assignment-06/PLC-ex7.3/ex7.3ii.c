//ii
void main(){
    int arr[20]; 

    squares(15, arr);

    int *sump;
    int sum;
    sum = arrsum(15, arr, sump);

    print(sum);
}

void squares(int n, int arr[]){

    int i;
    for (i = 0; i < n; i = i + 1) 
        arr[i] = i * i;
}

void arrsum(int n, int arr[], int *sump){

    int i;
    int sum;
    sum = 0;
    for (i = 0; i < n; i = i + 1)
        sum = sum + arr[i];

    sump = sum;
}
