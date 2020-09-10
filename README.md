# Validation 2 Classwork


## Models
ClubMember
- id : unique integer for identifying a ClubMember
- nickName : required
- firstName : required field
- lastName : required field
- clubRole : required (e.g. "President")
- email : must be valid email pattern
- phone - must be a valid phone number pattern

## Validation
- Add appropriate data annotations to model to enforce conditions
- Add appropriate data annotations to model to tailor the field label
- Add a custom error message to data annotations in model for any validated fields
- In *both* create and edit forms:\
	- At top of form add a generic message to "Please correct the following errors" *and* a bullet list of the validation errors found
	- Tailor validation error messages to display below any field in the form that fails validation
	- Style the field validation error messages *and* the form fields in error using CSS so they standout (e.g. red text and/or border or similar)
- Make the changes necessary to `_Layout.cshtml` to enable *client-side validation*

## Endpoints
- View All ClubMembers 
	- pass all ClubMembers in the database to a view
- View a ClubMember by ID
	- find a ClubMember by ID and pass to a view
	- if a ClubMember isn't found by ID return an ERROR view displaying an appropriate message 
- Display New ClubMember Form
	- render a view with a new ClubMember form
- Create a ClubMember
	- add a ClubMember to the database from an instance of the ClubMember model
	- if model is valid redirect to the view displaying all ClubMembers in the database
	- if the model throws an error pass a general error message to the view and display it above the form in the New ClubMember Form
	- if the model throws an error redirect to New ClubMember Form where errors should be displayed as specified above
- Display Update ClubMember Form
	- find a ClubMember by ID and pass to a view that renders an update ClubMember form
	- if a ClubMember isn't found by ID return an ERROR view displaying an appropriate message 
- Update a ClubMember
	- find a ClubMember by ID and update the found ClubMember in the database
	- if model is valid redirect to the view displaying all ClubMembers in the database
	- if the model throws an error pass a general error message to the view and display it above the form in the Edit ClubMember Form
	- if the model throws an error redirect to Edit ClubMember Form where errors should be displayed as specified above
- Delete a ClubMember
	- find a ClubMember by ID and delete from database
	- if a ClubMember isn't found by ID return an ERROR view displaying an appropriate message 

## Views
- View All ClubMembers
	- display a table of each ClubMembers' full name and ClubMember Position
	- link to each ClubMembers detail's from the ClubMembers full name
- View ClubMember Detail
	- display all properties for the ClubMember
	- display a button to edit a ClubMember
	- display a button to delete a ClubMember
- New ClubMember Form
	- display a form using HTML helper tags to create a new ClubMember
	- include all model properties except ID
	- pass form inputs to the Create a ClubMember action on submit
	- if form produces validation errors on submit, return to the form where errors should be displayed as specified above
- Update ClubMember Form
	- display a form using HTML helper tags to update an existing ClubMember
	- include all model properties
	- ClubMember ID should be a hidden form field
	- pass form to Update a ClubMember on submit
	- if form produces errors on submit, return to the form where errors should be displayed as specified above
- Error
	- display simple error message (e.g. "ClubMember Not Found") using View Data

