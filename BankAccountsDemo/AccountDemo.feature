Feature: AccountDemo

  As a user
  I want to manage bank accounts
  To perform various transactions


Scenario Outline: Create new Account with valid data
	Given Account Initial Balance is <initialBalance> 
	And Account name is '<accountName>'
	And Address is '<address>'
	When POST endpoint triggered to create new account with above details
	Then Verify the response code is Ok
	And Verify no error is returned
	And Verify the success message "Account created successfully"
	And Verify the account details are correctly returned in the JSON response for expected '<NewAccountNumber>'
	Examples: 
	| initialBalance | accountName | address | NewAccountNumber |
	| 1000           | Xyz         | Delhi   | X123             |
	| 2000           | Abc         | Noida   | Y456             |

Scenario Outline: Deposit money to an account
  Given Account with number '<accountNumber>' exists
  When PUT endpoint triggered to deposit <depositAmount> in <accountNumber>
  Then Verify the response code is 200
  And Verify no error is returned
  And Verify the success message "<depositAmount>$ deposited to Account <accountNumber> successfully"
  And Verify the new balance is <expectedBalance> in the response

Examples:
  | accountNumber | depositAmount | expectedBalance |
  | X123          | 500         | 1500          |
  | Y456          | 1000        | 3000          |

  Scenario Outline: Withdraw money from an account
  Given Account with number '<accountNumber>' exists
  When PUT endpoint triggered to withdraw <withdrawAmount> from <accountNumber>
  Then Verify the response code is 200
  And Verify no error is returned
  And Verify the success message "<withdrawAmount>$ withdrawn from Account <accountNumber> successfully"
  And Verify the new balance is <expectedBalance> in the response

Examples:
  | accountNumber | withdrawAmount | expectedBalance |
  | X123          | 500         | 1000          |
  | Y456          | 1000        | 2000          |


  Scenario Outline: Delete existing account
  Given Account with number '<accountNumber>' exists
  When DELETE endpoint triggered with '<accountNumber>'
  Then Verify the response code is 200
  And Verify no error is returned
  And Verify the success message "Account <accountNumber> deleted successfully"

Examples:
  | accountNumber |
  | X123          |
  | Y456          |