# Labyrinth

Implementation of Wilson's loop-erased random walk algorithm


Abstract: initialises a random maze, then initialises a crawler at a random space. Crawler will create path until it hits the maze, or until it hits a boundary 
at which point it self-deletes the path and resets. 

How it works:

Create a starting cell
pick a random direction from a possible list
if it's within range and does not connect to an open space, create an open space and loop
if it's out of range or open, terminate

will create 'rooms' (2x2 spaces)
