A = [1,1,1,5,6,7,8,9,12,13,14,17,25,35,55,73]

def linear(A,v):
    for i in range(len(A)):
        if v == A[i]:
            return i
        elif v < A[i]:
            return -1
    return -1




def binary(A,v):
    lp = 0
    hp = len(A)-1
    current = (hp+lp)//2

    while lp<=hp:
        if(A[current] == v):
            return current
        elif(A[current] > v):
            hp = current-1
        else:
            lp = current+1
        current = (hp+lp)//2
        
    return -1
    

print("LINEAR")
print(linear(A,12))
print(linear(A,15))

print("BINARY")
print(binary(A,12))
print(linear(A,15))

