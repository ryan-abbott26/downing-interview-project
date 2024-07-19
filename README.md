--DEBUGGING--

I have split out the Angular client from being included in the .sln file as I like to debug Angular apps in VS Code.
To run the Angular client, use a terminal in VS Code or a cmd prompt and run 'npm start'. It will then be hosted to https://localhost:4200

Make sure to restore nuget packages in Visual Studio & run 'npm install' in VSCode/cmd prompt before debugging.

--DATABASE--

The database being hosted locally means it's missing from any files here, therefore the connection string inside the CompanyRepository.cs file is redundant. This will need replacing with the new connection string from running the included 'db-creation.sql' file.
