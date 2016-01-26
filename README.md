# Open-Source Temporal Difference Implementation for Reinforcement Learning
This is a C# source code for temporal difference reinforcement learning.
Feel free to use this project for non-commercial purposes only.

## Environment setting
The environment is highly inspired by the Cliff Walking example from Sutton's Reinforcement Learning textbook.
We have a 5x10 grid-based environment like this:

---------------------
|S|C|C|C|C|C|C|C|C|G|
---------------------
| | | | | | | | | | |
---------------------
| | | | | | | | | | |
---------------------
| | | | | | | | | | |
---------------------
| | | | | | | | | | |
---------------------

S and G are the start and goal state, respectively.
C denotes a cliff.
There are 4 possible deterministic actions: top, right, down, and left.
Each action causes the agent to move in the corresponding direction by 1 unit.
If an action causes the agent to exit the grid, it has no effect and the agent remains in its location.
If an action takes the agent to a cliff, a reward of -1 is produced and the game is lost.
If an action takes the agent to the goal state, a reward of +1 is produced and the game is won.
In all other cases, the reward is 0.
Gama = 0.9
After winning or losing the game, the environment is reset and a new episode starts.

We can also have an enemy in the environment, which can be activated using the Enemy check box at the bottom.
At each frame, the enemy randomly chooses on of the 4 possible actions, and takes it.
The enemy cannot go to a cliff or goal state, obviously.

## Pre-requisites 
Microsoft Visual Studio 2015 (I wrote it with community edition)

## Using the code
Just open the solution using visual studio, and you're good.
If you don't want to edit the code, you can jump directly to running the executable in the [SOURCE_DIRECTORY]\PRL\bin\Release\TD.exe

## Note
There may be some bugs in the project. But I did my best to remove all of them.
If you find any bugs, please if you let me know.

## Contact info
Feel free to contact me if have any comments/questions via Amin.Babadi@yahoo.com
