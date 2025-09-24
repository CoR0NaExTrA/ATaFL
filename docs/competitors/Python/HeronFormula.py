import math

class Point2D:
    def __init__(self, x, y):
        self.x, self.y = x, y

def distance(a, b):
    return math.sqrt((a.x - b.x) ** 2 + (a.y - b.y) ** 2)

coords = list(map(float, input().split()))
A = Point2D(coords[0], coords[1])
B = Point2D(coords[2], coords[3])
C = Point2D(coords[4], coords[5])

a = distance(B, C)
b = distance(A, C)
c = distance(A, B)

s = (a + b + c) / 2
area = math.sqrt(s * (s - a) * (s - b) * (s - c))
print(area)