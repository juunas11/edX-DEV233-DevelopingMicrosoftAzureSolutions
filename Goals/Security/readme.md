# Security

Your next task will be to implement a simple security feature that will allow you to protect user information within your application. You will also implement a higher-level authorization scheme that will protect the administration features from anonymous access. 

## Masking Personal Information 

You will start by implementing a common feature in Azure SQL Database that will help protect Personally identifiable information (PII). You will implement Dynamic Data Masking and have e-mail information for each user masked at the database level before data is transmitted to the end user. You will also update the application so that it no longer has admin-level access to the entire SQL Server instance.

### Requirements

Here are some basic requirements:

- Implement Dynamic Data Masking for registrant's e-mail addresses.
- Create a User in the Azure SQL Database instance that has access to create or modify records but does not have administrative-level access to the database.
- Switch the connection string in the deployed Web App instance to use your new user identity instead of the default administrative-level identity.

### Demonstrate

Your group could be called on to demonstrate your solution by debugging the ASP.NET application locally using your new connection string. While debugging, you should be able to add a breakpoint and see that the data returned to your application is already masked and the application never has access to the full e-mail address for each user.

## Enabling Azure Active Directory Authentication

Finally, you will protect the Administration portal of the ASP.NET application by enabling Azure Active Directory Authentication only for the Administration portion of the web application using ASP.NET Identity. The admin portion of the web application is implemented using an ASP.NET MVC Area making it easier to isolate the authentication to only this particular area of the web application.

### Requirements

Here are some basic requirements:

- Implement ASP.NET Identity in your web application.
- Implement Azure Active Directory as the sole identity provider for your web application.
- Use the `[Authorize]` MVC class attribute to indicate that the Administration ASP.NET MVC Area is the only area that should be protected using Azure AD Authentication.
- Add a hyperlink in the web application that directs the user to the Administration portion of the site.

### Demonstrate

Your group could be called on to demonstrate your solution. You should first validate that the majority of the web application is unprotected. You should then click the Administration link and login using Azure Active Directory credentials to access the Administration portion of the web application.
