A = [1,3,6,7,10,23,28,34,38,43,55,55,56,78,90]

def linearSearch(arr, val):
    for i in range (len(arr)):
        if val == arr[i]:
            return i
    return -1

print(linearSearch(A,7))
