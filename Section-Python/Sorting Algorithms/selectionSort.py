def sortSelection(A):
    for i in range(len(A)):
        imin = findMin(i, A)
        swap(i, imin, A)
    return A

def findMin(i, A):
    imin = i
    for j in range(i+1, len(A)):
        if A[j] < A[imin]:
            imin = j
    return imin

def swap(i, j, A):
    A[i], A[j] = A[j], A[i]


A = [5, 7, 2, 1, 4]
print(sortSelection(A))

def sortSelection2(A):
    n = len(A)
    for i in range(n - 1):
        imin = i
        for j in range(i + 1, n):
            if A[j] < A[imin]:
                imin = j
        if imin != i:
            A[i], A[imin] = A[imin], A[i]
    return A
