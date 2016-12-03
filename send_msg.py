import socket
import time
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect(("127.0.0.1", 8123))
for i in range(1,100):
    print(i)
    sock.sendall(b'Msg\n')
    time.sleep(0.1)
sock.close()
