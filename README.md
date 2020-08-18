# TurretShooterGame

Overview
The goal of this project was to improve my knowledge and understanding in the Unity engine, learn 3D modeling with Blender, and improve my proficiency with the C# programming language.

Although incomplete, this project has helped me learn a lot of valueble skills.  I will take what I've learned into future personal projects, or in the computer science field.  

Platform
This game was made in Unity version 2019.3.0 and all code was written in C#.  3D assets were made in Blender version 2.8 and animated on Adobe's Mixamo website.  

Current State

Player

Movement
 - Player movement is similar to League of Legends.  To move, just click the destination and the player will autopath there.  
Enemies
 - A prefab of an enemy created in Blender and animated on Mixamo.  Placed enemies will target the player until killed.  The player can click on enemies to target them, however attacking has not been implemented yet for either the player or enemy.  Enemies also have health bars that will deplete and disappear when at 0 health.
Turrets
 - The player can also interact with the turret, however turrets' "upgrade" option is not programmed yet.  Turrets will automatically lock onto the closest enemy and shoot until the enemy is dead or out of range.  
Map
 - The map is simply a flat plane with trees made in Blender boardering the edge.
