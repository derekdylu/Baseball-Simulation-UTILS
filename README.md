## Utilities for Baseball Simulation Project

- Baseball-Arduino: Arduino code to control catcher and ball readiness system, connected via USB
- MyConsoleApp: Server to communicate with the robotic arm, connected via RJ45
- Baseball-Simulation.bat: Batch file to start all services
- Resources: Template files for arm server from Syntec

Reminders:
- Batch file is only for Windows
- Confirm the Arduino board type in Python server and correct port number in Arduino code and physical connection
- Arm server requires specific network settings and Visual Studio dependencies, check the control panel on Windows and the documentation from Syntec
- When individually starting the services, follow the order of the batch file