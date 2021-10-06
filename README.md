# Introduction

An API "SampleAPP" is provided with operations over a simple data model with two entities 1...N.
The API is structured using a layered architecture:

	- SampleApp.Api: controllers to access the different functionalities.
	- SampleApp.Application: business logic.
	- SampleApp.Application.Contracts: Interfaces & DTOs used by the API.
	- SampleApp.Infrastructure: data persistence.
	- SampleApp.Domain.Entities: DB entities.

The solution has two JSONs included used to seed the entity framework context (works InMemory).
In the SamplesController you will find all the functionalities this controller must implement already defined, some of the business logic is also implemented, you will have to finish the implementation of each one of the Application methods.

# Requirements

All the methods in the controller should implement the logic in it's definition. 
Although the entity context is already defined you have to implement the access to this context in each and every functionality provided the way you see fit.

## GetAllAsync

Apart from the expected logic described in the controller, the number of rows retrieved must be limited based on a configuration key. 
*For example: you can limit a request to the last N rows based on creation date.*

## UpdateAsync

The request must be validated according to these requirements:

- Name and Id properties are mandatory.
- Name has a MaxLength of 32 chars.
- Id must exist in the context.

## New Functionality

New endpoint to retrieve the SubSamples and it's Sample data flattened. Additionally:

- The request should allow to filter the results based on a "Sample"."Created" range.

Expected response structure:

```JSON
[
    {
        "SampleId": "",
        "SampleName": "",
        "SampleCreated": "",
        "SubSampleId": "",
        "SubSampleInfo": ""
    }
]
```

# Questions over the API

- Why do you think the dependency injection is implemented in each layer and not only in the Api?
- Do you think there is anything that can be improved in the SamplesController?

*These questions can be answered in Spanish*.

# Requirements summary
To help you keep track of it:
- Implement data access for each and every request already provided.
- Add limit based on config key on GetAll functionality.
- Validations Update method.
- New functionality with flattened data.
- Answer the questions