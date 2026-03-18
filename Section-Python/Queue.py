
class Queue:
    def __init__(self):
        self.inList = LinkedList()

    def __str__(self):
        return str(self.inList)
        
    def size(self):
        return self.inList.length

    def enq(self, e):
        self.inList.append(e)

    def deq(self):
        return self.inList.remove(0)
