# Search

Your next task will be to implement a search experience for your end users. Listing events in chronological order is not a solution that scales well to thousands or millions of events. To be proactive, your team has decided that it is time to implement a search solution with an API that can be used by third-parties.

## Implementing a Search Experience 

You will start by implementing a basic search page for your application. For this task, you will use Azure Search as your search engine since it integrates with Azure SQL Database in a relatively simple manner. You will create an indexer that automatically pulls data from the SQL Database instance and then updates the search engine. You will also ensure that any search requests from end users will only search the Title and Description fields.

### Requirements

Here are some basic requirements:

- Create a Search web page that allows you to search for Events.
- Implement Azure Search to support searching for events by title or description.
- Implement an automated Azure Search Indexer to pull data from SQL Database into the search engine's indexer.
- Show a result page with the list of events that matched the search query.

### Demonstrate

Your group could be called on to show off your search solution and web page. You may also be asked to show the code or HTTP request that constructed the search query.

## Creating a Public Events API

Now that you have a search engine in place, you should expose some of this search functionality to third-party applications that would like to integrate with your website. For this task, you will implement Azure API Management as a proxy service to route requests from external entities to your protected Azure Search instance. In API Management, you will create a portal experience that others can use to sign up for your API and use your search engine.

### Requirements

Here are some basic requirements:

- Create an API endpoint from your application to search events (**Hint:** You can use MVC Web API to create an `APIController` implementation).
- Integrate your application's HTTP endpoint as an API within the API Management service.
- Expose your API Management APIs using an Operation.

### Demonstrate

Your group could be called on to demonstrate their API Management portal. If called, you should allow other teams in the room to sign-up for your API and test it out using a tool such as [Fiddler](http://www.telerik.com/fiddler) or [Postman](https://www.getpostman.com/).
