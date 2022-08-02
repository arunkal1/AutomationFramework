Feature: Assignment2-UITest1
	Assignment 2: Test a flow and product results with Test Automation Technique

@Assignment2
Scenario Outline: UNiDAYS Navigation Journey
	Given the user navigates to the following URL 'https://www.myunidays.com/'
	And confirms the homepage has loaded and all navigation tabs are clickable and display content
	When the user clicks on the join now tab
	Then the user enters the registration information into the join now form
	| Key                         | Value                         |
	| personalEmailAddress        | <personalEmailAddress>        |
	| confirmPersonalEmailAddress | <confirmPersonalEmailAddress> |
	| password                    | <password>                    |
	| confirmPassword             | <confirmPassword>             |
	| gender                      | <gender>                      |
	| acceptTerms                 | <acceptTerms>                 |
	| successOrFailure            | <successOrFailure>            |
	# Check all combinations of mandatory fields only
	# check accessibility compliance level of join now page rendered

	Examples:
	| testName                                          | personalEmailAddress                    | confirmPersonalEmailAddress             | password     | confirmPassword | gender            | acceptTerms | successOrFailure    |
	| 01-personalEmailOnly                              | personalEmail@mail.com                  |                                         |              |                 |                   |             | allFieldsNotEntered |
	| 02-confirmPersonalEmailOnly                       |                                         | personalEmail@mail.com                  |              |                 |                   |             | allFieldsNotEntered |
	| 03-passwordOnly                                   |                                         |                                         | p4$$w0rd123. |                 |                   |             | allFieldsNotEntered |
	| 04-confirmPasswordOnly                            |                                         |                                         |              | p4$$w0rd123.    |                   |             | allFieldsNotEntered |
	| 05-genderOnlyMale                                 |                                         |                                         |              |                 | Male              |             | allFieldsNotEntered |
	| 06-genderOnlyFemail                               |                                         |                                         |              |                 | Female            |             | allFieldsNotEntered |
	| 07-genderOnlyPreferNotToSay                       |                                         |                                         |              |                 | Prefer not to say |             | allFieldsNotEntered |
	| 08-acceptTermsOnly                                |                                         |                                         |              |                 |                   | Yes         | allFieldsNotEntered |
	| 09-allFiledInGenderMale                           | personalEmail{{dateTimeStamp}}@mail.com | personalEmail{{dateTimeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Male              | Yes         | success             |
	| 10-allFiledInGenderFemale                         | personalEmail{{dateTimeStamp}}@mail.com | personalEmail{{dateTimeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Female            | Yes         | success             |
	| 11-allFiledInGenderPreferNotToSay                 | personalEmail{{dateTimeStamp}}@mail.com | personalEmail{{dateTimeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Prefer not to say | Yes         | success             |
	| 12-acceptTermsMissingGenderMale                   | personalEmail{{dateTimeStamp}}@mail.com | personalEmail{{dateTimeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Male              |             | allFieldsNotEntered |
	| 13-acceptTermsMissingGenderFemale                 | personalEmail{{dateTimeStamp}}@mail.com | personalEmail{{dateTimeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Female            |             | allFieldsNotEntered |
	| 14-acceptTermsMissingGenderPreferNotToSay         | personalEmail{{dateTimeStamp}}@mail.com | personalEmail{{dateTimeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Prefer not to say |             | allFieldsNotEntered |
	| 15-incorrectFormatEmailGenderMale                 | INCORRECTEMAILFORMAT                    | INCORRECTEMAILFORMAT                    | p4$$w0rd123. | p4$$w0rd123.    | Male              | Yes         | validationError     |
	| 16-incorrectFormatEmailGenderFemale               | INCORRECTEMAILFORMAT                    | INCORRECTEMAILFORMAT                    | p4$$w0rd123. | p4$$w0rd123.    | Female            | Yes         | validationError     |
	| 17-incorrectFormatEmailGenderPreferNotToSay       | INCORRECTEMAILFORMAT                    | INCORRECTEMAILFORMAT                    | p4$$w0rd123. | p4$$w0rd123.    | Prefer not to say | Yes         | validationError     |
	| 18-personalEmailAndConfirmPersonalEmailDoNotMatch | personalEmail{{dateTimeStamp}}@mail.com | wrongEmail@mail.com                     | p4$$w0rd123. | p4$$w0rd123.    | Male              | Yes         | validationError     |
	| 19-passwordAndConfirmPasswordDoNotMatch           | personalEmail{{dateTimeStamp}}@mail.com | personalEmail{{dateTimeStamp}}@mail.com | p4$$w0rd123. | wrongPassword   | Male              | Yes         | validationError     |