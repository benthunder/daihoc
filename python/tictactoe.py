import platform
from os import system
from select import select
from turtle import position
class Tictactoe:
    def __init__(self):
        self.gameRange = 0
        self.moveStep = {}
        self.board = [[]]
        self.HUMAN = -1
        self.COMP = +1
        self.humanChoiceChar = ''
        self.compChoiceChar = ''
        self.humanIsFirst = False

        self.inputGameSetting()
        self.runGame()

    def inputGameSetting(self):
        # Fist game rule
        while int(self.gameRange) < 3:
            try:
                self.gameRange = input('Select board game type[3 -> 10]: ').upper()
            except (EOFError, KeyboardInterrupt):
                print('Bye')
                exit()
            except (KeyError, ValueError):
                print('Bad choice')
                
        self.gameRange = int(self.gameRange)
        self.board = [[0 for x in range(self.gameRange)] for y in range(self.gameRange)]
        
        t = 1
        for i in range(self.gameRange):
            for j in range(self.gameRange):
                self.moveStep[t] = [i, j]
                t = t + 1

        while self.humanChoiceChar != 'O' and self.humanChoiceChar != 'X':
            try:
                print('')
                self.humanChoiceChar = input('Choose X or O\nChosen: ').upper()
            except (EOFError, KeyboardInterrupt):
                print('Bye')
                exit()
            except (KeyError, ValueError):
                print('Bad choice')

        if(self.humanChoiceChar == 'O'):
            self.compChoiceChar = 'X'
        else:
            self.compChoiceChar = 'O'

        while self.humanIsFirst != 'Y' and self.humanIsFirst != 'N':
            try:
                self.humanIsFirst = input('First to start?[y/n]: ').upper()
            except (EOFError, KeyboardInterrupt):
                print('Bye')
                exit()
            except (KeyError, ValueError):
                print('Bad choice')

        if(self.humanIsFirst == 'Y'):
            self.humanIsFirst = True
        else :
            self.humanIsFirst = False
        return

    def checkState(self,currentBoard,player):
        def checkRow():
            for i in range(self.gameRange):
                isChange = False
                for j in range(self.gameRange - 1):
                    if(currentBoard[i][j] != currentBoard[i][j+1] or currentBoard[i][j] != player):
                        isChange = True
                        continue
                if isChange is False:
                    return True

        def checkCol():
            for i in range(self.gameRange):
                isChange = False
                for j in range(self.gameRange - 1):
                    if(currentBoard[j][i] != currentBoard[j+1][i] or currentBoard[j][i] != player):
                        isChange = True
                        continue

                if isChange is False:
                    return True


        def checkCross():
            for i in range(self.gameRange - 1):
                if(currentBoard[i][i] != currentBoard[i+1][i+1] or currentBoard[i][i] != player or currentBoard[i+1][i+1] != player):
                    return False
            return True

        def checkRevertCross():
            for i in range(self.gameRange - 1):
                if(currentBoard[i][self.gameRange - 1 - i] != currentBoard[i+1][self.gameRange - 2 - i] or currentBoard[i][self.gameRange - 1 - i] != player):
                    return False
            return True

        if(checkCol() is True):
            return True
        if(checkRow() is True):
            return True
        if(checkCross() is True):
            return True
        if(checkRevertCross() is True):
            return True
            
        return False

    def getGameStatus(self , board):
        if(self.checkState(board,self.HUMAN)):
            return "HUMAN WIN"
        
        if(self.checkState(board,self.COMP)):
            return "COMP WIN"

        if(self.isContinueGame() is True):
            return "CONTINUE"
        
        if(self.isContinueGame() is False):
            return "DRAW"

    def renderBoard(self):
        self.cleanConsole()
        for i,row in enumerate(self.board):
            for j,cell in enumerate(row):
                if(cell == self.HUMAN):
                    print(self.humanChoiceChar + "|" , end='')
                elif(cell == self.COMP):
                    print(self.compChoiceChar + "|" , end='')
                else:
                    print(" |" , end='')
            
            print('')
            for x in range(len(row)):
                print('--',end='')
        
            print('')
    
    def cleanConsole(self):
        os_name = platform.system().lower()
        if 'windows' in os_name:
            system('cls')
        else:
            system('clear')

    def convertValue(self,val,toChar = False):
        # render to int
        if(toChar is True):
            if(val == self.HUMAN):
                return self.humanChoiceChar
            elif(val == self.COMP):
                return self.compChoiceChar
            else:
                return ' '
        else:
            if(val == self.humanChoiceChar):
                return self.HUMAN
            elif(val == self.compChoiceChar):
                return self.COMP
            else:
                return 0
                
    def isEmptyCell(self,position):
        print(self.moveStep[position])
        if(self.board[self.moveStep[position][0]][self.moveStep[position][1]] == 0):
            return True
        else:
            return False
    
    def isEmptyCellByLetter(self,letter,position):
        val = self.convertValue(letter,toChar = False)
        return self.isEmptyCell(val,position)

    def isContinueGame(self):
        for i,row in enumerate(self.board):
            for j,cell in enumerate(row):
                if (cell == 0):
                    return True
        return False

    def setMove(self,position,inpputChar):
        if(self.isEmptyCell(position)):
            self.board[self.moveStep[position][0]][self.moveStep[position][1]] = self.convertValue(inpputChar)
        else:
            return False

    def runGame(self):

        self.setMove(1,'X')
        self.setMove(2,'X')
        self.setMove(4,'X')
        self.setMove(9,'X')
        self.setMove(3,'O')
        self.setMove(5,'X')
        self.setMove(6,'O')
        self.setMove(7,'O')
        self.setMove(8,'O')
        self.renderBoard()
        
        print(self.getGameStatus(self.board))
        pass





            

game = Tictactoe()

