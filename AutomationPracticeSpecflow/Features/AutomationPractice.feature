Feature: AutomationPractice
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](AutomationPracticeSpecflow/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Create Account
Given I do not have an account
When I sign up with my email
And Fill in my personal information
And Fill in my address information
And Register for an account
Then I can see my account is logged in


@mytag
Scenario: Log into Account
Given I have an account
When I log into my account
Then I can see my account is logged in

@mytag
Scenario: Log in with bad credentials
Given I have an account
When I log into my account with incorrect details
Then I cannot log in