class BTNode:
    def __init__(self,d,l,r):
        self.data = d
        self.left = l
        self.right = r
          
    def updateChild(self, oldChild, newChild):
        if self.left == oldChild:
            self.left = newChild
        elif self.right == oldChild:
            self.right = newChild
        else: raise Exception("updateChild error")

    # prints the node and all its children in a string
    def __str__(self):  
        st = str(self.data)+" -> ["
        if self.left != None:
            st += str(self.left)
        else: st += "None"
        if self.right != None:
            st += ", "+str(self.right)
        else: st += ", None"
        return st + "]"


    #PRETTY PRINT METHOD
    def niceStr(self): # this goes in the BTNode class
        S = ["├","─","└","│"]
        angle = S[2]+S[1]+" "
        vdash = S[0]+S[1]+" "
        
        def niceRec(ptr,acc,pre):
            if ptr == None: return acc+pre+"None"
            if ptr.left==ptr.right==None: return acc+pre+str(ptr.data)
            if pre == vdash: pre2 = S[3]+"  "
            elif pre == angle: pre2 = "   "
            else: pre2 = ""
            left = niceRec(ptr.right,acc+pre2,vdash)
            right = niceRec(ptr.left,acc+pre2,angle)
            return acc+pre+str(ptr.data)+"\n"+left+"\n"+right
            
        return niceRec(self,"","")


class BST:
    def __init__(self):
        self.root = None
        self.size = 0
        
    def __str__(self):
        return str(self.root)

    def search(self, d):   
        ptr = self.root
        while ptr != None:
            if d == ptr.data:
                return True
            if d < ptr.data:
                ptr = ptr.left
            else:
                ptr = ptr.right
        return False    
    
    def add(self, d):
        if self.root == None:
            self.root = BTNode(d,None,None)
        else:
            ptr = self.root
            while True:
                if d < ptr.data:
                    if ptr.left == None:
                        ptr.left = BTNode(d,None,None)
                        break
                    ptr = ptr.left
                else:
                    if ptr.right == None:
                        ptr.right = BTNode(d,None,None)
                        break
                    ptr = ptr.right
        self.size += 1
    
    def count(self, d):
        ptr = self.root
        count = 0
        while ptr != None:
            ptr = self._searchNode(ptr,d)
            if ptr != None:
                count += 1
                ptr = ptr.right
        return count

    def _searchNode(self, ptr, d):
        while ptr != None:
            if d == ptr.data:
                return ptr
            if d < ptr.data:
                ptr = ptr.left
            else:
                ptr = ptr.right
        return None

    def remove(self,d):
        if self.root == None: return
        if self.root.data == d: 
            self.size -= 1
            return self._removeRoot()
        parentPtr = None
        ptr = self.root
        while ptr != None and ptr.data != d:
            parentPtr = ptr                
            if d < ptr.data:
                ptr = ptr.left
            else:
                ptr = ptr.right
        if ptr != None:
            self.size -= 1
            self._removeNode(ptr,parentPtr)
            
    # removes the node ptr from the tree
    def _removeNode(self, ptr, parentPtr):
        # there are 3 cases to consider:
        # 1. the node to be removed is a leaf (no children)
        if ptr.left == ptr.right == None:
            parentPtr.updateChild(ptr,None)
        # 2. the node to be removed has exactly one child            
        elif ptr.left == None:
            parentPtr.updateChild(ptr,ptr.right)
        elif ptr.right == None:
            parentPtr.updateChild(ptr,ptr.left)
        # 3. the node to be removed has both children
        else:
            # find the min node at the right of ptr -- and its parent
            parentMinRNode = ptr
            minRNode = ptr.right
            while minRNode.left != None:
                parentMinRNode = minRNode
                minRNode = minRNode.left
            # replace the data of ptr with that of the min node
            ptr.data = minRNode.data
            # bypass the min node
            parentMinRNode.updateChild(minRNode,minRNode.right)
        
    def _removeRoot(self):
        # this is essentially a hack: we are adding a dummy node at 
        # the root and call the previous method -- it allows us to
        # re-use code
        parentRoot = BTNode(None,self.root,None)
        self._removeNode(self.root,parentRoot)
        self.root = parentRoot.left


    #pretty print
    def niceStr(self):
        if self.root is None:
            return "<empty tree>"
        return self.root.niceStr()


    # QUESTION 2
    def min(self):
        if self.size == 0:
            return
        
        ptr = self.root
        while ptr.left is not None:
            ptr = ptr.left
        return ptr.data

    def max(self):
        if self.size == 0:
            return
        
        ptr = self.root
        while ptr.right is not None:
            ptr = ptr.right
        return ptr.data
        
    def removeAll(self,d):
        count = 0
        while self.search(d):
            self.remove(d)
            count += 1
        return count


    #QUESTION 3
    def _sumAllRec(self,ptr):
        if ptr is None:
            return 0

        return ptr.data +self._sumAllRec(ptr.left) + self._sumAllRec(ptr.right)

    def sumAll(self):
        return self._sumAllRec(self.root)

    def sumAllBFS(self):
        if self.root is None:
            return 0

        q = Queue()
        q.enq(self.root)
        total = 0

        while q.size() > 0:
            node = q.deq()
            total = total+node.data

            if node.left is not None:
                q.enq(node.left)
            if node.right is not None:
                q.enq(node.right)

        return total
        
    
    #QUESTION 4

    def toSortedArray(self):
        arr = [] * self.size
        self.toSortedArrayRec(self.root,arr)
        return arr
    
    
    def toSortedArrayRec(self,ptr,arr):
        if ptr is None:
            return
        self.toSortedArrayRec(ptr.left,arr)
        arr.append(ptr.data)
        self.toSortedArrayRec(ptr.right,arr)



    #QUESTION 5
    def __eq__(self,other):
        if self.size != other.size:
            return False
        
        arr1 = self.toSortedArray()
        arr2 = other.toSortedArray()
        for i in range(len(arr1)):
            if arr1[i] != arr2[i]:
                return False    
        return True
            
        
t = BST()
t.add("cat")
t.add("car")
t.add("cav")
t.add("cat")
t.add("put")
t.add("cart")
t.add("cs")
print(t)
print(t.count("cat"),t.remove("cat"),t.count("cat"),t.size)
print(t)
print(t.count("cat"),t.remove("cat"),t.count("cat"),t.size)
print(t)
print(t.count("put"),t.remove("put"),t.count("put"),t.size)
print(t)
print(t.count("put"),t.remove("put"),t.count("put"),t.size)
print(t)
