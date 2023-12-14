This is a Unity project developed for Oculus Quest 2 headset. 

The build may fail in the first try. Build and run again if the build fails.

**In game controls:**

  Return to main menu:     X + Y button
  
  Toggle Map On/Off  :     Index triggers
  
  Movements          :     Left Thumbstick

**Main Objective:** Go to the cave on the upper-left side of the map. 

**Challenges Encountered:**

The first challenge that we faced was to set up the maze generator object into the terrain. We used different 3D game objects for reference and set up the size of the maze accordingly. 

During the generation of a maze, we encountered a phenomenon known as Z-fighting affecting the cell walls. Z-fighting occurs when two or more polygons overlap in three-dimensional space and occupy the same depth in the framebuffer. As a result, the graphics engine is unable to determine which polygon should be drawn in front, leading to the flickering or jagged visual artifacts. Changing the dimension of maze cells resulted in an inconsistent maze. So, we dealt with the issue by adjusting the texture of the maze walls in order to mitigate the effect. 

Initially, both the terrain and the maze grid were bigger in size. The terrain also contained a lot of trees. This all was really computationally heavy. So, it caused stuttering when the project was run on the Quest 2 headset. So, we had to scale down the game environment to tackle the issue. 

At first, we intended to incorporate the riddles within the maze. But the maze itself was narrow, which made the task challenging. So, we implemented the maze chambers as a way to teleport the players in another scene. It not only solved this problem, but also helped us with the game’s storyline. 

**Potential Changes:** 

Multiplayer Mode: Implementing a multiplayer feature where players can compete or collaborate to solve the maze adds a social dimension to the game, enhancing its appeal.

VR Haptic Feedback Integration: Incorporating haptic feedback would make the game more immersive, allowing players to physically feel in-game interactions.

