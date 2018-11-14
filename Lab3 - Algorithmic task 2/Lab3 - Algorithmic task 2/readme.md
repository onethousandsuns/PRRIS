Бочкарев М.А. ПСм-12
Задание - https://docs.google.com/document/d/1RFlHU-aAjaUwC9L7tBdaLY4t5VgQgChTajD632HXjHI/edit
Затраченное время - 2 часа.

Записи записной книги храню в hashset _records, он обеспечивает быструю уникальную вставку новых значений.

Алгоритм поиска вхождений:
Создал второе хранилище, содержащее предпросчитанную информацию по вхождениям подстрок. Dictionary<string, int> _substringsCounts
При добавлении новой записи получаем все значения подстрок ( метод GetStringSubstrings( string stringValue ) ) и инкрементируем значения в _substringsCounts.

Вставка в _records O(1), O(n) если есть коллизии по хешу.
Вставка в _substringsCounts O(1).
Поиск значения в _substringsCounts O(1).