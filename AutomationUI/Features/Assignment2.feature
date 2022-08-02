Feature: Assignment2
	Assignment 2: Test a flow and product results with Test Automation Technique

@Assignment2
Scenario: 01_UNiDAYS_NavigationJourney
	Given the user navigates to the following URL 'https://www.myunidays.com/'
	And confirms the homepage has loaded and all navigation tabs are clickable and display content
	When the user clicks on the join now tab
	Then the user enters the registration information into the join now form
	| Key                         | Value                               |
	| personalEmailAddress        | personalEmail{{timeStamp}}@mail.com |
	| confirmPersonalEmailAddress | personalEmail{{timeStamp}}@mail.com |
	| password                    | p4$$w0rd123.                        |
	| confirmPassword             | p4$$w0rd123.                        |
	| gender                      | Male                                |
	| acceptTerms                 | Yes                                 |
	| successOrFailure            | success                             |

@Assignment2
Scenario Outline: 02_UNiDAYS_JoinNowValidation
	Given the user navigates to the following URL 'https://www.myunidays.com/'
	And the user confirms the homepage has loaded
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

	Examples:
	| testName                                          | personalEmailAddress                | confirmPersonalEmailAddress         | password     | confirmPassword | gender            | acceptTerms | successOrFailure           |
	| 01-personalEmailOnly                              | personalEmail@mail.com              |                                     |              |                 |                   |             | allFieldsNotEntered        |
	| 02-confirmPersonalEmailOnly                       |                                     | personalEmail@mail.com              |              |                 |                   |             | allFieldsNotEntered        |
	| 03-passwordOnly                                   |                                     |                                     | p4$$w0rd123. |                 |                   |             | allFieldsNotEntered        |
	| 04-confirmPasswordOnly                            |                                     |                                     |              | p4$$w0rd123.    |                   |             | allFieldsNotEntered        |
	| 05-genderOnlyMale                                 |                                     |                                     |              |                 | Male              |             | allFieldsNotEntered        |
	| 06-genderOnlyFemail                               |                                     |                                     |              |                 | Female            |             | allFieldsNotEntered        |
	| 07-genderOnlyPreferNotToSay                       |                                     |                                     |              |                 | Prefer not to say |             | allFieldsNotEntered        |
	| 08-acceptTermsOnly                                |                                     |                                     |              |                 |                   | Yes         | allFieldsNotEntered        |
	| 09-allFiledInGenderFemale                         | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Female            | Yes         | success                    |
	| 10-allFiledInGenderPreferNotToSay                 | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Prefer not to say | Yes         | success                    |
	| 11-acceptTermsMissingGenderMale                   | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    |                   | Yes         | missingGenderOption        |
	| 12-acceptTermsMissingGenderFemale                 | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    |                   | Yes         | missingGenderOption        |
	| 13-acceptTermsMissingGenderPreferNotToSay         | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    |                   | Yes         | missingGenderOption        |
	| 14-incorrectFormatEmailGenderMale                 | INCORRECTEMAILFORMAT                | INCORRECTEMAILFORMAT                | p4$$w0rd123. | p4$$w0rd123.    | Male              | Yes         | personalEmailFormatInvalid |
	| 15-incorrectFormatEmailGenderFemale               | INCORRECTEMAILFORMAT                | INCORRECTEMAILFORMAT                | p4$$w0rd123. | p4$$w0rd123.    | Female            | Yes         | personalEmailFormatInvalid |
	| 16-incorrectFormatEmailGenderPreferNotToSay       | INCORRECTEMAILFORMAT                | INCORRECTEMAILFORMAT                | p4$$w0rd123. | p4$$w0rd123.    | Prefer not to say | Yes         | personalEmailFormatInvalid |
	| 17-personalEmailAndConfirmPersonalEmailDoNotMatch | personalEmail{{timeStamp}}@mail.com | wrongEmail@mail.com                 | p4$$w0rd123. | p4$$w0rd123.    | Male              | Yes         | emailsDoNotMatch           |
	| 18-passwordAndConfirmPasswordDoNotMatch           | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | p4$$w0rd123. | wrongPassword   | Male              | Yes         | passwordsDoNotMatch        |
	| 19-invalidPasswordFormat                          | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | 1            | 1               | Male              | Yes         | passwordFormatInvalid      |
	| 20-missingAcceptTermsGenderMale                   | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Male              |             | missingAcceptTerms         |
	| 21-missingAcceptTermsGenderFemale                 | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Female            |             | missingAcceptTerms         |
	| 22-missingAcceptTermsGenderPreferNotToSay         | personalEmail{{timeStamp}}@mail.com | personalEmail{{timeStamp}}@mail.com | p4$$w0rd123. | p4$$w0rd123.    | Prefer not to say |             | missingAcceptTerms         |

@Assignment2
Scenario: 03_UNiDAYS_AccessibilityComplianceOfJoinNowPage
	Given the user navigates to the following URL 'https://www.myunidays.com/'
	And the user confirms the homepage has loaded
	When the user clicks on the join now tab
	Then the join now's page accessibility compliance level is checked