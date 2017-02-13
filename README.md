# angular2-nancy-notebucket

Angular 2 & NancyFX sample application with persistence, JWT authentication and other stuff.

![Screenshot 1](/screenshot1.png) ![Screenshot 1](/screenshot2.png)

This tiny web application is a WIP sample for a Angular 2 web application using C# and NancyFX as a REST backend.

The sample shows:

	* A possible loosely coupled structure of a Nancy-based REST backend 
	
	* Integrated Persistence Layer with a database, NHibernate, Schema Migrations
	
	* Integrated Session per Request Pattern using Nancy
	
	* Host Angular Application inside Nancy Application Host
	
	* REST Authentication and Authorization using JWT

So what is NoteBucket?  
NoteBucket is a fictional and awesome app that lets you store thoughts and wisdom as virtual notes.
Notes are categorized by folders and each user can define as many folders as he or she wants. 
So it's basically the online version of the good old Microsoft Notepad.

Currently, folder and note creation is not implemented, just note updates.
You can play with the demo data provided (see below).


## Build and Run

*This will take you approx. 5 minutes*:
1. Clone

2. Open the Solution File within Visual Studio or Mono Develop

3. Build the Solution. All assemblies are put into the artifacts/ folder.

4. Run the build-db.cmd or build-db.mono (don't forget to chmod +x on Linux / Mac) to build the SQLite database schema

5. Run NoteBucket.Backend.HostApplication.exe

6. REST is ready on localhost:5000

7. Navigate to localhost:5000/api/demo to create some demo data

8. Shell "cd NoteBUcket.Frontend/"

9. Shell "npm install"

10. Shell "gulp"

11. The web application gets compiled and artifacts are stored under artifacts/Content

12. localhost:5000/ to start the app


*Generated Test Logins*:
threepwood@note-bucket.io, Password: mightypirate
R2D2@note-bucket.io, Password: beepbeep


## Information on Backend Architecture

WIP.

## Persistence in a Nutshell

WIP.
Brief description of Persistence implementation coming soon.


## Authentication and Authorization in a Nutshell

WIP.
Brief description of Authentication/Authorization implementation coming soon.


## Contribute

The sample is not perfect, I've put it together within a day. 
I really welcome any feedback, improvements and features to the app.