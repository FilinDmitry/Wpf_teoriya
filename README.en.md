
# The practical work itself, its testing and refactoring, was done by students 3ISAP-223 Filin D. Bereznev Y. and Stepanov D.
## Для документации на русском, откройте [README.md](https://github.com/FilinDmitry/Wpf_teoriya/blob/PR14/README.md)
#### Примечание 
A file with a database script that does not include the records created during testing is provided in a separate file [script.sql](https://github.com/FilinDmitry/Wpf_teoriya/blob/PR14/script.sql)

### Test explorer before refactoring
<img width="1483" height="1012" alt="image" src="https://github.com/user-attachments/assets/e4f6d9ff-a1af-4116-8775-57caf1af4ff9" />


### Вывод о проведенном тестировании
Все тесты авторизации были пройдены успешно и не вызвали ошибок.

Testing of the authorization module revealed several numbers of errors:
- No validation for entering a date of birth
- No validation for entering spaces in the login and password
- No email validation during registration
- No comments or documentation for the code

### Test explorer after refactoring
<img width="1641" height="944" alt="image" src="https://github.com/user-attachments/assets/b02c3f0b-05ae-45de-adb0-a85cea7ce2b6" />


## Module of authorization and registration

Модуль предоставляет функционал для входа в аккаунт, регистрации новых пользователей и управления пользователями в базе данных.

### Метод аутентификации
Статический метод для проверки учетных данных и выполнения входа.

| Parameter | Type | Purpose |
|----------|-----|----------|
| `login_` | `string` | User's login |
| `password` | `string` | User's password |

**Возвращаемое значение:**
- `true` — вход выполнен успешно
- `false` — введены неверные данные

### Метод регистрации
Проверяет данные и добавляет нового пользователя в базу данных, а также происходит вход.

| Parameter | Type | Purpose |
|----------|-----|----------|
| `login` | `string` | Логин пользователя |
| `name` | `string` | Имя пользователя |
| `password` | `string` | Пароль пользователя |
| `email` | `string` | Почта пользователя |
| `birthday` | `DateTime?` | Дата рождения пользователя |

**Действия:**
1. Проверяет корректность введеных данных
2. Сохраняет пользователя через `Update(Users user)`
3. Осуществялет вход через `Check_user(string, string)`
**Возвращаемое значение:**
- `true` — создание пользователя выполнено успешно
- `false` — введены неверные данные для регистрации

### Variables

| Variable | Type | Purpose |
|------------|-----|------------|
| `is_reg` | `bool` | Флаг авторизации |
| `login` | `string` | Логин текущего пользователя |
| `id` | `int` | ID текущего пользователя |
| `name` | `string` | Имя текущего пользователя |
| `lst_users` | `List<Users>` | Кэш пользователей из БД |
| `min_age` | `int` | Константа минимального возраста для регистрации |

### Требования

- Контекст базы данных `Core.Context`
- Модель данных из приложенного файла `Sqript.sql`
- `WPF` для `MessageBox`

### Примечания

- Метод `Check_user` автоматически устанавливает глобальные переменные при успешном входе
- При неверных данных выводится сообщение через `MessageBox`

### The status of the methods

| Method | Access level | Purpose |
|-------|-----------------|------------|
| `Check_user` | `public static` | Авторизация пользователя |
| `New_user` | `public static` | Регистрация пользователя |
| `Update` | `private static` | Сохранение нового пользователя |
| `Emailvalidation` | `private static` | Проверка корректности email |
