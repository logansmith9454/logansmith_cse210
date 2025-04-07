This program is intended to help me with Rubik's cubes. There is an advanced method called EOLRb,
which has hundreds of cases, that I want to learn. However, very few people use this method, and
so there are not many resources on how to do it. This program allows me to put in the locations of
the pieces, and it will find the optimal solution for this step. It uses a brute force, meet-in-the-middle
strategy, as that is the only way to find a solution that is guaranteed to be optimal. The names of
the pieces and locations are done with the Speffz lettering scheme, which assigns letters to each
piece, making them easy to keep track of.

Classes:

Cube:
All the collective pieces of the cube. Methods include every type of move that can be done, displaying
the locations of all the pieces (which I used for debugging), validating that the given scramble is
actually possible to solve, and converting all the information in the instance into a tuple for fast comparisons.

Cycle (Corners/Centers):
Both the corners and centers are 4 pieces that simply rotate in a circle, so they can be imagined as one
larger piece. The main difference between the two is that the centers have two possible solved states, while
the corners only have one. This is why the corners have the isOriented bool. The only method (other than getters)
is Move, which moves them around.

Edge (LR/Ori):
These are the majority of the pieces that are moving around. The EOLRb step solves two of the edges and flips
the rest so that they are oriented correctly. The two that are solved are called the LR edges (because they
belong on the left and right side of the cube), and the other four I named Ori, because they only need to be
oriented correctly. The only methods other than getters and setters move the pieces around in various ways. These
are called by Cube's methods, which move all of the relevant edges at the same time.




Test inputs:
Here are some inputs that you can test, as this program is not very intuitive to use if you are not
very familiar with advanced speedsolving concepts.



Corner position: 3
Center position: 1
b located: b1
d located: a0
a orientation: 0
c orientation: 1
u orientation: 1
w orientation: 0

Output:
Movecount: 9
Solution: (U) M U M2 U' M U2 M U M'






Corner position: 3
Center position: 0
b located: b0
d located: w1
a orientation: 1
c orientation: 0
d orientation: 1
u orientation: 1

Output:
Movecount: 5
Solution: (U2) M' U' M U' M2





Corner position: 0
Center position: 1
b located: b0
d located: d0
a orientation: 0
c orientation: 0
u orientation: 0
w orientation: 0

Output:
Movecount: 13
Solution: (U') M' U' M U2 M' U M U2 M2 U M' U' M