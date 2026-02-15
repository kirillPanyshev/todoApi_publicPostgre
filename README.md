1. Вытянуть последний вариант проекта из ветки master/main
2. Исправить строку подключения в appsettings.json по своим параметрам сервера Postgre, сохранить в локальной ветке, пересобрать проект
3. В консоли диспетчера пакетов прописать Update-database для проведения миграции
4. Запустить проект
5. Запустить Swagger в браузере по URL, указанный в открывшейся консоли, добавив к нему /swagger
Пример: https://localhost:7277 + /swagger = https://localhost:7277/swagger, http://localhost:5026 + /swagger = http://localhost:5026/swagger
http://localhost:5000 + /swagger = http://localhost:5000/swagger итд.

Так же есть версия на InMemoryDb, она лежит в репозитории todoApi_Public
Для ее запуска:
1. Вытянуть последний вариант проекта из ветки master/main, пересобрать проект.
2. Запустить проект. При успешном запуске откроется cmd с прописанной локальной ссылкой и портом(при отсутствии пакета .net 9 в IDE вылезет подсказка по установке).
3. Запустить Swagger в браузере по URL, указанный в открывшейся консоли, добавив к нему /swagger
Пример: https://localhost:7277 + /swagger = https://localhost:7277/swagger, http://localhost:5026 + /swagger = http://localhost:5026/swagger
http://localhost:5000 + /swagger = http://localhost:5000/swagger итд.
