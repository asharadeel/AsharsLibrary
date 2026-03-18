A = [10,15,25,61,2,56,7,24,66,14,35,32]
print(A)
print("Sorting...")

def quickSort(A):
    quickSortRec(A,0,len(A))
    return A

def quickSortRec(A,lo,hi):
    if hi-lo <= 1:
        return
    iPivot = partition(A,lo,hi)
    quickSortRec(A,lo,iPivot)
    quickSortRec(A,iPivot+1, hi)
    return A

def partition(A,lo,hi):
    pivot = A[lo]
    B = [0 for i in range(lo,hi)]
    loB = 0
    hiB = len(B)-1

    for i in range(lo+1, hi):
        if A[i] < pivot:
            B[loB] = A[i]
            loB = loB +1
        else:
            B[hiB] = A[i]
            hiB = hiB -1

    B[loB] = pivot
    for i in range(len(B)):
        A[lo+i] = B[i]
    return lo+loB

print(quickSort(A))
