# Secure End-to-End encrypted , Chat Application using C#, SignalR , Winforms

This application is developed using the following technologies:

- C# , .Net 
- SignalR
- Windows Forms

This project was an advanced assignement in Advanced Programming subject at Polytechnic University of Tirana.

The main goal of this application is to provide end to end encryption for user one to one and group communication.
The end to end encryption is achieved using Diffie Hellman Key Exchange Algorithm.
The messages are encrypted in the database. However, the problem arose when encrypting messages end to end
for group users. The message had to be encrypted using each users public key, and sent to each receiver, who 
would then try to decrypt each one using his private key. 
Database encryption is achieved using a one time generated key for group and one time generated key for user.
