# APITestFramework
A testing framework for the API at numbersapi.com

## Installation

1. Download the project and unzip
2. Open the solution file with visual studio

---
## Information about the Numbers API

There are 4 categories of GET requests which the Numbers API provides:
1. Trivia
2. Math
3. Date
4. Year

These requests are sent in the following format:
```
*number*
*number*/*category*
random
random/*category*
*month*/*day*/date
```
These requests are returned as plain-text, but can be returned as JSON if specified.

### **Please note that sending a number with no category will default to trivia.**
---
Here are some example requests:
```
99/trivia
```
will return the following JSON:

```{
    "text": "99 is a common price ending in psychological pricing.",
    "number": 99,
    "found": true,
    "type": "trivia"
}
```
---
```
2/3/date
```
will return the following JSON
```{
    "text": "February 3rd is the day in 1900 that Governor of Kentucky William Goebel dies of wound sustained in an assassination attempt three days earlier in Frankfort, Kentucky.",
    "year": 1900,
    "number": 34,
    "found": true,
    "type": "date"
}
```
---
## Instructions

In order to begin testing, in the test class you must declare a service object.
```
SingleTriviaService _myService;
```
Then ensure that the SetUp function looks as follows:
```
[OneTimeSetup]
public async Task SetUp
{
  _myService = new();
  await _myService.GetRequestAsync("*category*/*number*");
}
```
Access the requests header files through the ```Service``` class methods:

- ```GetStatusCode()```
- ```GetContentType()```
- ```GetContentLength()```

The JSON returned by the API is stored inside of the Service class. Access it via the ```Content``` property. From there you can
access the ```Text```, ```Type```, ```Found``` and ```Number``` properties. Requests of type Date and Year will also contain a
```Year``` property.

An example of accessing the Text property would be as follows:
```
string text = _myService.Content.Text;
```
---
## Implementation

The API requests are handled by 3 classes, ```Service```,```CallManager``` and ```DTO```.

### Service

The ```Service``` class contains method definitions for the main interface between the tester and the API. This should be the only
object which the tester needs to interface with. 

*Properties*

- ```CallManager```, which handles the API requests, holds the returned headers and returns a string containing the JSON body.
- ```DTO``` which is responsible for parsing the returned string into JSON, which is then converted into a ```Model``` object.
- ```Model``` which contains the converted body of the response.

*Methods*

The public facing functions which will be used by the tester are:

```MakeRequestAsync()``` which handles the creation, sending, returning and converting of the request, via the contained classes.

Helper functions for accessing header elements. These consist of ```GetStatusCode()```, ```GetContentType()``` and ```GetContentLength()```.
If the project were to be extended, we would expand these helper functions to access every header from the response.

### CallManager

The ```CallManager``` class is responsible for creating and sending the API request, implemented using the C#'s inbuilt HTTPClient library. It receives
the returned request, in the form of an ```HttpResonseMessage``` object. This is split into the headers, which are stored as a property on the class, and returns a string containing the JSON body back to its containing ```Service```.

### DTO

The ```DTO``` is a simple object which has only one method: ```DeserializeJson()```. It takes a string input, converts it to JSON, then converts this into a ```Model```
object which contains the body of the request. This class exists purely to separate our JSON deserializing implementation from the ```Service``` class.

---
## Authors

Jasser Bawi

Alex Blunt

Scot Morrison
