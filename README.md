## HelPaw Backend

Це бекендова частина проєкту HelPaw — платформи для взаємодії волонтерів та притулків з метою допомоги безпритульним тваринам.

### Технології

- ASP.NET Core 8 Web API
- Entity Framework Core
- PostgreSQL
- Docker
- SignalR

### Швидкий старт

**Клонувати репозиторій:**

```bash
git clone https://github.com/GongoTeam/.git
cd backendhelppaw
```

**Налаштувати змінні середовища:**

Створити `.env` файл у корені проєкту на основі `.env.example`:

```bash
cp .env.example .env
```

Вказати свої дані до бази даних та JWT ключ у файлі `.env`.

**Запуск через Docker:**

```bash
docker-compose up --build
```

**Перевірка API:**

Swagger UI буде доступний за адресою:

[http://localhost:5000/swagger](http://localhost:5000/swagger)
