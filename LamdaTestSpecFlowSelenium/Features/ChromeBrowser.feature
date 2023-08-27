Feature: ChromeBrowsers
	Testing chrome browsers

@ToDoApp
Scenario Outline: Add items to the ToDoApp - Firefox
	Given I navigate to LamdaTest App on Following environment
		| Browser   | BrowserVersion   | OS   | Build   |
		| <Browser> | <BrowserVersion> | <OS> | <Build> |
		
	Then select the first item
	Then select the second item
	Then find the text box to enter the new value
	Then click the Submit button
	And verify whether the item is added to the list

Examples:
	| Browser | BrowserVersion | OS    | Build       |
	| chrome  | 116            | macOS | Alpha Build |
	| chrome  | 116            | WIN10 | Alpha Build |