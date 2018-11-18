## Project Aims

The following list gives a vague plan for this project

~~- [x] Users can register and login~~
- [ ] ~~When logged in,~~ users can see a list of bugs in a table
  - Columns: Title of bug, Date created
  - Columns are _not_ sortable
- [ ] User can click on a bug title and will be taken to a page with bug details
  - Page will include:
    - Title
    - Date Created
    - Status
    - Description
- [ ] User can create a bug by clicking a button on the main screen
  - Clicking the button opens a modal which collects information on the bug
    - Title
    - Description
  - Date Created is inferfed
  - As is status (defaults to Open)
- [ ] User can assign a bug to another user (or self), when viewing bug details
  - If the bug is not assigned to anyone, the "Assigned to" table is not visible
  - A buton is visible on the details view which opens a modal
  - Modal has a select element with a list of all users, and a button labelled "assign"
- [ ] Dockerfile allows for creation of container