
class Stack:
    def __init__(self):
        self.inList = LinkedList()

    def __str__(self):
        return str(self.inList)
        
    def size(self):
        return self.inList.length

    def push(self, e):
        self.inList.insert(0,e)

    def pop(self):
        return self.inList.remove(0)
