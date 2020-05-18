-- 3.  Подготовьте SQL запросы для заполнения таблиц данными.
    INSERT INTO dvd VALUES (default, 'La Dolce Vita', 1960);
    INSERT INTO dvd VALUES (default, 'La Strada', 1954);
    INSERT INTO dvd VALUES (default, 'Beanpole', 2010);
    INSERT INTO dvd VALUES (default, 'Closeness', 2010);
    INSERT INTO dvd VALUES (default, 'Stroszek', 1977);

    INSERT INTO customer VALUES (default, 'Werner', 'Herzog', '123456', '04.14.2020');
    INSERT INTO customer VALUES (default, 'Eva', 'Mattes', '654321', '02.12.2020');
    INSERT INTO customer VALUES (default, 'Lena', 'Lorenz', '987655', '12.03.2011');
    INSERT INTO customer VALUES (default, 'Burkhard', 'Driest', '639264', '10.22.2019');
    INSERT INTO customer VALUES (default, 'Clayton', 'Szalpinski', '123451', '01.12.2020');

    INSERT INTO offer VALUES (1, 1, 1, '04.14.2020', '05.14.2020');
    INSERT INTO offer VALUES (2, 2, 2, '02.12.2020', '12.12.2020');
    INSERT INTO offer VALUES (3, 3, 3, '04.03.2012', '05.05.2012');
    INSERT INTO offer VALUES (4, 4, 4, '10.22.2019', '10.23.2029');
    INSERT INTO offer VALUES (5, 5, 5, '01.12.2020', '06.12.2020');

-- 4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010,
-- отсортированных в алфавитном порядке по названию DVD.
    SELECT *
      FROM dvd
     WHERE
      dvd.production_year = 2010
    GROUP BY dvd.title, dvd.dvd_id;

-- 5.  Подготовьте SQL запрос для получения списка DVD дисков,
-- которые в настоящее время находятся у клиентов.
    SELECT dvd.dvd_id, dvd.title, dvd.production_year
      FROM dvd
        LEFT JOIN offer
          ON offer.dvd_id = dvd.dvd_id
        LEFT JOIN customer
          ON offer.customer_id = customer.customer_id
     WHERE '04.28.2020' BETWEEN offer_date AND return_date;

-- 6.  Напишите SQL запрос для получения списка клиентов, которые
-- брали какие-либо DVD диски в текущем году. В результатах запроса
-- необходимо также отразить какие диски брали клиенты.
    SELECT customer.customer_id, customer.first_name, customer.second_name
      FROM customer
        LEFT JOIN offer
          ON offer.customer_id = customer.customer_id
        LEFT JOIN dvd
          ON offer.dvd_id = dvd.dvd_id
     WHERE STRFTIME('%Y', offer.offer_date) = STRFTIME('%Y', DATE('now'));