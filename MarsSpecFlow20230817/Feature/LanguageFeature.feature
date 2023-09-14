Feature: LanguageFeature

As a QA tester for Mars application
I would like to create a new language records
so that I could mantain language details successfully


@order(1)
Scenario:01 Create a new language with valid and invalid details
	Given User logged into Mars application successfully
	When I navigte to language page
	And I create a new '<language>' with '<level>' record
	Then New  '<language>' with '<level>' record should be added successfully

	Examples: 
	| language       | level            |
	| Japanese       | Basic            |
	| Mandarin       | Native/Bilingual |
	| English        | Fluent           |
	| Chinese        | Conversational   |
	
	         
@order(2)
	Scenario:02 Edit the existing language with valid details
	Given User logged into Mars app successfully
	When I navigate to language page
	And I edit the existing '<languageToBeUpdated>' and/or '<levelToBeUpdated>' record and udpate with the new value '<language>' & '<level>' 
	Then Edited  '<language>' with '<level>' record should be edited successfully

	Examples: 
	| languageToBeUpdated | levelToBeUpdated | language		| level				|
	| Japanese			  | Basic			 | Japanese		| Fluent			|
	| Mandarin			  | Native/Bilingual | Mandarin		| Native/Bilingual	|
	| English			  | Fluent			 | #@$#@$#$12	| Basic				|
	| Chinese			  | Conversational   |  			| Fluent			|

	@order(3)
	Scenario:03 Delete the existing language with valid details
	Given User logged into Mars app successfully
	When I navigate to language page
	And I delete the existing '<language>' && '<level>' record
	Then I deleted record for '<language>' && '<level>' sucessfully

	Examples: 
	| language				| level				| 
	| Japanese				| Fluent			| 
	| Mandarin				| Bilingual         |	
	| #@$#@$#$12			| Native/Bilingual  |
	| Chinese				| Fluent			|


