A = [5,7,2,1,4]

def InsertionSort(B):
    for i in range (1,len(B)):
        insert(B[i],B,i)
    return B

def insert(v,A,h):
    for i in range(h-1,-1,-1):
        if v >= A[i]:
            A[i+1] = v
            return      
        A[i+1] = A[i]
    A[0] = v  

print (InsertionSort(A))
