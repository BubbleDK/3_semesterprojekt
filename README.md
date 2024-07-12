# Booking for Internetcafé (Gamingcafé/Onlinecafé)
![image](https://github.com/user-attachments/assets/707ffd90-dfaf-4e43-9740-44887b626d03)


## Overview

Welcome to Bookingsystem for an (imaginary) Internetcafé. A project developed on the 3rd semester of AP in Computer Science at UCN Aalborg by Christian Funder, Emil Tolstrup Petersen, Jakob Kjeldsteen, Mark Drongesen and Rasmus Gudiksen.

This project is the development of a Bookingsystem for an imaginary Internetcafé. The project consists of a Winforms based desktop app as frontend and a C# based backend with a relational SQL database

## Table of Contents
- [Usage](#usage)
- [Acknowledgements](#acknowledgements)

## Usage

This project has no actual use but is a learning project. The goal of the project was to learn about data concurrency and consistency. In a bookingsystem theres a possibility of more than one (1) user attempting to access the same resource.
Therefore we have to take measures to ensure that a seat is not booked twice in the same time interval and inform a user if they have tried to access a resource accessed by someone else.

The system can create bookings for a specific time interval, and save those to a database for one or more people at the same time.

The system also handles proper securing of passwords via a hashing algorithm (in this case Bcrypt)

Below are UI examples from the desktop app:

![image](https://github.com/user-attachments/assets/56077912-4f85-4cc0-b6e5-e32210aadf87)

![image](https://github.com/user-attachments/assets/dc99226f-48aa-4e07-8bf8-af2ce9d3f487)

![image](https://github.com/user-attachments/assets/2721feb4-9e6c-4b14-a2ed-46bb5dcf2fd2)

### Acknowledgements

Contributors: 
  - Emil Tolstrup Petersen ([BubbleDK](https://github.com/BubbleDK))
  - Jakob Kjeldsteen ([jkeldsteen](https://github.com/jkjeldsteen))
  - Christian Funder ([Youngfundish](https://github.com/Youngfundish))
  - Mark Drongesen ([DrDronge](https://github.com/DrDronge))
  - Rasmus Gudiksen ([neskidug](https://github.com/neskidug))

### Roadmap

No further development will be made on this project as it was part of a school project.

