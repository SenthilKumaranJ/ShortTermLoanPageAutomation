Feature: AudenShortTermLoan
	In order to decide and choose the appropriate amount of loan
	As a customer
	I should be able to vary, analyse and select appropriate loan amount

@Basestate

@Testcases
Scenario: Drag slider to minimum. Customer should not be able to set it less than £200
	Given I launch the ShortTermLoan Page
	When I set the loan amount slider to minimum
	Then Minimum loan amount should be £200 on the slider value 

Scenario: Drag slider to Maximum. Customer should not be able to set it to more than £500
	Given I launch the ShortTermLoan Page
	When I set the loan amount slider to Maximum
	Then Maximum loan amount should be £500 on the slider value

Scenario: After moving slider, Slider value is equal to the calculated loan value displayed below
	Given I launch the ShortTermLoan Page
	When I set the loan amount slider to any value
	Then loan slider value should be equal to the calculated loan value

Scenario: Setting Loan repayment as Sunday
	Given I launch the ShortTermLoan Page
	When I set the loan amount slider to any value
	And I set the payment date as Sunday
	Then First Payment date will be a Friday

Scenario: Setting Loan repayment as Saturday
	Given I launch the ShortTermLoan Page
	When I set the loan amount slider to any value
	And I set the payment date as Saturday
	Then First Payment date will be a Friday

	