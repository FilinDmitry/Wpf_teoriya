
# The practical work itself, its testing and refactoring, was done by students 3ISAP-223 Filin D. Bereznev Y. and Stepanov D.
## Для документации на русском, откройте [README.md](https://github.com/FilinDmitry/Wpf_teoriya/blob/PR14/README.md)
#### Примечание 
A file with a database script that does not include the records created during testing is provided in a separate file [script.sql](https://github.com/FilinDmitry/Wpf_teoriya/blob/PR14/script.sql)

### Test explorer before refactoring
<img width="1483" height="1012" alt="image" src="https://github.com/user-attachments/assets/e4f6d9ff-a1af-4116-8775-57caf1af4ff9" />


### Conclusion about the testing performed
All the authorization tests were passed successfully and did not cause any errors.

Testing of the regestration module revealed several numbers of errors:
- No validation for entering a date of birth
- No validation for entering spaces in the login and password
- No email validation during registration
- No comments or documentation for the code

### Test explorer after refactoring
<img width="1641" height="944" alt="image" src="https://github.com/user-attachments/assets/b02c3f0b-05ae-45de-adb0-a85cea7ce2b6" />


## Module of authorization and registration

The module provides functionality for logging into an account, registering new users, and write users in the database.

### Authentication method
A static method for checking data and logging in.

| Parameter | Type | Purpose |
|----------|-----|----------|
| `login_` | `string` | User's login |
| `password` | `string` | User's password |

**Returned value:**
- `true` — user succesfully logged into an account
- `false` — invalid input data

### Registration method
Checks the data and adds the new user to the database, and then make user logged in.

| Parameter | Type | Purpose |
|----------|-----|----------|
| `login` | `string` | User's login |
| `name` | `string` | User's name |
| `password` | `string` | User's password |
| `email` | `string` | User's email |
| `birthday` | `DateTime?` | User's birthday |

**Actions:**
1. Verifies the correctness of the entered data
2. Save user via `Update(Users user)`
3. Log via `Check_user(string, string)`
**Returned value:**
- `true` — if user creation was completed successfully
- `false` — incorrect registration information has been received

### Variables

| Variable | Type | Purpose |
|------------|-----|------------|
| `is_reg` | `bool` | Authorization flag |
| `login` | `string` | Current user's login |
| `id` | `int` | Current user's ID |
| `name` | `string` | Current user's name |
| `lst_users` | `List<Users>` | User cache from the database |
| `min_age` | `int` | The minimum age of user for registration |

### Requirements

- Database context `Core.Context`
- The data model from the attached file `Sqript.sql`
- `WPF`

### Remarks

- The `Check_user` method automatically sets global variables when a user logs in successfully
- If the data is incorrect, a message is displayed using `MessageBox`

### The status of the methods

| Method | Access level | Purpose |
|-------|-----------------|------------|
| `Check_user` | `public` | User authorization |
| `New_user` | `public` | User regestratration |
| `Update` | `private` | Saving a new user |
| `Emailvalidation` | `private` | email validation |
