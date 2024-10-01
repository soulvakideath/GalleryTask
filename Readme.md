Додаток до проекту:

Пермісії для користувачів можна видавати(хардкодингом) в бд RolePermissionsEntity 

1 - Create 1 - User 

2 - Read 1 - User 

3 - Update 2 - Admin 

4 - Delete 2 - Admin


Тим самим хардкодингом можна задавати роль при реєстрації в UserRepository

public async Task Add(User user) { var roleEntity = await _context.Roles .SingleOrDefaultAsync(r => r.Id == (int)Role.Admin) //Зміни Адмін на User

Старався зробити чисту і зрозумілу архітектуру сервера(Minimal Api, Driver domain) Часу було не багато, університет забирає також багато часу, оскільки вчусь на системах штучного інтелекту. Сподіваюсь оціните мою роботу.

З того, що планую ще зробити(виключно для себе, комітити зміни не буду) Потрібно реалізувати refresh/access token Зв'язати Юзера з Альбомами Добавити сторінку crud для фотографії
