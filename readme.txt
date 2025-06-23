https://github.com/ggpgw/raftlabsdemo

This Repository contains following projects:
1. ServiceComponent
	a. This project consists of all the Model classes in Models folder - 
	User.cs - Represents User.cs file 
	UserResponse.cs - Represents UserResponse
	PagedUserResponse.cs- Represents Page Information of data fetched

b. Client Folder
This consists of classes 
	a. ComponentClient.cs- Represents Client component used to connect to webapi to get the data.
	b. IComponentClient.cs- Interface use to represent the Component Interface
c. Services
	This represent the service configuration being used to call the external service.

2. ServiceComponentDemoApp
	This is a console app used to call the ServiceComponent which inturn calls the webapi to fetch the data.
3. ServiceComponentDemo.Tests
	This is the project for test cases

To open the project :
1. Download the project
2. Clicking on ServiceComponentDemoProject.sln will open the project
3. To run the project and console application open ServiceComponentDempApp folder and in visual studio code Terminal Write dotnet run will build and execute the Program.cs file 

	
