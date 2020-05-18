-- 1. (#15)  Напишите SQL запросы  для решения задач ниже.
--   1) Тактовые частоты CPU тех компьютеров, у которых объем
--   памяти 3000 Мб. Вывод: id, cpu, memory
        SELECT id, cpu, memory
          FROM PC
         WHERE memory = 3000
        ORDER BY id;
--   2) Минимальный объём жесткого диска, установленного в
--   компьютере на складе. Вывод: hdd
        SELECT MIN(hdd)
          FROM PC;
--   3) Количество компьютеров с минимальным объемом жесткого диска,
--   доступного на складе. Вывод: count, hdd
        SELECT COUNT (id), (SELECT MIN(hdd) FROM PC) AS min_hdd
          FROM PC
         WHERE min_hdd = hdd;

-- 2. (#30) Есть таблица следующего вида:
      CREATE TABLE track_downloads (
        download_id INTEGER PRIMARY KEY AUTOINCREMENT,
        track_id INT NOT NULL,
        user_id BIGINT(20) NOT NULL,
        download_time TIMESTAMP NOT NULL DEFAULT 0
      );

      INSERT INTO track_downloads
        (track_id, user_id, download_time)
      VALUES
        (4749, 383, '2010-11-19'),
        (4643, 383, '2010-11-19'),
        (844, 232, '2010-11-12'),
        (22, 4949, '2011-03-15'),
        (12, 84, '2010-02-02'),
        (885, 2323, '2010-11-19');

  -- Напишите SQL-запрос, возвращающий все пары (download_count, user_count),
  -- удовлетворяющие следующему условию:
  -- user_count — общее ненулевое число пользователей, сделавших
  -- ровно download_count скачиваний 19 ноября 2010 года.
    SELECT COUNT(download_id) AS download_count, COUNT(DISTINCT user_id) AS user_count
      FROM track_downloads
     WHERE download_time = '2010-11-19';

-- 3. (#10) Опишите разницу типов данных DATETIME и TIMESTAMP
    /*

    В MySQL функции DATE(), DAY(), MONTH() работают как в TIMESTAMP, так и в DATETIME.
    SQLite поддерживает только DATETIME.
    Объявление TIMESTAMP в SQLite: timestamp DATETIME DEFAULT CURRENT_TIMESTAMP.

    DATETIME
      - Использует 8 байт
      - Не привязан к временным зонам
      - Допустимый диапазон значений: 1000-01-01 00:00:00 to 9999-12-31 23:59:59

    TIMESTAMP
      - Значения преобразуются из текущего часового пояса в UTC для хранения и
        обратно преобразуются из UTC в текущий часовой пояс для извлечения
      - Использует 4 байта
      - Привязан к временным зонам
      - Допустимый диапазон значений: 1970-01-01 00:00:01 UTC to 2038-01-19 03:14:07 UTC.

     */

-- 4. (#20) Необходимо создать таблицу студентов (поля id, name) и таблицу курсов (поля id, name).
-- Каждый студент может посещать несколько курсов. Названия курсов и имена студентов - произвольны.
    CREATE TABLE student
    (
      id INTEGER
        CONSTRAINT student_pk
          PRIMARY KEY AUTOINCREMENT,
      name TEXT NOT NULL
    );

    CREATE TABLE course
    (
      id INTEGER
        CONSTRAINT course_pk
          PRIMARY KEY AUTOINCREMENT,
      name TEXT NOT NULL
    );

    CREATE TABLE student_x_course
    (
      id_student INTEGER,
      id_course INTEGER
    );

    INSERT INTO student (name)
    VALUES ('Mark'),
           ('Alber'),
           ('Pavel'),
           ('Johan'),
           ('David'),
           ('Martin');

    INSERT INTO course
      (name)
    VALUES ('History'),
           ('Economic'),
           ('Geometry');

    INSERT INTO student_x_course
    VALUES (1, 1),
           (1, 2),
           (2, 1),
           (2, 2),
           (2, 3),
           (3, 1),
           (3, 3),
           (4, 1),
           (4, 3),
           (5, 2),
           (5, 1),
           (6, 1);

--   Написать SQL запросы:
--     1. отобразить количество курсов, на которые ходит более 5 студентов
        SELECT COUNT(course.id)
          FROM student_x_course
            LEFT JOIN student ON student.id = student_x_course.id_student
            LEFT JOIN course ON course.id = student_x_course.id_course
        GROUP BY course.name
        HAVING COUNT(student.id) > 5;

--     2. отобразить все курсы, на которые записан определенный студент.
        SELECT student.name, course.name
          FROM student_x_course
            LEFT JOIN student ON student.id = student_x_course.id_student
            LEFT JOIN course ON course.id = student_x_course.id_course
        WHERE student.name = 'Mark';

-- 5. (5#) Может ли значение в столбце(ах), на который наложено ограничение
-- foreign key, равняться null? Привидите пример.
-- Может, если при создании foreign key не было указано условие NOT NULL.
-- Например (pharmacy_id = null):
    create table pharmacy
    (
      pharmacy_id INTEGER
        constraint pharmacy_pk
          primary key,
      name TEXT
    );

    create table medicine
    (
      medicine_id INTEGER
        constraint medicine_pk
          primary key autoincrement,
      name TEXT,
      pharmacy_id INTEGER
        constraint medicine_pharmacy_pharmacy_id_fk
          references pharmacy
    );

    INSERT INTO pharmacy (pharmacy_id, name)
      VALUES (1, 'Farma');

    INSERT INTO medicine (medicine_id, name, pharmacy_id)
      VALUES (1, 'XX', NULL);

    SELECT * FROM medicine;

-- 6. (#15) Как удалить повторяющиеся строки с использованием ключевого слова
-- Distinct? Приведите пример таблиц с данными и запросы.
    create table museum
    (
      museum_id INTEGER
        constraint museum_pk
          primary key,
      name TEXT not null,
      country TEXT not null
    );

    INSERT INTO museum (museum_id, name, country)
    VALUES
      (1, 'Louvre', 'France'),
      (2, 'Uffizi', 'Italy'),
      (3, 'Modern Art', 'France'),
      (4, 'Modern Art', 'USA'),
      (5, 'Orsea', 'France');

--  Показать все страны музеев, добавленных в таблицу
    SELECT DISTINCT country FROM museum;
--  Показать все уникальные названия музеев, добавленных в таблицу
    SELECT DISTINCT name FROM museum;

--   7. (#10) Есть две таблицы:
--     users - таблица с пользователями (users_id, name)
--     orders - таблица с заказами (orders_id, users_id, status)
      create table users
      (
        users_id INTEGER
          constraint users_pk
            primary key,
        name TEXT
      );

      create table orders
      (
        orders_id INTEGER
          constraint orders_pk
            primary key,
        users_id INTEGER
          constraint orders_users_users_id_fk
            references users,
        status INTEGER
      );

      INSERT INTO users (users_id, name)
      VALUES
         (1, 'Mark'),
         (2, 'Alber'),
         (3, 'Pavel'),
         (4, 'Johan'),
         (5, 'David'),
         (6, 'Martin');

      INSERT INTO orders (orders_id, users_id, status)
      VALUES
         (1, 1, 1),
         (2, 3, 1),
         (3, 1, 0),
         (4, 3, 0),
         (5, 1, 1),
         (6, 6, 0),
         (7, 6, 0),
         (8, 6, 0);

--     1) Выбрать всех пользователей из таблицы users,
--     у которых ВСЕ записи в таблице orders имеют status = 0



--     2) Выбрать всех пользователей из таблицы users,
--     у которых больше 5 записей в таблице orders имеют status = 1

-- 8. (#10)  В чем различие между выражениями HAVING и WHERE?
  -- 1) WHERE можно использовать с SELECT, UPDATE или DELETE, но HAVING можно
  -- использовать только с SELECT и GROUP BY
  -- 2) WHERE используется для фильтрации строк и применяется к каждой строке,
  -- в то время как HAVING используется для фильтрации групп
  -- 3) WHERE не поддерживает запросы с агрегатными функциями
  -- 4) HAVING менее эффективен в запросах с неагрегатными функциями