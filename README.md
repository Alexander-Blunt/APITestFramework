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

In order to begin testing, in the test class you must declare an appropriate service object based on the category you are testing.
```
SingleTriviaService _myTriviaService;
SingleMathService _myMathService;
SingleYearService _myYearService;
SingleDateService _myDateService;
```
Then ensure that the SetUp function looks as follows:
```
[OneTimeSetup]
public async Task SetUp
{
  _myTriviaService = new();
  await _myTriviaService.GetRequestAsync("category_string");
}
```
Access the API's returned status code with the ```GetStatusCode()``` method.

The JSON returned by the API is stored inside of the Service class. Access it via the ```Content``` property. From there you can
access the ```Text```, ```Type```, ```Found``` and ```Number``` properties. Requests of type Date and Year will also contain a
```Year``` property.

An example of accessing the Text property would be as follows:
```
string text = _myTriviaService.Content.Text;
```
---
## Implementation

The API requests are handled by 2 classes, ```Service``` and ```CallManager```.

### CallManager

The ```CallManager``` class is responsible for creating and sending the API request, implemented using the RestSharp library. It accepts
the returned JSON, then returns a ```RestResponse``` object back to its containing ```Service```.

### Service
The ```Service``` abstract class contains method definitions for the main interface between the tester and the API. This should be the only
object which the tester needs to interface with. 

It contains a ```CallManager```, which handles the API requests and returns the ```RestResponse```.

Subclasses of ```Service``` contain specific implementations of the ```MakeRequestAsync()``` method, which put appropriate suffixes for
making specific requests from the API. These methods all take a string argument, which is the number(s) to be passed to the ```CallManager``` 
as part of the API Request.

After the ```CallManager``` returns a ```RestResponse```, the ```Service``` then parses this into a public ```Model``` object, which has public
properties.

The public facing functions which will be used by the tester are:
- ```MakeRequestAsync()``` which is used in setup to create, send and return a request.
- ```GetStatusCode()``` which returns the status code of the query.

There is also the ```Content``` property, which contains the ```Model``` returned by the request. This will be directly accessed by the tester
to obtain specific data from the request, such as ```Text``` for the body, ```Type``` for the type of request etc.

---
## Authors

Jasser Bawi

Alex Blunt

Scot Morrison
