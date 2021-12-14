import numpy as np
import re

filenames = ['Fibonacci.txt', 'Hello.txt']
file = open(filenames[0], 'r')
res=file.read()
allElements = re.sub(r'\n', r' ', res)
allElements = allElements.split(' ')
cells = np.zeros(1000)
index = 0
register = -1

comms_list = {"moo", "mOo", "moO", "mOO", "Moo", "MOo", "MoO", "MOO", "OOO", "MMM", "OOM", "oom"}

i=0
while(i != len(allElements)):
    if allElements[i] == 'MoO':
        cells[index]+=1
    elif allElements[i] == 'MOo':
        cells[index]-=1
    elif allElements[i] == 'moO':
        index+=1
    elif allElements[i] == 'mOo':
        index-=1
    elif allElements[i] == 'OOM':
        print(int(cells[index]));
    elif allElements[i] == 'Moo':
        if cells[index] != 0:
            print(chr(int(cells[index])), end='')
        else:
            a = int(input("Введите число"))
            cells[index] = a;
    elif allElements[i] == 'OOO':
        cells[index] = 0
    elif allElements[i] == 'MMM':
        if register == -1:
            register = cells[index]
        else:
            cells[index] = register
            register = -1
    elif allElements[i] == 'moo':
        lvl = 1
        if cells[index] != 0:
            while lvl > 0:
                i-= 1;
                if allElements[i] == "MOO":
                    lvl-=1
                elif allElements[i] == "moo":
                    lvl+=1
    elif allElements[i] == 'MOO':
        lvl = 1;
        if cells[index] == 0:
            while lvl > 0:
                i+=1
                if allElements[i] == "MOO":
                    lvl+=1
                elif allElements[i]=='moo':
                    lvl-=1
    elif allElements[i] == 'mOO':
        if cells[index] == 3 or cells[index] > 11:
            exit()
        else:
            allElements[i] == comms_list[cells[index]]
            continue
    else:
        pass
    i+=1
