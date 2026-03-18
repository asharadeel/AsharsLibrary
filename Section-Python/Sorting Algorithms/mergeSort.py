A = [30,25,67,99,8,16,28,63,12,20]
print(A)
print("Sorting...")

B = [1,2,3,4,5,9,8,7,6]
def mergeSort(A):
    #base case
    if len(A) <= 1:
        return
    #split halves
    mid = len(A)//2
    h1 = A[:mid]
    h2 = A[mid:]
    #sort halves
    mergeSort(h1)   #recursive case
    mergeSort(h2)   #recursive case
    A = merge(h1,h2,A) #merge
    return A

def merge(h1,h2,A):
    #indexs 
    i = 0
    j1 = 0
    j2 = 0

    #main sorting algorithm - interleave elements of halves
    while j1 < len(h1) and j2<len(h2):
        if h1[j1] < h2[j2]:
            A[i] = h1[j1]
            j1 = j1+1
            i = i+1
        else:
            A[i] = h2[j2]
            j2 = j2+1
            i = i+1

    #put remaining elements in array 
    while j1 < len(h1):
        A[i] = h1[j1]
        j1 = j1+1
        i = i+1
    while j2 <len(h2):
        A[i] = h2[j2]
        j2 = j2+1
        i = i+1
        
    return A

print(mergeSort(B))
