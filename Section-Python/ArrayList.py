# An ArrayList (Dynamic)
class ArrayList:
    # Intialise
    def __init__(self):
        self.inArray = [0 for i in range(10)]
        self.count = 0

    # Fetch value
    def get(self, i):
        self._checkBounds(i, self.count - 1)
        return self.inArray[i]

    # Set value of a position to value
    def set(self, i, e):
        self._checkBounds(i, self.count - 1)
        self.inArray[i] = e

    # Check length
    def length(self):
        return self.count

    # Append a value
    def append(self, e):
        self.inArray[self.count] = e
        self.count += 1
        if len(self.inArray) == self.count:
            self._resizeUp()     

    # Insert a value 
    def insert(self, i, e):
        self._checkBounds(i, self.count)
        for j in range(self.count,i,-1):
            self.inArray[j] = self.inArray[j-1]
        self.inArray[i] = e
        self.count += 1
        if len(self.inArray) == self.count:
            self._resizeUp()     

    # Remove a value 
    def remove(self, i):
        self._checkBounds(i, self.count - 1)
        self.count -= 1
        val = self.inArray[i]
        for j in range(i,self.count):
            self.inArray[j] = self.inArray[j+1]
        return val

    # Display for print()
    def __str__(self):
        return str(self.inArray[:self.count])

    # Resize a static array (not applicable here, but exists for sake of example) to fit new data
    def _resizeUp(self):
        newArray = [0 for i in range(2*len(self.inArray))]
        for j in range(len(self.inArray)):
            newArray[j] = self.inArray[j]
        self.inArray = newArray

    
    # Append a series of values using an array
    def appendAll(self,A):
        for i in range (len(A)):
            self.append(A[i])

    # Convert Obj to Array
    def toArray(self):
        other = []
        for i in range (self.count):
            other.append(self.get(i))
        return other
    
    # Checks whether i is in [0,hi]
    def _checkBounds(self, i, hi):
        if i < 0 or i > hi:
            raise Exception("index "+str(i)+" out of bounds!")


    # Compare Two Values to see if values of first less than other (int)
    def __lt__(self, other):
        n = other.length() if self.length() < other.length() else self.length()
    
        for i in range(n):
            a = self.get(i) if i < self.count else 0
            b = other.get(i) if i < other.count else 0
    
            if a < b:
                return True
            elif a > b:
                return False
        return False
