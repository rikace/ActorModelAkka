# How to run
- Start the Web Application, open http://localhost:5000
- Start the Remote application
- In the web page http://localhost:5000 click "Start drawing"

# Know issue
- if the : http://localhost:5000 is blank see this references: 
	- https://github.com/aspnet/AspNetCore/issues/4587 
	- https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-2.2&tabs=visual-studio#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos
- Run this command  `dotnet dev-certs https --trust`

