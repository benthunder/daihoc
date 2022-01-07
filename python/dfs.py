class Graph:
    def __init__(self , input , start , end):
        self.listVisit = []
        self.ajInput = input
        self.listVertexResult = []
        self.listPathVertexResult = []
        self.start = start
        self.end = end

        self.listParent = {}


    def dfsNeibour(self , vertext):
        if vertext not in self.listVisit:
            self.listVisit.append(vertext)
        
        if(vertext == self.end):
            return

        for neighbour in self.ajInput[vertext]:
            if neighbour not in self.listVisit:
                self.listParent[neighbour] = vertext
                if(neighbour == self.end):
                    self.listVisit.append(neighbour)
                    return

                self.dfsNeibour(neighbour)
        
    def dfs (self):
        listRun = list(self.ajInput.keys())
        listRun.remove(self.start)
        listRun.insert(0,self.start)
        for vertext in listRun:
            if(vertext not in self.listVisit):
                self.dfsNeibour(vertext)

    def printResult(self):
        self.dfs()
        print("Dinh duyet : ")
        print(self.listVisit)


        # tim duong di
        print("Duong di : ")
        curVertext = self.end
        if(curVertext not in self.listParent.keys()):
            print("Khong co duong di")
        else :
            while (curVertext != self.start):
                self.listPathVertexResult.append(curVertext)
                curVertext = self.listParent[curVertext]

                if(curVertext == self.start):
                    self.listPathVertexResult.append(curVertext)

        if(len(self.listPathVertexResult) < 1):
            print("Khong co duong di")
        elif(self.listPathVertexResult[len(self.listPathVertexResult) - 1] != self.start):
            print("Khong co duong di")
        else :
            self.listPathVertexResult.reverse()
            print(self.listPathVertexResult)

graph = {
    'A' : ['B','C'],
    'B' : ['A', 'C', 'D'],
    'C' : ['A', 'B', 'D'],
    'D' : ['B', 'C', 'E', 'F', 'G'],
    'E' : ['D', 'G'],
    'F' : ['D', 'G'],
    'G' : ['D', 'E', 'F']
}
g = Graph(graph,'A','G')
g.printResult()