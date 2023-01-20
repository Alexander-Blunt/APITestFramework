# APITestFramework
A testing framework for the API at numbersapi.com

## Installation

??
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
## How to use it

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
## How it works

---
## Authors

Jasser Bawi

Alex Blunt

Scot Morrison
