class HashTable:
    # Create a default table of length 10 and threshold 0.75
    def __init__(self, m=10):    
        self.inArray = [LinkedList() for i in range(m)] 
        self.size = 0
        self.threshold = 0.75    # a default threshold of 0.75

    def hash(self, d):
        return d % len(self.inArray)
           
    def add(self, d):
        i = self.hash(d)
        self.inArray[i].insert(0,d)
        self.size += 1
        # condition that must be respected: self.size <= self.threshold * len(self.inArray)
        if self.size > self.threshold*len(self.inArray): self._resizeUp()
        
    def search(self, d):
        i = self.hash(d)
        if self.inArray[i].search(d) == -1: return False
        return True

    def remove(self, d):
        i = self.hash(d)
        if self.inArray[i].removeVal(d):
            self.size -= 1

    def _resizeUp(self):
        oldArray = self.inArray
        self.inArray = [LinkedList() for _ in range(2*len(oldArray))]
        for l in oldArray:
            while l.length > 0:
                d = l.remove(0)
                self.inArray[self.hash(d)].insert(0,d)            
            
    # these are to make our life easier in adding/removing many elements
    def addAll(self, A):
        for i in range(len(A)):
            self.add(A[i])

    def removeAll(self, A):
        for i in range(len(A)):
            self.remove(A[i])

    #--------------------------------
    #Q2A
    def count(self,d):
        i = self.hash(d)
        return self.inArray[i].count(d)
    
    #Q2B
    # iterates whole list and find max for each inarray
    def max(self):
        if self.size == 0:
            return None

        maxv = None

        for x in self.inArray:
            if x.length > 0:
                ptr = x.head
                while ptr != None:
                    if maxv == None or ptr.data > maxv:
                        maxv = ptr.data
                    ptr = ptr.next
        return maxv

    #Q2C
    # 
    def __str__(self):
        lines = []
        for i in range(len(self.inArray)): 
            lsstr = str(self.inArray[i]) ##lLL at index to str
            line = f"[{i}]" # formats index 
            if lsstr:
                line += "->" + lsstr
            lines.append(line)
        return "\n".join(lines)

    #------------------------------
    #Q3
                         
    def hash2(self,d):
        sum = 0
        numstr = str(abs(d))
        for digits in numstr:
            sum += int(digits)
        return sum % len(self.inArray)
    #----------------------------------
    #Q5
    #It creates an iterator that returns the next element in the hash table each time it’s called.
    def iter(self):
        self.iterPtr = (-1,-1) #arrIndex, listIndex
        for i in range ((len(self.inArray))):
            if self.inArray[i].length > 0:
                self.iterPtr = (i,0)
                break

        def iterator():
            if self.iterPtr == (-1,-1):
                return None

            i,j = self.iterPtr
            data = self.inArray[i].get(j)

            nexti = i+1
            nextj = j+1
            
            if  nextj < self.inArray [i].length:
                self.iterPtr = (i,nextj)
            else:
                found = False
                while (nexti) < len(self.inArray):
                    if self.inArray[nexti].length > 0:
                        self.iterPtr = (nexti,0)
                        found = True
                        break
                    nexti+=1
                if not found:
                    self.iterPtr = (-1,-1)
            return data
        return iterator


    #### HELPER METHOD FOR
    #### THE HASH TABLE
    #### USING THE LINKED LIST



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
            
    def count(self, d):
        cnt = 0; ptr = self.head
        while ptr != None:
            if ptr.data == d: cnt+=1
            ptr = ptr.next
        return cnt

    def get(self, i):
        ptr = self.head
        while ptr != None and i>0:
            ptr = ptr.next
            i -= 1
        return ptr.data    
    
    # removes the first occurrence of d if found
    # returns True if d removed, otherwise False
    def removeVal(self, d):
        if self.head == None: return False
        if self.head.data == d:
            self.head = self.head.next
            self.length -= 1
            return True
        ptr = self.head	
        while ptr.next != None:
            if ptr.next.data == d:
                ptr.next = ptr.next.next
                self.length -= 1
                return True
            ptr = ptr.next
        return False
    
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


