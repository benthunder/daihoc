#!/usr/bin/env python3
from math import inf as infinity
from pickle import FALSE, TRUE
from random import choice
import platform
import time
from os import system

"""
An implementation of Minimax AI Algorithm in Tic Tac Toe,
using Python.
This software is available under GPL license.
Author: Clederson Cruz
Year: 2017
License: GNU GENERAL PUBLIC LICENSE (GPL)
"""

def main():
    """
    Main function that calls all functions
    """


    HUMAN = -1
    COMP = +1
    board = [
        [0, 0, 0],
        [0, 0, 0],
        [0, 0, 0],
    ]

    clean()
    h_choice = ''  # X or O
    c_choice = ''  # X or O
    first = ''  # if human is the first
    type = 0 # 3 or 5 or 10 board game


    while h_choice != 'O' and h_choice != 'X':
        try:
            print('')
            h_choice = input('Choose X or O\nChosen: ').upper()
        except (EOFError, KeyboardInterrupt):
            print('Bye')
            exit()
        except (KeyError, ValueError):
            print('Bad choice')

    # Setting computer's choice
    if h_choice == 'X':
        c_choice = 'O'
    else:
        c_choice = 'X'

    # Human may starts first
    clean()
    while first != 'Y' and first != 'N':
        try:
            first = input('First to start?[y/n]: ').upper()
        except (EOFError, KeyboardInterrupt):
            print('Bye')
            exit()
        except (KeyError, ValueError):
            print('Bad choice')

    # Select board game type
    clean()
    while int(type) < 3:
        try:
            type = input('Select board game type[3 -> 10]: ').upper()
        except (EOFError, KeyboardInterrupt):
            print('Bye')
            exit()
        except (KeyError, ValueError):
            print('Bad choice')

    type = int(type)
    board = [[0 for x in range(type)] for y in range(type)]

    board = [[0, 0, 0, 0, 1], [0, 0, 0, 1, 0], [1, 0, 1, 0, 0], [0, 1, 0, 1, 0], [1, 0, 0, 0, 0]]

    if(wins(type,board,1) is TRUE):
        print('TRUE')

    if(wins(type,board,1) is FALSE):
        print('FALSE')

def wins(type,board,player):
    
    # Check rows wins
    def checkRow():
        for i in range(type):
            isChange = FALSE
            for j in range(type - 1):
                if(board[i][j] != board[i][j+1] or board[i][j] != player ):
                    isChange = TRUE
                    continue    
            
            if isChange is FALSE:
                return TRUE

        return FALSE

    def checkCol():
        for i in range(type):
            isChange = FALSE
            for j in range(type - 1):
                if(board[j][i] != board[j+1][i] or board[j][i] != player):
                    isChange = TRUE
                    continue    
            
            if isChange is FALSE:
                return TRUE
    
    def checkCross():
        for i in range(type - 1):
            if(board[i][i] != board[i+1][i+1] or board[i][i] != player or board[i+1][i+1] != player ):
                return FALSE
        return TRUE

    def checkRevertCross():
        for i in range(type - 1):
            if(board[i][type - 1 -i] != board[i+1][type - 2 -i] or board[i][type - 1 -i] != player ):
                return FALSE
        return TRUE

    if(checkCol() is TRUE):
        return TRUE
    if(checkRow() is TRUE):
        return TRUE
    if(checkCross() is TRUE):
        return TRUE
    if(checkRevertCross() is TRUE):
        return TRUE

    return FALSE




def clean():
    """
    Clears the console
    """
    os_name = platform.system().lower()
    if 'windows' in os_name:
        system('cls')
    else:
        system('clear')

def empty_cells(state):
    """
    Each empty cell will be added into cells' list
    :param state: the state of the current board
    :return: a list of empty cells
    """
    cells = []

    for x, row in enumerate(state):
        for y, cell in enumerate(row):
            if cell == 0:
                cells.append([x, y])

    return cells

if __name__ == '__main__':
    main()
