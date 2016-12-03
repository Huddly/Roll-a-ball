import socket
import time
import random
from array import array

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect(("127.0.0.1", 8123))
lst = ["ball1", "player1", "player2"]

for i in range(1,1000):
    msg = str(i*100) + ":" + lst[i % 3] + ":"
    msg += str(round(random.random()*10,2))
    msg += ":"  
    msg += str(round(random.random()*10,2)) + "\n"

    #print(msg)
    sock.sendall(bytes(msg, "utf-8"))
    time.sleep(0.1)
sock.close()
