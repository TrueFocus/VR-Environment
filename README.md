# Visual Pipeline for the PACOF Project 

## Project Description
This repository contains the project files for the virtual environment created for the PACOF project. This virtual environment is a visual approximation of the Franka Emika Panda and the whack-a-mole game of the PACOF project.
## Prerequisites
- Unity version 2022.3.29f
- An installation of the ROS TCP Endpoint package on the local PC.
- A PC with a connection to a Franka Emika Panda and a Force Dimension Omega 7 capable of running the `wham` launch file
## Installation Guide
1. Download the repository
2. Open the Unity hub app and press "Add"
3. Open the folder containing the downloaded copy of this repository
4. In the Unity file explorer go to Assets/Scenes and double click "VE1 v.2" to load into the virtual environment evaluated in "THE DESIGN AND DEVELOPMENT OF A VIRTUAL REALITY ENVIRONMENT FOR THE OPERATOR OF A TELEOPERATED ROBOT IN A TEST SETUP"
5. Go to robotics -> ROS settings in Unity and set the IP to 192.168.1.100 (double check to make sure the IP of the ROSConnection object has also changed) 
## Usage Guide

#### VR-Setup
Different headsets might work, but this virtual environment is designed for the HTC Vive, other headsets have not been tested. Make sure the base stations have a clear view of the operator while they are seated in a position that can access the Force Dimension Omega 7  
1. The HTC Vive should be set up using SteamVR and should be
2. Start SteamVR
3. When the scene is loaded it might be necessary to enable the Camera Offset object in which case the TestCameraHolder object should be disabled.
#### Start-up guide:
1. Turn on the Franka Emika Panda and local PC using the big red power switch and the small PC button
2. Plug the whack-a-mole game into the USB hub connected to the local PC
3. Log into the local PC and open a web browser with the IP address of the robot arm to connect to the robot arm 
4. Unlock the joints of the robot arm
5. Activate the FCI mode of the robot arm
6. Turn on the Force Dimension Omega 7
7. Calibrate the Force Dimension Omega 7
8. Plug the dark green ethernet cable into the computer used to run Unity
9. Open 2 terminal windows and enter the directory of the Catkin workspace
10. Run `roslaunch ros_tcp_endpoint endpoint.launch tcp_ip:=192.168.1.100` on the local PC
11. Run `roslaunch wham wham.launch` on the local PC
12. Open Unity on the PC used to run Unity and run with ROS IP = 192.168.1.100 in the ROS settings window (make sure the ROSConnection object has the same IP)
13. Unlock the safety button and control the robot.

#### Controls
- The "C" button can be used to calibrate the whack-a-mole game
- The space bar can be used to centre the position of the VR camera
- If necessary the height of the camera can be changed while the scene is running by changing the transform object of the "Camera Offset" object.

#### Shutdown guide:
1. Press the safety button to lock the Franka Emika Panda
2. Deactivate FCI 
3. Lock joints
4. Shut down robot
6. Shut down local pc
7. Shut down Unity and SteamVR
