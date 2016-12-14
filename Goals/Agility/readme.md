# Agility

Your first task will be to create an agile development and deployment solution that will allow your team to work together to author the solution and automatically deploy it to Azure. You will make a small change to the application as your second task to validate that your solution works.

## Configuring a Continuous Deployment Solution

You will start by implementing a continuous deployment solution. This solution is two-fold. First, there should be an App Service Web App that will be the eventual production instance of your application. Second, there should also be an online-hosted source control repository. The code in the primary branch of this repository should be the "gold" code that is reflected in the application running in your production instance. Your goal is to automate the deployment of code from your online source control repository to your application instance in Azure.

### Requirements

Here are some basic requirements:

- The solution must be web-hosted so that others can validate that your code is publically accessible.
- The solution should automatically deploy any code changes to an Azure Web App instance (*Hint: It does not necessarily need to deploy the solution to your production hosting slot*).  
- The solution should allow your team to collaborate and work on different parts of the application simultaneously.
- The solution should allow your team to communicate with each other via comments, text or some other measure.

### Demonstrate

Your group could be called on to review how you can track, review and merge changes as a team. You may also be asked to demonstrate a small change in the application being automatically deployed to Azure.

## Modernizing the Events Page

You will now prove that your continuous deployment solution works by updating code in GitHub and deploying it automatically to an Azure Web App instance. You should be able to use the GitHub flow to create branches for each feature and have various team members work on the specific features in their dedicated branch. Once complete, these team members can issue a pull request to merge their features back to the master branch. Your continuous deployment solution should then automatically deploy the code to Azure and you should immediately see the changes in the Web App solution. Your goal is to prove your continuous deployment workflow by implementing a simple real-world feature.

### Requirements

Here are some basic requirements:

- The solution should change the appearance of the home page listing all events.
- The solution should change the appearance of the event detail page listing details for an individual event.
- Use Bootstrap 4 UI components exclusively for each page that is changed.

### Demonstrate

Your group could be called on to demonstrate your changes to the home page (showing all events) and the event-detail page (showing a single event).
