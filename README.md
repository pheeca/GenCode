<p align="center">
  <img src="https://github.com/pheeca/GenCode/blob/main/Content/Logo Files/For Web/png/Color logo - no background.png" alt="GenCode" width="150"/>
</p>

# GenCode

[![AppVeyor](https://ci.appveyor.com/api/projects/status/l3kmfu18f4fbmuvu?svg=true)](https://ci.appveyor.com/project/pheeca/GenCode)
[![GitHub release](https://badge.fury.io/gh/pheeca%2FGenCode.svg)](https://github.com/pheeca/GenCode/releases/tag/v1.0.1)
[![NuGet package](https://badge.fury.io/nu/GenCode.svg)](https://www.nuget.org/packages/GenCode/)
[![NuGet](https://img.shields.io/nuget/dt/GenCode.svg)](https://www.nuget.org/packages/GenCode/)
[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/pheeca/GenCode/blob/main/CONTRIBUTING.md)

[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## Description

The GenCode library is a first-of-its-kind powerful ORM for LLM like GPT4 for helping LLM understand your application model. Perform NLP based model manipulaton and decision making fast for your .NET apps. With fast integration, package harness power of language tasks, including text generation, sentiment analysis, & more. See docs & examples. 

Usecases include improving data quality and enable more intelligent and adaptive software systems. With its easy-to-use API , this package empowers developers to harness the full potential of natural language processing within their projects. The library supports is continuously updated with new features and improvements. Comprehensive documentation and examples are available to facilitate rapid integration and adoption.
 Imagine if your applicantion objects can be modified by LLM Assistant based on data of object. Imagine if you could call "if" condition based of response from LLM.

## Features

- Easy Open AI integration.
- Use LLM to update class object and collection, using natural language descriptions.
- Comprehensive documentation and examples to facilitate rapid integration and adoption.
- Seamless integration into your .NET Standard 2.1 projects.
- New features and improvements added regularly.
- images/vision not supported at this time

## Use Case

- **Automatic Object Completion:** Ask LLM to fill empty fields of object
- **Dynamic Object Modification:** Ask LLM to expand or modify property of object
- **Sentiment Analysis and Property Assignment:** Ask LLM to check sentiments (positive/negitive) on object and fill the property. For example, sentiment analysis could be applied to customer feedback object.
- **Information Extraction :** Extract information from object and update object property with it. Example in a customer profile object, the LLM could extract demographic information such as age or location

These capabilities could be applied in various domains and use cases, such as:

**E-commerce:** Automatically updating product descriptions based on sentiment analysis of customer reviews.

**Customer Relationship Management (CRM):** Enhancing customer profiles by extracting and updating properties with relevant information from communication logs or social media interactions.

**Data Processing Pipelines:** Automatically completing and modifying data objects as part of data preprocessing tasks in machine learning pipelines.

**Natural Language Understanding (NLU):** Supporting conversational interfaces by dynamically updating objects based on user input and sentiment analysis of the conversation context.

## Installation

You can install GenCode via NuGet Package Manager:

```bash
nuget install GenCode
```
## Getting started

Explain how to use your package, provide clear and concise getting started instructions, including any necessary steps.

### Prerequisites

.NET Standard 2.1 or above

## Usage

Here's an example of how to use GenCode to update an object's properties using a natural language description:

```csharp
        using GenCode;

        // Story 1
        var story1 = new Story
        {
            Id = 1,
            Title = "The Lost Treasure",
            Description = "A group of adventurers embarks on a journey to find a lost treasure hidden deep within a mysterious jungle.",
            CreatedAt = DateTime.Now.AddDays(-30),
            UpdatedAt = DateTime.Now.AddDays(-15)
        };
        var key = Environment.GetEnvironmentVariable("DefaultLLM_API_KEY");
        var gencode = new GenCode(key);
        Story result = gencode.FillObject<Story>("Update Description to be more datailed", story1).Result;
        Console.WriteLine(result.Description);
```
For a collection
```csharp
        using GenCode;

        var story1 = new Story
 {
     Id = 1,
     Title = "The Lost Treasure",
     Description = "A group of adventurers embarks on a journey to find a lost treasure hidden deep within a mysterious jungle.",
     CreatedAt = DateTime.Now.AddDays(-30),
     UpdatedAt = DateTime.Now.AddDays(-15)
 };
 var story2 = new Story
 {
     Id = 2,
     Title = "The Treasure planet",
     Description = "A futuristic reimagining of Robert Louis Stevenson's classic 'Treasure Island' set in space.",
     CreatedAt = DateTime.Now.AddDays(-70),
     UpdatedAt = DateTime.Now.AddDays(-13)
 };
 var stories = new List<Story>() { story1 , story2 };

 
 var key = Environment.GetEnvironmentVariable("DefaultLLM_API_KEY");
 var gencode = new GenCode(key);
 List<Story> result = gencode.FillCollection<Story>("Update Description to be more datailed", stories.AsEnumerable()).Result.ToList();
 foreach (var resultItem in result)
 {
     Console.WriteLine(resultItem.Description);
 }
```


For Condition
```csharp
        bool? result = gencode.IsObject<Story>("Is this story correct?", story1).Result;
        Console.WriteLine(result);

        bool? result2 = gencode.Is("Does sun rise from east?").Result;
        Console.WriteLine(result2);
```
For more examples and detailed documentation, please visit our [GitHub repository](https://github.com/pheeca/GenCode).


## Additional documentation

- [Detailed documentation]()
- [Tutorial videos]()
- [Blog posts]()

## Contributing
Please read [CONTRIBUTING.md](https://github.com/pheeca/GenCode/blob/main/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Feedback

We welcome feedback from our users! If you have any questions, suggestions, or issues, please open an issue on our [GitHub repository](https://github.com/pheeca/GenCode) ~~or join our Discord channel. You can also follow us on Twitter for updates and announcements~~.

## Changelog
v 1.0.0 - Initial Architechture
v 1.0.1 - Basic working library
v 1.0.2 - Basic condition support