class Node:
    def __init__(self, d, n):
        self.data = d
        self.next = n

class LinkedList:
    def __init__(self):
        self.head = None
        self.length = 0

    def __str__(self):
        st = "--> "
        ptr = self.head
        while ptr != None:
            st = st + str(ptr.data)
            st = st+" -> "
            ptr = ptr.next
        return st+"None"
        
    def search(self, d):
        i = 0
        ptr = self.head
        while ptr != None:
            if ptr.data == d:
                return i
            ptr = ptr.next
            i += 1
        return -1
        
    def append(self, d):
        if self.head == None:      
            self.head = Node(d,None) 
        else:
            ptr = self.head
            while ptr.next != None:
                ptr = ptr.next
            ptr.next = Node(d,None)
        self.length += 1

        
    def insert(self, i, d):
        if self.head == None or i == 0:
            self.head = Node(d,self.head)
        else:
            ptr = self.head
            while i>1 and ptr.next != None:
                ptr = ptr.next
                i -= 1
            ptr.next = Node(d,ptr.next)
        self.length += 1

    def remove(self, i): # removes i-th element and returns it
        if self.head == None:
            return None
        if i == 0:
            val = self.head.data
            self.head = self.head.next
            self.length -= 1
            return val
        ptr = self.head
        while ptr.next != None:
            if i == 1:
                val = ptr.next.data
                ptr.next = ptr.next.next
                self.length -= 1
                return val                
            ptr = ptr.next
            i -= 1
    
    def removeVal(self, d):
        if self.head == None:
            return
        if self.head.data == d:
            self.head = self.head.next
            self.length -= 1
        else:
            ptr = self.head	
            while ptr.next != None:
                if ptr.next.data == d:
                    ptr.next = ptr.next.next
                    self.length -= 1
                    break
                ptr = ptr.next
    
    def sublist(self, i):
        ptr = self.head
        ls = LinkedList()
        ls.length = self.length
        while ptr != None and i>0:
            ptr = ptr.next
            i -= 1
            ls.length -= 1
        ls.head = ptr
        return ls


     #QUESTION 2
    def appendAll(self,d):
        for i in range (len(d)):
            self.append(d[i])

    def nullify(self):
        while self.head is not None:
            self.removeVal(self.head.data)
    
    def clone(self):
        ls = LinkedList()
        current = self.head
        while current is not None:
            ls.append(current.data)
            current = current.next
        return ls


    def merge(self,other):
        if other.head is None:
            return self
        
        if self.head is None:
            self.head = other.head
            self.length = other.length
        else:
            tail = self.head
            while tail.next is not None:
                tail = tail.next
            tail.next = other.head
            self.length += other.length
        
        other.head = None
        other.length = 0
        return self

    #QUESTION 3- INSERTION
    def insert2(self,i,d):
        self.head = self.insertRec(self.head,i,d)
        self.length += 1
        
    def insertRec(self,ptr,i,d):
        if i == 0:
            return Node(d,ptr)
        if ptr is None:
            return Node(d,None)
        ptr.next = self.insertRec(ptr.next,i-1,d)
        return ptr

    
    #QUESTION 4- SORT
    def sort(self):
        arr = [] 
    
        #copy arr
        current = self.head
        while current is not None:
            arr.append(current.data)
            current = current.next
    
        #sort
        self.quickSortRec(arr,0,len(arr))
    
        #rebuild
        self.head = None
        self.length = 0
        for i in range(len(arr)):
            self.append(arr[i])
    
    
    
    def quickSortRec(self,A,lo,hi):
        if hi-lo <= 1:
            return
        iPivot = self.partition(A,lo,hi)
        self.quickSortRec(A,lo,iPivot)
        self.quickSortRec(A,iPivot+1, hi)
        return A
    
    def partition(self,A,lo,hi):
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



    #QUESTION 5 - BREAK CYCLE
    def breakCycle(self):
        if self.head is None or self.head.next is None:
            return
    
        visited = []
        ptr = self.head
        prev = None
    
        while ptr is not None:
            if ptr in visited:
                break
            visited.append(ptr)
            prev = ptr
            ptr = ptr.next
    
        if ptr is None:
            self.length = len(visited)
            return
        else:
            prev.next = None
            self.length = len(visited)
    
