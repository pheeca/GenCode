# GenCode

[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## Description
Note: Not usable at the moment, Avoid usage

The GenCode library is a powerful tool for incorporating advanced language modeling capabilities into your .NET applications. With its easy-to-use API and seamless integration process, this package empowers developers to harness the full potential of natural language processing within their projects. The library supports various language tasks, including text generation, sentiment analysis, and more, and is continuously updated with new features and improvements. Comprehensive documentation and examples are available to facilitate rapid integration and adoption.

## Features

- Easy-to-use API for interacting with advanced language models.
- Seamless integration into your .NET Standard 2.1 projects.
- Support for various language tasks, including text generation, sentiment analysis, and more.
- Comprehensive documentation and examples to facilitate rapid integration and adoption.
- Support for .NET 6 and above.
- New features and improvements added regularly.
- Ability to update object properties using natural language descriptions.
- images/vision not supported at this time


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

var story1 = new Story
{
    Id = 1,
    Title = "The Lost Treasure",
    Description = "A group of adventurers embarks on a journey to find a lost treasure hidden deep within a mysterious jungle.",
    CreatedAt = DateTime.Now.AddDays(-30),
    UpdatedAt = DateTime.Now.AddDays(-15)
};
var gencode = new GenCode(apiKey, "https://api.deepinfra.com/v1/openai");
Story result = await gencode.FillObject<Story>("Update Description to be more detailed", story1);
Console.WriteLine(result.Description);
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
v 0.0.0 - Initial Architechture