Feature: NonChromeBrowser
	Testing Non chrome browsers

@ToDoApp
Scenario: Add items to the ToDoApp - Firefox
	Given I navigate to LamdaTest App on Following environment
		| Browser | BrowserVersion | OS          |
		| Firefox | 84.0           | Windowns 10 |
	Then select the first item
	Then select the second item
	Then find the text box to enter the new value
	Then click the Submit button
	And verify whether the item is added to the list