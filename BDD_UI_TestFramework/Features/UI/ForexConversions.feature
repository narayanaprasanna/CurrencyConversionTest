Feature: ForexConversions
 As a User I should be able to perform forex conversions in a converter widget

@ForexConversions
Scenario: 1_User should be able to specify numeric amount, source and target currency, and obtain conversion amount.
	Given User navigates to currency converter website
	When User able to enter the amount, source and target
	And User clicks on convert button
	Then Page should display the full conversion amount

@ForexConversions
Scenario: 2_Users should be able to specify whole integers and decimal numeric amounts.
	Given User navigates to currency converter website
	Then User should able to enter the specify whole integers and decimal numeric <amount>
Examples:
	| amount |
	| 1000   |
	| 50.5   |

@ForexConversions
Scenario: 3_Whenever system provides conversion results, it should display the full conversion amount for the value specified as well as the conversion rate of a single unit for both currencies.
	Given User navigates to currency converter website
	When User able to enter the amount, source and target
	And User clicks on convert button
	Then Page should display the full conversion amount
	And conversion rate of a single unit for both currencies

@ForexConversions
Scenario: 4_The conversion values presented for the amount specified (e.g. 10 USD = 8.90909 EUR) and the 1 unit values should be mathematically correct. i.e. if 1 USD = 0.890909 EUR, then 10 USD should equate to 8.90909 EUR.
	Given User navigates to currency converter website
	When User able to enter the amount, source and target
	And User clicks on convert button
	Then Page should display the full conversion amount
	And conversion rate of a single unit for both currencies
	Then Conversion value presented should be mathematically correct

@ForexConversions
Scenario: 5_The source and target currency dropdowns should list the most popular currencies at the top of the dropdown, and then list all other currencies in alphabetical order
	# Scenario 5: XE the current source and target dropdowns are not sorted as you stated so this cannot be validated. Requirement need to be updated.

	# Scenario 6: If user enters the negative numeric values then convert button is disabled in XE website. Requirement need to be updated.
@ForexConversions
Scenario: 6_If users specify negative numeric values, an error message should be displayed but conversion happens anyway
	Given User navigates to currency converter website
	When User enters the <NegativeAmount>, source and target
	Then Page should display the Error Message for NegativeAmount
	And Convert button should be disabled
Examples:
	| NegativeAmount |
	| -100           |

@ForexConversions
Scenario: 7_If users specify non numeric values, the system should give an error
	Given User navigates to currency converter website
	When User enters the <NonNumericValue>
	Then Page should display the Error Message for NonNumericValue
Examples:
	| NonNumericValue |
	| abc             |

@ForexConversions
Scenario: 8_User should be able to swap source and target currencies by clicking the ‘Invert Currencies’ button. Once the button is clicked on, the conversion is made
	Given User navigates to currency converter website
	When User able to enter the amount, source and target
	And User clicks on convert button
	And Page should display the full conversion amount
	And conversion rate of a single unit for both currencies
	When Invert currencies button is clicked
	Then Page should display the reverse conversions correctly

@ForexConversions
Scenario: 9_Whenever user performs a conversion (or reverses it), the page URI should be updated to reflect the amount, source and target currency for the conversion.
	Given User navigates to currency converter website
	When User able to enter the amount, source and target
	And User clicks on convert button
	Then the page URI should be updated to reflect the amount, source and target currency for the conversion

@ForexConversions
Scenario: 10_Users should be able to access a conversion page directly by specifying the right query string parameters.
	Given User navigates to currency converter website with url with query string parameters
	Then Page should display the full conversion amount

