# Drone Visualization

This is an informal project for testing out the new Unity VFX graph workflow. In it you fly a drone around in pitch darkness, and as its scanners pick up information about nearby objects it displays it in the form of a VFX particle.

<img src="https://media.giphy.com/media/gLL7h7e0dcWuStD6dn/giphy.gif" width="600" height="388" />

## Running the Project

This project is built off of Unity 2019.1.0b8 (a beta build). That said, it doesn't explicitly use any beta features, so it might run on or be convertable to 2018.3. The project also uses version 5.8.2 of the Visual Effect Graph package. Finally, note that the VFX graph requires a HDRP project.

Once the project is open you can find the project files in the "Drone Visualization" folder. The main scene is named similarly.

### Controls

* WASD - standard movement
* Q - move down
* E - move up
* J - rotate left
* K - rotate right

## Viewing the Code

The interesting files in the project are:
* `ScanVFX` : contains the VFX graph that runs all the visuals
* `Scanner` : C# script that hooks up to ScanVFX and controls particle spawning
